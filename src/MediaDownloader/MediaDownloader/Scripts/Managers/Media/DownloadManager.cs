using System;
using System.IO;
using System.Windows.Forms;
using MediaDownloader.Tools.CustomMessageBox;
using static MediaDownloader.Data.Storage;
using static MediaDownloader.Data.Structure.QueueItemStructure;
using static MediaDownloader.Tools.Files;
using static MediaDownloader.Tools.Forms;
using static MediaDownloader.Tools.Shell;
using static MediaDownloader.Managers.QueueItemManager;
using static MediaDownloader.Managers.Media.ConvertManager;

namespace MediaDownloader.Managers.Media
{
    public static class DownloadManager
    {
        public static void StartDownloadQueue(string[] queueList, Button downloadButton, Button downloadAllButton, ProgressBar progressBar)
        {
            try
            {
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Maximum = queueList.Length;
                });
            }
            catch { }

            for (int i = 0; i < queueList.Length; i++)
            {
                QueueItemBase queueItem = ReadQueueItem("MediaDownloader\\config\\queue\\" + queueList[i] + ".mdq");
                StartDownload(queueItem, downloadButton, downloadAllButton);

                try
                {
                    progressBar.Invoke((MethodInvoker)delegate
                    {
                        progressBar.Value = i + 1;
                    });
                }
                catch { }
            }
        }

        public static void StartDownload(QueueItemBase queueItem, Button downloadButton, Button downloadAllButton)
        {
            IS_DOWNLOADING = true;
            ChangeDownloadButtonColors(true, downloadButton, downloadAllButton);

            if (queueItem.OUTPUT_NAME == "" || queueItem.OUTPUT_NAME == null)
                queueItem.OUTPUT_NAME = "download " + DateTime.Now.ToString("[M-d-y_hms]");

            string downloadFile = DownloadMedia(queueItem);
            if (downloadFile == "")
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Error: Download Failed!", true);
                customMessageBox.ShowDialog();

                ChangeDownloadButtonColors(false, downloadButton, downloadAllButton);
                IS_DOWNLOADING = false;

                return;
            }
            ConvertMedia(queueItem, downloadFile);

            if (CONFIG.HISTORY_ENABLE)
            {
                WriteQueueItem(queueItem, "MediaDownloader\\config\\history\\(" + CONFIG.HISTORY_SAVE_INDEX + ") " + queueItem.OUTPUT_NAME + ".mdq");
                CONFIG.HISTORY_SAVE_INDEX++;
            }

            ChangeDownloadButtonColors(false, downloadButton, downloadAllButton);
            IS_DOWNLOADING = false;
        }

        private static string DownloadMedia(QueueItemBase queueItem)
        {
            CleanFolder("MediaDownloader\\working");

            string customArguments = "";
            if (queueItem.OUTPUT_FORMAT == "(custom arguments)")
                customArguments = queueItem.OUTPUT_YTDLP_ARGUMENTS + " ";

            StartProcess("MediaDownloader\\redist\\yt-dlp\\yt-dlp.exe", "-v --ffmpeg-location \"MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe\" " + customArguments + "-o \"MediaDownloader\\working\\raw\" " + queueItem.URL, "MediaDownloader " + VERSION + "   [DOWNLOADING  :  " + queueItem.URL.ToUpper() + "]", queueItem.OUTPUT_ENABLE_DISPLAY, queueItem.OUTPUT_ENABLE_PAUSE);
            string[] downloadPaths = Directory.GetFiles("MediaDownloader\\working");
            string downloadFile = "";
            for (int i = 0; i < downloadPaths.Length; i++)
            {
                if (Path.GetFileNameWithoutExtension(downloadPaths[i]) == "raw")
                    downloadFile = downloadPaths[i];
            }
            if (downloadFile == "")
                return "";
            return downloadFile;
        }
    }
}