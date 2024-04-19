using System.IO;
using System.Windows.Forms;

using MediaDownloader.Forms.CustomMessageBox;
using static MediaDownloader.Global;
using static MediaDownloader.Data.QueueItem.QueueItemManager;
using static MediaDownloader.Data.QueueItem.QueueItemStructure;
using static MediaDownloader.Tools.Forms;
using static MediaDownloader.Tools.Sounds;
using static MediaDownloader.Media.Converters.Converter;
using static MediaDownloader.Media.Downloaders.Downloader;

namespace MediaDownloader.Media.Downloaders
{
    public static class Queuer
    {
        public static void StartDownload(QueueItemBase queueItem, TextBox nameTextBox, Button downloadButton, Button downloadAllButton, ListBox historyListBox)
        {
            IS_DOWNLOADING = true;
            ChangeDownloadButtonColors(true, downloadButton, downloadAllButton);

            QueueItemBase lastQueueItem = new QueueItemBase();
            if (File.Exists("MediaDownloader\\temp\\lastQueueItem.mdqi"))
                lastQueueItem = ReadQueueItemFromFile("MediaDownloader\\temp\\lastQueueItem.mdqi");

            // this code sucks, let's not mention it :)
            bool skipDownload = false;
            if (
                lastQueueItem.URL == queueItem.URL &&
                lastQueueItem.OUTPUT_PLAYLIST_ENABLE == queueItem.OUTPUT_PLAYLIST_ENABLE &&
                queueItem.OUTPUT_FORMAT != "png (thumbnail)" &&
                queueItem.OUTPUT_FORMAT != "jpg (thumbnail)" &&
                queueItem.OUTPUT_FORMAT != "(custom arguments)"
                )
            {
                if (File.Exists("MediaDownloader\\temp\\lastDownload"))
                {
                    if (File.Exists(File.ReadAllText("MediaDownloader\\temp\\lastDownload")))
                    {
                        skipDownload = true;
                    }
                }
            }
            //

            lastQueueItem = queueItem;
            WriteQueueItemToFile(lastQueueItem, "MediaDownloader\\temp\\lastQueueItem.mdqi");

            string[] downloadFiles = DownloadMedia(queueItem, skipDownload);
            if (downloadFiles == null)
            {
                if (CONFIG.COMPLETE_SOUND_ENABLE)
                {
                    if (CONFIG.COMPLETE_SOUND_PATH == "")
                    {
                        PlaySound("MediaDownloader.Resources.download_complete_error.wav", true);
                    }
                    else
                    {
                        PlaySound(CONFIG.COMPLETE_SOUND_PATH, false);
                    }
                }

                CustomMessageBox customMessageBox = new CustomMessageBox("Error: Download Failed!", "OK", true);
                customMessageBox.ShowDialog();

                ChangeDownloadButtonColors(false, downloadButton, downloadAllButton);
                IS_DOWNLOADING = false;

                return;
            }

            // if downloadFiles is larger than 1, it will treat it as a playlist
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
                File.WriteAllText("MediaDownloader\\temp\\lastDownload", downloadFiles[0]);
                if (queueItem.OUTPUT_NAME == "" || queueItem.OUTPUT_NAME == null)
                    queueItem.OUTPUT_NAME = outputName;

                if (nameTextBox != null)
                {
                    try
                    {
                        nameTextBox.Invoke((MethodInvoker)delegate
                        {
                            nameTextBox.Text = queueItem.OUTPUT_NAME;
                        });
                    }
                    catch { }
                }

                ConvertMedia(queueItem, downloadFiles[0], queueItem.OUTPUT_NAME);
            }

            if (CONFIG.HISTORY_ENABLE)
            {
                queueItem.OUTPUT_NAME_AUTO_ENABLE = false;
                HISTORY.Insert(0, queueItem);

                ReadQueueItemPackToListBox(historyListBox, HISTORY, true);
            }

            ChangeDownloadButtonColors(false, downloadButton, downloadAllButton);
            IS_DOWNLOADING = false;

            if (CONFIG.COMPLETE_SOUND_ENABLE)
            {
                if (CONFIG.COMPLETE_SOUND_PATH == "")
                {
                    PlaySound("MediaDownloader.Resources.download_complete_success.wav", true);
                }
                else
                {
                    PlaySound(CONFIG.COMPLETE_SOUND_PATH, false);
                }
            }
        }
    }
}