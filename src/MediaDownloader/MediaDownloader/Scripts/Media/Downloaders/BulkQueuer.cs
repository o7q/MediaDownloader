using System.Windows.Forms;
using static MediaDownloader.Data.QueueItem.QueueItemManager;
using static MediaDownloader.Data.QueueItem.QueueItemStructure;
using static MediaDownloader.Media.Downloaders.Queuer;

namespace MediaDownloader.Media.Downloaders
{
    public static class BulkQueuer
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
    }
}