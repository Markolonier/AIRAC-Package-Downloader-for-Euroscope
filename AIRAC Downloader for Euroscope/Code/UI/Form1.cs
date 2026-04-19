using AIRAC_Downloader.Code.Core;
using AIRAC_Downloader_for_Euroscope.Code.Core;

namespace AIRAC_Downloader_for_Euroscope.Code.UI
{
    public partial class Main_Form : Form
    {
        WebsiteScraper scraper = new WebsiteScraper();

        public Main_Form()
        {
            InitializeComponent();
        }



        private void Main_Form_Load(object sender, EventArgs e)
        {
            Datahandling Datahandler = new(this);
            Datahandler.Import_Data();

            var vACCs = scraper.GetVaccList();

            foreach (var vACC in vACCs)
            {
                vacc_dd.Items.Add(vACC.Item1 + " || " + vACC.Item2);
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
    }
}