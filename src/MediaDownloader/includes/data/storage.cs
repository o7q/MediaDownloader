namespace MediaDownloader.Data
{
    public static class Storage
    {
        public const string version = "v3.9.0";

        public static string CONFIG_main = "MediaDownloader\\config\\config.md";
        public static string CONFIG_lock = "MediaDownloader\\config\\_lock";
        public static string CONFIG_base = "MediaDownloader\\config\\_base";

        public static string WORKING_md = "MediaDownloader\\working\\md.bat";
        public static string WORKING_md_header = "MediaDownloader\\working\\md_header";

        public static string REDIST_ytdlp = "MediaDownloader\\yt-dlp.exe";
        public static string REDIST_ffmpeg = "MediaDownloader\\ffmpeg.exe";

        // downloads
        public static string baseQuality = " -b:v 100M -b:a 320K ";
        public static string state_downloading = "[DOWNLOADING]\n";
        public static string state_preprocess = "[PRE-PROCESSING]\n";
        public static string state_cpu1 = "[CPU PROCESSING - PASS 1]\n";
        public static string state_cpu2 = "[CPU PROCESSING - PASS 2]\n";
        public static string state_cpu3 = "[CPU PROCESSING - PASS 3]\n";
        public static string state_gpu1 = "[GPU PROCESSING - PASS 1]\n";
        public static string state_finished = "[FINISHED]\n";
    }
}