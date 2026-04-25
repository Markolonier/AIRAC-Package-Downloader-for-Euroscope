using AIRAC_Downloader_for_Euroscope.Code.UI;
using System.Diagnostics;
using Windows.Security.Cryptography.Certificates;

namespace AIRAC_Downloader.Code.Core
{
    public class Injector
    {


        //Class to be used for injection
        public class Data
        {
            public Euroscope thisES { get; set; } = new();
            public VCCS thisVCCS { get; set; } = new();
            
            // Constructor
            public Data(
                string? callsign = null, string? realname = null, string? certificate= null, string? password = null, int? facility = null, int? rating = null, string? hoppie = null, List<string>? plugins = null, List<(string? Sound, int? Soundtype)>? Sounds = null,
                string? vccsNickname = null, uint? g2aptt = null, uint? g2gptt = null, string? captureMode = null, string? captureDevice = null, string? playbackMode = null, string? playbackDevice = null
            )
            {
                this.thisES.Callsign = callsign;
                this.thisES.Realname = realname;
                this.thisES.Certificate = certificate;
                this.thisES.Password = password;
                this.thisES.Facility = facility;
                this.thisES.Rating = rating;
                this.thisES.Hoppie = hoppie;
                this.thisES.Plugins = plugins;
                this.thisES.Sounds = Sounds;

                this.thisVCCS.Nickname = vccsNickname;
                this.thisVCCS.G2Aptt = g2aptt;
                this.thisVCCS.G2Gptt = g2gptt;
                this.thisVCCS.CaptureMode = captureMode;
                this.thisVCCS.CaptureDevice = captureDevice;
                this.thisVCCS.PlaybackMode = playbackMode;
                this.thisVCCS.PlaybackDevice = playbackDevice;

            }

            //Injection content
            public class Euroscope
            {

                public string? Callsign { get; set; }
                public string? Realname { get; set; }
                public string? Certificate { get; set; }
                public string? Password { get; set; }
                public int? Facility { get; set; }
                public int? Rating { get; set; }
                public string? Hoppie { get; set; }
                public List<string>? Plugins { get; set; } = [];
                public List<(string? Sound, int? Soundtype)>? Sounds { get; set; } = new List<(string? Sound, int? Soundtype)>();
            }

            public class VCCS
            {
                public string? Nickname { get; set; }
                public uint? G2Aptt { get; set; }
                public uint? G2Gptt { get; set; }
                public string? CaptureMode { get; set; }
                public string? CaptureDevice { get; set; }
                public string? PlaybackMode { get; set; }
                public string? PlaybackDevice { get; set; }
            }
        }

        /// <summary>
        /// Shows the Highest index of an keyWord in a prf file.
        /// e.g.:
        /// Plugins	Plugin0	\first.dll
        /// Plugins	Plugin1	\first.dll
        /// Plugins	Plugin2	\first.dll
        /// will return 2
        /// </summary>
        /// <param name="content">String of the prf file</param>
        /// <param name="keyWord">keyWord where the highest index is required of</param>
        /// <returns>Int of the highest Keyword</returns>
        private int GetHighestIndex(string content,  string keyWord)
        {

            //Splitting the content to receive ["0 \Link\to\first.dll", "1 \Link\to\second.dll", "2 \Link\to\third.dll"] need to parse the integer before the first whitespace
            string[] Splits = content.Split(keyWord);

            int Count = 0; // Highest number
            int currentNum = 0; // number of current iteration
            foreach (string Split in Splits)
            {
                try
                {
                    // Splitting at the first Whitespace between the current Plugin Index and the Link to the DLL File. And parsing the Pluginindex into an integer
                    currentNum = Int32.Parse(Split.Split("\t")[0]);
                    if (currentNum > Count) Count = currentNum; //set the count if Plugin Index is higher
                }
                catch { } // Some Plugins contain e.g.: "Plugins Plugin0Display0 Ground Radar display" catching these. They are not relevant because they are always following a .dll path entry
            }

            return Count;
        }

