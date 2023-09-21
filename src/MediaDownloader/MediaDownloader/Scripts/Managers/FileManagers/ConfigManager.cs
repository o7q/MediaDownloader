using System.IO;
using System.Text;
using static MediaDownloader.Data.Structure.ConfigStructure;

namespace MediaDownloader.Managers.FileManagers
{
    public static class ConfigManager
    {
        public static void WriteConfig(ConfigBase queueItem, string location)
        {
            var sb = new StringBuilder();
            foreach (var field in typeof(ConfigBase).GetFields())
            {
                object value = field.GetValue(queueItem);
                if (value != null)
                    sb.Append(field.Name + '=' + value.ToString());
                sb.Append('\n');
            }
            sb.Length--;
            File.WriteAllText(location, sb.ToString());
        }

        public static ConfigBase ReadConfig(string location)
        {
            ConfigBase config = new ConfigBase();

            string configRaw = File.ReadAllText(location);
            string[] configSetting = configRaw.Split('\n');

            for (int i = 0; i < configSetting.Length; i++)
            {
                string[] configSettingPair = configSetting[i].Split('=');

                switch (configSettingPair[0])
                {
                    case "MENU_EXPANDED_ENABLE": config.MENU_EXPANDED_ENABLE = bool.Parse(configSettingPair[1]); break;

                    case "QUEUE_SELECTED_INDEX": config.QUEUE_SELECTED_INDEX = int.Parse(configSettingPair[1]); break;

                    case "HISTORY_ENABLE": config.HISTORY_ENABLE = bool.Parse(configSettingPair[1]); break;
                    case "HISTORY_SELECTED_INDEX": config.HISTORY_SELECTED_INDEX = int.Parse(configSettingPair[1]); break;
                    case "HISTORY_SAVE_INDEX": config.HISTORY_SAVE_INDEX = int.Parse(configSettingPair[1]); break;

                    case "DATA_PACKING_ENABLE": config.DATA_PACKING_ENABLE = bool.Parse(configSettingPair[1]); break;
                    case "NOTIFICATIONS_ENABLE": config.NOTIFICATIONS_ENABLE = bool.Parse(configSettingPair[1]); break;
                }
            }

            return config;
        }
    }
}