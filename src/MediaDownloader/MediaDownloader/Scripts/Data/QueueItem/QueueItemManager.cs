using System;
using System.IO;
using System.Text;

using static MediaDownloader.Data.QueueItem.QueueItemStructure;
using static MediaDownloader.Tools.Strings;

namespace MediaDownloader.Data.QueueItem
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
                {
                    // this will convert the string to base64 in the case that the specific config value contains special characters to prevent the config reader from breaking
                    // such as if the user happened to use a special split character such as '\n' somewhere in the configuration
                    string keyValue = field.Name;
                    string configValue = value.ToString();
                    if (configValue.Contains("\n"))
                    {
                        configValue = EncodeString(configValue);
                        // indicate that the config value is in base64
                        keyValue += "_base64";
                    }

                    sb.Append(keyValue);
                    sb.Append('¶');
                    sb.Append(configValue);
                }
                sb.Append('\n');
            }
            sb.Length--;

            File.WriteAllText(queueFile, sb.ToString());
        }

        public static QueueItemBase ReadQueueItem(string queueFile)
        {
            string queueItemRaw = File.ReadAllText(queueFile);
            string[] queueItemSetting = queueItemRaw.Split('\n');

            QueueItemBase queueItem = new QueueItemBase();

            for (int i = 0; i < queueItemSetting.Length; i++)
            {
                string[] queueItemSettingPair = queueItemSetting[i].Split(new string[] { "¶" }, 2, StringSplitOptions.None);

                // check if the config key is in base64, if it is, convert it to plaintext and read it
                if (queueItemSettingPair[0].Contains("_base64"))
                {
                    queueItemSettingPair[1] = DecodeString(queueItemSettingPair[1]);
                    queueItemSettingPair[0] = queueItemSettingPair[0].Replace("_base64", "");
                }

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