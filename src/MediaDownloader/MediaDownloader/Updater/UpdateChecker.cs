using System;
using System.IO;
using System.Net;

namespace MediaDownloader.Updater
{
    public static class UpdateChecker
    {
        public static Tuple<bool, string> CheckForNewUpdate(string internal_version)
        {
            string remote_version = "";
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://raw.githubusercontent.com/o7q/MediaDownloader/main/remote/version");
                StreamReader reader = new StreamReader(stream);
                remote_version = reader.ReadToEnd();
            }
            catch { }

            if (remote_version != internal_version && remote_version != "")
                return Tuple.Create(true, remote_version);
            return Tuple.Create(false, "");
        }
    }
}