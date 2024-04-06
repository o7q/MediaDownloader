namespace MediaDownloader.Data.Config
{
    public class ConfigStructure
    {
        public struct ConfigBase
        {
            // user config
            public bool HISTORY_ENABLE;
            public bool NOTIFICATIONS_ENABLE;
            public bool TRUSTED_URLS_ENABLE;
            public string TRUSTED_URLS;

            public bool OUTPUT_DISPLAY_ENABLE;
            public bool OUTPUT_PAUSE_ENABLE;

            // program config
            public bool MENU_EXPANDED_ENABLE;

            public int QUEUE_SELECTED_INDEX;

            public int HISTORY_SELECTED_INDEX;
        }
    }
}