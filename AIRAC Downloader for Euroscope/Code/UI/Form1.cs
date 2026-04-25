using AIRAC_Downloader_for_Euroscope.Code.Core;

namespace AIRAC_Downloader_for_Euroscope.Code.UI
{
    public partial class Main_Form : Form
    {
        private WebsiteScraper scraper = new WebsiteScraper();
        private List<(String, String, String, String)>? availablePackages;
        private List<(String, String)>? availableVaccs;

        private static readonly List<string> Facilities =
        [
            "Observer",
            "Flight Service Station",
            "Clearance/Delivery",
            "Ground",
            "Tower",
            "Approach/Departure",
            "Center"
        ];
        private static readonly List<string> Ratings =
        [
            "Observer",
            "Ground/Delivery (STU1)",
            "Tower Controller (STU2)",
            "TMA Controller (STU3)",
            "Enroute Controller (CTR1)",
            "Controller 2(not in use)",
            "Senior controller (CTR3)",
            "Instructor 1", "Instructor 2",
            "Instructor 3",
            "Supervisor",
            "Administrator"
        ];
        private static readonly List<string> SoundTypes =
        [
            "Handoff Request",
            "Handoff Accept",
            "Conflict Alert",
            "Radio Message",
            "Private Message",
            "ATC Message",
            "Broadcast Message",
            "Landline request",
            "Supervisor call",
            "Connected",
            "Disconnected",
            "Ongoing coordination request",
            "Ongoing coordination accepted",
            "Ongoing coordination refused",
            "New ATIS message",
            "Handoff Refused",
            "Pointout",
            "Startup"
        ];
        private static readonly List<string> SoundTypes1 = new List<string>(SoundTypes);
        private static readonly List<string> SoundTypes2 = new List<string>(SoundTypes);
        private static readonly List<string> SoundTypes3 = new List<string>(SoundTypes);



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
            
            // Add lists to static drop down menues
            facility_dd.DataSource = Facilities;
            rating_dd.DataSource = Ratings;
            sound_dd_1.DataSource = SoundTypes1;
            sound_dd_2.DataSource = SoundTypes2;
            sound_dd_3.DataSource = SoundTypes3;

            //Form1.Dataimport.cs
            CheckConfigUpdate();
            ImportData();

        }
    }
}