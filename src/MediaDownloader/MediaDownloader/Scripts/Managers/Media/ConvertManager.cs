using System.IO;
using static MediaDownloader.Data.Global;
using static MediaDownloader.Data.Structure.QueueItemStructure;
using static MediaDownloader.Tools.Shell;

namespace MediaDownloader.Managers.Media
{
    public static class ConvertManager
    {
        public static void ConvertMedia(QueueItemBase queueItem, string downloadFile, string outputFile)
        {
            string videoCodec = "";
            string audioCodec = "";
            string mediaExtension = "";
            string mediaType = "";

            switch (queueItem.OUTPUT_FORMAT)
            {
                case "mp4 (fast)":
                    videoCodec = "-c:v copy ";
                    audioCodec = "-c:a copy ";
                    mediaExtension = "mp4";
                    mediaType = "video";
                    break;
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
                case "png (thumbnail)":
                    videoCodec = "";
                    audioCodec = "";
                    mediaExtension = "png";
                    mediaType = "thumbnail";
                    break;
                case "jpg (thumbnail)":
                    videoCodec = "";
                    audioCodec = "";
                    mediaExtension = "jpg";
                    mediaType = "thumbnail";
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
                    File.Copy(downloadFile, copyLocation + "\\" + outputFile + Path.GetExtension(downloadFile));
                }
                else
                    StartProcess("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe", "-i \"" + downloadFile + "\" " + queueItem.OUTPUT_FFMPEG_ARGUMENTS, "MediaDownloader " + VERSION + "   [CONVERTING  :  CUSTOM ARGUMENTS]", queueItem.OUTPUT_DISPLAY_ENABLE, queueItem.OUTPUT_PAUSE_ENABLE);
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

            if (queueItem.OUTPUT_CHANGE_RESOLUTION_ENABLE)
                convertScript += "-vf \"scale=" + queueItem.OUTPUT_RESOLUTION_WIDTH + ":" + queueItem.OUTPUT_RESOLUTION_HEIGHT + ",setsar=1\" ";

            if (queueItem.OUTPUT_CHANGE_FRAMERATE_ENABLE)
                convertScript += "-r " + queueItem.OUTPUT_FRAMERATE + " ";

            if (queueItem.OUTPUT_CHANGE_TIMEFRAME_ENABLE)
            {
                string startTime = queueItem.OUTPUT_TIMEFRAME_TRIM_FROM_START_ENABLE ? "" : "-ss " + queueItem.OUTPUT_TIMEFRAME_START + " ";
                string endTime = queueItem.OUTPUT_TIMEFRAME_TRIM_TO_END_ENABLE ? "" : "-to " + queueItem.OUTPUT_TIMEFRAME_END + " ";
                convertScript += startTime + endTime;
            }

            string convertArguments = "-loglevel verbose -y -i \"" + downloadFile + "\"" + convertScript + codecScript + "\"MediaDownloader\\temp\\converted." + mediaExtension + "\"";
            StartProcess("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe", convertArguments, "MediaDownloader " + VERSION + "   [CONVERTING  :  " + mediaType.ToUpper() + "]", queueItem.OUTPUT_DISPLAY_ENABLE, queueItem.OUTPUT_PAUSE_ENABLE);

            switch (mediaType)
            {
                case "video":
                case "audio":
                case "thumbnail":
                    {
                        string copyLocation = queueItem.OUTPUT_LOCATION == "" || queueItem.OUTPUT_LOCATION == null ? "Downloads" : queueItem.OUTPUT_LOCATION;
                        File.Copy("MediaDownloader\\temp\\converted." + mediaExtension, copyLocation + "\\" + outputFile + "." + mediaExtension);
                    }
                    break;

                case "gif":
                    {
                        string gifPaletteArguments = "-loglevel verbose -y -i \"MediaDownloader\\temp\\converted.mp4\" -vf palettegen \"MediaDownloader\\temp\\converted_gif_palette.png\"";
                        StartProcess("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe", gifPaletteArguments, "MediaDownloader " + VERSION + "   [CONVERTING  :  GIF PALETTE]", queueItem.OUTPUT_DISPLAY_ENABLE, queueItem.OUTPUT_PAUSE_ENABLE);
                        string gifConvertArguments = "-loglevel verbose -y -i \"MediaDownloader\\temp\\converted.mp4\" -i \"MediaDownloader\\temp\\converted_gif_palette.png\" -lavfi \"paletteuse\" \"MediaDownloader\\temp\\converted_gif.gif\"";
                        StartProcess("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe", gifConvertArguments, "MediaDownloader " + VERSION + "   [CONVERTING  :  GIF]", queueItem.OUTPUT_DISPLAY_ENABLE, queueItem.OUTPUT_PAUSE_ENABLE);

                        string copyLocation = queueItem.OUTPUT_LOCATION == "" || queueItem.OUTPUT_LOCATION == null ? "Downloads" : queueItem.OUTPUT_LOCATION;
                        File.Copy("MediaDownloader\\temp\\converted_gif.gif", copyLocation + "\\" + outputFile + ".gif");
                    }
                    break;

                case "sequence":
                    {
                        Directory.CreateDirectory("MediaDownloader\\temp\\converted_sequence");

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

                        string sequenceConvertArguments = "-loglevel verbose -y -i \"MediaDownloader\\temp\\converted.mp4\" \"MediaDownloader\\temp\\converted_sequence\\" + outputFile + ".%d." + imageExtension;
                        StartProcess("MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe", sequenceConvertArguments, "MediaDownloader " + VERSION + "   [CONVERTING  : IMAGE SEQUENCE]", queueItem.OUTPUT_DISPLAY_ENABLE, queueItem.OUTPUT_PAUSE_ENABLE);

                        string copyLocation = queueItem.OUTPUT_LOCATION == "" || queueItem.OUTPUT_LOCATION == null ? "Downloads" : queueItem.OUTPUT_LOCATION;
                        Directory.Move("MediaDownloader\\temp\\converted_sequence", copyLocation + "\\" + outputFile);
                    }
                    break;
            }
        }
    }
}