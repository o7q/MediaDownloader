using System.IO;
using static MediaDownloader.Data.Storage;
using static MediaDownloader.Data.Structure.QueueItemStructure;
using static MediaDownloader.Tools.Shell;

namespace MediaDownloader.Managers.Media
{
    public static class ConvertManager
    {
        public static void ConvertMedia(QueueItemBase queueItem, string downloadFile)
        {
            string videoCodec = "";
            string audioCodec = "";
            string mediaExtension = "";
            string mediaType = "";

            switch (queueItem.OUTPUT_FORMAT)
            {
                case "mp4":
                    videoCodec = "-c:v libx264 ";
                    audioCodec = "-c:a aac ";
                    mediaExtension = "mp4";
                    mediaType = "video";
                    break;
                case "mp4 (nvidia)":
                    videoCodec = "-c:v h264_nvenc ";
                    audioCodec = "-c:a aac ";
                    mediaExtension = "mp4";
                    mediaType = "video";
                    break;
                case "mp4 (amd)":
                    videoCodec = "-c:v h264_amf ";
                    audioCodec = "-c:a aac ";
                    mediaExtension = "mp4";
                    mediaType = "video";
                    break;
                case "webm":
                    videoCodec = "-c:v libvpx-vp9 ";
                    audioCodec = "-c:a libopus ";
                    mediaExtension = "webm";
                    mediaType = "video";
                    break;
                case "avi (uncompressed)":
                    videoCodec = "-c:v rawvideo ";
                    audioCodec = "-c:a pcm_s16le ";
                    mediaExtension = "avi";
                    mediaType = "video";
                    break;
                case "mp3":
                    videoCodec = "-vn ";
                    audioCodec = "-c:a libmp3lame ";
                    mediaExtension = "mp3";
                    mediaType = "audio";
                    break;
                case "wav":
                    videoCodec = "-vn ";
                    audioCodec = "-c:a pcm_s16le ";
                    mediaExtension = "wav";
                    mediaType = "audio";
                    break;
                case "ogg":
                    videoCodec = "-vn ";
                    audioCodec = "-c:a libvorbis ";
                    mediaExtension = "ogg";
                    mediaType = "audio";
                    break;
                case "aac":
                    videoCodec = "-vn ";
                    audioCodec = "-c:a aac ";
                    mediaExtension = "aac";
                    mediaType = "audio";
                    break;
                case "opus":
                    videoCodec = "-vn ";
                    audioCodec = "-c:a libopus ";
                    mediaExtension = "opus";
                    mediaType = "audio";
                    break;
                case "wma":
                    videoCodec = "-vn ";
                    audioCodec = "-c:a wmav2 ";
                    mediaExtension = "wma";
                    mediaType = "audio";
                    break;
                case "flac (lossless)":
                    videoCodec = "-vn ";
                    audioCodec = "-c:a flac ";
                    mediaExtension = "flac";
                    mediaType = "audio";
                    break;
                case "m4a (lossless)":
                    videoCodec = "-vn ";
                    audioCodec = "-c:a alac ";
                    mediaExtension = "m4a";
                    mediaType = "audio";
                    break;
                case "gif":
                    videoCodec = "-c:v libx264 ";
                    audioCodec = "-an ";
                    mediaExtension = "mp4";
                    mediaType = "gif";
                    break;
                case "png (sequence)":
                    videoCodec = "-c:v libx264 ";
                    audioCodec = "-an ";
                    mediaExtension = "mp4";
                    mediaType = "sequence";
                    break;
                case "jpg (sequence)":
                    videoCodec = "-c:v libx264 ";
                    audioCodec = "-an ";
                    mediaExtension = "mp4";
                    mediaType = "sequence";
                    break;
                case "(custom arguments)":
                    mediaType = "custom";
                    break;
            }

            if (mediaType == "custom")
            {
                if (queueItem.OUTPUT_FFMPEG_ARGUMENTS == "" || queueItem.OUTPUT_FFMPEG_ARGUMENTS == null)
                {
                    string copyLocation = queueItem.OUTPUT_LOCATION == "" || queueItem.OUTPUT_LOCATION == null ? "Downloads" : queueItem.OUTPUT_LOCATION;
                    File.Copy(downloadFile, copyLocation + "\\" + queueItem.OUTPUT_NAME + Path.GetExtension(downloadFile));
                }
                else
                    StartProcess("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe", "-i \"" + downloadFile + "\" " + queueItem.OUTPUT_FFMPEG_ARGUMENTS, "MediaDownloader " + VERSION + "   [CONVERTING  :  CUSTOM ARGUMENTS]", queueItem.OUTPUT_ENABLE_DISPLAY, queueItem.OUTPUT_ENABLE_PAUSE);
                return;
            }

            string bitrateSettings = "";

            switch (mediaType)
            {
                case "video":
                case "gif":
                case "sequence":
                    bitrateSettings = "-b:v " + queueItem.OUTPUT_BITRATE_VIDEO + " -b:a " + queueItem.OUTPUT_BITRATE_AUDIO + " ";
                    break;
                case "audio":
                    bitrateSettings = "-b:a " + queueItem.OUTPUT_BITRATE_AUDIO + " ";
                    break;
            }

            string convertScript = " ";
            string codecScript = videoCodec + audioCodec + bitrateSettings;

            if (queueItem.OUTPUT_ENABLE_CHANGE_RESOLUTION == true && mediaType != "audio")
                convertScript += "-vf \"scale=" + queueItem.OUTPUT_RESOLUTION_WIDTH + ":" + queueItem.OUTPUT_RESOLUTION_HEIGHT + ",setsar=1\" ";

            if (queueItem.OUTPUT_ENABLE_CHANGE_FRAMERATE == true && mediaType != "audio")
                convertScript += "-r " + queueItem.OUTPUT_FRAMERATE + " ";

            if (queueItem.OUTPUT_ENABLE_CHANGE_TIMEFRAME == true)
                convertScript += "-ss " + queueItem.OUTPUT_TIMEFRAME_START + " -to " + queueItem.OUTPUT_TIMEFRAME_END + " ";

            string convertArguments = "-loglevel verbose -y -i \"" + downloadFile + "\"" + convertScript + codecScript + "\"MediaDownloader\\working\\converted." + mediaExtension + "\"";
            StartProcess("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe", convertArguments, "MediaDownloader " + VERSION + "   [CONVERTING  :  VIDEO/AUDIO]", queueItem.OUTPUT_ENABLE_DISPLAY, queueItem.OUTPUT_ENABLE_PAUSE);

            switch (mediaType)
            {
                case "video":
                case "audio":
                    {
                        string copyLocation = queueItem.OUTPUT_LOCATION == "" || queueItem.OUTPUT_LOCATION == null ? "Downloads" : queueItem.OUTPUT_LOCATION;
                        File.Copy("MediaDownloader\\working\\converted." + mediaExtension, copyLocation + "\\" + queueItem.OUTPUT_NAME + "." + mediaExtension);
                    }
                    break;

                case "gif":
                    {
                        string gifPaletteArguments = "-loglevel verbose -y -i \"MediaDownloader\\working\\converted.mp4\" -vf palettegen \"MediaDownloader\\working\\gif_palette.png\"";
                        StartProcess("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe", gifPaletteArguments, "MediaDownloader " + VERSION + "   [CONVERTING  :  GIF PALETTE]", queueItem.OUTPUT_ENABLE_DISPLAY, queueItem.OUTPUT_ENABLE_PAUSE);
                        string gifConvertArguments = "-loglevel verbose -y -i \"MediaDownloader\\working\\converted.mp4\" -i \"MediaDownloader\\working\\gif_palette.png\" -lavfi \"paletteuse\" \"MediaDownloader\\working\\converted.gif\"";
                        StartProcess("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe", gifConvertArguments, "MediaDownloader " + VERSION + "   [CONVERTING  :  GIF]", queueItem.OUTPUT_ENABLE_DISPLAY, queueItem.OUTPUT_ENABLE_PAUSE);

                        string copyLocation = queueItem.OUTPUT_LOCATION == "" || queueItem.OUTPUT_LOCATION == null ? "Downloads" : queueItem.OUTPUT_LOCATION;
                        File.Copy("MediaDownloader\\working\\converted.gif", copyLocation + "\\" + queueItem.OUTPUT_NAME + ".gif");
                    }
                    break;

                case "sequence":
                    {
                        Directory.CreateDirectory("MediaDownloader\\working\\converted");

                        string imageExtension = "";
                        switch (queueItem.OUTPUT_FORMAT)
                        {
                            case "png (sequence)":
                                imageExtension = "png";
                                break;
                            case "jpg (sequence)":
                                imageExtension = "jpg";
                                break;
                        }

                        string sequenceConvertArguments = "-loglevel verbose -y -i \"MediaDownloader\\working\\converted.mp4\" \"MediaDownloader\\working\\converted\\" + queueItem.OUTPUT_NAME + ".%d." + imageExtension;
                        StartProcess("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe", sequenceConvertArguments, "MediaDownloader " + VERSION + "   [CONVERTING  : IMAGE SEQUENCE]", queueItem.OUTPUT_ENABLE_DISPLAY, queueItem.OUTPUT_ENABLE_PAUSE);

                        string copyLocation = queueItem.OUTPUT_LOCATION == "" || queueItem.OUTPUT_LOCATION == null ? "Downloads" : queueItem.OUTPUT_LOCATION;
                        Directory.Move("MediaDownloader\\working\\converted", copyLocation + "\\" + queueItem.OUTPUT_NAME);
                    }
                    break;
            }
        }
    }
}