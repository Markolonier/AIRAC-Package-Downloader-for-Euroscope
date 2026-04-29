using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{
    internal class GithubUpdater
    {
        private static readonly string RepoUrl = "https://api.github.com/repos/Markolonier/AIRAC-Package-Downloader-for-Euroscope/releases/latest";

        private GithubRelease CurrentRelease = null;

        private class GithubRelease()
        {
            public string tag_name { get; set; }
            public List<Asset> assets { get; set; }

            public class Asset
            {
                public string browser_download_url { get; set; }
            }
            public string body { get; set; }
        }

        public async Task<string> CheckUpdates()
        {
            // Create and prepare client
            using var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("AppUpdater");

            // Download json from Github API
            var json = await client.GetStringAsync(RepoUrl);
            
            // Create GithubRelease data
            CurrentRelease = JsonSerializer.Deserialize<GithubRelease>(json);
            Debug.WriteLine(JsonSerializer.Serialize<GithubRelease>(CurrentRelease));

            // Return true if update is available
            return CurrentRelease.tag_name;
        }

        public async void DownloadUpdate()
        {
            if (CurrentRelease?.assets == null || CurrentRelease.assets.Count == 0) await CheckUpdates();
            // variables
            var asset = CurrentRelease.assets.FirstOrDefault(a => a.browser_download_url.EndsWith(".exe"));
            if (asset == null) asset = CurrentRelease.assets.FirstOrDefault(a => a.browser_download_url.EndsWith(".zip"));
            string DownloadUrl = asset.browser_download_url;
            string DownloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string zipPath = Path.Combine(DownloadsFolder, DownloadUrl.Split('/').Last());
            

            // Download data
            using var client = new HttpClient();
            var data = await client.GetByteArrayAsync(asset.browser_download_url);
            await File.WriteAllBytesAsync(zipPath, data);

            string appDir = AppContext.BaseDirectory;
            string extractDir = Path.Combine(DownloadsFolder, "_temp AIRAC Download updater");
            string procName = Process.GetCurrentProcess().ProcessName;


            // Powershell Delete existing installation -> Extract zip file (if existing) -> Copy File(s) -> Delete temporary Download Files -> Start exe again
            string psCommand =
                "$ErrorActionPreference = 'Continue'; " +
                $"$file = '{zipPath}'; " +
                $"$dest = '{extractDir}'; " +
                $"$app = '{appDir}'; " +
                $"$procName = '{procName}'; " +
                "$exe = Join-Path $app 'AIRAC Downloader for Euroscope.exe'; " +
                "while (Get-Process -Name '$procName' -ErrorAction SilentlyContinue) { Start-Sleep -Milliseconds 200 }; " +

            // CONFIGS SICHERN
            "$config1 = Get-ChildItem -Path $app -Filter '*.config' -File -ErrorAction SilentlyContinue; " +
                "$config2 = Get-ChildItem -Path $app -Filter 'AIRAC Downloader Configuration.json' -File -ErrorAction SilentlyContinue; " +
                "$backup = @(); if ($config1) { $backup += $config1 }; if ($config2) { $backup += $config2 }; " +
                "$backupPaths = $backup.FullName; " +

                // APP ORDNER LEEREN OHNE CONFIGS
                "Get-ChildItem -Path $app | Where-Object { $backupPaths -notcontains $_.FullName } | Remove-Item -Recurse -Force; " +

                // FALL 3: DIREKTE EXE
                "if ($file.ToLower().EndsWith('.exe')) { " +

                    // EXE unter ihrem echten Namen kopieren
                    "$targetExe = Join-Path $app (Split-Path $file -Leaf); " +
                    "Copy-Item -Path $file -Destination $targetExe -Force; " +

                "} " +

                // FALL 1 & 2: ZIP ENTAPCKEN
                "else {" +
                    "if (Test-Path $dest) { Remove-Item $dest -Recurse -Force }; " +
                    "Expand-Archive -Path $file -DestinationPath $dest -Force; " +

                    // UNTERORDNER ERKENNEN
                    "$sub = Get-ChildItem -Path $dest -Directory | Select-Object -First 1; " +
                    "if ($sub) { $source = $sub.FullName } else { $source = $dest }; " +

                    // DATEIEN KOPIEREN
                    "Copy-Item -Path ($source + '\\*') -Destination $app -Recurse -Force; " +
                "}" +

                // CONFIGS WIEDERHERSTELLEN
                "foreach ($c in $backup) { Copy-Item -Path $c.FullName -Destination $app -Force }; " +

                // ZIP + TEMP LÖSCHEN (mit Fehler-Ignore)
                "Start-Sleep -Milliseconds 300; " +
                "try { Remove-Item $file -Force -ErrorAction Stop } catch {}; " +
                "try { Remove-Item $dest -Recurse -Force -ErrorAction Stop } catch {}; " +

                // APP STARTEN
                "Start-Process $exe; ";





            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C powershell -NoProfile -ExecutionPolicy Bypass -Command \"{psCommand}\"",
                CreateNoWindow = false,
                UseShellExecute = true,
            });

            Environment.Exit(0);
        }
    }
}
