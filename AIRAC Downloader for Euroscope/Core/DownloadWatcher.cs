using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Security.Policy;
using System.Text;
using System.Windows;

namespace AIRAC_Downloader_for_Euroscope.Core
{
    internal class DownloadWatcher
    {
        private TaskCompletionSource<bool> _watcher = new();
        private FileSystemWatcher? watcher;

        private readonly string BaseUrl = "https://files.aero-nav.com/";

        private readonly string ICAO;
        private readonly string DownloadFolder;
        private readonly string TargetFolder;
        public string ExtractedDir { get; private set; }

        public DownloadWatcher(string ICAO, string targetFolder, string? DownloadFolder, string? BaseUrl)
        {
            this.ICAO = ICAO;
            this.TargetFolder = targetFolder;
            
            if (DownloadFolder != null) this.DownloadFolder = DownloadFolder;
            else this.DownloadFolder = GetDefaultDownloadFolder();

            if(BaseUrl != null) this.BaseUrl = BaseUrl;
        }
        

        private static string GetDefaultDownloadFolder() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        public void OpenBrowser()
        {
            string url = BaseUrl + ICAO;
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        public Task StartWatcher()
        {
            watcher = new FileSystemWatcher(this.DownloadFolder, "*.zip")
            {
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            };

            watcher.Changed += async (s, e) =>
            {
                try
                {
                    string fileName = Path.GetFileName(e.FullPath);
                    if (!fileName.StartsWith(ICAO, StringComparison.OrdinalIgnoreCase)) return;

                    // small delay to allow browser to create temp files (.crdownload etc.)
                    await Task.Delay(500);

                    // Wait until file is fully available
                    bool ok = await WaitForFileAvailable(e.FullPath, TimeSpan.FromMinutes(10));
                    if (!ok)
                    {
                        throw new Exception($"The file {fileName} could not be opened.");
                    }

                    // Ensure base folder exists
                    Directory.CreateDirectory(TargetFolder);

                    // Create a folder per FIR (overwrite behavior handled by ExtractToDirectory)
                    this.ExtractedDir = Path.Combine(TargetFolder, ICAO);
                    if (Directory.Exists(this.ExtractedDir)) Directory.Delete(this.ExtractedDir, true);
                    Directory.CreateDirectory(this.ExtractedDir);

                    // Extract (overwrite)
                    try
                    {
                        ZipFile.ExtractToDirectory(e.FullPath, this.ExtractedDir, overwriteFiles: true);
                        File.Delete(e.FullPath);
                    }
                    catch (IOException)
                    {
                        // In rare cases the zip may still be locked; retry once after small wait
                        await Task.Delay(500);
                        ZipFile.ExtractToDirectory(e.FullPath, this.ExtractedDir, overwriteFiles: true);
                    }

                    // Stop watching
                    watcher.EnableRaisingEvents = false;
                }
                catch (Exception ex)
                {
                    _watcher.TrySetException(ex);
                }

            };

            return _watcher.Task;
        }



        private static async Task<bool> WaitForFileAvailable(string path, TimeSpan timeout)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            while (sw.Elapsed < timeout)
            {
                try
                {
                    if (!File.Exists(path))
                    {
                        await Task.Delay(500);
                        continue;
                    }

                    // If file has temporary extension used by browser - wait
                    string ext = Path.GetExtension(path);
                    if (ext.Equals(".crdownload", StringComparison.OrdinalIgnoreCase) ||
                        ext.Equals(".part", StringComparison.OrdinalIgnoreCase) ||
                        ext.Equals(".tmp", StringComparison.OrdinalIgnoreCase))
                    {
                        await Task.Delay(1000);
                        continue;
                    }

                    // Try open exclusively
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        if (fs.Length > 0) return true;
                    }
                }
                catch
                {
                    // locked -> wait
                    await Task.Delay(1000);
                }
            }
            return false;
        }
    }
}
