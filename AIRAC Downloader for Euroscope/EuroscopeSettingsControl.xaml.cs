using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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


        /// <summary>
        /// Checks if all checkboxes in the provided collection are checked, unchecked, or a mix of both.
        /// </summary>
        /// <param name="checkboxes">The collection of checkboxes to check.</param>
        /// <returns>True if all are checked, false if all are unchecked, null if a mix.</returns>
        private bool? IsAllChecked(IEnumerable<FrameworkElement> checkboxes)
        {
            int checkedCount = 0;
            int checkBoxesCount = 0;

            foreach (var chk in checkboxes)
            {
                var chkCast = chk as CheckBox;
                if (chkCast != null && chkCast.IsChecked == true)
                {
                    checkedCount++;
                }
                if (chkCast != null)
                {
                    checkBoxesCount++;
                }
            }

            if (checkedCount == 0)
            {
                return false;
            }
            else if (checkedCount == checkBoxesCount)
            {
                return true;
            }
            else
            {
                return null;
            }
        }


        // -------------------------------
        // The following methods are for the checkboxes that enable/disable the corresponding TextBoxes in the Main Grid.
        // They also call ChangedOne_Checked to update the state of the "Enable All" checkbox.
        // -------------------------------

        // This method lists all the checkboxes in the MainGrid and updates the "Enable All" checkbox based on their states.
        private void ChangedOne_Checked()
        {
            //The named Grid, and not TabControl
            var children = LogicalTreeHelper.GetChildren(MainGrid).OfType<FrameworkElement>().Where(e => e.Name != "CheckEnableAll");
            CheckEnableAll.IsChecked = IsAllChecked(children);

        }
        
        private void CheckCallsign_Toggled(object sender, RoutedEventArgs e)
        {
            Callsign.IsEnabled = CheckCallsign.IsChecked == true;
            ChangedOne_Checked();
        }
        private void CheckRealName_Toggled(object sender, RoutedEventArgs e)
        {
            RealName.IsEnabled = CheckRealName.IsChecked == true;
            ChangedOne_Checked();
        }

        private void CheckCertificate_Toggled(object sender, RoutedEventArgs e)
        {
            Certificate.IsEnabled = CheckCertificate.IsChecked == true;
            ChangedOne_Checked();
        }

        private void CheckPassword_Toggled(object sender, RoutedEventArgs e)
        {
            Password.IsEnabled = CheckPassword.IsChecked == true;
            ChangedOne_Checked();
        }

        private void CheckFacility_Toggled(object sender, RoutedEventArgs e)
        {
            Facility.IsEnabled = CheckFacility.IsChecked == true;
            ChangedOne_Checked();
        }

        private void CheckRating_Toggled(object sender, RoutedEventArgs e)
        {
            Rating.IsEnabled = CheckRating.IsChecked == true;
            ChangedOne_Checked();
        }

        private void CheckHoppie_Toggled(object sender, RoutedEventArgs e)
        {
            Hoppie.IsEnabled = CheckHoppie.IsChecked == true;
            ChangedOne_Checked();
        }

        //Enables or disables all TextBoxes based on the state of the "Enable All" checkbox.
        private void CheckEnableAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckCallsign.IsChecked = CheckRealName.IsChecked = CheckCertificate.IsChecked = CheckPassword.IsChecked = CheckFacility.IsChecked = CheckRating.IsChecked = CheckHoppie.IsChecked = CheckEnableAll.IsChecked == true;
        }
    }
}