using AIRAC_Downloader.Code.Core;
using AIRAC_Downloader_for_Euroscope.Code.Core;
using System;
using static AIRAC_Downloader.Code.Core.Datahandling;

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

            var Packs = await Get_packs();
            pack_dd.Items.Clear();
            foreach (var Pack in Packs)
            {
                pack_dd.Items.Add(Pack[0]);
            }
            if (pack_dd.Items.Contains(GetSetting("pack_dd")))
            {
                pack_dd.Text = GetSetting("pack_dd");
            }
            else
            {
                pack_dd.SelectedIndex = 0;
            }

            if (vacc_dd.Text != "" && pack_dd.Text != "")
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
            Pack_AIRAC.Text = string.Join(": ", "AIRAC", Packages_list[pack_dd.SelectedIndex][1]);
            Pack_Version.Text = string.Join(": ", "Version", Packages_list[pack_dd.SelectedIndex][2]);
            Pack_Released.Text = string.Join(": ", "Released", Packages_list[pack_dd.SelectedIndex][3]);

            if (vacc_dd.Text != "" && pack_dd.Text != "")
            {
                Download.Enabled = true;
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
            Datahandling Datahandler = new(this);
            Datahandler.Export_Data();
        }


        public void save_vacc_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(save_to_tb, "Within the specified Folder there will be an subfolder created for the according VACC Code (e.g. 'EDXX').\nWithin the Subfolder of the VACC you can find the folder of the downloaded Package.");
        }
    }
}