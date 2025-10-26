using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{
    public static class AiracAutoInstaller
    {
        private static FileSystemWatcher? watcher;

        // Standard-Ordner (Downloads). Kann als Parameter erweitert werden.
        private static string GetDefaultDownloadFolder()
            => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        /// <summary>
        /// Öffnet die Browserseite für das FIR (z. B. "EDMM") und überwacht den Download-Ordner.
        /// Sobald eine passende ZIP erkannt und vollständig heruntergeladen ist, wird sie entpackt
        /// und der callback mit dem entpackten Ordnerpfad aufgerufen.
        /// </summary>
        /// <param name="fir">FIR-Code (z.B. "EDMM")</param>
        /// <param name="targetPath">Zielordner zum entpacken</param>
        /// <param name="onExtracted">Callback, wird mit dem entpackten Ordnerpfad aufgerufen</param>
        /// <param name="downloadFolder">Optional: Pfad zum Download-Ordner (null = Standard)</param>
        public static void StartBrowserAndWatch(string fir, string targetPath, Action<string> onExtracted, string? downloadFolder = null)
        {
            if (string.IsNullOrWhiteSpace(fir)) throw new ArgumentException("fir must be set", nameof(fir));
            if (onExtracted == null) throw new ArgumentNullException(nameof(onExtracted));

            string dlFolder = downloadFolder ?? GetDefaultDownloadFolder();
            string url = $"https://files.aero-nav.com/{fir}";

            // Start browser
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

            // Setup watcher
            watcher = new FileSystemWatcher(dlFolder, "*.zip")
            {
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            };

            // When a file is created, check it (only relevant filenames that contain the FIR)
            watcher.Changed += async (s, e) =>
            {
                try
                {
                    string fileName = Path.GetFileName(e.FullPath);
                    if (!fileName.StartsWith(fir, StringComparison.OrdinalIgnoreCase)) return;

                    // small delay to allow browser to create temp files (.crdownload etc.)
                    await Task.Delay(500);

                    // Wait until file is fully available
                    bool ok = await WaitForFileAvailable(e.FullPath, TimeSpan.FromMinutes(10));
                    if (!ok)
                    {
                        MessageBox.Show($"The file {fileName} could not be opened.", "AIRAC Downloader", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Ensure base folder exists
                    Directory.CreateDirectory(targetPath);

                    // Create a folder per FIR (overwrite behavior handled by ExtractToDirectory)
                    string extractDir = Path.Combine(targetPath, fir);
                    if (Directory.Exists(extractDir)) Directory.Delete(extractDir, true);
                    Directory.CreateDirectory(extractDir);

                    // Extract (overwrite)
                    try
                    {
                        ZipFile.ExtractToDirectory(e.FullPath, extractDir, overwriteFiles: true);
                        File.Delete(e.FullPath);
                    }
                    catch (IOException)
                    {
                        // In rare cases the zip may still be locked; retry once after small wait
                        await Task.Delay(500);
                        ZipFile.ExtractToDirectory(e.FullPath, extractDir, overwriteFiles: true);
                    }

                    // Stop watching (optional — if you want continuous monitoring, remove this)
                    watcher.EnableRaisingEvents = false;

                    // Call the provided callback with the extracted folder path
                    try
                    {
                        onExtracted?.Invoke(extractDir);
                    }
                    catch (Exception exCallback)
                    {
                        // Swallow exceptions from the callback but log them
                        MessageBox.Show($"Error while editing unpacked files: {exCallback.Message}", "AIRAC Downloader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while editing on downloads: {ex.Message}", "AIRAC Downloader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Info für Benutzer
            MessageBox.Show($"Browser opened. Please download the {fir}-ZIP file into {dlFolder}.\n\n" +
                            $"I will unzip the file and edit it automatically.", "AIRAC Downloader");
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
