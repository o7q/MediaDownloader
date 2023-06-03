using System;
using System.Windows.Forms;

namespace MediaDownloader.Tools
{
    public static class Error
    {
        public static void redistError(string errMsg)
        {
            MessageBox.Show("\"" + errMsg + "\" was not found! Exiting MediaDownloader.\n\nMake sure you have \"yt-dlp.exe\" and \"ffmpeg.exe\" in a folder named \"MediaDownloader\" next to \"MediaDownloader.exe\".\nIf you are using scoop please make sure you have installed everything correctly.");
            Environment.Exit(1);
        }

        public static void installError(string file, Exception ex)
        {
            MessageBox.Show("Error while installing \"" + file + "\" from scoop!\n\nFull Error:\n" + ex);
        }
    }
}