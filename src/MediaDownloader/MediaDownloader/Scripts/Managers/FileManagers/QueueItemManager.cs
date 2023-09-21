using System.IO;
using System.Text;
using static MediaDownloader.Data.Structure.QueueItemStructure;

namespace MediaDownloader.Managers.FileManagers
{
    public static class QueueItemManager
    {
        public static void WriteQueueItem(QueueItemBase queueItem, string queueFile)
        {
            var sb = new StringBuilder();
            foreach (var field in typeof(QueueItemBase).GetFields())
            {
                object value = field.GetValue(queueItem);
                if (value != null)
                    sb.Append(field.Name + '¶' + value.ToString());
                sb.Append('ʃ');
            }
            sb.Length--;

            File.WriteAllText(queueFile, sb.ToString());
        }

        public static QueueItemBase ReadQueueItem(string queueFile)
        {
            string queueItemRaw = File.ReadAllText(queueFile);
            string[] queueItemSetting = queueItemRaw.Split('ʃ');

            QueueItemBase queueItem = new QueueItemBase();

            for (int i = 0; i < queueItemSetting.Length; i++)
            {
                string[] queueItemSettingPair = queueItemSetting[i].Split('¶');

                switch (queueItemSettingPair[0])
                {
                    case "URL": queueItem.URL = queueItemSettingPair[1]; break;
                    case "OUTPUT_PLAYLIST_ENABLE": queueItem.OUTPUT_PLAYLIST_ENABLE = bool.Parse(queueItemSettingPair[1]); break;

                    case "OUTPUT_NAME": queueItem.OUTPUT_NAME = queueItemSettingPair[1]; break;
                    case "OUTPUT_NAME_AUTO_ENABLE": queueItem.OUTPUT_NAME_AUTO_ENABLE = bool.Parse(queueItemSettingPair[1]); break;

                    case "OUTPUT_LOCATION": queueItem.OUTPUT_LOCATION = queueItemSettingPair[1]; break;

                    case "OUTPUT_FORMAT": queueItem.OUTPUT_FORMAT = queueItemSettingPair[1]; break;

                    case "OUTPUT_CHANGE_TIMEFRAME_ENABLE": queueItem.OUTPUT_CHANGE_TIMEFRAME_ENABLE = bool.Parse(queueItemSettingPair[1]); break;
                    case "OUTPUT_TIMEFRAME_START": queueItem.OUTPUT_TIMEFRAME_START = queueItemSettingPair[1]; break;
                    case "OUTPUT_TIMEFRAME_END": queueItem.OUTPUT_TIMEFRAME_END = queueItemSettingPair[1]; break;
                    case "OUTPUT_TIMEFRAME_TRIM_FROM_START_ENABLE": queueItem.OUTPUT_TIMEFRAME_TRIM_FROM_START_ENABLE = bool.Parse(queueItemSettingPair[1]); break;
                    case "OUTPUT_TIMEFRAME_TRIM_TO_END_ENABLE": queueItem.OUTPUT_TIMEFRAME_TRIM_TO_END_ENABLE = bool.Parse(queueItemSettingPair[1]); break;

                    case "OUTPUT_BITRATE_VIDEO": queueItem.OUTPUT_BITRATE_VIDEO = queueItemSettingPair[1]; break;
                    case "OUTPUT_BITRATE_AUDIO": queueItem.OUTPUT_BITRATE_AUDIO = queueItemSettingPair[1]; break;

                    case "OUTPUT_CHANGE_RESOLUTION_ENABLE": queueItem.OUTPUT_CHANGE_RESOLUTION_ENABLE = bool.Parse(queueItemSettingPair[1]); break;
                    case "OUTPUT_RESOLUTION_WIDTH": queueItem.OUTPUT_RESOLUTION_WIDTH = queueItemSettingPair[1]; break;
                    case "OUTPUT_RESOLUTION_HEIGHT": queueItem.OUTPUT_RESOLUTION_HEIGHT = queueItemSettingPair[1]; break;

                    case "OUTPUT_CHANGE_FRAMERATE_ENABLE": queueItem.OUTPUT_CHANGE_FRAMERATE_ENABLE = bool.Parse(queueItemSettingPair[1]); break;
                    case "OUTPUT_FRAMERATE": queueItem.OUTPUT_FRAMERATE = queueItemSettingPair[1]; break;

                    case "OUTPUT_YTDLP_ARGUMENTS": queueItem.OUTPUT_YTDLP_ARGUMENTS = queueItemSettingPair[1]; break;
                    case "OUTPUT_FFMPEG_ARGUMENTS": queueItem.OUTPUT_FFMPEG_ARGUMENTS = queueItemSettingPair[1]; break;

                    case "OUTPUT_DISPLAY_ENABLE": queueItem.OUTPUT_DISPLAY_ENABLE = bool.Parse(queueItemSettingPair[1]); break;
                    case "OUTPUT_PAUSE_ENABLE": queueItem.OUTPUT_PAUSE_ENABLE = bool.Parse(queueItemSettingPair[1]); break;
                }
            }

            return queueItem;
        }
    }
}