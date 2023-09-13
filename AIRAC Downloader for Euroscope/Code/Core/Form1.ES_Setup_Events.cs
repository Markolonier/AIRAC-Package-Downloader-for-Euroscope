using System;
using System.Windows.Forms;

namespace AIRAC_Downloader.Code.Core
{
    public class ES_Events
    {
        private Main_Form Main_Form;
        public ES_Events(Main_Form main_Form)
        {
            this.Main_Form = main_Form;
        }

        public void OpenPlugin(TextBox textbox)
        {
            Main_Form.plugin_opendialogue.DefaultExt = "dll";
            Main_Form.plugin_opendialogue.Filter = "EuroScope plugins (*.dll)|*.dll";
            Main_Form.plugin_opendialogue.FilterIndex = 1;
            Main_Form.plugin_opendialogue.CheckFileExists = true;
            Main_Form.plugin_opendialogue.CheckPathExists = true;
            Main_Form.plugin_opendialogue.ShowDialog();

            textbox.Text = Main_Form.plugin_opendialogue.FileName;
        }
        public void OpenSound(TextBox textbox)
        {
            Main_Form.sound_opendialogue.DefaultExt = "wav";
            Main_Form.sound_opendialogue.Filter = "Wave files (*.wav)|*.wav";
            Main_Form.sound_opendialogue.FilterIndex = 1;
            Main_Form.sound_opendialogue.CheckFileExists = true;
            Main_Form.sound_opendialogue.CheckPathExists = true;
            Main_Form.sound_opendialogue.ShowDialog();

            textbox.Text = Main_Form.sound_opendialogue.FileName;
        }


        public void Callsign_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.callsign_cb.Checked == false)
            {
                Main_Form.callsign_tb.Enabled = false;
            }
            else
            {
                Main_Form.callsign_tb.Enabled = true;
            }
        }

        public void Realname_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.realname_cb.Checked == false)
            {
                Main_Form.realname_tb.Enabled = false;
            }
            else
            {
                Main_Form.realname_tb.Enabled = true;
            }
        }

        public void Certificate_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.certificate_cb.Checked == false)
            {
                Main_Form.certificate_tb.Enabled = false;
            }
            else
            {
                Main_Form.certificate_tb.Enabled = true;
            }
        }

        public void Password_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.password_cb.Checked == false)
            {
                Main_Form.password_tb.Enabled = false;
            }
            else
            {
                Main_Form.password_tb.Enabled = true;
            }
        }

        public void Facility_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.facility_cb.Checked == false)
            {
                Main_Form.facility_dd.Enabled = false;
            }
            else
            {
                Main_Form.facility_dd.Enabled = true;
            }
        }

        public void Rating_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.rating_cb.Checked == false)
            {
                Main_Form.rating_dd.Enabled = false;
            }
            else
            {
                Main_Form.rating_dd.Enabled = true;
            }
        }

        public void Nickname_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.nickname_cb.Checked == false)
            {
                Main_Form.nickname_tb.Enabled = false;
            }
            else
            {
                Main_Form.nickname_tb.Enabled = true;
            }
        }

        public void plugin1_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.plugin1_cb.Checked == false)
            {
                Main_Form.p1_tb.Enabled = false;
                Main_Form.p1_open.Enabled = false;
            }
            else
            {
                Main_Form.p1_tb.Enabled = true;
                Main_Form.p1_open.Enabled = true;
            }
        }

        public void plugin2_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.plugin2_cb.Checked == false)
            {
                Main_Form.p2_tb.Enabled = false;
                Main_Form.p2_open.Enabled = false;
            }
            else
            {
                Main_Form.p2_tb.Enabled = true;
                Main_Form.p2_open.Enabled = true;
            }
        }

        public void plugin3_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.plugin3_cb.Checked == false)
            {
                Main_Form.p3_tb.Enabled = false;
                Main_Form.p3_open.Enabled = false;
            }
            else
            {
                Main_Form.p3_tb.Enabled = true;
                Main_Form.p3_open.Enabled = true;
            }
        }

        public void sound1_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.sound1_cb.Checked == false)
            {
                Main_Form.s1_tb.Enabled = false;
                Main_Form.s1_open.Enabled = false;
                Main_Form.sound_dd_1.Enabled = false;
            }
            else
            {
                Main_Form.s1_tb.Enabled = true;
                Main_Form.s1_open.Enabled = true;
                Main_Form.sound_dd_1.Enabled = true;
            }
        }

        public void sound2_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.sound2_cb.Checked == false)
            {
                Main_Form.s2_tb.Enabled = false;
                Main_Form.s2_open.Enabled = false;
                Main_Form.sound_dd_2.Enabled = false;
            }
            else
            {
                Main_Form.s2_tb.Enabled = true;
                Main_Form.s2_open.Enabled = true;
                Main_Form.sound_dd_2.Enabled = true;
            }
        }

        public void sound3_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_Form.sound3_cb.Checked == false)
            {
                Main_Form.s3_tb.Enabled = false;
                Main_Form.s3_open.Enabled = false;
                Main_Form.sound_dd_3.Enabled = false;
            }
            else
            {
                Main_Form.s3_tb.Enabled = true;
                Main_Form.s3_open.Enabled = true;
                Main_Form.sound_dd_3.Enabled = true;
            }
        }

        public void p1_open_Click(object sender, EventArgs e)
        {
            OpenPlugin(Main_Form.p1_tb);
        }

        public void p2_open_Click(object sender, EventArgs e)
        {
            OpenPlugin(Main_Form.p2_tb);
        }

        public void p3_open_Click(object sender, EventArgs e)
        {
            OpenPlugin(Main_Form.p3_tb);
        }
        public void s1_open_Click(object sender, EventArgs e)
        {
            OpenSound(Main_Form.s1_tb);
        }

        public void s2_open_Click(object sender, EventArgs e)
        {
            OpenSound(Main_Form.s2_tb);
        }

        public void s3_open_Click(object sender, EventArgs e)
        {
            OpenSound(Main_Form.s3_tb);
        }

        public void show_pwd_MouseDown(object sender, MouseEventArgs e)
        {
            Main_Form.password_tb.PasswordChar = '\0';
        }

        public void show_pwd_MouseUp(object sender, MouseEventArgs e)
        {
            Main_Form.password_tb.PasswordChar = '*';
        }
    }
}