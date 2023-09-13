using System;
using static AIRAC_Downloader.Code.Core.Datahandling;

namespace AIRAC_Downloader.Code.Core
{
    public class AeroNav_Events
    {
        private Main_Form mainForm;
        public AeroNav_Events(Main_Form mainForm)
        {
            this.mainForm = mainForm;
        }
        public void Save_to_btn_Click(object sender, EventArgs e)
        {
            mainForm.save_folder.ShowDialog();
            mainForm.save_to_tb.Text = mainForm.save_folder.SelectedPath.ToString();
        }

        public async void Vacc_dd_SelectedValueChanged(object sender, EventArgs e)
        {
            mainForm.pack_dd.UseWaitCursor = true;

            var Packs = await mainForm.Get_packs();
            mainForm.pack_dd.Items.Clear();
            foreach (var Pack in Packs)
            {
                mainForm.pack_dd.Items.Add(Pack[0]);
            }
            if (mainForm.pack_dd.Items.Contains(GetSetting("pack_dd")))
            {
                mainForm.pack_dd.Text = GetSetting("pack_dd");
            }
            else
            {
                mainForm.pack_dd.SelectedIndex = 0;
            }
            mainForm.pack_dd.UseWaitCursor = false;
        }

        public async void Vacc_dd_VisibleChanged(object sender, EventArgs e)
        {
            mainForm.vacc_dd.UseWaitCursor = true;
            var VACCS = await mainForm.Get_VACCS();
            foreach (var VACC in VACCS)
            {
                mainForm.vacc_dd.Items.Add(string.Join(" || ", VACC));
            }
            if (GetSetting("vacc_dd") != "")
            {
                mainForm.vacc_dd.Text = GetSetting("vacc_dd");
            }
            else
            else
            {
                mainForm.vacc_dd.SelectedIndex = 0;
            }
            mainForm.vacc_dd.Enabled = true;
            mainForm.vacc_dd.UseWaitCursor = false;

            if (GetSetting("pack_dd") != "")
            {
                mainForm.pack_dd.Text = GetSetting("pack_dd");
            }
        }

        public void Pack_dd_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainForm.Pack_AIRAC.Text = string.Join(": ", "AIRAC", Main_Form.Packages_list[mainForm.pack_dd.SelectedIndex][1]);
            mainForm.Pack_Version.Text = string.Join(": ", "Version", Main_Form.Packages_list[mainForm.pack_dd.SelectedIndex][2]);
            mainForm.Pack_Released.Text = string.Join(": ", "Released", Main_Form.Packages_list[mainForm.pack_dd.SelectedIndex][3]);
        }

        public void Download_Click(object sender, EventArgs e)
        {
            Downloader Download_class = new Downloader(this.mainForm);
            Download_class.Start_Download();
        }


        public void Save_Data_Click(object sender, EventArgs e)
        {
            Datahandling Datahandler = new Datahandling(this.mainForm);
            Datahandler.Export_Data();
        }


        public void save_vacc_MouseHover(object sender, EventArgs e)
        {
            mainForm.toolTip1.SetToolTip(mainForm.save_to_tb, "Within the specified Folder there will be an subfolder created for the according VACC Code (e.g. 'EDXX').\nWithin the Subfolder of the VACC you can find the folder of the downloaded Package.");
        }
    }
}