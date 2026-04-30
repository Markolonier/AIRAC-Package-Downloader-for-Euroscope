using AIRAC_Downloader_for_Euroscope.Code.Core;
using AIRAC_Downloader_for_Euroscope.Services;
using Microsoft.Win32;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace AIRAC_Downloader_for_Euroscope
{
    /// <summary>
    /// Interaktionslogik für AeroNavSettings.xaml
    /// </summary>
    public partial class AeroNavSettings : UserControl
    {
        public event EventHandler<ToggleDownloadButtonArgs> ToggleDownload;
        public event Action SaveRequested;

        private List<(string, string)>? availableVaccs;
        private List<(string, string, string, string)>? availablePackages;
        public AeroNavSettings()
        {
            InitializeComponent();
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            initVaccList();
        }

        private void initVaccList()
        {
            WebsiteScraper scraper = new();
            availableVaccs = scraper.GetVaccList();
            foreach (var vACC in availableVaccs)
            {
                VACC.Items.Add(vACC.Item1 + " || " + vACC.Item2);
            }
            VACC.SelectedIndex = 0;
            VACC.IsEnabled = true;
        }
        private void changedVaccSelection(object sender, SelectionChangedEventArgs e)
        {
            WebsiteScraper scraper = new();
            availablePackages = scraper.GetPacksList(availableVaccs[VACC.SelectedIndex].Item1);
            Package.Items.Clear();
            foreach (var package in availablePackages)
            {
                Package.Items.Add(package.Item1);
            }
            Package.SelectedIndex = 0;
        }

        private async void selectNewLocalFolder(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog()
            {
                Multiselect = false,
                Title = "Select local package folder",
            };
            if(dialog.ShowDialog() == true)
            {
                PackageFolder.Text = dialog.FolderName;
                triggerDownloadToggleEvent();
            }
        }

        private async void scanNewOfflinePackage(object? sender, RoutedEventArgs? e)
        {
            int count = 0;
            while(Package.Items.Count == 0 && count <= 2)
            { await Task.Delay(500); count++; }
            if(Package.Items.Count != 0)
            {
                string path = Path.Combine(PackageFolder.Text, availablePackages[Package.SelectedIndex].Item1.Split(" ")[0]);
                (string rev, string Version, string Date) = CurrentInstalledAirac.getCurrentInstalledAIRAC(path);
                OfflineAirac.Text = $"AIRAC: {rev}";
                OfflineVersion.Text = $"Version: {Version}";
                OfflineReleased.Text = $"Released: {Date}";
            }
            else
            {
                OfflineAirac.Text = $"AIRAC: n/a";
                OfflineVersion.Text = $"Version: n/a";
                OfflineReleased.Text = $"Released: n/a";
            }
            
        }

        private async void changedPackageSelection(object sender, SelectionChangedEventArgs e)
        {
            scanNewOfflinePackage(null, null);
            int count = 0;
            while (Package.Items.Count == 0 && count <= 2)
            { await Task.Delay(500); count++; }
            OnlineAirac.Text = $"AIRAC: {availablePackages[Package.SelectedIndex].Item2}";
            OnlineVersion.Text = $"Version: {availablePackages[Package.SelectedIndex].Item3}";
            OnlineReleased.Text = $"Released: {availablePackages[Package.SelectedIndex].Item4}";

            triggerDownloadToggleEvent();
        }

        private void triggerDownloadToggleEvent()
        {
            ToggleDownloadButtonArgs args;

            if (!string.IsNullOrWhiteSpace(Package.Text) &&
                !string.IsNullOrEmpty(PackageFolder.Text))
            {
                args = new ToggleDownloadButtonArgs(
                    enabled: true,
                    packageName: availablePackages[Package.SelectedIndex].Item1
                );

            }
            else
            {
                args = new ToggleDownloadButtonArgs(
                    enabled: false,
                    packageName: string.Empty
                );
            }
            ToggleDownload?.Invoke(this, args);
        }

        private void SaveUserConfig(object sender, RoutedEventArgs e)
        {
            SaveRequested?.Invoke();
        }
    }
}
