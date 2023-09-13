using AIRAC_Downloader_for_Euroscope.Code.UI;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AIRAC_Downloader.Code.Core
{
    public class VCCS_Events
    {
        private Main_Form mainForm;
        public VCCS_Events(Main_Form mainForm)
        {
            this.mainForm = mainForm;
        }

        public void Nickname_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (mainForm.nickname_cb.Checked)
            {
                mainForm.nickname_tb.Enabled = true;
            }
            else
            {
                mainForm.nickname_tb.Enabled = false;
            }
        }

        public void Capture_mode_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (mainForm.capture_mode_cb.Checked == false)
            {
                mainForm.capture_mode_dd.Enabled = false;
            }
            else
            {
                mainForm.capture_mode_dd.Enabled = true;
                List<string> capture_mode_l = new List<string> { "Direct Sound", "Windows Audio Session" };
                mainForm.capture_mode_dd.DataSource = capture_mode_l;
            }
        }

        public void Capture_device_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (mainForm.capture_device_cb.Checked == false)
            {
                mainForm.capture_device_dd.Enabled = false;
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
                mainForm.capture_device_dd.DataSource = capture_device_l;
                mainForm.capture_device_dd.Enabled = true;
            }
        }

        public void Playback_device_pb_CheckedChanged(object sender, EventArgs e)
        {
            if (mainForm.playback_device_cb.Checked == false)
            {
                mainForm.playback_device_dd.Enabled = false;
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
                mainForm.playback_device_dd.DataSource = playback_device_l;
                mainForm.playback_device_dd.Enabled = true;
            }
        }

        public void Playback_mode_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (mainForm.playback_mode_cb.Checked == false)
            {
                mainForm.playback_mode_dd.Enabled = false;
            }
            else
            {
                mainForm.playback_mode_dd.Enabled = true;
                List<string> capture_mode_l = new List<string> { "Direct Sound", "Windows Audio Session" };
                mainForm.playback_mode_dd.DataSource = capture_mode_l;
            }
        }

        public void G2a_ptt_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (mainForm.g2a_ptt_cb.Checked == false)
            {
                mainForm.g2a_btn.Enabled = false;
            }
            else
            {
                mainForm.g2a_btn.Enabled = true;
            }
        }

        public void G2a_btn_Click(object sender, EventArgs e)
        {
            mainForm.g2a_btn.Text = "Listening to Keyboard Input";
            mainForm.g2a_btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G2a_btn_KeyDown);
        }

        public void G2a_btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Escape")
            {
                mainForm.g2a_btn.Text = "Click to Scan for Keyboard input";
            }
            else
            {
                Console.WriteLine(e.KeyData.ToString());
                mainForm.g2a_btn.Text = e.KeyCode.ToString();
            }
        }

        public void G2g_ptt_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (mainForm.g2g_ptt_cb.Checked == false)
            {
                mainForm.g2g_btn.Enabled = false;
            }
            else
            {
                mainForm.g2g_btn.Enabled = true;
            }
        }

        public void G2g_btn_Click(object sender, EventArgs e)
        {
            mainForm.g2g_btn.Text = "Listening to Keyboard Input";
            mainForm.g2g_btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.G2g_btn_KeyDown);
        }

        public void G2g_btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Escape")
            {
                mainForm.g2g_btn.Text = "Click to Scan for Keyboard input";
            }
            else
            {
                mainForm.g2g_btn.Text = e.KeyCode.ToString();
            }
        }
    }
}