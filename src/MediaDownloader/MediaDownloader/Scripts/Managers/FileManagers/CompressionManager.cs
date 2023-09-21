using System.IO;
using System.IO.Compression;
using static MediaDownloader.Data.Global;

namespace MediaDownloader.Managers.FileManagers
{
    public static class CompressionManager
    {
        public static void CompressFolder(string folder, string path)
        {
            if (CONFIG.DATA_PACKING_ENABLE)
            {
                ZipFile.CreateFromDirectory(folder, path, CompressionLevel.Fastest, false);
                Directory.Delete(folder, true);
            }
            else
                Directory.Move(folder, Path.ChangeExtension(path, ""));
        }

        public static void DecompressFolder(string name, string path)
        {
            if ((CONFIG.DATA_PACKING_ENABLE && !Directory.Exists(Path.ChangeExtension(name, ""))) || File.Exists(name))
            {
                ZipFile.ExtractToDirectory(name, path);
                File.Delete(name);
            }
            else
                Directory.Move(Path.ChangeExtension(name, ""), path);
        }
    }
}