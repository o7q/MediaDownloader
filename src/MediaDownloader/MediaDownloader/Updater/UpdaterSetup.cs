﻿using System.IO;

using static MediaDownloader.Updater.ResourceReader;

namespace MediaDownloader.Updater
{
    public static class UpdaterSetup
    {
        public static void InstallUpdater()
        {
            Directory.CreateDirectory("MediaDownloader\\updater");
            File.WriteAllText("MediaDownloader\\updater\\Updater.bat", ReadLocalResource("MediaDownloader.Updater.Content.Updater.bat"));
            File.WriteAllText("MediaDownloader\\updater\\update.ps1", ReadLocalResource("MediaDownloader.Updater.Content.update.ps1"));
        }
    }
}