namespace AIRAC_Downloader_for_Euroscope.Services
{
    public class ToggleDownloadButtonArgs : EventArgs
    {
        public bool Enabled { get; }
        public string PackageName { get; }

        public ToggleDownloadButtonArgs(bool enabled,  string packageName)
        {
            Enabled = enabled;
            PackageName = packageName;
        }
    }
}
