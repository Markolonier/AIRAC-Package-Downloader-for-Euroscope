using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AIRAC_Downloader_for_Euroscope.Code.Core
{
    internal class GithubUpdater
    {
        private static readonly string RepoUrl = "https://api.github.com/repos/Markolonier/AIRAC-Package-Downloader-for-Euroscope/releases/latest";
        private static readonly string ThisVersion = "v2.1.0";

        private GithubRelease CurrentRelease = null;

        private class GithubRelease()
        {
            public string Tag_name { get; set; }
            public List<Asset> Assets { get; set; }

            public class Asset
            {
                public string Browser_download_url { get; set; }
            }
            public string Body { get; set; }
        }

        public async Task<bool> CheckUpdates()
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
            return (ThisVersion != CurrentRelease.Tag_name);
        }

        public async void DownloadUpdate()
        {
            if (CurrentRelease?.Assets == null || CurrentRelease.Assets.Count == 0) await CheckUpdates();
            // variables
            var asset = CurrentRelease.Assets.FirstOrDefault(a => a.Browser_download_url.EndsWith(".zip"));
            string DownloadUrl = asset.Browser_download_url;
            string DownloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string zipPath = Path.Combine(DownloadsFolder, DownloadUrl.Split('/').Last());
            

            // Download data
            using var client = new HttpClient();
            var data = await client.GetByteArrayAsync(asset.Browser_download_url);
            File.WriteAllBytes(zipPath, data);

            string appDir = AppContext.BaseDirectory;
            string extractDir = Path.Combine(DownloadsFolder, "_temp AIRAC Download updater");


            // Powershell Delete existing installation -> Extract zip file -> Delete temporary Download Files -> Start exe again
            string psCommand =
                $"$zip = '{zipPath}'; " +
                $"$dest = '{extractDir}'; " +
                $"$app = '{appDir}'; " +
                "$exe = Join-Path $app 'AIRAC Downloader for Euroscope.exe'; " +
                "Start-Sleep -Milliseconds 800; " +

                // CONFIGS SICHERN
                "$config1 = Get-ChildItem -Path $app -Filter '*.config' -File -ErrorAction SilentlyContinue; " +
                "$config2 = Get-ChildItem -Path $app -Filter 'AIRAC Downloader Configuration.json' -File -ErrorAction SilentlyContinue; " +
                "$backup = @(); if ($config1) { $backup += $config1 }; if ($config2) { $backup += $config2 }; " +
                "$backupPaths = $backup.FullName; " +

                // APP ORDNER LEEREN OHNE CONFIGS
                "Get-ChildItem -Path $app | Where-Object { $backupPaths -notcontains $_.FullName } | Remove-Item -Recurse -Force; " +

                // ZIP ENTAPCKEN & UNTERORDNER FINDEN
                "if (Test-Path $dest) { Remove-Item $dest -Recurse -Force }; " +
                "Expand-Archive -Path $zip -DestinationPath $dest -Force; " +
                "$sub = Get-ChildItem -Path $dest -Directory | Select-Object -First 1; " +
                "$source = $sub.FullName; " +

                // DATEIEN KOPIEREN
                "Copy-Item -Path ($source + '\\*') -Destination $app -Recurse -Force; " +

                // CONFIGS WIEDERHERSTELLEN
                "foreach ($c in $backup) { Copy-Item -Path $c.FullName -Destination $app -Force }; " +

                // Delete downloads Folder
                "Start-Sleep -Milliseconds 300; " +
                "try { Remove-Item $zip -Force -ErrorAction Stop } catch {}; " +
                "try { Remove-Item $dest -Recurse -Force -ErrorAction Stop } catch {}; " +


                // APP STARTEN
                "Start-Process $exe";




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
