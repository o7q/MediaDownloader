using System.IO;
using System.Windows.Forms;
using MediaDownloader.Tools.CustomMessageBox;
using static MediaDownloader.Global;
using static MediaDownloader.Data.QueueItem.QueueItemManager;
using static MediaDownloader.Data.QueueItem.QueueItemStructure;
using static MediaDownloader.Tools.Forms;
using static MediaDownloader.Media.Converters.Converter;
using static MediaDownloader.Media.Downloaders.Downloader;

namespace MediaDownloader.Media.Downloaders
{
    public static class Queuer
    {
        public static void StartDownload(QueueItemBase queueItem, TextBox nameTextBox, Button downloadButton, Button downloadAllButton)
        {
            IS_DOWNLOADING = true;
            ChangeDownloadButtonColors(true, downloadButton, downloadAllButton);

            string[] downloadFiles = DownloadMedia(queueItem);
            if (downloadFiles == null)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Error: Download Failed!", "OK", true);
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
    }
}