using System;
using static MediaDownloader.Updater.ResourceReader;

namespace MediaDownloader.Updater
{
    public static class UpdateChecker
    {
        public static Tuple<bool, string> CheckForNewUpdate(string internal_version)
        {
            string remote_version = ReadRemoteResource("https://raw.githubusercontent.com/o7q/MediaDownloader/main/remote/version");

            if (remote_version != internal_version && remote_version != "")
                return Tuple.Create(true, remote_version);
            return Tuple.Create(false, "");
        }
    }
}