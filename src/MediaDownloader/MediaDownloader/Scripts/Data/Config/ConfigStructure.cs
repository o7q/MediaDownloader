namespace MediaDownloader.Data.Config
{
    public class ConfigStructure
    {
        public struct ConfigBase
        {
            // user config
            public bool HISTORY_ENABLE;
            public bool NOTIFICATIONS_ENABLE;
            public bool DATA_PACKING_ENABLE;
            public bool TRUSTED_URLS_ENABLE;
            public string TRUSTED_URLS;

            // program config
            public bool MENU_EXPANDED_ENABLE;

            public int QUEUE_SELECTED_INDEX;

            public int HISTORY_SELECTED_INDEX;
            public int HISTORY_SAVE_INDEX;
        }
    }
}