using AIRAC_Downloader_for_Euroscope.Code.Core;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AIRAC_Downloader_for_Euroscope.Code.UI
{
    partial class Main_Form
    {

        public void Nickname_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (nickname_cb.Checked)
            {
                nickname_tb.Enabled = true;
            }
            else
            {
                nickname_tb.Enabled = false;
            }
        }

        public void Capture_mode_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (capture_mode_cb.Checked == false)
            {
                capture_mode_dd.Enabled = false;
            }
            else
            {
                capture_mode_dd.Enabled = true;
                List<string> capture_mode_l = new List<string> { "Direct Sound", "Windows Audio Session" };
                capture_mode_dd.DataSource = capture_mode_l;
            }
        }

        public void Capture_device_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (capture_device_cb.Checked == false)
            {
                capture_device_dd.Enabled = false;
            }
            else
            {
                List<string> capture_device_l = new List<string>();
                var enumerator = new MMDeviceEnumerator();
                foreach (var endpoint in
                         enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
                {
                    capture_device_l.Add(endpoint.FriendlyName);
                }
                capture_device_dd.DataSource = capture_device_l;
                capture_device_dd.Enabled = true;
            }
        }

        public void Playback_device_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (playback_device_cb.Checked == false)
            {
                playback_device_dd.Enabled = false;
            }
            else
            {
                List<string> playback_device_l = new List<string>();
                var enumerator = new MMDeviceEnumerator();
                foreach (var endpoint in
                         enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                {
                    playback_device_l.Add(endpoint.FriendlyName);
                }
                playback_device_dd.DataSource = playback_device_l;
                playback_device_dd.Enabled = true;
            }
        }

        public void Playback_mode_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (playback_mode_cb.Checked == false)
            {
                playback_mode_dd.Enabled = false;
            }
            else
            {
                playback_mode_dd.Enabled = true;
                List<string> capture_mode_l = new List<string> { "Direct Sound", "Windows Audio Session" };
                playback_mode_dd.DataSource = capture_mode_l;
            }
        }

        public void G2a_ptt_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (g2a_ptt_cb.Checked == false)
            {
                g2a_btn.Enabled = false;
            }
            else
            {
                g2a_btn.Enabled = true;
            }
        }

        public void G2a_btn_Click(object sender, EventArgs e)
        {
            g2a_btn.Text = "Listening to Keyboard Input";
            uint code = VCCS_Keyboard_Listener.ListenForKey();
            MessageBox.Show($"EuroScope-Code: {code}");
            g2a_btn.Text = "Done";
        }

        public void G2g_ptt_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (g2g_ptt_cb.Checked == false)
            {
                g2g_btn.Enabled = false;
            }
            else
            {
                g2g_btn.Enabled = true;
            }
        }

        public void G2g_btn_Click(object sender, EventArgs e)
        {
            g2g_btn.Text = "Listening to Keyboard Input";
            uint code = VCCS_Keyboard_Listener.ListenForKey();
            MessageBox.Show($"EuroScope-Code: {code}");
            g2g_btn.Text = "Done";
        }



        // ------------------------------------------------------------
        // Registrierung von Raw Input (Keyboard)
        // ------------------------------------------------------------
        private void RegisterForRawInput()
        {
            RAWINPUTDEVICE[] rid = new RAWINPUTDEVICE[1];
            rid[0].usUsagePage = 0x01;   // Generic desktop controls
            rid[0].usUsage = 0x06;       // Keyboard
            rid[0].dwFlags = 0;          // Receive input even if not focused
            rid[0].hwndTarget = this.Handle;

            if (!RegisterRawInputDevices(rid, 1, (uint)Marshal.SizeOf(typeof(RAWINPUTDEVICE))))
                MessageBox.Show("Raw Input Registrierung fehlgeschlagen.");
            else
                MessageBox.Show("Raw Input aktiviert. Drücke jetzt Tasten!");
        }

        // ------------------------------------------------------------
        // Window-Message-Verarbeitung (WM_INPUT)
        // ------------------------------------------------------------
        protected override void WndProc(ref Message m)
        {
            const int WM_INPUT = 0x00FF;
            if (m.Msg == WM_INPUT)
            {
                uint dwSize = 0;
                GetRawInputData(m.LParam, RID_INPUT, IntPtr.Zero, ref dwSize, (uint)Marshal.SizeOf<RAWINPUTHEADER>());

                IntPtr buffer = Marshal.AllocHGlobal((int)dwSize);
                try
                {
                    if (GetRawInputData(m.LParam, RID_INPUT, buffer, ref dwSize, (uint)Marshal.SizeOf<RAWINPUTHEADER>()) == dwSize)
                    {
                        RAWINPUT raw = Marshal.PtrToStructure<RAWINPUT>(buffer);

                        if (raw.header.dwType == RIM_TYPEKEYBOARD)
                        {
                            int scanCode = raw.data.MakeCode;
                            bool isE0 = (raw.data.Flags & RI_KEY_E0) != 0;

                            uint euro = (uint)((scanCode | (isE0 ? 0xE000 : 0)) << 8);

                            MessageBox.Show(
                                $"EuroScope-Code: {euro}\nScanCode: {scanCode}\nExtended: {isE0}",
                                "Key Captured",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }

            base.WndProc(ref m);
        }

        // ------------------------------------------------------------
        // Strukturen & Konstanten für Raw Input
        // ------------------------------------------------------------
        private const int RID_INPUT = 0x10000003;
        private const int RIM_TYPEKEYBOARD = 1;
        private const int RI_KEY_E0 = 0x02;

        [StructLayout(LayoutKind.Sequential)]
        private struct RAWINPUTDEVICE
        {
            public ushort usUsagePage;
            public ushort usUsage;
            public uint dwFlags;
            public IntPtr hwndTarget;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RAWINPUTHEADER
        {
            public uint dwType;
            public uint dwSize;
            public IntPtr hDevice;
            public IntPtr wParam;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct RAWINPUT
        {
            [FieldOffset(0)] public RAWINPUTHEADER header;
            [FieldOffset(16)] public RAWKEYBOARD data;
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

        [DllImport("User32.dll")]
        private static extern bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevices, uint uiNumDevices, uint cbSize);

        [DllImport("User32.dll")]
        private static extern uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);
    }
}