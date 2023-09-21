using System.IO;
using static MediaDownloader.Updater.ResourceReader;

namespace MediaDownloader.Updater
{
    public static class UpdaterSetup
    {
        public static void InstallUpdater()
        {
            Directory.CreateDirectory("MediaDownloader\\updater");

            if (!File.Exists("MediaDownloader\\updater\\Updater.bat"))
                File.WriteAllText("MediaDownloader\\updater\\Updater.bat", ReadLocalResource("MediaDownloader.Updater.Content.Updater.bat"));
            if (!File.Exists("MediaDownloader\\updater\\Updater.ps1"))
                File.WriteAllText("MediaDownloader\\updater\\Updater.ps1", ReadLocalResource("MediaDownloader.Updater.Content.Updater.ps1"));
        }
    }
}