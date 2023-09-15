using AIRAC_Downloader.Code.Core;

namespace AIRAC_Downloader_for_Euroscope.Code.UI
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }



        private async void Main_Form_Load(object sender, EventArgs e)
        {
            Datahandling Datahandler = new(this);
            Datahandler.Import_Data();
            vacc_dd.UseWaitCursor = true;
            var VACCS = await Get_VACCS();
            foreach (var VACC in VACCS)
            {
                vacc_dd.Items.Add(string.Join(" || ", VACC));
            }
            if (Datahandling.GetSetting("vacc_dd") != "")
            {
                Console.WriteLine("Vacc_dd Available");
                vacc_dd.Text = Datahandling.GetSetting("vacc_dd");
            }
            else
            {
                vacc_dd.SelectedIndex = 0;
            }
            vacc_dd.Enabled = true;
            vacc_dd.UseWaitCursor = false;

            if (Datahandling.GetSetting("pack_dd") != "")
            {
                pack_dd.Text = Datahandling.GetSetting("pack_dd");
            }
        }



        public static List<List<string>> all_VACCS = new List<List<string>>();
        public static List<string> datasource = new List<string>();
        public static List<List<string>> Packages_list = new List<List<string>>();

        public async Task<List<List<string>>> Get_VACCS()
        {
            string url = "https://files.aero-nav.com/";
            using (var client = new HttpClient())
            {
                var html = await client.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var table = doc.DocumentNode.SelectSingleNode("//table[@class='table table-striped table-hover']");

                foreach (var tr in table.ChildNodes)
                {
                    List<string> vacc = new List<string>();
                    int inner = 0;
                    foreach (var td in tr.ChildNodes)
                    {
                        if (inner == 3 || inner == 5)
                        {
                            vacc.Add(td.InnerText);
                        }
                        inner++;

                    }
                    all_VACCS.Add(vacc);
                }
                return all_VACCS;
            }
        }

        public async Task<List<List<string>>> Get_packs()
        {
            Packages_list.Clear();

            //Position of VACC Name in VACC Name List and Create Link
            List<string> VACC_ICAO = new List<string>(vacc_dd.Text.Split(new string[] { " || " }, StringSplitOptions.None));
            string url = "https://files.aero-nav.com/" + VACC_ICAO[0];

            //Load URL
            using (var client = new HttpClient())
            {
                var html = await client.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                //Select Table acc. to Class
                var table = doc.DocumentNode.SelectSingleNode("//table[@class='table table-striped table-hover table-bordered']");
                int row_counter = 0;

                //Iterate through rows in table
                foreach (var tr in table.ChildNodes)
                {
                    List<string> Packs = new List<string>();
                    //First Row (0) is header of table
                    if (row_counter > 1)
                    {
                        int column_counter = 0;
                        //Iterate through columns in the acc. Row
                        foreach (var td in tr.ChildNodes)
                        {
                            //If column_counter: 2 = Packagename; 3 = AIRAC; 4= Version
                            if (column_counter == 1 || column_counter == 2 || column_counter == 3 || column_counter == 4)
                            {
                                //Add Text of cell to temp Packs List
                                Packs.Add(td.InnerText);
                            }
                            column_counter++;
                        }

                    }
                    //All Information of one Pack add to full Packages List
                    //Console.WriteLine(string.Join(", ", Packs));
                    if (string.Join("", Packs) != "")
                    {
                        Packages_list.Add(Packs);
                    }
                    row_counter++;

                }
                return Packages_list;
            }
        }
    }
}