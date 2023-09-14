using System;
using System.Windows.Forms;

namespace AIRAC_Downloader_for_Euroscope.Code.UI
{
    partial class Main_Form
    {

        public void OpenPlugin(TextBox textbox)
        {
            plugin_opendialogue.DefaultExt = "dll";
            plugin_opendialogue.Filter = "EuroScope plugins (*.dll)|*.dll";
            plugin_opendialogue.FilterIndex = 1;
            plugin_opendialogue.CheckFileExists = true;
            plugin_opendialogue.CheckPathExists = true;
            plugin_opendialogue.ShowDialog();

            textbox.Text = plugin_opendialogue.FileName;
        }
        public void OpenSound(TextBox textbox)
        {
            sound_opendialogue.DefaultExt = "wav";
            sound_opendialogue.Filter = "Wave files (*.wav)|*.wav";
            sound_opendialogue.FilterIndex = 1;
            sound_opendialogue.CheckFileExists = true;
            sound_opendialogue.CheckPathExists = true;
            sound_opendialogue.ShowDialog();

            textbox.Text = sound_opendialogue.FileName;
        }


        public void Callsign_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (callsign_cb.Checked == false)
            {
                callsign_tb.Enabled = false;
            }
            else
            {
                callsign_tb.Enabled = true;
            }
        }

        public void Realname_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (realname_cb.Checked == false)
            {
                realname_tb.Enabled = false;
            }
            else
            {
                realname_tb.Enabled = true;
            }
        }

        public void Certificate_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (certificate_cb.Checked == false)
            {
                certificate_tb.Enabled = false;
            }
            else
            {
                certificate_tb.Enabled = true;
            }
        }

        public void Password_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (password_cb.Checked == false)
            {
                password_tb.Enabled = false;
                show_pwd.Enabled = false;
            }
            else
            {
                password_tb.Enabled = true;
                show_pwd.Enabled = true;
            }
        }

        public void Facility_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (facility_cb.Checked == false)
            {
                facility_dd.Enabled = false;
            }
            else
            {
                facility_dd.Enabled = true;
            }
        }

        public void Rating_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (rating_cb.Checked == false)
            {
                rating_dd.Enabled = false;
            }
            else
            {
                rating_dd.Enabled = true;
            }
        }

        public void plugin1_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (plugin1_cb.Checked == false)
            {
                p1_tb.Enabled = false;
                p1_open.Enabled = false;
            }
            else
            {
                p1_tb.Enabled = true;
                p1_open.Enabled = true;
            }
        }

        public void plugin2_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (plugin2_cb.Checked == false)
            {
                p2_tb.Enabled = false;
                p2_open.Enabled = false;
            }
            else
            {
                p2_tb.Enabled = true;
                p2_open.Enabled = true;
            }
        }

        public void plugin3_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (plugin3_cb.Checked == false)
            {
                p3_tb.Enabled = false;
                p3_open.Enabled = false;
            }
            else
            {
                p3_tb.Enabled = true;
                p3_open.Enabled = true;
            }
        }

        public void sound1_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (sound1_cb.Checked == false)
            {
                s1_tb.Enabled = false;
                s1_open.Enabled = false;
                sound_dd_1.Enabled = false;
            }
            else
            {
                s1_tb.Enabled = true;
                s1_open.Enabled = true;
                sound_dd_1.Enabled = true;
            }
        }

        public void sound2_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (sound2_cb.Checked == false)
            {
                s2_tb.Enabled = false;
                s2_open.Enabled = false;
                sound_dd_2.Enabled = false;
            }
            else
            {
                s2_tb.Enabled = true;
                s2_open.Enabled = true;
                sound_dd_2.Enabled = true;
            }
        }

        public void sound3_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (sound3_cb.Checked == false)
            {
                s3_tb.Enabled = false;
                s3_open.Enabled = false;
                sound_dd_3.Enabled = false;
            }
            else
            {
                s3_tb.Enabled = true;
                s3_open.Enabled = true;
                sound_dd_3.Enabled = true;
            }
        }

        public void p1_open_Click(object sender, EventArgs e)
        {
            OpenPlugin(p1_tb);
        }

        public void p2_open_Click(object sender, EventArgs e)
        {
            OpenPlugin(p2_tb);
        }

        public void p3_open_Click(object sender, EventArgs e)
        {
            OpenPlugin(p3_tb);
        }
        public void s1_open_Click(object sender, EventArgs e)
        {
            OpenSound(s1_tb);
        }

        public void s2_open_Click(object sender, EventArgs e)
        {
            OpenSound(s2_tb);
        }

        public void s3_open_Click(object sender, EventArgs e)
        {
            OpenSound(s3_tb);
        }

        public void show_pwd_MouseDown(object sender, MouseEventArgs e)
        {
            password_tb.UseSystemPasswordChar = false;
        }

        public void show_pwd_MouseUp(object sender, MouseEventArgs e)
        {
            password_tb.UseSystemPasswordChar = true;
        }

        public void show_hoppie_MouseDown(object sender, MouseEventArgs e)
        {
            hoppie_tb.UseSystemPasswordChar = false;
        }

        public void show_hoppie_MouseUp(object sender, MouseEventArgs e)
        {
            hoppie_tb.UseSystemPasswordChar = true;
        }

        public void Hoppie_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (hoppie_cb.Checked)
            {
                hoppie_tb.Enabled = true;
                show_hoppie.Enabled = true;
            }
            else
            {
                hoppie_tb.Enabled = false;
                show_hoppie.Enabled = false;
            }
        }
    }
}