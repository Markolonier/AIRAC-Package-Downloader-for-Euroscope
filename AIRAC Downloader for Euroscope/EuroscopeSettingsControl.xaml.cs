using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public class SoundEntry : INotifyPropertyChanged
        {
            private bool _isSelected;
            public bool IsSelected
            {
                get => _isSelected;
                set
                {
                    if (_isSelected != value)
                    {
                        _isSelected = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
                    }
                }
            }

            private bool _isEnabled;
            public bool IsEnabled
            {
                get => _isEnabled;
                set
                {
                    if (_isEnabled != value)
                    {
                        _isEnabled = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnabled)));
                    }
                }
            }


            public string SoundFile { get; set; }
            public string SoundType { get; set; }


            public event PropertyChangedEventHandler PropertyChanged;
        }

        public ObservableCollection<SoundEntry> Sounds { get; set; } = new();

        //Custom Plugins
        public class PluginEntry : INotifyPropertyChanged
        {
            private bool _isSelected;
            public bool IsSelected
            {
                get => _isSelected;
                set
                {
                    if (_isSelected != value)
                    {
                        _isSelected = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
                    }
                }
            }


            private bool _isEnabled;
            public bool IsEnabled
            {
                get => _isEnabled;
                set
                {
                    if (_isEnabled != value)
                    {
                        _isEnabled = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnabled)));
                    }
                }
            }


            public string PluginPath { get; set; }


            public event PropertyChangedEventHandler PropertyChanged;
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




        // -------------------------------
        // Soundslist
        // -------------------------------

        // -------------
        // Select Column
        // -------------
        // Update Select All Header if Datagrid checkbox changes
        private void Sound_UpdateSelectAllHeader()
        {
            int IsSelectedCount = 0;
            foreach (SoundEntry sound in Sounds)
            {
                if (sound.IsSelected)
                {
                    IsSelectedCount++;
                }
            }
            if (IsSelectedCount == 0)
            {
                CheckSelectAllSounds.IsChecked = false;
            }
            else if (IsSelectedCount == Sounds.Count)
            {
                CheckSelectAllSounds.IsChecked = true;
            }
            else
            {
                CheckSelectAllSounds.IsChecked = null;
            }
        }

        // If Datagrid Checkbox changes update corresponding SoundEntry and call Header Updater
        private void SoundsList_CurrentCellIsSelectedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null)
                return;

            var entry = cb.DataContext as SoundEntry;
            if (entry == null)
                return;

            // neuen Wert direkt übernehmen
            entry.IsSelected = cb.IsChecked == true;

            // jetzt Header aktualisieren
            Sound_UpdateSelectAllHeader();
        }

        //Update Cell Checkboxes when Header Checkbox clicked
        private void CheckSelectAllSounds_Toggled(object sender, RoutedEventArgs e)
        {
            if (DataContext is not EuroscopeSettingsControl vm)
                return;

            bool newValue = ((CheckBox)sender).IsChecked == true;

            foreach (var sound in vm.Sounds)
                sound.IsSelected = newValue;
        }


        // -------------
        // Enable Column
        // -------------

        private void Sound_UpdateEnableAllHeader()
        {
            int IsEnabledCount = 0;
            foreach (SoundEntry sound in Sounds)
            {
                if (sound.IsEnabled)
                {
                    IsEnabledCount++;
                }
            }
            if (IsEnabledCount == 0)
            {
                CheckEnableAllSounds.IsChecked = false;
            }
            else if (IsEnabledCount == Sounds.Count)
            {
                CheckEnableAllSounds.IsChecked = true;
            }
            else
            {
                CheckEnableAllSounds.IsChecked = null;
            }
        }

        // If Datagrid Checkbox changes update corresponding SoundEntry and call Header Updater
        private void SoundsList_CurrentCellIsEnabledChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null)
                return;

            var entry = cb.DataContext as SoundEntry;
            if (entry == null)
                return;

            // neuen Wert direkt übernehmen
            entry.IsEnabled = cb.IsChecked == true;

            // jetzt Header aktualisieren
            Sound_UpdateEnableAllHeader();
        }

        //Update Cell Checkboxes when Header Checkbox clicked
        private void CheckEnableAllSounds_Toggled(object sender, RoutedEventArgs e)
        {
            if (DataContext is not EuroscopeSettingsControl vm)
                return;

            bool newValue = ((CheckBox)sender).IsChecked == true;

            foreach (var sound in vm.Sounds)
                sound.IsEnabled = newValue;
        }

        private void Click_RemoveSoundRow(object sender, RoutedEventArgs e)
        {
            var toRemove = Sounds.Where(s => s.IsSelected).ToList();
            foreach(var sound in toRemove)
                Sounds.Remove(sound);

            Sound_UpdateEnableAllHeader();
            Sound_UpdateSelectAllHeader();
        }






        // -------------------------------
        // Pluginslist
        // -------------------------------

        // -------------
        // Select Column
        // -------------
        // Update Select All Header if Datagrid checkbox changes
        private void Plugin_UpdateSelectAllHeader()
        {
            int IsSelectedCount = 0;
            foreach (PluginEntry Plugin in Plugins)
            {
                if (Plugin.IsSelected)
                {
                    IsSelectedCount++;
                }
            }
            if (IsSelectedCount == 0)
            {
                CheckSelectAllPlugins.IsChecked = false;
            }
            else if (IsSelectedCount == Plugins.Count)
            {
                CheckSelectAllPlugins.IsChecked = true;
            }
            else
            {
                CheckSelectAllPlugins.IsChecked = null;
            }
        }

        // If Datagrid Checkbox changes update corresponding PluginEntry and call Header Updater
        private void PluginsList_CurrentCellIsSelectedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null)
                return;

            var entry = cb.DataContext as PluginEntry;
            if (entry == null)
                return;

            // neuen Wert direkt übernehmen
            entry.IsSelected = cb.IsChecked == true;

            // jetzt Header aktualisieren
            Plugin_UpdateSelectAllHeader();
        }

        //Update Cell Checkboxes when Header Checkbox clicked
        private void CheckSelectAllPlugins_Toggled(object sender, RoutedEventArgs e)
        {
            if (DataContext is not EuroscopeSettingsControl vm)
                return;

            bool newValue = ((CheckBox)sender).IsChecked == true;

            foreach (var Plugin in vm.Plugins)
                Plugin.IsSelected = newValue;
        }


        // -------------
        // Enable Column
        // -------------

        private void Plugin_UpdateEnableAllHeader()
        {
            int IsEnabledCount = 0;
            foreach (PluginEntry Plugin in Plugins)
            {
                if (Plugin.IsEnabled)
                {
                    IsEnabledCount++;
                }
            }
            if (IsEnabledCount == 0)
            {
                CheckEnableAllPlugins.IsChecked = false;
            }
            else if (IsEnabledCount == Plugins.Count)
            {
                CheckEnableAllPlugins.IsChecked = true;
            }
            else
            {
                CheckEnableAllPlugins.IsChecked = null;
            }
        }

        // If Datagrid Checkbox changes update corresponding PluginEntry and call Header Updater
        private void PluginsList_CurrentCellIsEnabledChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null)
                return;

            var entry = cb.DataContext as PluginEntry;
            if (entry == null)
                return;

            // neuen Wert direkt übernehmen
            entry.IsEnabled = cb.IsChecked == true;

            // jetzt Header aktualisieren
            Plugin_UpdateEnableAllHeader();
        }

        //Update Cell Checkboxes when Header Checkbox clicked
        private void CheckEnableAllPlugins_Toggled(object sender, RoutedEventArgs e)
        {
            if (DataContext is not EuroscopeSettingsControl vm)
                return;

            bool newValue = ((CheckBox)sender).IsChecked == true;

            foreach (var Plugin in vm.Plugins)
                Plugin.IsEnabled = newValue;
        }

        private void Click_RemovePluginRow(object sender, RoutedEventArgs e)
        {
            var toRemove = Plugins.Where(s => s.IsSelected).ToList();
            foreach (var Plugin in toRemove)
                Plugins.Remove(Plugin);

            Plugin_UpdateEnableAllHeader();
            Plugin_UpdateSelectAllHeader();
        }
    }
}