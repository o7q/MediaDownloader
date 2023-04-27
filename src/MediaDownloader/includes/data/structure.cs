namespace MediaDownloader.Data
{
    public static class Structure
    {
        public struct ConfigBase
        {
            public string URL;
            public string DOWNLOAD_NAME;
            public int FORMAT_INDEX;
            public string DOWNLOAD_LOCATION;
            public bool USE_TIMEFRAME;
            public string TIMEFRAME_START;
            public string TIMEFRAME_END;
            public string GIF_RESOLUTION;
            public string GIF_FRAMERATE;
            public bool USE_GPU_ENCODER;
            public string GPU_ENCODER;
            public string YTDLP_ARGUMENTS;
            public bool USE_DISPLAY_OUTPUT;
            public bool USE_KEEP_OUTPUT;
            public bool USE_CPU_ENCODER;
        }
    }
}