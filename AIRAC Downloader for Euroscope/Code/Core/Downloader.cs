using AIRAC_Downloader_for_Euroscope.Code.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace AIRAC_Downloader.Code.Core
{
    public class Downloader
    {
        private Main_Form Main_Form;



        public Downloader(Main_Form main_Form)
        {
            this.Main_Form = main_Form;
        }




        public void Start_Download()
        {
            Main_Form.Download.Enabled = false;
            string url = "https://files.aero-nav.com/" + Main_Form.pack_dd.Text.Replace(" ", "/") + "_" + Main_Form.Pack_Released.Text.Replace("-", "").Replace(" ", "").Replace(":", "").Replace("Released", "") + "-" + Main_Form.Pack_AIRAC.Text.Replace(" ", "").Replace("/", "").Replace("AIRAC:", "") + "-" + Main_Form.Pack_Version.Text.Replace("Version: ", "") + ".zip";
            Console.WriteLine(url);
            List<string> VACC_ICAO = new List<string>(Main_Form.pack_dd.Text.Split(new string[] { " " }, StringSplitOptions.None));
            string folder = Main_Form.save_to_tb.Text + "\\" + VACC_ICAO[0];
            DirectoryInfo VACC_Folder = System.IO.Directory.CreateDirectory(folder);

            folder = VACC_Folder.FullName + "\\" + VACC_ICAO[1];
            if (Directory.Exists(folder)) System.IO.Directory.Delete(folder, true);

            string file = VACC_Folder.FullName + "\\" + VACC_ICAO[1] + ".zip";

            Console.WriteLine(VACC_Folder.FullName);
            Console.WriteLine(file);

            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
            wc.Headers.Add(HttpRequestHeader.Referer, "https://files.aero-nav.com/EDXX/");
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            wc.DownloadFileAsync
            (
            // Param1 = Link of file
            new System.Uri(url),
            // Param2 = Path to save
            file
            );
        }



        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Main_Form.download_bar.Value = e.ProgressPercentage;
        }



        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            List<string> VACC_ICAO = new List<string>(Main_Form.pack_dd.Text.Split(new string[] { " " }, StringSplitOptions.None));
            string folder = Main_Form.save_to_tb.Text + "\\" + VACC_ICAO[0];
            DirectoryInfo VACC_Folder = System.IO.Directory.CreateDirectory(folder);

            folder = VACC_Folder.FullName + "\\" + VACC_ICAO[1];
            if (Directory.Exists(folder)) System.IO.Directory.Delete(folder, true);

            string file = VACC_Folder.FullName + "\\" + VACC_ICAO[1] + ".zip";
            ZipFile.ExtractToDirectory(file, folder);
            System.IO.File.Delete(file);

            Injector Inject = new Injector(Main_Form);
            Inject.Search_and_Inject_Data(folder);
            Main_Form.download_bar.Value = 0;
        }
    }
}