using AIRAC_Downloader_for_Euroscope.Code.Core;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace AIRAC_Downloader_for_Euroscope
{
    /// <summary>
    /// Interaktionslogik für AeroNavSettingsControl.xaml
    /// </summary>
    public partial class AeroNavSettingsControl : UserControl
    {

        private List<WebsiteScraper.VaccContent>? availableVaccs;
        public List<WebsiteScraper.PackageContent>? availablePackages { get; private set; }

        public ObservableCollection<string> VaccList { get; set; } = new();
        public ObservableCollection<string> PackageList { get; set; } = new();

        public AeroNavSettingsControl()
        {
            InitializeComponent();
            DataContext = this;
            InitVaccList();
        }


        private void InitVaccList()
        {
            string currentItem = (string)VACC.SelectedValue;
            VaccList.Clear();
            
            WebsiteScraper scraper = new();
            availableVaccs = scraper.GetVaccList();
            foreach (var vACC in availableVaccs)
            {
                VaccList.Add(vACC.ICAO + " || " + vACC.VaccName);
            }

            VACC.IsEnabled = true;
            if(currentItem != null)
            {
                VACC.SelectedValue = currentItem;
            }
            else { VACC.SelectedIndex = 0; }
            changedVaccSelection(null, null);
            VACC.SelectionChanged += changedVaccSelection;
        }


        private void changedVaccSelection(object? sender, SelectionChangedEventArgs? e)
        {
            PackageList.Clear();
            WebsiteScraper scraper = new();
            string currentItem = null;
            if (VACC.SelectedIndex != -1)
            {
                currentItem = (string)Package.SelectedValue;
                availablePackages = scraper.GetPacksList(availableVaccs[VACC.SelectedIndex].ICAO);
            }
            else
            {
                availablePackages = scraper.GetPacksList(availableVaccs[0].ICAO);
            }


            try
            {
                foreach (var package in availablePackages)
                {
                    PackageList.Add(package.PackageName);
                }
            }
            catch { }

            Package.IsEnabled = true;
            if (currentItem != null)
                Package.SelectedValue = currentItem;

            else
            {
                Package.SelectedIndex = 0;
            }
        }


        private async void changedPackageSelection(object sender, SelectionChangedEventArgs e)
        {
            scanNewOfflinePackage(null, null);
            int count = 0;
            while (Package.Items.Count == 0 && count <= 2)
            { await Task.Delay(500); count++; }
            if (Package.SelectedIndex != -1)
            {
                OnlineAirac.Text = $"AIRAC: {availablePackages[Package.SelectedIndex].AIRAC}";
                OnlineVersion.Text = $"Version: {availablePackages[Package.SelectedIndex].Version}";
                OnlineReleased.Text = $"Released: {availablePackages[Package.SelectedIndex].Released}";
            }
            else
            {
                OnlineAirac.Text = $"AIRAC: n/a";
                OnlineVersion.Text = $"Version: n/a";
                OnlineReleased.Text = $"Released: n/a";
            }

            MainWindow.Instance?.ToggleDownloadButton();
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
                MainWindow.Instance?.ToggleDownloadButton();
            }
        }


        private async void scanNewOfflinePackage(object? sender, RoutedEventArgs? e)
        {
            int count = 0;
            while(Package.Items.Count == 0 && count <= 2)
            { await Task.Delay(500); count++; }
            if(Package.Items.Count != 0 && Package.SelectedIndex != -1)
            {
                string path = Path.Combine(PackageFolder.Text, availablePackages[Package.SelectedIndex].ICAO);
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

        
        private void SaveUserConfig(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance?.OnSaveRequested();
        }
    }
}
