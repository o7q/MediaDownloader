﻿using System;
using System.IO;
using System.Text;

using static MediaDownloader.Data.Config.ConfigStructure;

namespace MediaDownloader.Data.Config
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
                string[] configSettingPair = configSetting[i].Split(new string[] { "=" }, 2, StringSplitOptions.None);

                switch (configSettingPair[0])
                {
                    // user config
                    case "HISTORY_ENABLE": config.HISTORY_ENABLE = bool.Parse(configSettingPair[1]); break;
                    case "NOTIFICATIONS_ENABLE": config.NOTIFICATIONS_ENABLE = bool.Parse(configSettingPair[1]); break;
                    case "TRUSTED_URLS_ENABLE": config.TRUSTED_URLS_ENABLE = bool.Parse(configSettingPair[1]); break;
                    case "TRUSTED_URLS": config.TRUSTED_URLS = configSettingPair[1]; break;
                    case "COMPLETE_SOUND_ENABLE": config.COMPLETE_SOUND_ENABLE = bool.Parse(configSettingPair[1]); break;
                    case "COMPLETE_SOUND_PATH": config.COMPLETE_SOUND_PATH = configSettingPair[1]; break;

                    case "OUTPUT_DISPLAY_ENABLE": config.OUTPUT_DISPLAY_ENABLE = bool.Parse(configSettingPair[1]); break;
                    case "OUTPUT_PAUSE_ENABLE": config.OUTPUT_PAUSE_ENABLE = bool.Parse(configSettingPair[1]); break;

                    // program config
                    case "MENU_EXPANDED_ENABLE": config.MENU_EXPANDED_ENABLE = bool.Parse(configSettingPair[1]); break;

                    case "QUEUE_SELECTED_INDEX": config.QUEUE_SELECTED_INDEX = int.Parse(configSettingPair[1]); break;

                    case "HISTORY_SELECTED_INDEX": config.HISTORY_SELECTED_INDEX = int.Parse(configSettingPair[1]); break;
                }
            }

            return config;
        }
    }
}