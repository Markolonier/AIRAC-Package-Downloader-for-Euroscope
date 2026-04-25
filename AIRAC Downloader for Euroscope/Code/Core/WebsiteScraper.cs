using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{
    public class WebsiteScraper
    {
        private static string Website = "https://files.aero-nav.com/";

        /// <summary>
        ///     Returns the HTML Document from a given URL
        /// </summary>
        /// <param name="Url">The URL String from the Website</param>
        /// <returns>The HtmlDocument Object</returns>
        private static HtmlAgilityPack.HtmlDocument GetHtmlCode(string Url)
        {
            using (var client = new HttpClient())
            {
                var WebText = Task.Run(() => client.GetStringAsync(Url)).GetAwaiter().GetResult();
                var HtmlCode = new HtmlAgilityPack.HtmlDocument();
                HtmlCode.LoadHtml(WebText);
                return HtmlCode;
            }
            
        }


        /// <summary>
        ///     Creates a List of all vACCs available in AeroNav GNG
        /// </summary>
        /// <returns>Returns a List with the Tuple of all vACCs as [(ICAO, vACC Name)]</returns>
        public List<(String, String)> GetVaccList()
        {
            var VACCs = new List<(String, String)>();
            
            // Download HTML Website content
            HtmlAgilityPack.HtmlDocument HtmlCode = GetHtmlCode(Website);

            //Select Table in HTML Document containing all vACCs
            var table = HtmlCode.DocumentNode.SelectSingleNode("//table[@class='table table-striped table-hover']");

            //Iterate TableRows of vACCs and add their 
            foreach (var tr in table.ChildNodes)
            {
                if(tr.ChildNodes.Count >= 5) // to filter last row containing "Powered by AeroNav Association"
                {
                    // ChildNodes[3] = Column of vACC-ICAO; ChildNodes[5] = Column of vACC-Name
                    VACCs.Add((tr.ChildNodes[3].InnerText, tr.ChildNodes[5].InnerText));
                }
            }


            return VACCs;
        }

        /// <summary>
        ///     Returns all Packs available within the given vACC
        /// </summary>
        /// <param name="ICAO">ICAO Code of concerning vACC</param>
        /// <returns>Returns a List of Tuples of all Packs like [(Packagename, AIRAC, Version, Released)]</returns>
        public List<(String, String, String, String)> GetPacksList(string ICAO)
        {
            var Packs = new List<(String, String, String, String)>();

            // Download HTML Website content
            HtmlAgilityPack.HtmlDocument HtmlCode = GetHtmlCode(Website +  ICAO);
            
            // Select Table
            var table = HtmlCode.DocumentNode.SelectSingleNode("//table[@class='table table-striped table-hover table-bordered']");

            // To skip Table header
            foreach (var tr in table.ChildNodes.Skip(2))
            {
                if (tr.ChildNodes.Count >= 4) // probably not required but doesn't hurt
                {
                    Packs.Add((tr.ChildNodes[1].InnerText, tr.ChildNodes[2].InnerText, tr.ChildNodes[3].InnerText, tr.ChildNodes[4].InnerText));
                }
            }

            return Packs;
        }
    }
}
