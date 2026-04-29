using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{
    internal class CurrentInstalledAirac
    {
        private static string GetLast(string source)
        {
            if (26 >= source.Length)
                return source;
            return source.Substring(source.Length - 26);
        }


        ///
        /// <summary>
        /// Extracts the AIRAC, release date and version from the FIR folder
        /// <\summary>
        /// <param name="path">The directory path to and including the FIR folder </param>
        /// <returns>A tuple of the currently installed AIRAC e.g. (AIRAC / AIRAC Rev., Version, AIRAC Date [Y-M-D]) or ("n/a", "n/a", "n/a")</returns>

        public static (string, string, string) getCurrentInstalledAIRAC(string path)
        {
            if (!Directory.Exists(path))
            {
                return ("n/a", "n/a", "n/a");
            }

            //Search for Windows Script Component file and return Filename as String
            var WindowsScriptComponents = Directory.GetFiles(path, "*.sct", SearchOption.TopDirectoryOnly);
            if (WindowsScriptComponents.Length > 1) return ("n/a","n/a","n/a") ;
            string WindowsScriptComponent = WindowsScriptComponents[0];

            //Format Filename to Create List with Data
            WindowsScriptComponent = WindowsScriptComponent.Replace(".sct", "");
            string Packagedata = GetLast(WindowsScriptComponent);
            string[] releasedata = Packagedata.Split("-");

            //Frag mich doch nicht ob das besser geht lol...
            string AIRAC = $"{releasedata[1][0]}{releasedata[1][1]}{releasedata[1][2]}{releasedata[1][3]}";
            string AIRACrev = $"{releasedata[1][4]}{releasedata[1][5]}";

            string version = releasedata[2].Replace("0", "");

            string AIRACversionYEAR = $"{releasedata[0][0]}{releasedata[0][1]}{releasedata[0][2]}{releasedata[0][3]}";
            string AIRACversionMONTH = $"{releasedata[0][4]}{releasedata[0][5]}";
            string AIRACversionDAY = $"{releasedata[0][6]}{releasedata[0][7]}";


            return ($"{AIRAC} / {AIRACrev}", version, $"{AIRACversionYEAR}-{AIRACversionMONTH}-{AIRACversionDAY}");
        }
    }
}
