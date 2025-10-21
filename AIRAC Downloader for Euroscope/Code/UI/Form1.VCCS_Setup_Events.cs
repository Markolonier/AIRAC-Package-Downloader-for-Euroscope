using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Data;
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
            g2a_btn.KeyDown += new KeyEventHandler(G2a_btn_KeyDown);
        }

        public void G2a_btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Escape")
            {
                g2a_btn.Text = "Set Hotkey";
            }
            else
            {
                Console.WriteLine(e.KeyData.ToString());
                g2a_btn.Text = e.KeyCode.ToString();
            }
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
            g2g_btn.KeyDown += new KeyEventHandler(G2g_btn_KeyDown);
        }

        public void G2g_btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Escape")
            {
                g2g_btn.Text = "Set Hotkey";
            }
            else
            {
                g2g_btn.Text = e.KeyCode.ToString();
            }
        }
    }
}