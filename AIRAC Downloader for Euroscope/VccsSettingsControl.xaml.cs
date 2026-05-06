using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.Asio;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace AIRAC_Downloader_for_Euroscope
{
    /// <summary>
    /// Interaktionslogik für VccsSettingsControl.xaml
    /// </summary>
    public partial class VccsSettingsControl : UserControl
    {

        public ObservableCollection<string> InputAudioDevices { get; set; } = new();
        public ObservableCollection<string> InputAudioAPIs { get; set; } = new()
        {
            "Direct Sound",
            "Windows Audio Session"
        };
        public ObservableCollection<string> OutputAudioDevices { get; set; } = new();
        public ObservableCollection<string> OutputAudioAPIs { get; set; } = new()
        {
            "Direct Sound",
            "Windows Audio Session"
        };

        public KeyboardListener.KeyResult? G2aPttKey { get; set; } = null;
        public KeyboardListener.KeyResult? G2gPttKey { get; set; } = null;

        public VccsSettingsControl()
        {
            InitializeComponent();
            DataContext = this;

            var enumerator = new MMDeviceEnumerator();

            //Parse and add Input Devices
            var inputDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            foreach (var dev in inputDevices)
            {
                this.InputAudioDevices.Add(dev.FriendlyName);
            }

            //Parse and add Output Devices
            var outputDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            foreach (var dev in outputDevices)
            {
                this.OutputAudioDevices.Add(dev.FriendlyName);
            }
        }

        private async void G2A_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            G2A.Content = "Press a key for G2A PTT...";
            KeyboardListener.KeyResult? newKey = await KeyboardListener.Instance.ListenAsync(this);
            if (newKey != null)
                G2aPttKey = newKey;

            if(G2aPttKey != null)
                G2A.Content = $"G2A PTT: {G2aPttKey.Value.Name}";
            else
                G2A.Content = "G2A PTT: Not set";
        }

        private async void G2G_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            G2G.Content = "Press a key for G2G PTT...";
            KeyboardListener.KeyResult? newKey = await KeyboardListener.Instance.ListenAsync(this);
            if (newKey != null)
                G2gPttKey = newKey;

            if (G2gPttKey != null)
                G2G.Content = $"G2G PTT: {G2gPttKey.Value.Name}";
            else
                G2G.Content = "G2G PTT: Not set";
        }

        private void G2Adelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            G2aPttKey = null;
            G2A.Content = "G2A PTT: Not set";
        }

        private void G2Gdelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            G2gPttKey = null;
            G2G.Content = "G2G PTT: Not set";
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

        private void CheckNickname_Toggled(object sender, RoutedEventArgs e)
        {
            Nickname.IsEnabled = CheckNickname.IsChecked == true;
            ChangedOne_Checked();
        }
        private void CheckG2A_Toggled(object sender, RoutedEventArgs e)
        {
            G2A.IsEnabled = G2Adelete.IsEnabled = CheckG2A.IsChecked == true;
            ChangedOne_Checked();
        }

        private void CheckG2G_Toggled(object sender, RoutedEventArgs e)
        {
            G2G.IsEnabled = G2Gdelete.IsEnabled = CheckG2G.IsChecked == true;
            ChangedOne_Checked();
        }

        private void CheckCaptureMode_Toggled(object sender, RoutedEventArgs e)
        {
            CaptureMode.IsEnabled = CheckCaptureMode.IsChecked == true;
            ChangedOne_Checked();
        }

        private void CheckCaptureDevice_Toggled(object sender, RoutedEventArgs e)
        {
            CaptureDevice.IsEnabled = CheckCaptureDevice.IsChecked == true;
            ChangedOne_Checked();
        }

        private void CheckPlaybackMode_Toggled(object sender, RoutedEventArgs e)
        {
            PlaybackMode.IsEnabled = CheckPlaybackMode.IsChecked == true;
            ChangedOne_Checked();
        }

        private void CheckPlaybackDevice_Toggled(object sender, RoutedEventArgs e)
        {
            PlaybackDevice.IsEnabled = CheckPlaybackDevice.IsChecked == true;
            ChangedOne_Checked();
        }

        //Enables or disables all TextBoxes based on the state of the "Enable All" checkbox.
        private void CheckEnableAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckNickname.IsChecked = CheckG2A.IsChecked = CheckG2G.IsChecked = CheckCaptureMode.IsChecked = CheckCaptureDevice.IsChecked = CheckPlaybackMode.IsChecked = CheckPlaybackDevice.IsChecked = CheckEnableAll.IsChecked == true;
        }
    }
}
