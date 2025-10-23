using AIRAC_Downloader_for_Euroscope.Code.Core;
using AIRAC_Downloader_for_Euroscope.Code.UI;
using System;
using System.Configuration;
using System.Text;

namespace AIRAC_Downloader.Code.Core
{
    public class Datahandling
    {
        private Main_Form Main_Form;
        public Datahandling(Main_Form Main_Form)
        {
            this.Main_Form = Main_Form;
        }

        // G2A Key Data
        public static uint G2A_ScanCode { get; set; }
        public static bool G2A_IsExtended { get; set; }

        // G2G Key Data
        public static uint G2G_ScanCode { get; set; }
        public static bool G2G_IsExtended { get; set; }


        public void Export_Data()
        {
            if (Main_Form.callsign_cb.Checked)
            {
                SetSetting("callsign_cb", "true");
                SetSetting("callsign_tb", Main_Form.callsign_tb.Text);
            }
            else
            {
                SetSetting("callsign_cb", "false");
            }

            if (Main_Form.realname_cb.Checked)
            {
                SetSetting("realname_cb", "true");
                SetSetting("realname_tb", Main_Form.realname_tb.Text);
            }
            else
            {
                SetSetting("realname_cb", "false");
            }

            if (Main_Form.certificate_cb.Checked)
            {
                SetSetting("certificate_cb", "true");
                SetSetting("certificate_tb", Main_Form.certificate_tb.Text);
            }
            else
            {
                SetSetting("certificate_cb", "false");
            }

            if (Main_Form.password_cb.Checked)
            {
                SetSetting("password_cb", "true");
                Encoding enc = new UTF8Encoding(true, true);
                byte[] bytes = enc.GetBytes(Main_Form.password_tb.Text);
                SetSetting("password_tb", string.Join(", ", bytes));
            }
            else
            {
                SetSetting("password_cb", "false");
            }

            if (Main_Form.facility_cb.Checked)
            {
                SetSetting("facility_cb", "true");
                SetSetting("facility_dd", Main_Form.facility_dd.Text);
            }
            else
            {
                SetSetting("facility_cb", "false");
            }

            if (Main_Form.rating_cb.Checked)
            {
                SetSetting("rating_cb", "true");
                SetSetting("rating_dd", Main_Form.rating_dd.Text);
            }
            else
            {
                SetSetting("rating_cb", "false");
            }

            if (Main_Form.plugin1_cb.Checked)
            {
                SetSetting("plugin1_cb", "true");
                SetSetting("p1_tb", Main_Form.p1_tb.Text);
            }
            else
            {
                SetSetting("plugin1_cb", "false");
            }

            if (Main_Form.plugin2_cb.Checked)
            {
                SetSetting("plugin2_cb", "true");
                SetSetting("p2_tb", Main_Form.p2_tb.Text);
            }
            else
            {
                SetSetting("plugin2_cb", "false");
            }

            if (Main_Form.plugin3_cb.Checked)
            {
                SetSetting("plugin3_cb", "true");
                SetSetting("p3_tb", Main_Form.p3_tb.Text);
            }
            else
            {
                SetSetting("plugin3_cb", "false");
            }

            if (Main_Form.sound1_cb.Checked)
            {
                SetSetting("sound1_cb", "true");
                SetSetting("s1_tb", Main_Form.s1_tb.Text);
                SetSetting("sound_dd_1", Main_Form.sound_dd_1.Text);
            }
            else
            {
                SetSetting("sound1_cb", "false");
            }

            if (Main_Form.sound2_cb.Checked)
            {
                SetSetting("sound2_cb", "true");
                SetSetting("s2_tb", Main_Form.s2_tb.Text);
                SetSetting("sound_dd_2", Main_Form.sound_dd_2.Text);
            }
            else
            {
                SetSetting("sound2_cb", "false");
            }

            if (Main_Form.sound3_cb.Checked)
            {
                SetSetting("sound3_cb", "true");
                SetSetting("s3_tb", Main_Form.s3_tb.Text);
                SetSetting("sound_dd_3", Main_Form.sound_dd_3.Text);
            }
            else
            {
                SetSetting("sound3_cb", "false");
            }

            if (Main_Form.hoppie_cb.Checked)
            {
                SetSetting("hoppie_cb", "true");
                SetSetting("hoppie_tb", Main_Form.hoppie_tb.Text);
            }

            if (Main_Form.nickname_cb.Checked)
            {
                SetSetting("nickname_cb", "true");
                SetSetting("nickname_tb", Main_Form.nickname_tb.Text);
            }
            else
            {
                SetSetting("nickname_cb", "false");
            }

            if (Main_Form.g2a_ptt_cb.Checked)
            {
                SetSetting("G2A_PTT", "true");
                SetSetting("G2A_Scancode", G2A_ScanCode.ToString());
            }
            else
            {
                SetSetting("G2A_PTT", "false");
            }

            if (Main_Form.g2g_ptt_cb.Checked)
            {
                SetSetting("G2G_PTT", "true");
                SetSetting("G2G_Scancode", G2G_ScanCode.ToString());
            }
            else
            {
                SetSetting("G2G_PTT", "false");
            }

            if (Main_Form.capture_mode_cb.Checked)
            {
                SetSetting("capture_mode_cb", "true");
                SetSetting("capture_mode_dd", Main_Form.capture_mode_dd.Text);
            }
            else
            {
                SetSetting("capture_mode_cb", "false");
            }

            if (Main_Form.capture_device_cb.Checked)
            {
                SetSetting("capture_device_cb", "true");
                SetSetting("capture_device_dd", Main_Form.capture_device_dd.Text);
            }
            else
            {
                SetSetting("capture_device_cb", "false");
            }

            if (Main_Form.playback_mode_cb.Checked)
            {
                SetSetting("playback_mode_cb", "true");
                SetSetting("playback_mode_dd", Main_Form.playback_mode_dd.Text);
            }
            else
            {
                SetSetting("playback_mode_cb", "false");
            }

            if (Main_Form.playback_device_cb.Checked)
            {
                SetSetting("playback_device_cb", "true");
                SetSetting("playback_device_dd", Main_Form.playback_device_dd.Text);
            }
            else
            {
                SetSetting("playback_device_cb", "false");
            }

            SetSetting("save_to_tb", Main_Form.save_to_tb.Text);
            SetSetting("vacc_dd", Main_Form.vacc_dd.Text);
            SetSetting("pack_dd", Main_Form.pack_dd.Text);
        }










