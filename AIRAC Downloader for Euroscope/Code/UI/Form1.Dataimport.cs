using AIRAC_Downloader_for_Euroscope.Code.Core;
using System.Reflection.Metadata;

namespace AIRAC_Downloader_for_Euroscope.Code.UI
{
    public partial class Main_Form : Form
    {
        ConfigControl ConfigHandler = new ConfigControl();

        /// <summary>
        /// Checks whether an update is available to the current update or not
        /// </summary>
        private void CheckConfigUpdate()
        {
            if (ConfigHandler.ExistsOldConfig())
            {
                if (MessageBox.Show("You have an old Configuration saved that is unsupported.\nShould this be updated fully automatically now?", "Old Configuration found", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {
                        ConfigHandler.UpdateOldConfigs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error whilst updating Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Imports all Data from an Config File into the Main_Form
        /// </summary>
        private async Task ImportData()
        {
            ConfigControl.Config config = ConfigControl.ImportControl();
            if (config != null)
            {

                //Euroscope Setup Part
                if (config.thisES.Callsign is not null)
                {
                    this.callsign_cb.Checked = true;
                    this.callsign_tb.Text = config.thisES.Callsign.ToString();
                }
                else
                {
                    this.callsign_tb.Text = string.Empty;
                    this.callsign_cb.Checked = false;
                }

                if (config.thisES.Realname is not null)
                {
                    this.realname_cb.Checked = true;
                    this.realname_tb.Text = config.thisES.Realname.ToString();
                }
                else
                {
                    this.realname_tb.Text = string.Empty;
                    this.realname_cb.Checked = false;
                }

                if (config.thisES.Certificate is not null)
                {
                    this.certificate_cb.Checked = true;
                    this.certificate_tb.Text = config.thisES.Certificate.ToString();
                }
                else
                {
                    this.certificate_tb.Text = string.Empty;
                    this.certificate_cb.Checked = false;
                }

                if (config.thisES.Password is not null)
                {
                    this.password_cb.Checked = true;
                    this.password_tb.Text= config.thisES.Password.ToString();
                }
                else
                {
                    this.password_tb.Text = string.Empty;
                    this.password_cb.Checked = false;
                }

                if (config.thisES.Facility is not null)
                {
                    this.facility_cb.Checked = true;
                    if (facility_dd.Items.Contains(config.thisES.Facility.ToString()))
                    {
                        this.facility_dd.Text = config.thisES.Facility.ToString();
                    }
                    else this.facility_dd.Text = string.Empty;
                }
                else
                {
                    this.facility_dd.Text = string.Empty;
                    this.facility_cb.Checked = false;
                }

                if (config.thisES.Rating is not null)
                {
                    this.rating_cb.Checked = true;
                    if (this.rating_dd.Items.Contains(config.thisES.Rating.ToString()))
                    {
                        this.rating_dd.Text = config.thisES.Rating.ToString();
                    }
                    else this.rating_dd.Text = string.Empty;
                }
                else
                {
                    this.rating_dd.Text = string.Empty;
                    this.rating_cb.Checked = false;
                }

                if (config.thisES.Hoppie is not null)
                {
                    this.hoppie_cb.Checked = true;
                    this.hoppie_tb.Text = config.thisES.Hoppie.ToString();
                }
                else
                {
                    this.hoppie_tb.Text= string.Empty;
                    this.hoppie_cb.Checked= false;
                }

                if (config.thisES.Plugins.Count > 0)
                {
                    this.plugin1_cb.Checked = true;
                    this.p1_tb.Text = config.thisES.Plugins[0].ToString();
                }
                else
                {
                    this.p1_tb.Text = string.Empty;
                    this.plugin1_cb.Checked = false;
                }

                if (config.thisES.Plugins.Count > 1)
                {
                    this.plugin2_cb.Checked = true;
                    this.p2_tb.Text = config.thisES.Plugins[1].ToString();
                }
                else
                {
                    this.p2_tb.Text= string.Empty;
                    this.plugin2_cb.Checked= false;
                }

                if (config.thisES.Plugins.Count > 2)
                {
                    this.plugin3_cb.Checked = true;
                    this.p3_tb.Text = config.thisES.Plugins[2].ToString();
                }
                else
                {
                    this.p3_tb.Text= string.Empty;
                    this.plugin3_cb.Checked = false;
                }

                if (config.thisES.Sounds.Count > 0)
                {
                    this.sound1_cb.Checked = true;
                    this.s1_tb.Text = config.thisES.Sounds[0].ToTuple().Item1.ToString();
                    if (this.sound_dd_1.Items.Contains(config.thisES.Sounds[0].ToTuple().Item2.ToString()))
                    {
                        this.sound_dd_1.Text = config.thisES.Sounds[0].ToTuple().Item2.ToString();
                    }
                    else this.sound_dd_1.Text = string.Empty;
                }
                else
                {
                    this.s1_tb.Text= string.Empty;
                    this.sound_dd_1.Text = string.Empty;
                    this.sound1_cb.Checked= false;
                }

                if (config.thisES.Sounds.Count > 1)
                {
                    this.sound2_cb.Checked = true;
                    this.s2_tb.Text = config.thisES.Sounds[1].ToTuple().Item1.ToString();
                    if (this.sound_dd_2.Items.Contains(config.thisES.Sounds[1].ToTuple().Item2.ToString()))
                    {
                        this.sound_dd_2.Text = config.thisES.Sounds[1].ToTuple().Item2.ToString();
                    }
                    else this.sound_dd_2.Text = string.Empty;
                }
                else
                {
                    this.s2_tb.Text= string.Empty;
                    this.sound_dd_2.Text = string.Empty;
                    this.sound2_cb.Checked = false;

                }

                if (config.thisES.Sounds.Count > 2)
                {
                    this.sound3_cb.Checked = true;
                    this.s3_tb.Text = config.thisES.Sounds[2].ToTuple().Item1.ToString();
                    if (this.sound_dd_3.Items.Contains(config.thisES.Sounds[2].ToTuple().Item2.ToString()))
                    {
                        this.sound_dd_3.Text = config.thisES.Sounds[2].ToTuple().Item2.ToString();
                    }
                    else this.sound_dd_3.Text = string.Empty;
                }
                else
                {
                    this.s3_tb.Text = string.Empty;
                    this.sound3_cb.Checked = false;
                }

                //VCCS Setup
                if (config.thisVCCS.Nickname is not null)
                {
                    this.nickname_cb.Checked = true;
                    this.nickname_tb.Text = config.thisVCCS.Nickname.ToString();
                }
                else
                {
                    this.nickname_tb.Text = string.Empty;
                    this.nickname_cb.Checked = false;
                }

                if (config.thisVCCS.G2Aptt is not null)
                {
                    this.g2a_ptt_cb.Checked = true;
                    this.g2a_btn.Text = config.thisVCCS.G2Aptt.ToString();
                }
                else
                {
                    this.g2a_btn.Text = string.Empty;
                    this.g2a_ptt_cb.Checked= false;
                }

                if (config.thisVCCS.G2Gptt is not null)
                {
                    this.g2g_ptt_cb.Checked = true;
                    this.g2g_btn.Text = config.thisVCCS.G2Gptt.ToString();
                }

                if (config.thisVCCS.CaptureMode is not null)
                {
                    this.capture_mode_cb.Checked = true;
                    if (this.capture_mode_dd.Items.Contains(config.thisVCCS.CaptureMode.ToString()))
                    {
                        this.capture_mode_dd.Text = config.thisVCCS.CaptureMode.ToString();
                    }
                    else this.capture_mode_dd.Text = string.Empty;
                }
                else
                {
                    this.capture_mode_dd.Text = string.Empty;
                    this.capture_mode_cb.Checked = false;
                }

                if (config.thisVCCS.CaptureDevice is not null)
                {
                    this.capture_device_cb.Checked = true;
                    if (this.capture_device_dd.Items.Contains(config.thisVCCS.CaptureDevice.ToString()))
                    {
                        this.capture_device_dd.Text = config.thisVCCS.CaptureDevice.ToString();
                    }
                    else this.capture_device_dd.Text = string.Empty;
                }
                else
                {
                    this.capture_device_dd.Text = string.Empty;
                    this.capture_device_cb.Checked = false;
                }

                if (config.thisVCCS.PlaybackMode is not null)
                {
                    this.playback_mode_cb.Checked = true;
                    if (this.playback_mode_dd.Items.Contains(config.thisVCCS.PlaybackMode.ToString()))
                    {
                        this.playback_mode_dd.Text = config.thisVCCS.PlaybackMode.ToString();
                    }
                    else this.playback_mode_dd.Text = string.Empty;

                }
                else
                {
                    this.playback_mode_dd.Text = string.Empty;
                    this.playback_mode_cb.Checked = false;
                }

                if (config.thisVCCS.PlaybackDevice is not null)
                {
                    this.playback_device_cb.Checked = true;
                    if (this.playback_device_dd.Items.Contains(config.thisVCCS.PlaybackDevice.ToString()))
                    {
                        this.playback_device_dd.Text = config.thisVCCS.PlaybackDevice.ToString();
                    }
                    else this.playback_device_dd.Text = string.Empty;
                }
                else
                {
                    this.playback_device_dd.Text = string.Empty;
                    this.playback_device_cb.Checked = false;
                }

                //AeroNav Setup
                if (config.thisAN.VACC is not null && this.vacc_dd.Items.Contains(config.thisAN.VACC.ToString()))
                {
                    this.vacc_dd.Text = config.thisAN.VACC.ToString();
                }

                if (config.thisAN.Package is not null)
                {
                    int Retry = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (this.pack_dd.Items.Contains(config.thisAN.Package.ToString()))
                        {
                            this.pack_dd.Text = config.thisAN.Package.ToString();
                            break;
                        }
                        else
                        {
                            await Task.Delay(1000);
                            Retry++;
                        }
                    }
                }

                if (config.thisAN.Folder is not null)
                {
                    this.save_to_tb.Text = config.thisAN.Folder.ToString();
                }
                else
                {
                    this.save_to_tb.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Exports all Data from the Main_Form to an Config File
        /// </summary>
        private void ExportData()
        {
            ConfigControl.Config Data = new();
            
            //Euroscope  Setup
            if (this.callsign_cb.Checked)
            {
                Data.thisES.Callsign = this.callsign_tb.Text;
            }
            if (this.realname_cb.Checked)
            {
                Data.thisES.Realname = this.realname_tb.Text;
            }
            if (this.certificate_cb.Checked)
            {
                Data.thisES.Certificate = this.certificate_tb.Text;
            }
            if (this.password_cb.Checked)
            {
                Data.thisES.Password = this.password_tb.Text;
            }
            if (this.facility_cb.Checked)
            {
                Data.thisES.Facility = this.facility_dd.Text;
            }
            if (this.rating_cb.Checked)
            {
                Data.thisES.Rating = this.rating_dd.Text;
            }
            if (this.hoppie_cb.Checked)
            {
                Data.thisES.Hoppie = this.hoppie_tb.Text;
            }
            if (this.plugin1_cb.Checked)
            {
                Data.thisES.Plugins.Add(this.p1_tb.Text);
            }
            if (this.plugin2_cb.Checked)
            {
                Data.thisES.Plugins.Add(this.p2_tb.Text);
            }
            if (this.plugin3_cb.Checked)
            {
                Data.thisES.Plugins.Add(this.p3_tb.Text);
            }
            if (this.sound1_cb.Checked)
            {
                Data.thisES.Sounds.Add((this.s1_tb.Text, this.sound_dd_1.Text));
            }
            if (this.sound2_cb.Checked)
            {
                Data.thisES.Sounds.Add((this.s2_tb.Text, this.sound_dd_2.Text));
            }
            if (this.sound3_cb.Checked)
            {
                Data.thisES.Sounds.Add((this.s3_tb.Text, this.sound_dd_3.Text));
            }

            //VCCS Setup
            if (this.nickname_cb.Checked)
            {
                Data.thisVCCS.Nickname = this.nickname_tb.Text;
            }
            if (this.g2a_ptt_cb.Checked)
            {
                Data.thisVCCS.G2Aptt = this.g2a_btn.Text;
            }
            if (this.g2g_ptt_cb.Checked)
            {
                Data.thisVCCS.G2Gptt = this.g2g_btn.Text;
            }
            if (this.capture_mode_cb.Checked)
            {
                Data.thisVCCS.CaptureMode = this.capture_mode_dd.Text;
            }
            if (this.capture_device_cb.Checked)
            {
                Data.thisVCCS.CaptureDevice = this.capture_device_dd.Text;
            }
            if (this.playback_mode_cb.Checked)
            {
                Data.thisVCCS.PlaybackMode = this.playback_mode_dd.Text;
            }
            if (this.playback_device_cb.Checked)
            {
                Data.thisVCCS.PlaybackDevice = this.playback_device_dd.Text;
            }

            //AeroNav Setup
            if (this.vacc_dd.Text != "")
            {
                Data.thisAN.VACC = this.vacc_dd.Text;
            }
            if (this.pack_dd.Text != "")
            {
                Data.thisAN.Package = this.pack_dd.Text;
            }
            if (this.save_to_tb.Text != "")
            {
                Data.thisAN.Folder = this.save_to_tb.Text;
            }

            //Export Data Object
            ConfigHandler.ExportIntoJson(Data);
        }
    }
}
