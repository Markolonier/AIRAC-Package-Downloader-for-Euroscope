using AIRAC_Downloader.Code.Core;
using AIRAC_Downloader_for_Euroscope.Code.Core;
using System.Diagnostics;

namespace AIRAC_Downloader_for_Euroscope.Code.UI
{
    partial class Main_Form
    {
        
        private void Save_to_btn_Click(object sender, EventArgs e)
        {
            save_folder.ShowDialog();
            save_to_tb.Text = save_folder.SelectedPath.ToString();
        }

        private async void Vacc_dd_SelectedValueChanged(object sender, EventArgs e)
        {
            pack_dd.UseWaitCursor = true;

            availablePackages = scraper.GetPacksList(availableVaccs[vacc_dd.SelectedIndex].Item1);
            pack_dd.Items.Clear();
            foreach (var Pack in availablePackages)
            {
                pack_dd.Items.Add(Pack.Item1);
            }
            pack_dd.SelectedIndex = 0;

            if (vacc_dd.Text != "" && pack_dd.Text != "" && save_to_tb.Text != "")
            {
                Download.Enabled = true;
            }
            else
            {
                Download.Enabled = false;
            }
                pack_dd.UseWaitCursor = false;
        }

        private void Pack_dd_SelectedValueChanged(object sender, EventArgs e)
        {
            Pack_AIRAC.Text = "AIRAC : " + availablePackages[pack_dd.SelectedIndex].Item2;
            Pack_Version.Text = "Version : " + availablePackages[pack_dd.SelectedIndex].Item3;
            Pack_Released.Text = "Released : " + availablePackages[pack_dd.SelectedIndex].Item4; ;

            if (vacc_dd.Text != "" && pack_dd.Text != "" && save_to_tb.Text != "")
            {
                Download.Enabled = true;
                (string AIRAC, string version, string releasedate) = Core.CurrentInstalledAirac.getCurrentInstalledAIRAC(Path.Combine(save_to_tb.Text, availablePackages[pack_dd.SelectedIndex].Item1.Split(" ")[0]));
                currently_installed_AIRAC.Text = $"AIRAC: {AIRAC}";
                currently_installed_released.Text = $"Released: {releasedate}";
                currently_installed_version.Text = $"Version: {version}";
            }
            else
            {
                Download.Enabled = false;
            }
        }

        private void save_to_tb_TextChanged(object sender, EventArgs e)
        {
            if (vacc_dd.Text != "" && pack_dd.Text != "" && save_to_tb.Text != "")
            {
                Download.Enabled = true;
                (string AIRAC, string version, string releasedate) = Core.CurrentInstalledAirac.getCurrentInstalledAIRAC(Path.Combine(save_to_tb.Text, availablePackages[pack_dd.SelectedIndex].Item1.Split(" ")[0]));
                currently_installed_AIRAC.Text = $"AIRAC: {AIRAC}";
                currently_installed_released.Text = $"Released: {releasedate}";
                currently_installed_version.Text = $"Version: {version}";
            }
            else
            {
                Download.Enabled = false;
            }
        }

        private void Download_Click(object sender, EventArgs e)
        {
            AiracAutoInstaller.StartBrowserAndWatch(this.pack_dd.Text.Split(" ")[0], this.save_to_tb.Text, (extractedFolder) =>
            {
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        Injector inject = new();

                        //Create a list out of all plugins
                        string?[] pluginsWithNull = [
                            plugin1_cb.Checked ? p1_tb.Text : null,
                            plugin2_cb.Checked ? p2_tb.Text : null,
                            plugin3_cb.Checked ? p3_tb.Text : null
                        ];
                        List<string> plugins = pluginsWithNull.Where(i => i != null).ToList();

                        //Create a list out of all sounds
                        List<(string, int?)> soundsWithNull = [
                            sound1_cb.Checked ? (s1_tb.Text, sound_dd_1.SelectedIndex + 1) : (null, null),
                            sound2_cb.Checked ? (s2_tb.Text, sound_dd_2.SelectedIndex + 1) : (null, null),
                            sound3_cb.Checked ? (s3_tb.Text, sound_dd_3.SelectedIndex + 1) : (null, null)
                        ];
                        List<(string? Sound, int? Soundtype)>? sounds = soundsWithNull.Where(i => i != (null, null)).ToList();

                        //Call the Constructor of the Data Object that is required for the InjectAllDatas() call
                        Injector.Data currentData = new(
                            callsign: callsign_cb.Checked ? callsign_tb.Text : null,
                            realname: realname_cb.Checked ? realname_tb.Text : null,
                            certificate: certificate_cb.Checked ? certificate_tb.Text : null,
                            password: password_cb.Checked ? password_tb.Text : null,
                            facility: facility_cb.Checked ? facility_dd.SelectedIndex : null,
                            rating: rating_cb.Checked ? rating_dd.SelectedIndex : null,
                            hoppie: hoppie_cb.Checked ? hoppie_tb.Text : null,
                            plugins: plugins,
                            Sounds: sounds,

                            vccsNickname: nickname_cb.Checked ? nickname_tb.Text : null,
                            g2aptt: g2a_ptt_cb.Checked ? G2Abttn.Code : null,
                            g2gptt: g2g_ptt_cb.Checked ? G2Gbttn.Code : null,
                            captureMode: capture_mode_cb.Checked ? capture_mode_dd.Text : null,
                            captureDevice: capture_device_cb.Checked ? capture_device_dd.Text : null,
                            playbackMode: playback_mode_cb.Checked ? playback_mode_dd.Text : null,
                            playbackDevice: playback_device_cb.Checked ? playback_device_dd.Text : null
                        );


                        inject.InjectAllDatas(currentData, extractedFolder);


                        MessageBox.Show("Injection finished", "AIRAC Downloader");
                    }));
                }
                catch (ObjectDisposedException)
                {
                    // Form geschlossen; ignoriere
                }
            });
        }


        private void Save_Data_Click(object sender, EventArgs e)
        {
            ExportData();
        }


        private void save_vacc_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(save_to_tb, "Within the specified Folder there will be an subfolder created for the according VACC Code (e.g. 'EDXX').\nWithin the Subfolder of the VACC you can find the folder of the downloaded Package.");
        }
    }
}