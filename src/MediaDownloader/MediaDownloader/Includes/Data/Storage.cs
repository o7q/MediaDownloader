namespace MediaDownloader.Data
{
    public static class Storage
    {
        public const string version = "v3.10.0";

        public const string CONFIG_main = "MediaDownloader\\config\\config.md";
        public const string CONFIG_lock = "MediaDownloader\\config\\_lock";
        public const string CONFIG_base = "MediaDownloader\\config\\_base";

        public const string WORKING_md = "MediaDownloader\\working\\md.bat";
        public const string WORKING_md_header = "MediaDownloader\\working\\md_header";

        public const string REDIST_ytdlp = "MediaDownloader\\yt-dlp.exe";
        public const string REDIST_ffmpeg = "MediaDownloader\\ffmpeg.exe";

        // downloads
        public const string state_downloading = "[DOWNLOADING]\n";
        public const string state_preprocess = "[CPU PRE-PROCESSING - PASS 1]\n";
        public const string state_cpu1 = "[CPU PROCESSING - PASS 1]\n";
        public const string state_cpu2 = "[CPU PROCESSING - PASS 2]\n";
        public const string state_cpu3 = "[CPU PROCESSING - PASS 3]\n";
        public const string state_gpu1 = "[GPU PROCESSING - PASS 1]\n";
        public const string state_finalize = "[FINALIZING]\n";
        public const string state_finished = "[FINISHED]\n";
    }
}