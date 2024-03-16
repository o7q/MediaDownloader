using System;
using System.Text.RegularExpressions;

using static MediaDownloader.Updater.ResourceReader;

namespace MediaDownloader.Updater
{
    public static class UpdateChecker
    {
        public static Tuple<bool, string> CheckForNewUpdate(string internal_version)
        {
            string remote_internal_version = ReadRemoteResource("https://raw.githubusercontent.com/o7q/MediaDownloader/main/remote/version");

            int internal_version_int, remote_internal_version_int;
            int.TryParse(Regex.Replace(internal_version, "[^0-9]", ""), out internal_version_int);
            int.TryParse(Regex.Replace(remote_internal_version, "[^0-9]", ""), out remote_internal_version_int);

            if (internal_version_int < remote_internal_version_int && internal_version_int != 0 && remote_internal_version_int != 0)
                return Tuple.Create(true, remote_internal_version);
            return Tuple.Create(false, "");
        }
    }
}