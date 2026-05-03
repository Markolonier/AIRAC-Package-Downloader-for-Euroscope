using AIRAC_Downloader_for_Euroscope.Code.Core;
using AIRAC_Downloader_for_Euroscope.Services;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace AIRAC_Downloader_for_Euroscope
{
    /// <summary>
    /// Interaktionslogik für AeroNavSettingsControl.xaml
    /// </summary>
    public partial class AeroNavSettingsControl : UserControl
    {
        public event EventHandler<ToggleDownloadButtonArgs> ToggleDownload;
        public event Action SaveRequested;

        private List<(string, string)>? availableVaccs;
        private List<(string, string, string, string)>? availablePackages;

        public ObservableCollection<string> VaccList { get; set; } = new();
        public ObservableCollection<string> PackageList { get; set; } = new();

        public AeroNavSettingsControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            initVaccList();
        }


        private void initVaccList()
        {
            string currentItem = (string)VACC.SelectedValue;
            VaccList.Clear();
            
            WebsiteScraper scraper = new();
            availableVaccs = scraper.GetVaccList();
            foreach (var vACC in availableVaccs)
            {
                VaccList.Add(vACC.Item1 + " || " + vACC.Item2);
            }

            VACC.IsEnabled = true;
            if(currentItem != null)
            {
                VACC.SelectedValue = currentItem;
            }
            else { VACC.SelectedIndex = 0; }
            
        }


        private void changedVaccSelection(object sender, SelectionChangedEventArgs e)
        {
            if(VACC.SelectedIndex != -1)
            {
                string currentItem = (string)Package.SelectedValue;
                PackageList.Clear();

                WebsiteScraper scraper = new();
                availablePackages = scraper.GetPacksList(availableVaccs[VACC.SelectedIndex].Item1);
                try
                {
                    foreach (var package in availablePackages)
                    {
                        PackageList.Add(package.Item1);
                    }
                }
                catch { }

                Package.IsEnabled = true;
                if(currentItem != null)
                {
                    Package.SelectedValue = currentItem;
                }
                else { Package.SelectedIndex = 0; }
            }
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
            if(Package.Items.Count != 0 && Package.SelectedIndex != -1)
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
            if(Package.SelectedIndex != -1)
            {
                OnlineAirac.Text = $"AIRAC: {availablePackages[Package.SelectedIndex].Item2}";
                OnlineVersion.Text = $"Version: {availablePackages[Package.SelectedIndex].Item3}";
                OnlineReleased.Text = $"Released: {availablePackages[Package.SelectedIndex].Item4}";
            }
            else
            {
                OnlineAirac.Text = $"AIRAC: n/a";
                OnlineVersion.Text = $"Version: n/a";
                OnlineReleased.Text = $"Released: n/a";
            }

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
