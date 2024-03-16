using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

using MediaDownloader.Tools.CustomMessageBox;
using MediaDownloader.Setup.BootstrapForm;
using static MediaDownloader.Global;
using static MediaDownloader.Tools.FolderCompressor;
using static MediaDownloader.Updater.UpdaterSetup;
using static MediaDownloader.Data.Config.ConfigManager;

namespace MediaDownloader
{
    internal static class Init
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

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
                CONFIG.NOTIFICATIONS_ENABLE = true;
                CONFIG.DATA_ZIPPING_ENABLE = false;
                CONFIG.TRUSTED_URLS = "youtube.com,youtu.be,twitter.com,instagram.com";
            }

            if (File.Exists("MediaDownloader\\config\\queue.zip") || Directory.Exists("MediaDownloader\\config\\queue"))
                DecompressFolder("MediaDownloader\\config\\queue.zip", "MediaDownloader\\config\\queue_temp");
            else
                Directory.CreateDirectory("MediaDownloader\\config\\queue_temp");

            if (File.Exists("MediaDownloader\\config\\history.zip") || Directory.Exists("MediaDownloader\\config\\history"))
                DecompressFolder("MediaDownloader\\config\\history.zip", "MediaDownloader\\config\\history_temp");
            else
                Directory.CreateDirectory("MediaDownloader\\config\\history_temp");

            Directory.CreateDirectory("MediaDownloader\\temp");
            Directory.CreateDirectory("Downloads");

            // start MainMenu
            Application.Run(new MainMenu());
        }
    }
}