using System.IO;
using System.IO.Compression;
using System.Net;

namespace MediaDownloader.Setup
{
    public static class Bootstrapper
    {

        public static void InstallYtdlp()
        {
            try
            {
                Directory.Delete("MediaDownloader\\redist\\yt-dlp", true);
            }
            catch { }
            Directory.CreateDirectory("MediaDownloader\\redist\\yt-dlp");

            using (var client = new WebClient())
                client.DownloadFile("https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe", "MediaDownloader\\redist\\yt-dlp\\yt-dlp.exe");
        }

        public static void InstallFFmpeg()
        {
            try
            {
                Directory.Delete("MediaDownloader\\redist\\ffmpeg", true);
            }
            catch { }
            Directory.CreateDirectory("MediaDownloader\\redist\\ffmpeg");

            using (var client = new WebClient())
                client.DownloadFile("https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip", "MediaDownloader\\redist\\ffmpeg\\ffmpeg.zip");

            ZipFile.ExtractToDirectory("MediaDownloader\\redist\\ffmpeg\\ffmpeg.zip", "MediaDownloader\\redist\\ffmpeg");

            string[] ffmpegRedistPaths = Directory.GetDirectories("MediaDownloader\\redist\\ffmpeg");
            Directory.Move(ffmpegRedistPaths[0], "MediaDownloader\\redist\\ffmpeg\\ffmpeg");

            File.Move("MediaDownloader\\redist\\ffmpeg\\ffmpeg\\bin\\ffmpeg.exe", "MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe");
            File.Move("MediaDownloader\\redist\\ffmpeg\\ffmpeg\\bin\\ffprobe.exe", "MediaDownloader\\redist\\ffmpeg\\ffprobe.exe");

            Directory.Delete("MediaDownloader\\redist\\ffmpeg\\ffmpeg", true);
            File.Delete("MediaDownloader\\redist\\ffmpeg\\ffmpeg.zip");
        }
    }
}