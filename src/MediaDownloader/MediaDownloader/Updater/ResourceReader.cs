using System.IO;
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
    }
}