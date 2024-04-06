using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

using static MediaDownloader.Data.QueueItem.QueueItemStructure;
using static MediaDownloader.Media.Downloaders.Queuer;

namespace MediaDownloader.Media.Downloaders
{
    public static class BulkQueuer
    {
        public static void StartDownloadQueue(List<QueueItemBase> queueList, Button downloadButton, Button downloadAllButton, Panel progressPanel, Label progressLabel, ListBox historyListBox)
        {
            try
            {
                progressPanel.Invoke((MethodInvoker)delegate
                {
                    progressPanel.Width = 0;
                });

                progressLabel.Invoke((MethodInvoker)delegate
                {
                    progressLabel.Text = "0/" + queueList.Count + "  |  0.00%  |  00:00:00";
                });
            }
            catch { }

            int progressBarWidth = 0;
            float percentage = 0;
            int totalSeconds = 0;

            for (int i = 0; i < queueList.Count; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                QueueItemBase queueItem = queueList[i];
                StartDownload(queueItem, null, downloadButton, downloadAllButton, historyListBox);

                percentage = ((i + 1) / (float)queueList.Count) * 100;
                progressBarWidth = (int)((125 / (float)100) * percentage);

                stopwatch.Stop();

                totalSeconds += stopwatch.Elapsed.Seconds;
                int averageSeconds = (totalSeconds / (i + 1)) * (queueList.Count - (i + 1));

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
                        progressLabel.Text = (i + 1) + "/" + queueList.Count + "  |  " + percentage.ToString("0.00") + "%  |  " + time;
                    });
                }
                catch { }
            }
        }
    }
}