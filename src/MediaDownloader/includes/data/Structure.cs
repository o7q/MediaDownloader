namespace MediaDownloader.Data
{
    public class Structure
    {
        public struct ConfigBase
        {
            public string URL;

            public string DOWNLOAD_NAME;

            public int FORMAT_INDEX;

            public bool USE_TIMEFRAME;
            public string TIMEFRAME_START;
            public string TIMEFRAME_END;

            public string DOWNLOAD_LOCATION;

            public string VIDEO_BITRATE;
            public string AUDIO_BITRATE;

            public string GIF_RESOLUTION;
            public string GIF_FRAMERATE;

            public bool USE_GPU_ENCODER;
            public string GPU_ENCODER;

            public bool USE_CPU_ENCODER;

            public string YTDLP_ARGUMENTS;

            public bool USE_DISPLAY_OUTPUT;
            public bool USE_KEEP_OUTPUT;
        }
    }
}