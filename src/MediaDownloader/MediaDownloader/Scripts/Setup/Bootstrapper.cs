using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using System.Drawing;

namespace MediaDownloader.Setup
{
    public static class Bootstrapper
    {

        public static void InstallYtdlp(Label statusLabel)
        {
            statusLabel.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = "(downloading...)";
                statusLabel.ForeColor = Color.DarkGray;
            });

            try
            {
                Directory.Delete("MediaDownloader\\redist\\yt-dlp", true);
            }
            catch { }
            Directory.CreateDirectory("MediaDownloader\\redist\\yt-dlp");

            using (var client = new WebClient())
                client.DownloadFile("https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe", "MediaDownloader\\redist\\yt-dlp\\yt-dlp.exe");

            statusLabel.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = "(found)";
                statusLabel.ForeColor = Color.DarkSeaGreen;
            });
        }

        public static void InstallFFmpeg(Label statusLabel)
        {
            statusLabel.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = "(downloading...)";
                statusLabel.ForeColor = Color.DarkGray;
            });

            try
            {
                Directory.Delete("MediaDownloader\\redist\\ffmpeg", true);
            }
            catch { }
            Directory.CreateDirectory("MediaDownloader\\redist\\ffmpeg");

            using (var client = new WebClient())
                client.DownloadFile("https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip", "MediaDownloader\\redist\\ffmpeg\\ffmpeg.zip");

            statusLabel.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = "(extracting...)";
                statusLabel.ForeColor = Color.DarkGray;
            });

            ZipFile.ExtractToDirectory("MediaDownloader\\redist\\ffmpeg\\ffmpeg.zip", "MediaDownloader\\redist\\ffmpeg");

            string[] ffmpegRedistPaths = Directory.GetDirectories("MediaDownloader\\redist\\ffmpeg");
            Directory.Move(ffmpegRedistPaths[0], "MediaDownloader\\redist\\ffmpeg\\ffmpeg");

            File.Move("MediaDownloader\\redist\\ffmpeg\\ffmpeg\\bin\\ffmpeg.exe", "MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe");
            File.Move("MediaDownloader\\redist\\ffmpeg\\ffmpeg\\bin\\ffprobe.exe", "MediaDownloader\\redist\\ffmpeg\\ffprobe.exe");

            Directory.Delete("MediaDownloader\\redist\\ffmpeg\\ffmpeg", true);
            File.Delete("MediaDownloader\\redist\\ffmpeg\\ffmpeg.zip");

            statusLabel.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = "(found)";
                statusLabel.ForeColor = Color.DarkSeaGreen;
            });
        }
    }
}