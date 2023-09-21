using System.IO;
using static MediaDownloader.Updater.ResourceReader;

namespace MediaDownloader.Updater
{
    public static class UpdaterSetup
    {
        public static void InstallUpdater()
        {
            Directory.CreateDirectory("MediaDownloader\\updater");
            File.WriteAllText("MediaDownloader\\updater\\Updater.ps1", ReadLocalResource("MediaDownloader.Updater.Content.Updater.ps1"));
        }
    }
}