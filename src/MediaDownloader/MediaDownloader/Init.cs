using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using MediaDownloader.Tools.CustomMessageBox;
using static MediaDownloader.Setup.Bootstrap;

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

            bool ytdlpCheck = true;
            bool ffmpegCheck = true;
            if (!File.Exists("MediaDownloader\\redist\\yt-dlp\\yt-dlp.exe"))
                ytdlpCheck = false;
            if (!File.Exists("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe") || !File.Exists("MediaDownloader\\redist\\ffmpeg\\ffprobe.exe"))
                ffmpegCheck = false;

            if (!ytdlpCheck || !ffmpegCheck)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("One or more redist files are missing.\nMediaDownloader will download and install them automatically.\n\nPress OK to continue\nPress CLOSE to cancel", true);
                customMessageBox.ShowDialog();

                if (customMessageBox.Result == DialogResult.Cancel)
                    return;
            }

            Directory.CreateDirectory("MediaDownloader\\config\\queue");
            Directory.CreateDirectory("MediaDownloader\\config\\history");
            Directory.CreateDirectory("MediaDownloader\\working");
            Directory.CreateDirectory("Downloads");

            if (!ytdlpCheck)
                InstallYtdlp();
            if (!ffmpegCheck)
                InstallFFmpeg();

            // start MainMenu
            Application.Run(new MainMenu());
        }
    }
}