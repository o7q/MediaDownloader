using System;
using System.IO;
using System.IO.Compression;

using MediaDownloader.Forms.CustomMessageBox;
using static MediaDownloader.Global;
using static MediaDownloader.Data.QueueItem.QueueItemManager;

namespace MediaDownloader.Tools.MigrationTools.Functions
{
    public static class QueueItemPack
    {
        public static void MigrateQueueItemPack(string mode)
        {
            string path = "";
            string extension = "";
            switch (mode)
            {
                case "queue":
                    path = "MediaDownloader\\config\\queue";
                    break;

                case "history":
                    path = "MediaDownloader\\config\\history";
                    break;
            }

            if (File.Exists(path + ".zip"))
                extension = ".zip";
            else if (File.Exists(path + ".pack"))
                extension = ".pack";

            string readMode = "";

            if (Directory.Exists(path))
            {
                readMode = "folder";
            }
            else if (File.Exists(path + extension))
            {
                readMode = "archive";
            }

            if (readMode != "")
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("MediaDownloader has detected config files from an older version.\n\nIt will attempt to migrate files from this directory:\n" + path, "OK", true);
                customMessageBox.ShowDialog();

                try
                {
                    if (readMode == "archive")
                    {
                        Directory.CreateDirectory(path);
                        ZipFile.ExtractToDirectory(path + extension, path);
                        File.Delete(path + extension);
                    }

                    string[] files = Directory.GetFiles(path);

                    Array.Sort(files, (a, b) =>
                    {
                        int numA = int.Parse(a.Substring(a.IndexOf("(") + 1, a.IndexOf(")") - a.IndexOf("(") - 1));
                        int numB = int.Parse(b.Substring(b.IndexOf("(") + 1, b.IndexOf(")") - b.IndexOf("(") - 1));
                        return numB.CompareTo(numA);
                    });

                    for (int i = 0; i < files.Length; i++)
                    {
                        HISTORY.Add(ReadQueueItemFromFile(files[i]));
                    }

                    Directory.Move(path, path + "_old");
                }
                catch (Exception ex)
                {
                    CustomMessageBox customMessageBoxErr = new CustomMessageBox("MediaDownloader was unable to migrate old config files!\n\nFull Error:\n" + ex, "OK", true);
                    customMessageBoxErr.ShowDialog();
                }
            }
        }
    }
}