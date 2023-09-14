using AIRAC_Downloader.Code.Core;
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
            pack_dd.UseWaitCursor = false;
        }

        public async void Vacc_dd_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        public void Pack_dd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pack_AIRAC.Text = string.Join(": ", "AIRAC", Packages_list[pack_dd.SelectedIndex][1]);
            Pack_Version.Text = string.Join(": ", "Version", Packages_list[pack_dd.SelectedIndex][2]);
            Pack_Released.Text = string.Join(": ", "Released", Packages_list[pack_dd.SelectedIndex][3]);
        }

        public void Download_Click(object sender, EventArgs e)
        {
            Downloader Download_class = new(this);
            Download_class.Start_Download();
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