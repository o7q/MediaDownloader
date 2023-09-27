using static MediaDownloader.Data.Config.ConfigStructure;

namespace MediaDownloader
{
    public static class Global
    {
        public const string VERSION = "v4.3.0";
        public const string VERSION_INTERNAL = "v4.3.0.0";
        public static string VERSION_REMOTE;

        public static ConfigBase CONFIG = new ConfigBase();
        public static bool IS_DOWNLOADING = false;
    }
}