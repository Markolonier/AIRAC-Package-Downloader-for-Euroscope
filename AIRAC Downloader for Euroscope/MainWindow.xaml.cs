using AIRAC_Downloader_for_Euroscope.Code.Core;
using AIRAC_Downloader_for_Euroscope.Services;
using MaterialDesignColors.Recommended;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Input;

namespace AIRAC_Downloader_for_Euroscope
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AeroNavSettings.ToggleDownload += ToggleDownloadButton;
            AeroNavSettings.SaveRequested += OnSaveRequested;
            OnNewConfigImport();
        }

        private void ToggleDownloadButton(object sender, ToggleDownloadButtonArgs e)
        {
            this.Download.IsEnabled = e.Enabled;
            if (e.Enabled)
                this.DownloadButtonText.Text = $"Download {e.PackageName} now";
            else
                this.DownloadButtonText.Text = "Download not possible. Select Folder and Package in AeroNav first";
        }

        private void OnSaveRequested()
        {
            //TBD
        }

        private void OnNewConfigImport()
        {
            ConfigControl.Config newConfig = ConfigControl.ImportControl();
            
            if(newConfig != null)
            {
                //Euroscope Setup
                EuroscopeSettigs.CheckCallsign.IsChecked = newConfig.thisES.Callsign != null ? true : false;
                EuroscopeSettigs.Callsign.Text = newConfig.thisES.Callsign != null ? newConfig.thisES.Callsign : string.Empty;

                EuroscopeSettigs.CheckRealName.IsChecked = newConfig.thisES.Realname != null ? true : false;
                EuroscopeSettigs.Realname.Text = newConfig.thisES.Realname != null ? newConfig.thisES.Realname : string.Empty;
                
                EuroscopeSettigs.CheckCertificate.IsChecked = newConfig.thisES.Certificate != null ? true : false;
                EuroscopeSettigs.Certificate.Text = newConfig.thisES.Certificate != null ? newConfig.thisES.Certificate : string.Empty;
                
                EuroscopeSettigs.CheckPassword.IsChecked = newConfig.thisES.Password != null ? true : false;
                EuroscopeSettigs.Password.Password = newConfig.thisES.Password != null ? newConfig.thisES.Password : string.Empty;
                
                EuroscopeSettigs.CheckFacility.IsChecked = newConfig.thisES.Facility != null ? true : false;
                EuroscopeSettigs.Facility.SelectedValue = newConfig.thisES.Facility != null ? newConfig.thisES.Facility : string.Empty;
                
                EuroscopeSettigs.CheckRating.IsChecked = newConfig.thisES.Rating != null ? true : false;
                EuroscopeSettigs.Rating.SelectedValue = newConfig.thisES.Rating != null ? newConfig.thisES.Rating : string.Empty;
                
                EuroscopeSettigs.CheckHoppie.IsChecked = newConfig.thisES.Hoppie != null ? true : false;
                EuroscopeSettigs.Hoppie.Password = newConfig.thisES.Hoppie != null ? newConfig.thisES.Hoppie : string.Empty;

                foreach ((string Sound, int Soundtype) Sound in newConfig.thisES.Sounds)
                {
                    string name = EuroscopeSettings.SoundTypes[Sound.Item2];

                    EuroscopeSettigs.Sounds.Add(new EuroscopeSettings.SoundEntry
                    {
                        IsSelected = false,
                        IsEnabled = true,
                        SoundFile = Sound.Item1,
                        SoundType = name
                    });
                }

                foreach (string plugin in newConfig.thisES.Plugins)
                {
                    EuroscopeSettigs.Plugins.Add(new EuroscopeSettings.PluginEntry
                    {
                        IsSelected = false,
                        IsEnabled = true,
                        PluginPath = plugin,
                    });
                }


                //VCCS Setup
                VccsSettings.CheckNickname.IsChecked = newConfig.thisVCCS.Nickname != null ? true : false;
                VccsSettings.Nickname.Text = newConfig.thisVCCS.Nickname != null ? newConfig.thisVCCS.Nickname : string.Empty;
                
                VccsSettings.CheckG2A.IsChecked = newConfig.thisVCCS.G2Aptt != 0 ? true : false;
                //tbd...

                VccsSettings.CheckG2G.IsChecked = newConfig.thisVCCS.G2Gptt != 0 ? true : false;
                //tbd...

                VccsSettings.CheckCaptureMode.IsChecked = newConfig.thisVCCS.CaptureMode != null ? true : false;
                VccsSettings.CaptureMode.SelectedValue = newConfig.thisVCCS.CaptureMode != null ? newConfig.thisVCCS.CaptureMode : string.Empty;
                
                VccsSettings.CheckCaptureDevice.IsChecked = newConfig.thisVCCS.CaptureDevice != null ? true : false;
                VccsSettings.CaptureDevice.SelectedValue = newConfig.thisVCCS.CaptureDevice != null ? newConfig.thisVCCS.CaptureDevice : string.Empty;
                
                VccsSettings.CheckPlaybackMode.IsChecked = newConfig.thisVCCS.PlaybackMode != null ? true : false;
                VccsSettings.PlaybackMode.SelectedValue = newConfig.thisVCCS.PlaybackMode != null ? newConfig.thisVCCS.PlaybackMode : string.Empty;
                
                VccsSettings.CheckPlaybackDevice.IsChecked = newConfig.thisVCCS.PlaybackDevice != null ? true : false;
                VccsSettings.PlaybackDevice.SelectedValue = newConfig.thisVCCS.PlaybackDevice != null ? newConfig.thisVCCS.PlaybackDevice : string.Empty;


                //AeroNav Setup
                AeroNavSettings.VACC.SelectedValue = newConfig.thisAN.VACC != null ? newConfig.thisAN.VACC : string.Empty;
                AeroNavSettings.Package.SelectedValue = newConfig.thisAN.Package != null ? newConfig.thisAN.Package : string.Empty;
                AeroNavSettings.PackageFolder.Text = newConfig.thisAN.Folder != null ? newConfig.thisAN.Folder : string.Empty;
            }
        }

        // dragging the window
        private bool RestoreIfMoved;
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                return;
            }
            else if (WindowState == WindowState.Maximized)
            {
                RestoreIfMoved = true;
                return;
            }

            DragMove();
        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RestoreIfMoved = false;
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (RestoreIfMoved)
            {
                RestoreIfMoved = false;

                double percentHorizontal = e.GetPosition(this).X / ActualWidth;
                double targetHorizontal = RestoreBounds.Width * percentHorizontal;

                double percentVertical = e.GetPosition(this).Y / ActualHeight;
                double targetVertical = RestoreBounds.Height * percentVertical;

                WindowState = WindowState.Normal;

                POINT lMousePosition;
                GetCursorPos(out lMousePosition);

                Left = lMousePosition.X - targetHorizontal;
                Top = lMousePosition.Y - targetVertical;

                DragMove();
            }
        }

        // helper method to get the cursor position
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT(int x, int y)
        {
            public int X = x;
            public int Y = y;
        }


        // minimizing and closing the window
        private void Window_StateChanged(object sender, EventArgs e)
        {
            MaximizeOrUnMaximizeWindowButtonIcon.Kind = WindowState != WindowState.Maximized ? PackIconKind.Maximize : PackIconKind.WindowRestore;
        }
        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void MaximizeOrUnMaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}