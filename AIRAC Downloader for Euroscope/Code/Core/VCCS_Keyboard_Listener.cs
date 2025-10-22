using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{
    public static class VCCS_Keyboard_Listener
    {
        // ----------------------------------------------------------------
        //  Öffentliche API
        // ----------------------------------------------------------------
        public static async Task<uint> ListenForKeyAsync()
        {
            return await Task.Run(() => ListenForKey());
        }

        public static uint ListenForKey()
        {
            uint lastEuroScopeCode = 0;
            bool done = false;

            IntPtr hInstance = GetModuleHandle(null);
            string className = "EuroscopeRawInputHelper_Class";

            var wndClass = new WNDCLASSEX();
            wndClass.cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX));
            wndClass.style = 0;
            wndClass.lpfnWndProc = Marshal.GetFunctionPointerForDelegate((WndProcDelegate)((hWnd, msg, wParam, lParam) =>
            {
                if (msg == WM_INPUT)
                {
                    uint dwSize = 0;

                    // 1️⃣ Größe der Daten abfragen
                    GetRawInputData(lParam, RID_INPUT, IntPtr.Zero, ref dwSize, (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER)));

                    // 2️⃣ Daten lesen
                    if (dwSize > 0)
                    {
                        GetRawInputData(lParam, RID_INPUT, out RAWINPUT raw, ref dwSize, (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER)));

                        if (raw.header.dwType == RIM_TYPEKEYBOARD)
                        {
                            ushort make = raw.keyboard.MakeCode;
                            ushort flags = raw.keyboard.Flags;
                            ushort vkey = raw.keyboard.VKey;
                            uint msgcode = raw.keyboard.Message;
                            bool isExt = (flags & RI_KEY_E0) != 0 || (flags & RI_KEY_E1) != 0;

                            uint euro = EuroScopeFromScan(make, isExt);
                            lastEuroScopeCode = euro;
                            done = true;
                        }
                    }
                }

                return DefWindowProcW(hWnd, msg, wParam, lParam);
            }));
            wndClass.hInstance = hInstance;
            wndClass.lpszClassName = className;

            RegisterClassExW(ref wndClass);

            IntPtr hwnd = CreateWindowExW(0, className, "EuroscopeRawInputWindow", 0, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, hInstance, IntPtr.Zero);
            if (hwnd == IntPtr.Zero)
                throw new InvalidOperationException("CreateWindowExW fehlgeschlagen: " + Marshal.GetLastWin32Error());

            // 3️⃣ Raw Input registrieren
            RAWINPUTDEVICE rid = new RAWINPUTDEVICE
            {
                usUsagePage = 0x01,
                usUsage = 0x06,
                dwFlags = RIDEV_INPUTSINK,
                hwndTarget = hwnd
            };

            if (!RegisterRawInputDevices(ref rid, 1, (uint)Marshal.SizeOf(typeof(RAWINPUTDEVICE))))
                throw new InvalidOperationException("RegisterRawInputDevices fehlgeschlagen: " + Marshal.GetLastWin32Error());

            // 4️⃣ Message-Loop starten
            MSG msg;
            while (!done && GetMessage(out msg, IntPtr.Zero, 0, 0))
            {
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
                Thread.Sleep(5);
            }

            return lastEuroScopeCode;
        }

        // ----------------------------------------------------------------
        //  Hilfsfunktionen
        // ----------------------------------------------------------------
        private static uint EuroScopeFromScan(ushort scan, bool isExtended)
        {
            uint sc = (uint)(isExtended ? ((scan & 0xFF) | 0x100) : (scan & 0xFF));
            return sc << 16;
        }

        // ----------------------------------------------------------------
        //  Win32 Definitionen
        // ----------------------------------------------------------------
        private const int WM_INPUT = 0x00FF;
        private const int RID_INPUT = 0x10000003;
        private const int RIM_TYPEKEYBOARD = 1;
        private const int RIDEV_INPUTSINK = 0x00000100;
        private const int RI_KEY_E0 = 0x02;
        private const int RI_KEY_E1 = 0x04;

        [StructLayout(LayoutKind.Sequential)]
        private struct RAWINPUTHEADER
        {
            public uint dwType;
            public uint dwSize;
            public IntPtr hDevice;
            public IntPtr wParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RAWKEYBOARD
        {
            public ushort MakeCode;
            public ushort Flags;
            public ushort Reserved;
            public ushort VKey;
            public uint Message;
            public uint ExtraInformation;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RAWINPUT
        {
            public RAWINPUTHEADER header;
            public RAWKEYBOARD keyboard;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RAWINPUTDEVICE
        {
            public ushort usUsagePage;
            public ushort usUsage;
            public uint dwFlags;
            public IntPtr hwndTarget;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public int pt_x;
            public int pt_y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WNDCLASSEX
        {
            public uint cbSize;
            public uint style;
            public IntPtr lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
            public IntPtr hIconSm;
        }

        // -------------------- P/Invoke --------------------
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

        [DllImport("user32.dll")]
        private static extern IntPtr DefWindowProcW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll")]
        private static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        private static extern IntPtr DispatchMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        private static extern ushort RegisterClassExW([In] ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll")]
        private static extern IntPtr CreateWindowExW(
            int dwExStyle,
            string lpClassName,
            string lpWindowName,
            int dwStyle,
            int x, int y,
            int nWidth, int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