        /// <summary>
        /// Injects all Data into the unpacked package
        /// </summary>
        /// <param name="toInject"></param>
        /// <param name="PackageFolder"></param>
        public void InjectAllDatas(Data toInject, string PackageFolder)
        {
            //List of all Profiles
            string[] files = Directory.GetFiles(PackageFolder, "*.prf", SearchOption.AllDirectories);

            
            string GeneralProfileString = ""; //Content to be injected into all Profiles

            //Add Euroscope Content to Profile content
            GeneralProfileString += $"LastSession\tconnecttype\t0{Environment.NewLine}";
            GeneralProfileString += $"LastSession\tserver\tAUTOMATIC{Environment.NewLine}";
            
            if (toInject.thisES.Sounds is not null && toInject.thisES.Sounds.Count > 0)
            {
                foreach ((string Sound, int Soundtype) sound in toInject.thisES.Sounds)
                {
                    GeneralProfileString += $"Sounds\tSound{sound.Item2}\t{sound.Item1}{Environment.NewLine}";
                }
            }

            if (toInject.thisES.Callsign is not null)
            {
                GeneralProfileString += $"LastSession\tcallsign\t{toInject.thisES.Callsign}{Environment.NewLine}";
            }
            if (toInject.thisES.Realname is not null)
            {
                GeneralProfileString += $"LastSession\trealname\t{toInject.thisES.Realname}{Environment.NewLine}";
            }
            if (toInject.thisES.Certificate is not null)
            {
                GeneralProfileString += $"LastSession\tcertificate\t{toInject.thisES.Certificate}{Environment.NewLine}";
            }
            if (toInject.thisES.Password is not null)
            {
                GeneralProfileString += $"LastSession\tpassword\t{toInject.thisES.Password}{Environment.NewLine}";
            }
            if (toInject.thisES.Facility is not null)
            {
                GeneralProfileString += $"LastSession\tfacility\t{toInject.thisES.Facility}{Environment.NewLine}";
            }
            if (toInject.thisES.Rating is not null)
            {
                GeneralProfileString += $"LastSession\trating\t{toInject.thisES.Rating}{Environment.NewLine}";
            }



            //VCCS Content
            if (toInject.thisVCCS.Nickname is not null)
            {
                GeneralProfileString += $"TeamSpeakVccs\tTs3NickName\t{toInject.thisVCCS.Nickname}{Environment.NewLine}";
            }
            if (toInject.thisVCCS.G2Aptt is not null)
            {
                GeneralProfileString += $"TeamSpeakVccs\tTs3G2APtt\t{toInject.thisVCCS.G2Aptt}{Environment.NewLine}";
            }
            if (toInject.thisVCCS.G2Gptt is not null)
            {
                GeneralProfileString += $"TeamSpeakVccs\tTs3G2GPtt\t{toInject.thisVCCS.G2Gptt}{Environment.NewLine}";
            }
            if (toInject.thisVCCS.PlaybackMode is not null)
            {
                GeneralProfileString += $"TeamSpeakVccs\tPlaybackMode\t{toInject.thisVCCS.PlaybackMode}{Environment.NewLine}";
            }
            if (toInject.thisVCCS.PlaybackDevice is not null)
            {
                GeneralProfileString += $"TeamSpeakVccs\tPlaybackDevice\t{toInject.thisVCCS.PlaybackDevice}{Environment.NewLine}";
            }
            if (toInject.thisVCCS.CaptureMode is not null)
            {
                GeneralProfileString += $"TeamSpeakVccs\tCaptureMode\t{toInject.thisVCCS.CaptureMode}{Environment.NewLine}";
            }
            if (toInject.thisVCCS.CaptureDevice is not null)
            {
                GeneralProfileString += $"TeamSpeakVccs\tCaptureDevice\t{toInject.thisVCCS.CaptureDevice}{Environment.NewLine}";
            }


            //
            // Plugins have an counting index. e.g.:
            // Plugins Plugin0 \Link\to\first.dll
            // Plugins Plugin1 \Link\to\second.dll
            // Plugins Plugin2 \Link\to\third.dll
            // Therefore there need to be a scan on a per profile basis for existing plugins.
            foreach (string file in files)
            {

                string PerProfileString = GeneralProfileString;

                //Add Plugins to PerProfileString if Plugins selected
                if (toInject.thisES.Plugins is not null && toInject.thisES.Plugins.Count > 0)
                {
                    string Content = File.ReadAllText(file);

                    int PluginsCount = GetHighestIndex(Content, "Plugins\tPlugin");
                    
                    foreach (string plugin in toInject.thisES.Plugins)
                    {
                        PluginsCount++;
                        PerProfileString += $"Plugins\tPlugin{PluginsCount}\t{plugin}{Environment.NewLine}";
                    }
                }

                File.AppendAllText(file, PerProfileString);

            }




            //Hoppie
            if (toInject.thisES.Hoppie is not null)
            {
                var all_folders = Directory.GetDirectories(PackageFolder, "*", SearchOption.AllDirectories);
                
                foreach (string folder in all_folders)
                {
                    if(Directory.GetFiles(folder).ToList().Exists(x => x.Contains("TopSkyCPDLChoppieCode")))
                    {
                        var template = Path.Combine(folder, "TopSkyCPDLChoppieCode.template.txt");
                        if (File.Exists(template)) File.Delete(template);

                        File.WriteAllText(template, toInject.thisES.Hoppie);

                    }
                }
            }
        }
    }
}