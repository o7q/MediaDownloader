using System.IO;

using static MediaDownloader.Global;
using static MediaDownloader.Data.QueueItem.QueueItemStructure;
using static MediaDownloader.Tools.Shell;
using static MediaDownloader.Tools.Files;

namespace MediaDownloader.Media
{
    public static class YtdlpWrapper
    {
        public static string[] DownloadQueueItem(QueueItemBase queueItem, bool skipDownload)
        {
            if (!skipDownload)
            {
                CleanPath("MediaDownloader\\temp", new string[] { "lastQueueItem.mdqi", "lastDownload" });
                Directory.CreateDirectory("MediaDownloader\\temp\\download");

                string downloadName;
                if (queueItem.OUTPUT_NAME_AUTO_ENABLE || queueItem.OUTPUT_PLAYLIST_ENABLE || queueItem.OUTPUT_NAME == "" || queueItem.OUTPUT_NAME == null)
                    downloadName = "%(title)s";
                else
                    downloadName = queueItem.OUTPUT_NAME;

                string customArguments = "";
                if (queueItem.OUTPUT_FORMAT == "(custom arguments)")
                    customArguments = queueItem.OUTPUT_YTDLP_ARGUMENTS + " ";

                string downloadScript;

                switch (queueItem.OUTPUT_FORMAT)
                {
                    case "png (thumbnail)":
                    case "jpg (thumbnail)":
                        downloadScript = "-v --ffmpeg-location \"MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe\" --skip-download --write-thumbnail -o \"MediaDownloader\\temp\\download\\" + downloadName + "\" " + queueItem.URL;
                        break;

                    default:
                        downloadScript = "-v --ffmpeg-location \"MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe\" " + customArguments + "-o \"MediaDownloader\\temp\\download\\" + downloadName + "\" " + queueItem.URL;
                        break;
                }

                StartProcess("MediaDownloader\\redist\\yt-dlp\\yt-dlp.exe", downloadScript, "MediaDownloader " + VERSION + "   [DOWNLOADING  :  " + queueItem.URL.ToUpper() + "]", CONFIG.OUTPUT_DISPLAY_ENABLE, CONFIG.OUTPUT_PAUSE_ENABLE);
            }

            string[] downloadPaths = Directory.GetFiles("MediaDownloader\\temp\\download");
            if (downloadPaths.Length == 0 && queueItem.OUTPUT_FORMAT != "(custom arguments)")
                return null;

            return downloadPaths;
        }
    }
}