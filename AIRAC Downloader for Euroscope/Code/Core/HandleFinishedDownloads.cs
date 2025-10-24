using AIRAC_Downloader.Code.Core;
using AIRAC_Downloader_for_Euroscope.Code.UI;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{
     public class HandleFinishedDownloads
    {
        public HandleFinishedDownloads(Main_Form main_Form)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "Downloads";
            openFileDialog1.Filter = "ZIP-Archive (*.zip)|*.zip";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.Multiselect = false;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            main_Form.download_lbl.Text = "Unzipping";

            string file = openFileDialog1.FileName;

            List<string> VACC_ICAO = new List<string>(main_Form.pack_dd.Text.Split(new string[] { " " }, StringSplitOptions.None));
            string folder = main_Form.save_to_tb.Text + "\\" + VACC_ICAO[0];
            DirectoryInfo VACC_Folder = System.IO.Directory.CreateDirectory(folder);
            Console.WriteLine("Folder:" + folder);
            Console.WriteLine("File:" + file);

            folder = VACC_Folder.FullName + "\\" + VACC_ICAO[1];
            if (Directory.Exists(folder)) System.IO.Directory.Delete(folder, true);

            ZipFile.ExtractToDirectory(file, folder);
            System.IO.File.Delete(file);

            Injector Inject = new Injector(main_Form);
            Inject.Search_and_Inject_Data(folder);

            main_Form.download_lbl.Text = "Finished";
            main_Form.download_bar.Value = 100;
        }
    }
}
