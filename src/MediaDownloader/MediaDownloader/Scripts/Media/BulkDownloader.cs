using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

using MediaDownloader.Media;
using static MediaDownloader.Data.QueueItem.QueueItemStructure;

namespace MediaDownloader.Media
{
    public class BulkDownloader
    {
        private QueueItemBase queueItem;
        private ControlPack controlPack;
        private List<QueueItemBase> queueList;

        public BulkDownloader(QueueItemBase queueItem, ControlPack controlPack, List<QueueItemBase> queueList)
        {
            this.controlPack = controlPack;
            this.controlPack = controlPack;
            this.queueList = queueList;
        }

        public void StartBulkDownload()
        {
            try
            {
                controlPack.progressPanel.Invoke((MethodInvoker)delegate
                {
                    controlPack.progressPanel.Width = 0;
                });

                controlPack.progressLabel.Invoke((MethodInvoker)delegate
                {
                    controlPack.progressLabel.Text = "0/" + queueList.Count + "  |  0.00%  |  00:00:00";
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

                Downloader queuer = new Downloader(queueItem, controlPack);
                queuer.StartDownload();

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
                    controlPack.progressPanel.Invoke((MethodInvoker)delegate
                    {
                        controlPack.progressPanel.Width = progressBarWidth;
                    });

                    controlPack.progressLabel.Invoke((MethodInvoker)delegate
                    {
                        controlPack.progressLabel.Text = (i + 1) + "/" + queueList.Count + "  |  " + percentage.ToString("0.00") + "%  |  " + time;
                    });
                }
                catch { }
            }
        }
    }
}