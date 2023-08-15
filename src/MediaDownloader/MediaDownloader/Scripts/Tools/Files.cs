using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MediaDownloader.Tools
{
    public static class Files
    {
        public static void CleanFolder(string path)
        {
            // delete all files
            foreach (string file in Directory.GetFiles(path))
                File.Delete(file);

            // delete all folders
            foreach (string folder in Directory.GetDirectories(path))
                Directory.Delete(folder, true);
        }
    }
}