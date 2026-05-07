using System.Net.Http;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{
    public class WebsiteScraper
    {
        public record PackageContent
        {
            public string ICAO { get; init; }
            public string PackageName { get; init; }
            public string AIRAC { get; init; }
            public string Version { get; init; }
            public string Released { get; init; }
        }

        public record VaccContent
        {
            public string ICAO { get; init; }
            public string VaccName { get; init; }
        }

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
        /// <returns>Returns a List of VaccContent Objects</returns>
        public List<VaccContent> GetVaccList()
        {
            List<VaccContent> VACCs = new ();
            
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
                    VACCs.Add(new VaccContent { ICAO=tr.ChildNodes[3].InnerText, VaccName=tr.ChildNodes[5].InnerText });
                    //VACCs.Add((tr.ChildNodes[3].InnerText, tr.ChildNodes[5].InnerText));
                }
            }


            return VACCs;
        }

        /// <summary>
        ///     Returns all Packs available within the given vACC
        /// </summary>
        /// <param name="ICAO">ICAO Code of concerning vACC</param>
        /// <returns>Returns a List of PackageContent Objects</returns>
        public List<PackageContent> GetPacksList(string ICAO)
        {
            List<PackageContent> Packs = new();

            // Download HTML Website content
            HtmlAgilityPack.HtmlDocument HtmlCode = GetHtmlCode(Website +  ICAO);
            
            // Select Table
            var table = HtmlCode.DocumentNode.SelectSingleNode("//table[@class='table table-striped table-hover table-bordered']");

            // To skip Table header
            string PackICAO = null;
            foreach (var tr in table.ChildNodes.Skip(2))
            {
                if (tr.ChildNodes.Count >= 4) // probably not required but doesn't hurt
                {
                    PackICAO = tr.ChildNodes[1].InnerText.Split(' ')[0];
                    Packs.Add(new PackageContent {ICAO=PackICAO, PackageName=tr.ChildNodes[1].InnerText, AIRAC=tr.ChildNodes[2].InnerText, Version=tr.ChildNodes[3].InnerText, Released=tr.ChildNodes[4].InnerText });    
                }
            }

            return Packs;
        }
    }
}
