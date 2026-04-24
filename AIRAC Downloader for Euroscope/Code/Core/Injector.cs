using AIRAC_Downloader_for_Euroscope.Code.UI;
using System;
using System.Collections.Generic;
using System.IO;

namespace AIRAC_Downloader.Code.Core
{
    public class Injector
    {
        private Main_Form Main_Form;

        public Injector(Main_Form Main_Form)
        {
            this.Main_Form = Main_Form;
        }

        public void Search_and_Inject_Data(string VACC_Folder)
        {

            string[] files = Directory.GetFiles(VACC_Folder, "*.prf", SearchOption.AllDirectories);

            string prf_inject_string = "";


            if (Main_Form.sound1_cb.Checked)
            {
                prf_inject_string += "Sounds\tSound" + Main_Form.sound_dd_1.SelectedIndex + "\t" + Main_Form.s1_tb.Text + "\n";
            }
            if (Main_Form.sound2_cb.Checked)
            {
                prf_inject_string += "Sounds\tSound" + Main_Form.sound_dd_2.SelectedIndex + "\t" + Main_Form.s2_tb.Text + "\n";
            }
            if (Main_Form.sound3_cb.Checked)
            {
                prf_inject_string += "Sounds\tSound" + Main_Form.sound_dd_3.SelectedIndex + "\t" + Main_Form.s3_tb.Text + "\n";
            }
            prf_inject_string += "LastSession\tconnecttype\t0\n";
            if (Main_Form.callsign_cb.Checked)
            {
                prf_inject_string += "LastSession\tcallsign\t" + Main_Form.callsign_tb.Text + "\n";
            }
            if (Main_Form.realname_cb.Checked)
            {
                prf_inject_string += "LastSession\trealname\t" + Main_Form.realname_tb.Text + "\n";
            }
            if (Main_Form.certificate_cb.Checked)
            {
                prf_inject_string += "LastSession\tcertificate\t" + Main_Form.certificate_tb.Text + "\n";
            }
            if (Main_Form.password_cb.Checked)
            {
                prf_inject_string += "LastSession\tpassword\t" + Main_Form.password_tb.Text + "\n";
            }
            if (Main_Form.facility_cb.Checked)
            {
                prf_inject_string += "LastSession\tfacility\t" + Main_Form.facility_dd.SelectedIndex + "\n";
            }
            if (Main_Form.rating_cb.Checked)
            {
                prf_inject_string += "LastSession\trating\t" + Main_Form.rating_dd.SelectedIndex + "\n";
            }
            prf_inject_string += "LastSession\tserver\tAUTOMATIC\n";
            if (Main_Form.nickname_cb.Checked)
            {
                prf_inject_string += "TeamSpeakVccs\tTs3NickName\t" + Main_Form.nickname_tb.Text + "\n";
            }
            /*if (Main_Form.g2a_ptt_cb.Checked)
            {
                prf_inject_string += "TeamSpeakVccs\tTs3G2APtt\t" + Datahandling.G2A_ScanCode + "\n";
            }
            if (Main_Form.g2g_ptt_cb.Checked)
            {
                prf_inject_string += "TeamSpeakVccs\tTs3G2GPtt\t" + Datahandling.G2G_ScanCode + "\n";
            }*/
            if (Main_Form.playback_mode_cb.Checked)
            {
                prf_inject_string += "TeamSpeakVccs\tPlaybackMode\t" + Main_Form.playback_mode_dd.Text + "\n";
            }
            if (Main_Form.playback_device_cb.Checked)
            {
                prf_inject_string += "TeamSpeakVccs\tPlaybackDecvice\t" + Main_Form.playback_device_dd.Text + "\n";
            }
            if (Main_Form.capture_mode_cb.Checked)
            {
                prf_inject_string += "TeamSpeakVccs\tCaptureMode\t" + Main_Form.capture_mode_dd.Text + "\n";
            }
            if (Main_Form.capture_device_cb.Checked)
            {
                prf_inject_string += "TeamSpeakVccs\tCaptureDevice\t" + Main_Form.capture_device_dd.Text + "\n";
            }

            foreach (string file in files)
            {
                string prf_inject_string_file = prf_inject_string;
                int plugin = 0;
                string Content = File.ReadAllText(file);
                List<string> split_Content = new List<string>(Content.Split(new string[] { "Plugins\tPlugin" }, StringSplitOptions.None));
                int i = 0;
                foreach (string line in split_Content)
                {
                    if (i > 0)
                    {
                        int result = 0;
                        try
                        {
                            string str_result = line.Substring(0, 2);
                            result = Int32.Parse(str_result);
                        }
                        catch
                        {
                            string str_result = line.Substring(0, 1);
                            result = Int32.Parse(str_result);
                        }

                        //int result = line[0] - '0';

                        if (result > plugin)
                        {
                            plugin = result;
                        }
                    }
                    i++;

                }
                Console.WriteLine(plugin);

                if (Main_Form.plugin1_cb.Checked)
                {
                    plugin++;
                    Console.WriteLine(plugin);
                    prf_inject_string_file += "Plugins\tPlugin" + plugin + "\t" + Main_Form.p1_tb.Text + "\n";
                }

                if (Main_Form.plugin2_cb.Checked)
                {
                    plugin++;
                    prf_inject_string_file += "Plugins\tPlugin" + plugin + "\t" + Main_Form.p2_tb.Text + "\n";
                }

                if (Main_Form.plugin3_cb.Checked)
                {
                    plugin++;
                    prf_inject_string_file += "Plugins\tPlugin" + plugin + "\t" + Main_Form.p3_tb.Text + "\n";
                }

                Content += prf_inject_string_file;
                File.WriteAllText(file, Content);
            }




            //Hoppie
            if (Main_Form.hoppie_cb.Checked)
            {
                var all_folders = Directory.GetDirectories(VACC_Folder, "*", SearchOption.AllDirectories);
                
                foreach (string folder in all_folders)
                {
                    if(Directory.GetFiles(folder).ToList().Exists(x => x.Contains("TopSkyCPDLChoppieCode")))
                    {
                        var template = Path.Combine(folder, "TopSkyCPDLChoppieCode.template.txt");
                        if (File.Exists(template)) File.Delete(template);

                        File.WriteAllText(Path.Combine(folder, "TopSkyCPDLChoppieCode.txt"), Main_Form.hoppie_tb.Text);

                    }
                }
            }



            Main_Form.Download.Enabled = true;
            MessageBox.Show("Injection finished", "AIRAC Downloader");
        }
    }
}