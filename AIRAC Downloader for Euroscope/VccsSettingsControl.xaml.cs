using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.Asio;
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
    }
}
