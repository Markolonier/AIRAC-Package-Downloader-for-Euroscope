using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AIRAC_Downloader_for_Euroscope
{
    /// <summary>
    /// Interaktionslogik für EuroscopeSettingsControl.xaml
    /// </summary>
    public partial class EuroscopeSettingsControl : UserControl
    {

        //Custom Sounds
        public static List<string> SoundTypes { get; } = new()
        {
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
        };
        public class SoundEntry
        {
            public bool IsSelected { get; set; }
            public bool IsEnabled { get; set; }
            public string SoundFile { get; set; }
            public string SoundType { get; set; }
        }

        public ObservableCollection<SoundEntry> Sounds { get; set; } = new();

        //Custom Plugins
        public class PluginEntry
        {
            public bool IsSelected { get; set; }
            public bool IsEnabled { get; set; }
            public string PluginPath { get; set; }
        }

        public ObservableCollection<PluginEntry> Plugins { get; set; } = new();

        public ObservableCollection<string> Facilities { get; set; } = new()
        {
            "Observer",
            "Flight Service Station",
            "Clearance/Delivery",
            "Ground",
            "Tower",
            "Approach/Departure",
            "Center",
            ""
        };

        public ObservableCollection<string> Ratings { get; set; } = new()
        {
            "Observer",
            "Ground/Delivery (STU1)",
            "Tower Controller (STU2)",
            "TMA Controller (STU3)",
            "Enroute Controller (CTR1)",
            "Controller 2(not in use)",
            "Senior controller (CTR3)",
            "Instructor 1",
            "Instructor 2",
            "Instructor 3",
            "Supervisor",
            "Administrator",
            ""
        };

        public EuroscopeSettingsControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }

    
}
