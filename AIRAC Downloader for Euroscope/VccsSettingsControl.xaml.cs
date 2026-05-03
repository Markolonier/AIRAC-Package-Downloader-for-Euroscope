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
    }
}
