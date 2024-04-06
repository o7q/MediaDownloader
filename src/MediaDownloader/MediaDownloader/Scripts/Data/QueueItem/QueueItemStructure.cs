namespace MediaDownloader.Data.QueueItem
{
    public class QueueItemStructure
    {
        public struct QueueItemBase
        {
            public string URL;
            public bool OUTPUT_PLAYLIST_ENABLE;

            public string OUTPUT_NAME;
            public bool OUTPUT_NAME_AUTO_ENABLE;

            public string OUTPUT_LOCATION;

            public string OUTPUT_FORMAT;

            public bool OUTPUT_CHANGE_TIMEFRAME_ENABLE;
            public string OUTPUT_TIMEFRAME_START;
            public string OUTPUT_TIMEFRAME_END;
            public bool OUTPUT_TIMEFRAME_TRIM_FROM_START_ENABLE;
            public bool OUTPUT_TIMEFRAME_TRIM_TO_END_ENABLE;

            public string OUTPUT_BITRATE_VIDEO;
            public string OUTPUT_BITRATE_AUDIO;

            public bool OUTPUT_CHANGE_RESOLUTION_ENABLE;
            public string OUTPUT_RESOLUTION_WIDTH;
            public string OUTPUT_RESOLUTION_HEIGHT;

            public bool OUTPUT_CHANGE_FRAMERATE_ENABLE;
            public string OUTPUT_FRAMERATE;

            public string OUTPUT_YTDLP_ARGUMENTS;
            public string OUTPUT_FFMPEG_ARGUMENTS;
        }
    }
}