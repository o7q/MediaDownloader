using System.IO;
using System.Windows.Forms;

namespace MediaDownloader.Tools
{
    public static class Files
    {
        public static void CleanPath(string path, string[] ignoredExtensions)
        {
            CleanFiles(path, ignoredExtensions);
            CleanFolders(path);
        }

        public static void CleanFiles(string path, string[] ignoredFiles)
        {
            // delete all files
            foreach (string file in Directory.GetFiles(path))
            {
                bool deleteFile = true;
                if (ignoredFiles != null)
                {
                    for (int i = 0; i < ignoredFiles.Length; i++)
                    {
                        string fileName = Path.GetFileName(file);
                        if (fileName == ignoredFiles[i])
                        {
                            deleteFile = false;
                            break;
                        }
                    }
                }

                if (deleteFile)
                    File.Delete(file);
            }
        }

        public static void CleanFolders(string path)
        {
            // delete all folders
            foreach (string folder in Directory.GetDirectories(path))
                Directory.Delete(folder, true);
        }
    }
}