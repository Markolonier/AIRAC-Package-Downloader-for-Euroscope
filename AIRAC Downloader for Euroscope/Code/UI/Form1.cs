using AIRAC_Downloader_for_Euroscope.Code.Core;

namespace AIRAC_Downloader_for_Euroscope.Code.UI
{
    public partial class Main_Form : Form
    {
        WebsiteScraper scraper = new WebsiteScraper();
        List<(String, String, String, String)>? availablePackages;
        List<(String, String)>? availableVaccs;
        public Main_Form()
        {
            InitializeComponent();
            
        }



        private void Main_Form_Load(object sender, EventArgs e)
        {
            //Get vACCs and add them to the Dropdown
            availableVaccs = scraper.GetVaccList();
            foreach (var vACC in availableVaccs)
            {
                vacc_dd.Items.Add(vACC.Item1 + " || " + vACC.Item2);
            }
            vacc_dd.SelectedIndex = 0;
            vacc_dd.Enabled = true;

            //Form1.Dataimport.cs
            CheckConfigUpdate();
            ImportData();

        }



        public static List<List<string>> all_VACCS = new List<List<string>>();
        public static List<string> datasource = new List<string>();
        public static List<List<string>> Packages_list = new List<List<string>>();
    }
}