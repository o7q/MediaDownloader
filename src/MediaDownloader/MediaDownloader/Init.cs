using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MediaDownloader.Tools.CustomMessageBox;
using static MediaDownloader.Data.Global;
using static MediaDownloader.Setup.Bootstrapper;
using static MediaDownloader.Updater.UpdaterSetup;
using static MediaDownloader.Managers.FileManagers.ConfigManager;
using static MediaDownloader.Managers.FileManagers.CompressionManager;

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
                CustomMessageBox customMessageBox = new CustomMessageBox("An instance of MediaDownloader is already running.\n\nHaving two or more instances of MediaDownloader running simultaneously\ncan cause issues (file corruption, malfunctioning).\n\nAre you sure you want to continue?\n\nPress OK to continue\nPress CLOSE to cancel", true);
                customMessageBox.ShowDialog();
                if (customMessageBox.Result == DialogResult.Cancel)
                    return;
            }

            // detect if redists exist
            bool ytdlpCheck = true;
            bool ffmpegCheck = true;
            string redistText = "";
            if (!File.Exists("MediaDownloader\\redist\\yt-dlp\\yt-dlp.exe"))
            {
                ytdlpCheck = false;
                redistText += "\n- yt-dlp";
            }
            if (!File.Exists("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe") || !File.Exists("MediaDownloader\\redist\\ffmpeg\\ffprobe.exe"))
            {
                ffmpegCheck = false;
                redistText += "\n- ffmpeg";
            }

            if (!ytdlpCheck || !ffmpegCheck)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("MediaDownloader will download the following redist files:" + redistText + "\n\nPress OK to continue\nPress CLOSE to cancel", true);
                customMessageBox.ShowDialog();

                if (customMessageBox.Result == DialogResult.Cancel)
                    return;
            }

            if (!ytdlpCheck)
                InstallYtdlp();
            if (!ffmpegCheck)
                InstallFFmpeg();

            InstallUpdater();

            if (File.Exists("MediaDownloader\\config\\config.cfg"))
                CONFIG = ReadConfig("MediaDownloader\\config\\config.cfg");
            else
                CONFIG.DATA_ENABLE_PACKING = true;

            if (File.Exists("MediaDownloader\\config\\queue.pack") || Directory.Exists("MediaDownloader\\config\\queue"))
                DecompressFolder("MediaDownloader\\config\\queue.pack", "MediaDownloader\\config\\queue_temp");
            else
                Directory.CreateDirectory("MediaDownloader\\config\\queue_temp");

            if (File.Exists("MediaDownloader\\config\\history.pack") || Directory.Exists("MediaDownloader\\config\\history"))
                DecompressFolder("MediaDownloader\\config\\history.pack", "MediaDownloader\\config\\history_temp");
            else
                Directory.CreateDirectory("MediaDownloader\\config\\history_temp");

            Directory.CreateDirectory("MediaDownloader\\temp");
            Directory.CreateDirectory("Downloads");

            // start MainMenu
            Application.Run(new MainMenu());
        }
    }
}