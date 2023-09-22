using System.IO;
using System.Net;
using System.Reflection;

namespace MediaDownloader.Updater
{
    public static class ResourceReader
    {
        public static string ReadLocalResource(string path)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(path))
            {
                if (stream == null)
                    return null;

                using (StreamReader reader = new StreamReader(stream))
                {
                    string resourceContent = reader.ReadToEnd();
                    return resourceContent;
                }
            }
        }

        public static string ReadRemoteResource(string url)
        {
            string remote_content = "";
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(url);
                StreamReader reader = new StreamReader(stream);
                remote_content = reader.ReadToEnd();
            }
            catch { }

            return remote_content;
        }
    }
}