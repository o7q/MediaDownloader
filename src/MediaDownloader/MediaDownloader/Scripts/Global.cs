using static MediaDownloader.Data.Config.ConfigStructure;

namespace MediaDownloader
{
    public static class Global
    {
        public const string VERSION = "v4.3.1";
        public const string VERSION_INTERNAL = "v4.3.1.0";
        public static string VERSION_INTERNAL_REMOTE;

        public static ConfigBase CONFIG = new ConfigBase();
        public static bool IS_DOWNLOADING = false;
    }
}