        public void Import_Data()
        {
            //Callsign
            if (GetSetting("callsign_cb") == "true")
            {
                Main_Form.callsign_cb.Checked = true;
                Main_Form.callsign_tb.Text = GetSetting("callsign_tb");
            }
            else
            {
                Main_Form.callsign_cb.Checked = false;
            }

            //Real Name
            if (GetSetting("realname_cb") == "true")
            {
                Main_Form.realname_cb.Checked = true;
                Main_Form.realname_tb.Text = GetSetting("realname_tb");
            }
            else
            {
                Main_Form.realname_cb.Checked = false;
            }

            //Certificate
            if (GetSetting("certificate_cb") == "true")
            {
                Main_Form.certificate_cb.Checked = true;
                Main_Form.certificate_tb.Text = GetSetting("certificate_tb");
            }
            else
            {
                Main_Form.certificate_cb.Checked = false;
            }

            //Password
            if (GetSetting("password_cb") == "true")
            {
                Main_Form.password_cb.Checked = true;

                Encoding enc = new UTF8Encoding(true, true);
                var parts = GetSetting("password_tb").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                byte[] bytes = Array.ConvertAll(parts, p => byte.Parse(p));
                string pswd = enc.GetString(bytes);
                Main_Form.password_tb.Text = pswd;
            }
            else
            {
                Main_Form.password_cb.Checked = false;
            }

            //Facility
            if (GetSetting("facility_cb") == "true")
            {
                Main_Form.facility_cb.Checked = true;
                Main_Form.facility_dd.Text = GetSetting("facility_dd");
            }
            else
            {
                Main_Form.facility_cb.Checked = false;
            }

            //Rating
            if (GetSetting("rating_cb") == "true")
            {
                Main_Form.rating_cb.Checked = true;
                Main_Form.rating_dd.Text = GetSetting("rating_dd");
            }
            else
            {
                Main_Form.rating_cb.Checked = false;
            }

            if (GetSetting("plugin1_cb") == "true")
            {
                Main_Form.plugin1_cb.Checked = true;
                Main_Form.p1_tb.Text = GetSetting("p1_tb");
            }
            else
            {
                Main_Form.plugin1_cb.Checked = false;
            }

            if (GetSetting("plugin2_cb") == "true")
            {
                Main_Form.plugin2_cb.Checked = true;
                Main_Form.p2_tb.Text = GetSetting("p2_tb");
            }
            else
            {
                Main_Form.plugin2_cb.Checked = false;
            }

            if (GetSetting("plugin3_cb") == "true")
            {
                Main_Form.plugin3_cb.Checked = true;
                Main_Form.p3_tb.Text = GetSetting("p3_tb");
            }
            else
            {
                Main_Form.plugin3_cb.Checked = false;
            }

            if (GetSetting("sound1_cb") == "true")
            {
                Main_Form.sound1_cb.Checked = true;
                Main_Form.s1_tb.Text = GetSetting("s1_tb");
                Main_Form.sound_dd_1.Text = GetSetting("sound_dd_1");
            }
            else
            {
                Main_Form.sound1_cb.Checked = false;
            }

            if (GetSetting("sound2_cb") == "true")
            {
                Main_Form.sound2_cb.Checked = true;
                Main_Form.s2_tb.Text = GetSetting("s2_tb");
                Main_Form.sound_dd_2.Text = GetSetting("sound_dd_2");
            }
            else
            {
                Main_Form.sound2_cb.Checked = false;
            }

            if (GetSetting("sound3_cb") == "true")
            {
                Main_Form.sound3_cb.Checked = true;
                Main_Form.s3_tb.Text = GetSetting("s3_tb");
                Main_Form.sound_dd_3.Text = GetSetting("sound_dd_3");
            }
            else
            {
                Main_Form.sound3_cb.Checked = false;
            }

            if (GetSetting("hoppie_cb") == "true")
            {
                Main_Form.hoppie_cb.Checked = true;
                Main_Form.hoppie_tb.Text = GetSetting("hoppie_tb");
            }
            else
            {
                Main_Form.hoppie_cb.Checked = false;
            }

            if (GetSetting("nickname_cb") == "true")
            {
                Main_Form.nickname_cb.Checked = true;
                Main_Form.nickname_tb.Text = GetSetting("nickname_tb");
            }
            else
            {
                Main_Form.nickname_cb.Checked = false;
            }

            if (GetSetting("G2A_PTT") == "true")
            {
                Main_Form.g2a_ptt_cb.Checked = true;
                uint euroScopeCode = Convert.ToUInt32(GetSetting("G2A_Scancode"));

                ushort G2A_ScanCode = (ushort)((euroScopeCode >> 16) & 0xFF);
                bool G2A_IsExtended = ((euroScopeCode >> 16) & 0x100) != 0;

                Main_Form.g2a_btn.Text = VCCS_Keyboard_Listener.GetKeyName((ushort)G2A_ScanCode, G2A_IsExtended);
            }
            else
            {
                Main_Form.g2a_ptt_cb.Checked = false;
            }

            if (GetSetting("G2G_PTT") == "true")
            {
                Main_Form.g2g_ptt_cb.Checked = true;
                uint euroScopeCode = Convert.ToUInt32(GetSetting("G2G_Scancode"));

                ushort G2G_ScanCode = (ushort)((euroScopeCode >> 16) & 0xFF);
                bool G2G_IsExtended = ((euroScopeCode >> 16) & 0x100) != 0;

                Main_Form.g2g_btn.Text = VCCS_Keyboard_Listener.GetKeyName((ushort)G2G_ScanCode, G2G_IsExtended);
            }
            else
            {
                Main_Form.g2g_ptt_cb.Checked = false;
            }

            if (GetSetting("capture_mode_cb") == "true")
            {
                Main_Form.capture_mode_cb.Checked = true;
                Main_Form.capture_mode_dd.Text = GetSetting("capture_mode_dd");
            }
            else
            {
                Main_Form.capture_mode_cb.Checked = false;
            }

            if (GetSetting("capture_device_cb") == "true")
            {
                Main_Form.capture_device_cb.Checked = true;
                Main_Form.capture_device_dd.Text = GetSetting("capture_device_dd");
            }
            else
            {
                Main_Form.capture_device_cb.Checked = false;
            }

            if (GetSetting("playback_mode_cb") == "true")
            {
                Main_Form.playback_mode_cb.Checked = true;
                Main_Form.playback_mode_dd.Text = GetSetting("playback_mode_dd");
            }
            else
            {
                Main_Form.playback_mode_cb.Checked = false;
            }

            if (GetSetting("playback_device_cb") == "true")
            {
                Main_Form.playback_device_cb.Checked = true;
                Main_Form.playback_device_dd.Text = GetSetting("playback_device_dd");
            }
            else
            {
                Main_Form.playback_device_cb.Checked = false;
            }
            Main_Form.save_to_tb.Text = GetSetting("save_to_tb");

        }


        //
        // Get App.Config Settings
        //
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        //
        // Set App.Config Settings
        //
        public static void SetSetting(string key, string value)
        {
            Configuration configuration =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (configuration.AppSettings.Settings[key] == null)
            {
                configuration.AppSettings.Settings.Add(key, value);
            }
            else
            {
                configuration.AppSettings.Settings[key].Value = value;
            }
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}