using AIRAC_Downloader.Code.Core;
using AIRAC_Downloader_for_Euroscope.Code.Core;

namespace AIRAC_Downloader_for_Euroscope.Code.UI
{
    partial class Main_Form
    {
        
        public void Save_to_btn_Click(object sender, EventArgs e)
        {
            save_folder.ShowDialog();
            save_to_tb.Text = save_folder.SelectedPath.ToString();
        }

        public async void Vacc_dd_SelectedValueChanged(object sender, EventArgs e)
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

        public void Pack_dd_SelectedValueChanged(object sender, EventArgs e)
        {
            Pack_AIRAC.Text = "AIRAC : " + availablePackages[pack_dd.SelectedIndex].Item2;
            Pack_Version.Text = "Version : " + availablePackages[pack_dd.SelectedIndex].Item3;
            Pack_Released.Text = "Released : " + availablePackages[pack_dd.SelectedIndex].Item4; ;

            if (vacc_dd.Text != "" && pack_dd.Text != "" && save_to_tb.Text != "")
            {
                Download.Enabled = true;
                (string AIRAC, string version, string releasedate) = Core.CurrentInstalledAirac.getCurrentInstalledAIRAC(Path.Combine(save_to_tb.Text, Packages_list[pack_dd.SelectedIndex][0].Split(" ")[0]));
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
                (string AIRAC, string version, string releasedate) = Core.CurrentInstalledAirac.getCurrentInstalledAIRAC(Path.Combine(save_to_tb.Text, Packages_list[pack_dd.SelectedIndex][0].Split(" ")[0]));
                currently_installed_AIRAC.Text = $"AIRAC: {AIRAC}";
                currently_installed_released.Text = $"Released: {releasedate}";
                currently_installed_version.Text = $"Version: {version}";
            }
            else
            {
                Download.Enabled = false;
            }
        }

        public void Download_Click(object sender, EventArgs e)
        {
            AiracAutoInstaller.StartBrowserAndWatch(this.pack_dd.Text.Split(" ")[0], this.save_to_tb.Text, (extractedFolder) =>
            {
                // this.Invoke sorgt dafür, dass Search_and_Inject_Data auf UI-Thread läuft
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        Injector inject = new Injector (this);
                        inject.Search_and_Inject_Data(extractedFolder);
                    }));
                }
                catch (ObjectDisposedException)
                {
                    // Form geschlossen; ignoriere
                }
            });
        }


        public void Save_Data_Click(object sender, EventArgs e)
        {
            ExportData();
        }


        public void save_vacc_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(save_to_tb, "Within the specified Folder there will be an subfolder created for the according VACC Code (e.g. 'EDXX').\nWithin the Subfolder of the VACC you can find the folder of the downloaded Package.");
        }
    }
}