﻿using static MediaDownloader.Data.Structure.ConfigStructure;

namespace MediaDownloader.Data
{
    public static class Storage
    {
        public const string VERSION = "v4.1.1";
        public static ConfigBase CONFIG = new ConfigBase();
        public static bool IS_DOWNLOADING = false;
    }
}