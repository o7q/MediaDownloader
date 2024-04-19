using System.Collections.Generic;

using static MediaDownloader.Data.Config.ConfigStructure;
using static MediaDownloader.Data.QueueItem.QueueItemStructure;

namespace MediaDownloader
{
    public static class Global
    {
        public const string VERSION = "v4.4.1";
        public const string VERSION_INTERNAL = "v4.4.1.0";
        public static string VERSION_INTERNAL_REMOTE;

        public static List<QueueItemBase> QUEUE = new List<QueueItemBase>();
        public static List<QueueItemBase> HISTORY = new List<QueueItemBase>();

        public static ConfigBase CONFIG = new ConfigBase();
        public static bool IS_DOWNLOADING = false;
    }
}