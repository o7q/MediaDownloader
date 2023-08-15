namespace MediaDownloader.Data.Structure
{
    public class QueueItemStructure
    {
        public struct QueueItemBase
        {
            public string URL;

            public string OUTPUT_NAME;
            public string OUTPUT_LOCATION;

            public string OUTPUT_FORMAT;

            public string OUTPUT_BITRATE_VIDEO;
            public string OUTPUT_BITRATE_AUDIO;

            public bool OUTPUT_ENABLE_CHANGE_RESOLUTION;
            public string OUTPUT_RESOLUTION_WIDTH;
            public string OUTPUT_RESOLUTION_HEIGHT;

            public bool OUTPUT_ENABLE_CHANGE_FRAMERATE;
            public string OUTPUT_FRAMERATE;

            public bool OUTPUT_ENABLE_CHANGE_TIMEFRAME;
            public string OUTPUT_TIMEFRAME_START;
            public string OUTPUT_TIMEFRAME_END;

            public string OUTPUT_YTDLP_ARGUMENTS;
            public string OUTPUT_FFMPEG_ARGUMENTS;

            public bool OUTPUT_ENABLE_DISPLAY;
            public bool OUTPUT_ENABLE_PAUSE;
        }
    }
}