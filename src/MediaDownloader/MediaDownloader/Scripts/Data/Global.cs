using static MediaDownloader.Data.Structure.ConfigStructure;

namespace MediaDownloader.Data
{
    public static class Global
    {
        public const string VERSION = "v4.2.0";

        public static ConfigBase CONFIG = new ConfigBase();
        public static bool IS_DOWNLOADING = false;
    }
}