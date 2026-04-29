using System.Configuration;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
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
        private static string JsonConfigPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + JsonConfigFName;
        //old Config File
        private static string dotConfigFName= "AIRAC Downloader for Euroscope.dll.config";
        private static string dotConfigPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + dotConfigFName;


        //Class to be used for import and export of configs
        public class Config
        {
            public Euroscope thisES { get; set; } = new();
            public VCCS thisVCCS { get; set; } = new();
            public AeroNav thisAN { get; set; } = new();
            
            
            // 2 Constructors
            public Config() { }
            public Config(string? Version,
                string? Callsign, string? Realname, string? Certificate, string? Password, string? Facility, string? Rating, string? Hoppie, List<string>? Plugins, List<(string Sound, int Soundtypes)>? Sounds,
                string? Nickname, uint G2Aptt, uint G2Gptt, string? CaptureMode, string? CaptureDevice, string? PlaybackMode, string? PlaybackDevice,
                string? VACC, string? Package, string? Folder
            )
            {
                this.Version =Version;

                this.thisES.Callsign = Callsign;
                this.thisES.Realname = Realname;
                this.thisES.Certificate = Certificate;
                this.thisES.Password = Password;
                this.thisES.Facility = Facility;
                this.thisES.Rating = Rating;
                this.thisES.Hoppie = Hoppie;
                this.thisES.Plugins = Plugins;
                this.thisES.Sounds = Sounds;

                this.thisVCCS.Nickname = Nickname;
                this.thisVCCS.G2Aptt = G2Aptt;
                this.thisVCCS.G2Gptt = G2Gptt;
                this.thisVCCS.CaptureMode = CaptureMode;
                this.thisVCCS.CaptureDevice = CaptureDevice;
                this.thisVCCS.PlaybackMode = PlaybackMode;
                this.thisVCCS.PlaybackDevice = PlaybackDevice;

                this.thisAN.VACC = VACC;
                this.thisAN.Package = Package;
                this.thisAN.Folder = Folder;
            }

            // Config Version
            public string Version { get; set; }

            // Config main content
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
                public List<(string Sound, int Soundtype)> Sounds { get; set; } = new List<(string Sound, int Soundtype)>();
            }

            public class VCCS
            {
                public string Nickname { get; set; }
                public uint G2Aptt { get; set; }
                public uint G2Gptt { get; set; }
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
            Config importConfig = JsonSerializer.Deserialize<Config>(Jsonfile, new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
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
            //old .conf config files
            string[] oldConfigFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, dotConfigFName, SearchOption.TopDirectoryOnly);
            //old .json config files
            string[] oldVersion = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, JsonConfigFName, SearchOption.TopDirectoryOnly);
            
            //check for old version and return true
            if (oldConfigFiles.Length > 0)
            {
                return true;
            }
            foreach (string filename in oldVersion)
            {
                Config Configuration = JsonSerializer.Deserialize<Config>(File.ReadAllText(filename));
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

            if (configs.Length > 1) throw new Exception("Update failed: more than one config file existing in program folder");
            if (configs.Length == 0) throw new FileNotFoundException("No config file existing");
            if (configs[0].EndsWith(".config"))
            {
                Config updatedConfig = new Config();
                updatedConfig.Version = currentVersion;

                //Decoding for Password
                Encoding enc = new UTF8Encoding(true, true);
                var parts = GetSetting("password_cb", "password_tb").Split(new[] { ',' } , StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    byte[] bytes = Array.ConvertAll(parts, p => byte.Parse(p));
                    updatedConfig.thisES.Password = enc.GetString(bytes);
                }
                //Euroscope Part
                updatedConfig.thisES.Callsign = GetSetting("callsign_cb", "callsign_tb");
                updatedConfig.thisES.Realname = GetSetting("realname_cb", "realname_tb");
                updatedConfig.thisES.Certificate = GetSetting("certificate_cb", "certificate_tb");
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
                    updatedConfig.thisES.Sounds.Add(new(GetSetting("sound1_cb", "s1_tb"), Int32.Parse(GetSetting("sound1_cb", "sound_dd_1"))));
                }
                if (GetSetting("sound2_cb", "s2_tb") is not null)
                {
                    updatedConfig.thisES.Sounds.Add((GetSetting("sound2_cb", "s2_tb"), Int32.Parse(GetSetting("sound2_cb", "sound_dd_2"))));
                }
                if (GetSetting("sound3_cb", "s3_tb") is not null)
                {
                    updatedConfig.thisES.Sounds.Add((GetSetting("sound3_cb", "s3_tb"), Int32.Parse(GetSetting("sound3_cb", "sound_dd_3"))));
                }


                //VCCS Part
                updatedConfig.thisVCCS.Nickname = GetSetting("nickname_cb", "nickname_tb");
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
