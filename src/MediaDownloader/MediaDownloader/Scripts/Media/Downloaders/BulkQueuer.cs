using System.Diagnostics;
using System.Windows.Forms;

using static MediaDownloader.Data.QueueItem.QueueItemManager;
using static MediaDownloader.Data.QueueItem.QueueItemStructure;
using static MediaDownloader.Media.Downloaders.Queuer;

namespace MediaDownloader.Media.Downloaders
{
    public static class BulkQueuer
    {
        public static void StartDownloadQueue(string[] queueList, Button downloadButton, Button downloadAllButton, Panel progressPanel, Label progressLabel)
        {
            try
            {
                progressPanel.Invoke((MethodInvoker)delegate
                {
                    progressPanel.Width = 0;
                });

                progressLabel.Invoke((MethodInvoker)delegate
                {
                    progressLabel.Text = "0/" + queueList.Length + "  |  0.00%  |  00:00:00";
                });
            }
            catch { }

            int progressBarWidth = 0;
            float percentage = 0;
            int totalSeconds = 0;

            for (int i = 0; i < queueList.Length; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                QueueItemBase queueItem = ReadQueueItem("MediaDownloader\\config\\queue_temp\\" + queueList[i] + ".mdq");
                StartDownload(queueItem, null, downloadButton, downloadAllButton);

                percentage = ((i + 1) / (float)queueList.Length) * 100;
                progressBarWidth = (int)((125 / (float)100) * percentage);

                stopwatch.Stop();

                totalSeconds += stopwatch.Elapsed.Seconds;
                int averageSeconds = (totalSeconds / (i + 1)) * (queueList.Length - (i + 1));

                int hours = averageSeconds / 3600;
                int minutes = (averageSeconds % 3600) / 60;
                int seconds = averageSeconds % 60;
                string time = $"{hours:D2}:{minutes:D2}:{seconds:D2}";

                try
                {
                    progressPanel.Invoke((MethodInvoker)delegate
                    {
                        progressPanel.Width = progressBarWidth;
                    });

                    progressLabel.Invoke((MethodInvoker)delegate
                    {
                        progressLabel.Text = (i + 1) + "/" + queueList.Length + "  |  " + percentage.ToString("0.00") + "%  |  " + time;
                    });
                }
                catch { }
            }
        }
    }
}