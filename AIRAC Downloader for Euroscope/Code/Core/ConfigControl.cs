using System.Configuration;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{
    public class ConfigControl
    {
        //Version of current Json Config File
        private static string currentVersion = "V1.1";
        //new Json Config File
        private static string JsonConfigFName = "AIRAC Downloader Configuration.json";
        private static string JsonConfigPath = Application.StartupPath + "\\" + JsonConfigFName;
        //old Config File
        private static string dotConfigFName= "AIRAC Downloader for Euroscope.dll.config";
        private static string dotConfigPath = Application.StartupPath + "\\" + dotConfigFName;

        public class Config
        {
            public Euroscope thisES { get; set; } = new();
            public VCCS thisVCCS { get; set; } = new();
            public AeroNav thisAN { get; set; } = new();

            public string? Version { get; set; }

            public class Euroscope
            {

                public string Callsign { get; set; }
                public string Realname { get; set; }
                public string Certificate { get; set; }
                public string Password { get; set; }
                public string Facility { get; set; }
                public string Rating { get; set; }
                public string Hoppie { get; set; }
                public List<string> Plugins { get; set; } = [];
                public List<(string Sound, string Soundtype)> Sounds { get; set; } = new List<(string Sound, string Soundtype)>();
            }

            public class VCCS
            {
                public string Nickname { get; set; }
                public string G2Aptt { get; set; }
                public string G2Gptt { get; set; }
                public string CaptureMode { get; set; }
                public string CaptureDevice { get; set; }
                public string PlaybackMode { get; set; }
                public string PlaybackDevice { get; set; }
            }

            public class AeroNav
            {
                public string VACC { get; set; }
                public string Package { get; set; }
                public string Folder { get; set; }
            }
        }

        //
        // Get Config from old .config Files
        //
        private static string? GetSetting(string? checkbox, string key)
        {
            if (ConfigurationManager.AppSettings[checkbox] == "true" || checkbox is null)
            {
                return ConfigurationManager.AppSettings[key];
            }
            return null;
        }

        /// <summary>
        /// Creates a Json File to Safe current Userinputs
        /// </summary>
        /// <param name="datas">The filled ConfigControl.Config Class to be safed</param>
        public void ExportIntoJson(Config datas)
        {
            string path = JsonConfigPath;
            datas.Version = currentVersion;
            string Json = JsonSerializer.Serialize(datas, new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
            if (File.Exists(path)) File.Delete(path);
            File.WriteAllText(path, Json);
        }

        /// <summary>
        /// Imports the Config Json File
        /// </summary>
        /// <returns>The filled ConfigControl.Config Class from the safed parameters</returns>
        public static Config ImportControl()
        {
            if (!File.Exists(JsonConfigPath))
            {
                return null;
            }
            string Jsonfile = File.ReadAllText(JsonConfigPath);
            Config importConfig = JsonSerializer.Deserialize<Config>(Jsonfile);
            if (importConfig.Version.ToString() != currentVersion) throw new Exception("Config outdated. Please update at Program Startup");
            return importConfig;
        }


        //##############
        //Config Updater
        //##############


        /// <summary>
        /// Checks if a deprecated Config File or older Version exists
        /// </summary>
        /// <returns>Boolean if Config is old</returns>
        public bool ExistsOldConfig()
        {
            string[] oldConfigFiles = Directory.GetFiles(Application.StartupPath, dotConfigFName, SearchOption.TopDirectoryOnly);
            string[] oldVersion = Directory.GetFiles(Application.StartupPath, JsonConfigFName, SearchOption.TopDirectoryOnly);
            if (oldConfigFiles.Length > 0)
            {
                return true;
            }
            foreach (string filename in oldVersion)
            {
                Config Configuration = JsonSerializer.Deserialize<Config>(File.ReadAllText(filename));
                //using var jsonConfig = JsonDocument.Parse(filename);
                if (currentVersion != Configuration.Version) return true;
            }
            return false;
        }

        /// <summary>
        /// Detects old Config Files or old versions and updates automatically to the most current version
        /// </summary>
        public void UpdateOldConfigs()
        {
            string[] configs = [];
            if (File.Exists(dotConfigFName))
            {
                configs = configs.Append(dotConfigFName).ToArray();
            }
            if (File.Exists(JsonConfigFName))
            {
                configs = configs.Append(JsonConfigFName).ToArray();
            }
                //.Append(Directory.GetFiles(Application.StartupPath, JsonConfigFName, SearchOption.TopDirectoryOnly)).ToArray();

            /*foreach (string oldConfig in oldConfigs)
            {
                if (configs.Length == 0)
                {
                    configs = [oldConfig];
                }
                configs = configs.Append(oldConfig).ToArray();
            }*/

            if (configs.Length > 1) throw new Exception("Update failed: more than one config file existing in program folder");
            if (configs.Length == 0) throw new FileNotFoundException("No config file existing");
            if (configs[0].EndsWith(".config"))
            {
                Config updatedConfig = new Config();
                updatedConfig.Version = currentVersion;

                //Euroscope Part
                updatedConfig.thisES.Callsign = GetSetting("callsign_cb", "callsign_tb");
                updatedConfig.thisES.Realname = GetSetting("realname_cb", "realname_tb");
                updatedConfig.thisES.Certificate = GetSetting("certificate_cb", "certificate_tb");
                updatedConfig.thisES.Password = GetSetting("password_cb", "password_tb");
                updatedConfig.thisES.Facility = GetSetting("facility_cb", "facility_dd");
                updatedConfig.thisES.Rating = GetSetting("rating_cb", "rating_dd");
                updatedConfig.thisES.Hoppie = GetSetting("hoppie_cb", "hoppie_tb");

                if (GetSetting("plugin1_cb", "p1_tb") is not null) //Add second Plugin if is not null
                {
                    updatedConfig.thisES.Plugins.Add(GetSetting("plugin1_cb", "p1_tb"));
                }
                
                if (GetSetting("plugin2_cb", "p2_tb") is not null) //Add second Plugin if is not null
                {
                    updatedConfig.thisES.Plugins.Add(GetSetting("plugin2_cb", "p2_tb"));
                }
                if (GetSetting("plugin3_cb", "p3_tb") is not null) //Add third Plugin if is not null
                {
                    updatedConfig.thisES.Plugins.Add(GetSetting("plugin3_cb", "p3_tb"));
                }

                if(GetSetting("sound1_cb", "s1_tb") is not null)
                {
                    updatedConfig.thisES.Sounds.Add(new(GetSetting("sound1_cb", "s1_tb"), GetSetting("sound1_cb", "sound_dd_1")));
                }
                if (GetSetting("sound2_cb", "s2_tb") is not null)
                {
                    updatedConfig.thisES.Sounds.Add((GetSetting("sound2_cb", "s2_tb"), GetSetting("sound2_cb", "sound_dd_2")));
                }
                if (GetSetting("sound3_cb", "s3_tb") is not null)
                {
                    updatedConfig.thisES.Sounds.Add((GetSetting("sound3_cb", "s3_tb"), GetSetting("sound3_cb", "sound_dd_3")));
                }


                //VCCS Part
                updatedConfig.thisVCCS.Nickname = GetSetting("nickname_cb", "nickname_tb");
                updatedConfig.thisVCCS.G2Aptt = GetSetting("G2A_PTT", "G2A_Scancode");
                updatedConfig.thisVCCS.G2Gptt = GetSetting("G2G_PTT", "G2G_Scancode");
                updatedConfig.thisVCCS.CaptureMode = GetSetting("capture_mode_cb", "capture_mode_dd");
                updatedConfig.thisVCCS.CaptureDevice = GetSetting("capture_device_cb", "capture_device_dd");
                updatedConfig.thisVCCS.PlaybackMode = GetSetting("playback_mode_cb", "playback_mode_dd");
                updatedConfig.thisVCCS.PlaybackDevice = GetSetting("playback_device_cb", "playback_device_dd");

                //AeroNav Part
                updatedConfig.thisAN.VACC = GetSetting(null, "vacc_dd");
                updatedConfig.thisAN.Package = GetSetting(null, "pack_dd");
                updatedConfig.thisAN.Folder = GetSetting(null, "save_to_tb");


                //Serialize updatedConfig into Json and save to StartupPath
                ExportIntoJson(updatedConfig);

                File.Delete(dotConfigPath);
            }
            else
            {
                throw new Exception("Config-version of Json file not supported");
            }
        }
    }
}
