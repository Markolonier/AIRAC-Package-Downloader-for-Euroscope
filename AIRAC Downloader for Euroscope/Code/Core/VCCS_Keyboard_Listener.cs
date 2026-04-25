using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{

    // ChatGPT did this and I have no clue what happens here.
    // Ain't touching this because it works somehow...
    public class VCCS_Keyboard_Listener : NativeWindow, IDisposable
    {
        private static VCCS_Keyboard_Listener? instance;

        private TaskCompletionSource<KeyResult>? keyTcs;
        private bool disposed;

        public struct KeyResult
        {
            public uint Code { get; set; }
            public string Name { get; set; }
            public bool IsExtended { get; set; }
            public KeyResult(uint Code, string Name, bool IsExtended)
            {
                this.Code = Code;
                this.Name = Name;
                this.IsExtended = IsExtended;
            }
        }

        private VCCS_Keyboard_Listener()
        {
            CreateHandle(new CreateParams());
            RegisterRawInput();
        }

        public static VCCS_Keyboard_Listener Instance
            => instance ??= new VCCS_Keyboard_Listener();

        public Task<KeyResult?> ListenAsync(CancellationToken cancellationToken = default)
        {
            // Falls bereits aktiv → abbrechen und NULL zurückgeben
            if (keyTcs != null && !keyTcs.Task.IsCompleted)
            {
                keyTcs.TrySetCanceled();
                keyTcs = null;

                return Task.FromResult<KeyResult?>(null);
            }

            keyTcs = new TaskCompletionSource<KeyResult>(
                TaskCreationOptions.RunContinuationsAsynchronously);

            if (cancellationToken != default)
            {
                cancellationToken.Register(() =>
                {
                    keyTcs?.TrySetCanceled(cancellationToken);
                });
            }

            return keyTcs.Task.ContinueWith(t =>
            {
                if (t.IsCanceled)
                    return (KeyResult?)null;

                return t.Result;
            });
        }

        private void RegisterRawInput()
        {
            RAWINPUTDEVICE rid = new RAWINPUTDEVICE
            {
                usUsagePage = 0x01,
                usUsage = 0x06,
                dwFlags = 0,
                hwndTarget = Handle
            };

            if (!RegisterRawInputDevices(ref rid, 1, (uint)Marshal.SizeOf(rid)))
                throw new InvalidOperationException("Failed to register raw input device.");
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_INPUT = 0x00FF;
            const int RID_INPUT = 0x10000003;
            const int RIM_TYPEKEYBOARD = 1;

            const int RI_KEY_E0 = 0x02;
            const int RI_KEY_E1 = 0x04;
            const int RI_KEY_BREAK = 0x01;

            if (m.Msg == WM_INPUT)
            {
                uint size = 0;
                GetRawInputData(m.LParam, RID_INPUT, IntPtr.Zero, ref size, (uint)Marshal.SizeOf<RAWINPUTHEADER>());
                if (size == 0)
                    return;

                GetRawInputData(m.LParam, RID_INPUT, out RAWINPUT raw, ref size, (uint)Marshal.SizeOf<RAWINPUTHEADER>());

                if (raw.header.dwType != RIM_TYPEKEYBOARD)
                    return;

                ushort make = raw.keyboard.MakeCode;
                ushort flags = raw.keyboard.Flags;

                bool isKeyUp = (flags & RI_KEY_BREAK) != 0;
                if (isKeyUp)
                    return; // nur KeyDown

                bool isExt = (flags & RI_KEY_E0) != 0 || (flags & RI_KEY_E1) != 0;

                uint code = (uint)(((make & 0xFF) | (isExt ? 0x100u : 0u)) << 16);
                string name = GetKeyName(make, isExt);

                keyTcs?.TrySetResult(new KeyResult(code, name, isExt));
            }

            base.WndProc(ref m);
        }

        public static string GetKeyName(ushort scanCode, bool isExtended)
        {
            int lParam = (scanCode << 16) | (isExtended ? 1 << 24 : 0);
            var sb = new StringBuilder(64);

            int len = GetKeyNameTextW(lParam, sb, sb.Capacity);
            return len > 0 ? sb.ToString() : $"Scan {scanCode}";
        }

        public void Dispose()
        {
            if (disposed)
                return;

            DestroyHandle();
            disposed = true;
        }


        /// <summary>
        /// Returns the Struct of the Keycode from the Parameters
        /// </summary>
        /// <param name="scanCode">ScanCode of the keyboard Key</param>
        /// <returns></returns>
        public static KeyResult FromScanCode(uint code)
        {
            ushort scanCode = (ushort)((code >> 16) & 0xFF);
            bool isExtended = ((code >> 16) & 0x100) != 0;

            string name = GetKeyName(scanCode, isExtended);

            return new KeyResult(code, name, isExtended);
        }

        // ---- native structs / imports ----

        [StructLayout(LayoutKind.Sequential)]
        struct RAWINPUTDEVICE
        {
            public ushort usUsagePage;
            public ushort usUsage;
            public uint dwFlags;
            public IntPtr hwndTarget;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RAWINPUTHEADER
        {
            public uint dwType;
            public uint dwSize;
            public IntPtr hDevice;
            public IntPtr wParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RAWKEYBOARD
        {
            public ushort MakeCode;
            public ushort Flags;
            public ushort Reserved;
            public ushort VKey;
            public uint Message;
            public uint ExtraInformation;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RAWINPUT
        {
            public RAWINPUTHEADER header;
            public RAWKEYBOARD keyboard;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterRawInputDevices(
            ref RAWINPUTDEVICE pRawInputDevices,
            uint uiNumDevices,
            uint cbSize);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetRawInputData(
            IntPtr hRawInput,
            uint uiCommand,
            IntPtr pData,
            ref uint pcbSize,
            uint cbSizeHeader);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetRawInputData(
            IntPtr hRawInput,
            uint uiCommand,
            out RAWINPUT pData,
            ref uint pcbSize,
            uint cbSizeHeader);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetKeyNameTextW(
            int lParam,
            StringBuilder lpString,
            int nSize);
    }
}