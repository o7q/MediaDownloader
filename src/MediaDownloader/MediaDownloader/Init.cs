using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

using MediaDownloader.Tools.MigrationTools;
using MediaDownloader.Forms.BootstrapForm;
using MediaDownloader.Forms.CustomMessageBox;
using static MediaDownloader.Global;
using static MediaDownloader.Updater.UpdaterSetup;
using static MediaDownloader.Data.Config.ConfigManager;
using static MediaDownloader.Data.QueueItem.QueueItemManager;

namespace MediaDownloader
{
    internal static class Init
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Directory.CreateDirectory("MediaDownloader\\config");
            Directory.CreateDirectory("MediaDownloader\\redist");
            Directory.CreateDirectory("MediaDownloader\\temp");
            Directory.CreateDirectory("MediaDownloader\\updater");
            Directory.CreateDirectory("Downloads");

            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("An instance of MediaDownloader is already running.\n\nHaving two or more instances of MediaDownloader running simultaneously\ncan cause issues (file corruption, malfunctioning).\n\nAre you sure you want to continue?\n\nPress OK to continue\nPress CLOSE to cancel", "OK", true);
                customMessageBox.ShowDialog();
                if (customMessageBox.Result == DialogResult.Cancel)
                    return;
            }

            bool ytdlpMissing = false;
            bool ffmpegMissing = false;

            if (!File.Exists("MediaDownloader\\redist\\yt-dlp\\yt-dlp.exe"))
                ytdlpMissing = true;

            if (
                !File.Exists("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe") ||
                !File.Exists("MediaDownloader\\redist\\ffmpeg\\ffprobe.exe")
                )
            {
                ffmpegMissing = true;
            }

            if (ytdlpMissing || ffmpegMissing)
            {
                BootstrapForm bootstrapForm = new BootstrapForm(ytdlpMissing, ffmpegMissing);
                bootstrapForm.ShowDialog();

                if (bootstrapForm.Result == DialogResult.Cancel)
                {
                    Environment.Exit(0);
                }
            }

            InstallUpdater();

            if (File.Exists("MediaDownloader\\config\\config.cfg"))
                CONFIG = ReadConfig("MediaDownloader\\config\\config.cfg");
            else
            {
                CONFIG.COMPLETE_SOUND_ENABLE = true;
                CONFIG.NOTIFICATIONS_ENABLE = true;
                CONFIG.HISTORY_ENABLE = true; 
                CONFIG.TRUSTED_URLS = "youtube.com,youtu.be,twitter.com,instagram.com";
            }

            if (File.Exists("MediaDownloader\\config\\queue.mdqipack"))
                if (File.ReadAllText("MediaDownloader\\config\\queue.mdqipack") != "")
                    QUEUE = ReadQueueItemPackFromFile("MediaDownloader\\config\\queue.mdqipack");
            if (File.Exists("MediaDownloader\\config\\history.mdqipack"))
                if (File.ReadAllText("MediaDownloader\\config\\history.mdqipack") != "")
                    HISTORY = ReadQueueItemPackFromFile("MediaDownloader\\config\\history.mdqipack");

            // run the migrator
            Migrator.Run();

            // start MainMenu
            Application.Run(new MainMenu());
        }
    }
}