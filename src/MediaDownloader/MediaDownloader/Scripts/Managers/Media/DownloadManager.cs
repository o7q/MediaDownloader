using System.IO;
using System.Windows.Forms;
using MediaDownloader.Tools.CustomMessageBox;
using static MediaDownloader.Data.Global;
using static MediaDownloader.Data.Structure.QueueItemStructure;
using static MediaDownloader.Tools.Shell;
using static MediaDownloader.Tools.Files;
using static MediaDownloader.Tools.Forms;
using static MediaDownloader.Managers.Media.ConvertManager;
using static MediaDownloader.Managers.FileManagers.QueueItemManager;

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
                QueueItemBase queueItem = ReadQueueItem("MediaDownloader\\config\\queue_temp\\" + queueList[i] + ".mdq");
                StartDownload(queueItem, null, downloadButton, downloadAllButton);

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

        public static void StartDownload(QueueItemBase queueItem, TextBox nameTextBox, Button downloadButton, Button downloadAllButton)
        {
            IS_DOWNLOADING = true;
            ChangeDownloadButtonColors(true, downloadButton, downloadAllButton);

            string[] downloadFiles = DownloadMedia(queueItem);
            if (downloadFiles == null)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Error: Download Failed!", true);
                customMessageBox.ShowDialog();

                ChangeDownloadButtonColors(false, downloadButton, downloadAllButton);
                IS_DOWNLOADING = false;

                return;
            }

            if (downloadFiles.Length > 1)
            {
                string copyLocation = queueItem.OUTPUT_LOCATION == "" || queueItem.OUTPUT_LOCATION == null ? "Downloads" : queueItem.OUTPUT_LOCATION;
                string directoryName = queueItem.OUTPUT_NAME == "" || queueItem.OUTPUT_NAME == null ? "unnamed" : queueItem.OUTPUT_NAME;

                Directory.CreateDirectory(copyLocation + "\\" + directoryName);

                for (int i = 0; i < downloadFiles.Length; i++)
                    ConvertMedia(queueItem, downloadFiles[i], directoryName + "\\" + Path.GetFileNameWithoutExtension(downloadFiles[i]));
            }
            else
            {
                string outputName = Path.GetFileNameWithoutExtension(downloadFiles[0]);
                queueItem.OUTPUT_NAME = outputName;
                if (nameTextBox != null)
                {
                    try
                    {
                        nameTextBox.Invoke((MethodInvoker)delegate
                        {
                            nameTextBox.Text = outputName;
                        });
                    }
                    catch { }
                }

                ConvertMedia(queueItem, downloadFiles[0], queueItem.OUTPUT_NAME);
            }

            if (CONFIG.HISTORY_ENABLE)
            {
                if (CONFIG.HISTORY_SAVE_INDEX == 0)
                    CONFIG.HISTORY_SAVE_INDEX = 1;

                WriteQueueItem(queueItem, "MediaDownloader\\config\\history_temp\\(" + CONFIG.HISTORY_SAVE_INDEX + ") " + (queueItem.OUTPUT_NAME == "" || queueItem.OUTPUT_NAME == null ? "unnamed" : queueItem.OUTPUT_NAME) + ".mdq");
                CONFIG.HISTORY_SAVE_INDEX++;
            }

            ChangeDownloadButtonColors(false, downloadButton, downloadAllButton);
            IS_DOWNLOADING = false;
        }

        private static string[] DownloadMedia(QueueItemBase queueItem)
        {
            CleanFolder("MediaDownloader\\temp");
            Directory.CreateDirectory("MediaDownloader\\temp\\download");

            string downloadName;
            if (queueItem.OUTPUT_NAME_AUTO_ENABLE)
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

            StartProcess("MediaDownloader\\redist\\yt-dlp\\yt-dlp.exe", downloadScript, "MediaDownloader " + VERSION + "   [DOWNLOADING  :  " + queueItem.URL.ToUpper() + "]", queueItem.OUTPUT_DISPLAY_ENABLE, queueItem.OUTPUT_PAUSE_ENABLE);
            string[] downloadPaths = Directory.GetFiles("MediaDownloader\\temp\\download");
            if (downloadPaths.Length == 0 && queueItem.OUTPUT_FORMAT != "(custom arguments)")
                return null;

            return downloadPaths;
        }
    }
}