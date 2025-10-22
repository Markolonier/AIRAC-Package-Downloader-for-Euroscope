using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{
    public class VCCS_Keyboard_Listener : NativeWindow
    {
        private static VCCS_Keyboard_Listener? instance;
        private TaskCompletionSource<(uint code, string name)>? keyTcs;

        private VCCS_Keyboard_Listener()
        {
            CreateHandle(new CreateParams());
            RegisterRawInput();
        }

        public static VCCS_Keyboard_Listener Instance => instance ??= new VCCS_Keyboard_Listener();

        public Task<(uint code, string name)> ListenAsync()
        {
            keyTcs = new TaskCompletionSource<(uint, string)>();
            return keyTcs.Task;
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
            RegisterRawInputDevices(ref rid, 1, (uint)Marshal.SizeOf(rid));
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_INPUT = 0x00FF;
            const int RID_INPUT = 0x10000003;
            const int RIM_TYPEKEYBOARD = 1;
            const int RI_KEY_E0 = 0x02;
            const int RI_KEY_E1 = 0x04;

            if (m.Msg == WM_INPUT)
            {
                uint size = 0;
                GetRawInputData(m.LParam, RID_INPUT, IntPtr.Zero, ref size, (uint)Marshal.SizeOf<RAWINPUTHEADER>());
                if (size == 0) return;

                GetRawInputData(m.LParam, RID_INPUT, out RAWINPUT raw, ref size, (uint)Marshal.SizeOf<RAWINPUTHEADER>());
                if (raw.header.dwType != RIM_TYPEKEYBOARD) return;

                ushort make = raw.keyboard.MakeCode;
                ushort flags = raw.keyboard.Flags;
                bool isExt = (flags & RI_KEY_E0) != 0 || (flags & RI_KEY_E1) != 0;

                uint euro = (uint)(((make & 0xFF) | (isExt ? 0x100u : 0u)) << 16);
                string name = GetKeyName(make, isExt);

                keyTcs?.TrySetResult((euro, name));
            }

            base.WndProc(ref m);
        }

        private static string GetKeyName(ushort scanCode, bool isExtended)
        {
            int lParam = (scanCode << 16) | (isExtended ? 1 << 24 : 0);
            var sb = new System.Text.StringBuilder(64);
            int len = GetKeyNameTextW(lParam, sb, sb.Capacity);
            return len > 0 ? sb.ToString() : $"Scan {scanCode}";
        }

        // ---- native structs / imports ----
        [StructLayout(LayoutKind.Sequential)]
        struct RAWINPUTDEVICE
        {
            public ushort usUsagePage, usUsage;
            public uint dwFlags;
            public IntPtr hwndTarget;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RAWINPUTHEADER
        {
            public uint dwType, dwSize;
            public IntPtr hDevice, wParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RAWKEYBOARD
        {
            public ushort MakeCode, Flags, Reserved, VKey;
            public uint Message, ExtraInformation;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RAWINPUT
        {
            public RAWINPUTHEADER header;
            public RAWKEYBOARD keyboard;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterRawInputDevices(ref RAWINPUTDEVICE pRawInputDevices, uint uiNumDevices, uint cbSize);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetRawInputData(IntPtr hRawInput, uint uiCommand, out RAWINPUT pData, ref uint pcbSize, uint cbSizeHeader);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetKeyNameTextW(int lParam, System.Text.StringBuilder lpString, int nSize);
    }
}
