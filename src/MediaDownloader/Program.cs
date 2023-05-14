using System;
using System.IO;
using System.Text;
using System.Timers;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static MediaDownloader.Tools.Text;
using static MediaDownloader.Tools.Error;
using static MediaDownloader.Data.Storage;
using static MediaDownloader.Data.Variables;
using static MediaDownloader.Data.Structure;

namespace MediaDownloader
{
    public partial class Program : Form
    {
        // configure mouse window events
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;

        // grab dlls for mousedown
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // program events

        public Program()
        {
            InitializeComponent();
        }

        ConfigBase config = new ConfigBase();

        // program load
        private void Program_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("MediaDownloader");

            if (UseConfigCheckbox.Checked == false)
                ClearSettings();

            if (File.Exists(CONFIG_lock) == true)
            {
                if (File.ReadAllText(CONFIG_lock) == "1")
                    UseConfigCheckbox.Checked = true;
            }

            #region loadConfig
            // load data from file
            if (File.Exists(CONFIG_main))
            {
                string configFile = File.ReadAllText(CONFIG_main);
                string[] configSetting = configFile.Split('\n');

                for (int i = 0; i < configSetting.Length; i++)
                {
                    string[] configSettingPair = configSetting[i].Split('¶');

                    switch (configSettingPair[0])
                    {
                        case "URL": UrlTextbox.Text = configSettingPair[1]; break;

                        case "DOWNLOAD_NAME": FilenameTextbox.Text = configSettingPair[1]; break;
                        case "FORMAT_INDEX": FormatCombobox.SelectedIndex = int.Parse(configSettingPair[1]); break;

                        case "VIDEO_BITRATE": VideoBitrateTextbox.Text = configSettingPair[1]; break;
                        case "AUDIO_BITRATE": AudioBitrateTextbox.Text = configSettingPair[1]; break;

                        case "USE_TIMEFRAME": UseTimeframeCheckbox.Checked = bool.Parse(configSettingPair[1]); break;
                        case "TIMEFRAME_START": TimeframeStartTextbox.Text = configSettingPair[1]; break;
                        case "TIMEFRAME_END": TimeframeEndTextbox.Text = configSettingPair[1]; break;

                        case "DOWNLOAD_LOCATION": config.DOWNLOAD_LOCATION = configSettingPair[1]; break;

                        case "GIF_RESOLUTION": GifResolutionTextbox.Text = configSettingPair[1]; break;
                        case "GIF_FRAMERATE": GifFramerateTextbox.Text = configSettingPair[1]; break;

                        case "USE_GPU_ENCODER": UseGpuCheckbox.Checked = bool.Parse(configSettingPair[1]); break;
                        case "GPU_ENCODER": GpuEncoderTextbox.Text = configSettingPair[1]; break;

                        case "USE_CPU_ENCODER": UseCpuCheckbox.Checked = bool.Parse(configSettingPair[1]); break;

                        case "YTDLP_ARGUMENTS": YtdlpArgumentsTextbox.Text = configSettingPair[1]; break;

                        case "USE_DISPLAY_OUTPUT": DisplayOutputCheckbox.Checked = bool.Parse(configSettingPair[1]); break;
                        case "USE_KEEP_OUTPUT": KeepOutputCheckbox.Checked = bool.Parse(configSettingPair[1]); break;
                    }
                }
            }
            #endregion

            #region loadTooltips
            // bind tooltips
            string[] tooltipMap = {
                "BannerPicture", "MediaDownloader by o7q",
                "VersionLabel", "Version " + version,

                "MinimizeButton", "Minimize",
                "ExitButton", "Close",

                "UrlLabel", "URL to be downloaded",
                "UrlTextbox", "URL to be downloaded",

                "FilenameLabel", "File name for the download",
                "FilenameTextbox", "File name for the download",

                "FormatLabel", "Media format for download",
                "FormatCombobox", "Media format for download",

                "ViewAvailableFormatsButton", "Display all the available media formats found on the server for the specified URL",

                "UseTimeframeCheckbox", "Trim the download to a specific length with a start and end timestamp - Examples: \"0:00 - 0:10\" | \"1:25 - 2:30\" | \"2:30:40 - 3:05:15\"",
                "TimeframeStartLabel", "Trim start time",
                "TimeframeStartTextbox", "Trim start time",
                "TimeframeEndLabel", "Trim end time",
                "TimeframeEndTextbox", "Trim end time",

                "DownloadButton", "Download from the URL using the configured options",

                "ChangeLocationButton", "Change the folder location for download",
                "OpenLocationButton", "Open the selected download location in the file explorer",
                "ClearLocationButton", "Reset the selected download location",
                "DirectoryLabel", "Currently selected download location [" + config.DOWNLOAD_LOCATION + "]",

                "MoreOptionsLabel", "More extensive options",

                "BitrateLabel", "Bitrate settings for the encoder - (affects downloads only when ffmpeg is used in the process! - for example, when using either timeframe, CPU, or GPU options, these bitrate settings will apply)",
                "VideoBitrateLabel", "Bitrate for video - Examples: \"100M\" | \"900K\" (M = MB/s, K = KB/s)",
                "VideoBitrateTextbox", "Bitrate for video - Examples: \"100M\" | \"900K\" (M = MB/s, K = KB/s)",
                "AudioBitrateLabel", "Bitrate for audio - Examples: \"320K\" | \"10K\" (M = MB/s, K = KB/s)",
                "AudioBitrateTextbox", "Bitrate for audio - Examples: \"320K\" | \"10K\" (M = MB/s, K = KB/s)",

                "GifQualityLabel", "Quality settings for gif",
                "GifResolutionLabel", "Width resolution for gif - Keeps ratio (FFmpeg args = r:-2)",
                "GifResolutionTextbox", "Width resolution for gif - Keeps ratio (FFmpeg args = r:-2)",
                "GifFramerateLabel", "Framerate for gif",
                "GifFramerateTextbox", "Framerate for gif",

                "UseCpuCheckbox", "Enable video encoding - This can fix problems with importing or viewing videos in some software - (encodes on the CPU using FFmpeg, this feature is very slow and it only supports mp4, does not work while \"Encode Video (GPU)\" is enabled)",

                "UseGpuCheckbox", "Enable GPU accelerated video encoding - This can fix problems with importing or viewing videos in some software (encodes on the GPU using FFmpeg, this feature only supports mp4, does not work while \"Encode Video (CPU)\" is enabled)",
                "CodecLabel", "Encoder to be used - Examples: Nvidia = \"h264_nvenc\" | AMD = \"h264_amf\")",
                "GpuEncoderTextbox", "Encoder to be used - Examples: Nvidia = \"h264_nvenc\" | AMD = \"h264_amf\")",

                "YtdlpArgumentsLabel", "Custom arguments for yt-dlp (double-click to open the yt-dlp GitHub repository)",
                "YtdlpArgumentsTextbox", "Custom arguments for yt-dlp (double-click to open the yt-dlp GitHub repository)",

                "OutputLabel", "Output log options",
                "DisplayOutputCheckbox", "Display the verbose log while downloading in a separate command prompt window",
                "KeepOutputCheckbox", "Causes the command prompt to stay open after the download finishes (helpful for debugging)",

                "UseConfigCheckbox", "Save all current component states to config files - If enabled, then on program startup all component states will be restored",
                "ClearConfigButton", "Clear all component states"
            };

            // load tooltips
            for (int i = 0; i < tooltipMap.Length; i += 2)
                ProgramToolTip.SetToolTip(Controls.Find(tooltipMap[i], true)[0], tooltipMap[i + 1]);

            // configure tooltip draw
            ProgramToolTip.AutoPopDelay = 10000;
            ProgramToolTip.InitialDelay = 500;
            ProgramToolTip.ReshowDelay = 100;
            ProgramToolTip.OwnerDraw = true;
            ProgramToolTip.BackColor = Color.FromArgb(32, 32, 32);
            ProgramToolTip.ForeColor = Color.FromArgb(150, 150, 150);
            #endregion

            if (config.DOWNLOAD_LOCATION == "" || config.DOWNLOAD_LOCATION == null)
            {
                useDefaultLocation = true;
                DirectoryLabel.Text = "";
            }
            else
            {
                useDefaultLocation = false;
                DirectoryLabel.Text = config.DOWNLOAD_LOCATION;
            }

            // configure title
            title = "\ntitle MediaDownloader " + version + "     ";
            VersionLabel.Text = version;

            VersionLabel.Location = new Point(Width - (VersionLabel.Width + 48), VersionLabel.Location.Y);

            // configure starting arguments
            baseArguments = "@echo off\ncd \"MediaDownloader\\working\"" + title + state_downloading + "type \"md_header\"\necho.\necho.\n\"..\\yt-dlp.exe\" -vU --ffmpeg-location \"..\\ffmpeg.exe\" ";

            // check if the custom directory is missing
            if (Directory.Exists(config.DOWNLOAD_LOCATION) == false && useDefaultLocation == false)
            {
                clearLocation();
                DirectoryLabel.ForeColor = Color.Brown;
                DirectoryLabel.Text = "Directory no longer exists";
                ProgramToolTip.SetToolTip(DirectoryLabel, "The previous directory no longer exists");
            }

            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                DialogResult prompt = MessageBox.Show("An instance of MediaDownloader is already running.\nHaving two or more instances of MediaDownloader running simultaneously can cause issues (file corruption, malfunctioning).\n\nAre you sure you want to continue?", "", MessageBoxButtons.YesNo);
                if (prompt == DialogResult.No) Environment.Exit(0);
            }

            #region redistCheck
            string scoop_ytdlp = "..\\..\\yt-dlp\\current\\yt-dlp.exe";
            string scoop_ffmpeg = "..\\..\\ffmpeg\\current\\bin\\ffmpeg.exe";

            // install redists from scoop
            if (File.Exists(scoop_ytdlp) == true)
            {
                try
                {
                    if (File.Exists(REDIST_ytdlp) == true)
                        File.Delete(REDIST_ytdlp);
                    File.Copy(scoop_ytdlp, REDIST_ytdlp);
                }
                catch (Exception ex) { installError("yt-dlp.exe", ex); }
            }
            if (File.Exists(scoop_ffmpeg) == true)
            {
                try
                {
                    if (File.Exists(REDIST_ffmpeg) == true)
                        File.Delete(REDIST_ffmpeg);
                    File.Copy(scoop_ffmpeg, REDIST_ffmpeg);
                }
                catch (Exception ex) { installError("ffmpeg.exe", ex); }
            }

            // check if redists exist
            if (File.Exists(REDIST_ytdlp) == true)
                ytdlpCheck = true;
            else
                redistError("yt-dlp.exe");

            if (File.Exists(REDIST_ffmpeg) == true)
                ffmpegCheck = true;
            else
                redistError("ffmpeg.exe");

            if (ytdlpCheck == true && ffmpegCheck == true)
            {
                // configure default configs
                Directory.CreateDirectory("Downloads");
                Directory.CreateDirectory("MediaDownloader\\config");
                Directory.CreateDirectory("MediaDownloader\\working");

                if (File.Exists(CONFIG_base) == false)
                    UseConfigCheckbox.Checked = true;
                File.WriteAllText(CONFIG_base, "");
            }
            #endregion

            // configure and start scanClock
            System.Timers.Timer scanClock = new System.Timers.Timer();
            scanClock.Elapsed += new ElapsedEventHandler(RedistScan);
            scanClock.Interval = 1000;
            scanClock.Enabled = true;
        }

        // draw tooltips
        private void ProgramToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        // do tick
        private void RedistScan(object source, ElapsedEventArgs e)
        {
            CheckBat(false, false);
        }

        #region downloader

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            #region scriptDictionary

            // configure variables
            string url = UrlTextbox.Text;
            string name = FilenameTextbox.Text == "" ? "download" : FilenameTextbox.Text;
            string format = FormatCombobox.Text;
            string timeframeStart = TimeframeStartTextbox.Text;
            string timeframeEnd = TimeframeEndTextbox.Text;
            string gifResolution = GifResolutionTextbox.Text;
            string gifFramerate = GifFramerateTextbox.Text;
            string gpuEncoder = GpuEncoderTextbox.Text;
            string ytdlpArguments = YtdlpArgumentsTextbox.Text;

            string bitrateSettings = " -b:v " + config.VIDEO_BITRATE + " -b:a " + config.AUDIO_BITRATE + " ";

            string dateID = DateTime.Now.ToString("[M-d-y_hms]");
            downloadName = name + " " + dateID;

            // process format
            string fileExtension = "";
            switch (FormatCombobox.Text)
            {
                case "mp4": fileExtension = ".mp4"; break;
                case "mkv": fileExtension = ".mkv"; break;
                case "webm": fileExtension = ".webm"; break;

                case "mp3": fileExtension = ".mp3"; break;
                case "wav": fileExtension = ".wav"; break;
                case "ogg":
                    fileExtension = ".ogg";
                    bitrateSettings = " ";
                    break;
                case "flac": fileExtension = ".flac"; break;
                case "opus": fileExtension = ".opus"; break;

                case "gif": fileExtension = ".gif"; break;

                case "vectorscope": fileExtension = ".mp4"; break;
                case "spectogram": fileExtension = ".mp4"; break;
                case "histogram": fileExtension = ".mp4"; break;
                case "showcqt": fileExtension = ".mp4"; break;
                case "showfreqs": fileExtension = ".mp4"; break;
                case "waves": fileExtension = ".mp4"; break;
            }

            string fileExtensionPreprocessOverride = fileExtension;
            switch (FormatCombobox.Text)
            {
                case "gif": fileExtensionPreprocessOverride = ".mp4"; break;
                case "png sequence": fileExtensionPreprocessOverride = ".mp4"; break;
                case "jpg sequence": fileExtensionPreprocessOverride = ".mp4"; break;

                case "vectorscope": fileExtensionPreprocessOverride = ".mp3"; break;
                case "spectogram": fileExtensionPreprocessOverride = ".mp3"; break;
                case "histogram": fileExtensionPreprocessOverride = ".mp3"; break;
                case "showcqt": fileExtensionPreprocessOverride = ".mp3"; break;
                case "showfreqs": fileExtensionPreprocessOverride = ".mp3"; break;
                case "waves": fileExtensionPreprocessOverride = ".mp3"; break;
            }

            string preprocessor;
            string finalize;
            string finalize_directory;

            if (UseTimeframeCheckbox.Checked == true)
                preprocessor = title + state_preprocess +
                               "..\\ffmpeg.exe -loglevel verbose -y -i \"raw" + fileExtensionPreprocessOverride + "\" -ss " + timeframeStart + " -to " + timeframeEnd + bitrateSettings + "\"tmp0" + fileExtensionPreprocessOverride + "\"";
            else
                preprocessor = title + state_preprocess +
                               "rename \"raw" + fileExtensionPreprocessOverride + "\" \"tmp0" + fileExtensionPreprocessOverride + "\"";

            if (useDefaultLocation == true)
            {
                finalize = title + state_finalize +
                           "copy \"final" + fileExtension + "\" \"..\\..\\Downloads\\" + downloadName + fileExtension + "\" /y";
                finalize_directory = title + state_finalize +
                                     "robocopy \"final\" \"..\\..\\Downloads\\" + downloadName + "\" /e";
            }
            else
            {
                finalize = title + state_finalize +
                           "copy \"final" + fileExtension + "\" \"" + config.DOWNLOAD_LOCATION + "\\" + downloadName + fileExtension + "\" /y";
                finalize_directory = title + state_finalize +
                                     "robocopy \"final\" \"" + config.DOWNLOAD_LOCATION + "\\" + downloadName + "\" /e";
            }

            // mp4
            string mp4 = baseArguments + "--remux-video mp4 -o \"raw\" " + url +
                         preprocessor +
                         title + state_cpu1 +
                         "rename \"tmp0.mp4\" \"final.mp4\"" +
                         finalize;
            //
            string mp4_useCpu = baseArguments + "--remux-video mp4 -o \"raw\" " + url +
                                preprocessor +
                                title + state_cpu1 +
                                "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp4\" -c:v h264 -c:a aac" + bitrateSettings + "\"final.mp4\"" +
                                finalize;
            //
            string mp4_useGpu = baseArguments + "--remux-video mp4 -o \"raw\" " + url +
                                preprocessor +
                                title + state_gpu1 +
                                "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp4\" -c:v " + gpuEncoder + " -c:a aac" + bitrateSettings + "\"final.mp4\"" +
                                finalize;

            // mkv
            string mkv = baseArguments + "--remux-video mkv -o \"raw\" " + url +
                         preprocessor +
                         title + state_cpu1 +
                         "rename \"tmp0.mkv\" \"final.mkv\"" +
                         finalize;
            //
            string mkv_useCpu = baseArguments + "--remux-video mkv -o \"raw\" " + url +
                                preprocessor +
                                title + state_cpu1 +
                                "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mkv\" -c:v h264 -c:a aac " + bitrateSettings + "\"final.mkv\"" +
                                finalize;
            //
            string mkv_useGpu = baseArguments + "--remux-video mkv -o \"raw\" " + url +
                                preprocessor +
                                title + state_gpu1 +
                                "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mkv\" -c:v " + gpuEncoder + " -c:a aac" + bitrateSettings + "\"final.mkv\"" +
                                finalize;


            // webm
            string webm = baseArguments + "--remux-video webm -o \"raw\" " + url +
                          preprocessor +
                          title + state_cpu1 +
                          "rename \"tmp0.webm\" \"final.webm\"" +
                          finalize;

            string webm_useCpu = baseArguments + "--remux-video webm -o \"raw\" " + url +
                                 preprocessor +
                                 title + state_cpu1 +
                                 "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.webm\" -c:v vp9 -c:a libvorbis " + bitrateSettings + "\"final.webm\"" +
                                 finalize;

            // mp3
            string mp3 = baseArguments + "-x --audio-format mp3 --audio-quality 0 -o \"raw\" " + url +
                         preprocessor +
                         title + state_cpu1 +
                         "rename \"tmp0.mp3\" \"final.mp3\"" +
                         finalize;

            // wav
            string wav = baseArguments + "-x --audio-format wav --audio-quality 0 -o \"raw\" " + url +
                         preprocessor +
                         title + state_cpu1 +
                         "rename \"tmp0.wav\" \"final.wav\"" +
                         finalize;

            // ogg
            string ogg = baseArguments + "-x --audio-format vorbis --audio-quality 0 -o \"raw\" " + url +
                         preprocessor +
                         title + state_cpu1 +
                         "rename \"tmp0.ogg\" \"final.ogg\"" +
                         finalize;

            // flac
            string flac = baseArguments + "-x --audio-format flac --audio-quality 0 -o \"raw\" " + url +
                          preprocessor +
                          title + state_cpu1 +
                          "rename \"tmp0.flac\" \"final.flac\"" +
                          finalize;

            // opus
            string opus = baseArguments + "-x --audio-format opus --audio-quality 0 -o \"raw\" " + url +
                          preprocessor +
                          title + state_cpu1 +
                          "rename \"tmp0.opus\" \"final.opus\"" +
                          finalize;

            // gif
            string gif = baseArguments + "--remux-video mp4 -o \"raw\" " + url +
                         preprocessor +
                         title + state_cpu1 +
                         "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp4\" -vf \"scale=trunc(" + gifResolution + "/2)*2:-2\" -r " + gifFramerate + " \"tmp1.mp4\"" +
                         title + state_cpu2 +
                         "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp1.mp4\" -vf palettegen \"tmp1_palette.png\"" +
                         title + state_cpu3 +
                         "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp1.mp4\" -i \"tmp1_palette.png\" -lavfi \"paletteuse\" \"final.gif\"" +
                         finalize;

            // png sequence
            string png_sequence = baseArguments + "--remux-video mp4 -o \"raw\" " + url +
                                  preprocessor +
                                  title + state_cpu1 +
                                  "mkdir \"final\"\n" +
                                  "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp4\" \"final\\" + name + ".%%d.png\"" +
                                  finalize_directory;

            // jpg sequence
            string jpg_sequence = baseArguments + "--remux-video mp4 -o \"raw\" " + url +
                                  preprocessor +
                                  title + state_cpu1 +
                                  "mkdir \"final\"\n" +
                                  "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp4\" -q:v 1 \"final\\" + name + ".%%d.jpg\"" +
                                  finalize_directory;

            // vectorscope
            string vectorscope = baseArguments + "-x --audio-format mp3 --audio-quality 0 -o \"raw\" " + url +
                                 preprocessor +
                                 title + state_cpu1 +
                                 "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp3\" -filter_complex \"[0:a]avectorscope=s=854x854:zoom=1.5:rc=255:gc=255:bc=255:rf=25:gf=15:bf=20,format=yuv420p[v]\" -map \"[v]\" -map 0:a -b:v " + config.VIDEO_BITRATE + " -b:a " + config.AUDIO_BITRATE + " \"final.mp4\"" +
                                 finalize;

            // spectogram
            string spectogram = baseArguments + "-x --audio-format mp3 --audio-quality 0 -o \"raw\" " + url +
                                preprocessor +
                                title + state_cpu1 +
                                "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp3\" -filter_complex \"[0:a]showspectrum=s=854x480:mode=combined:slide=scroll:color=green:saturation=0.5:scale=cbrt,format=yuv420p[v]\" -map \"[v]\" -map 0:a -b:v " + config.VIDEO_BITRATE + " -b:a " + config.AUDIO_BITRATE + " \"final.mp4\"" +
                                finalize;

            // histogram
            string histogram = baseArguments + "-x --audio-format mp3 --audio-quality 0 -o \"raw\" " + url +
                               preprocessor +
                               title + state_cpu1 +
                               "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp3\" -filter_complex \"[0:a]ahistogram=s=854x480:slide=scroll:scale=cbrt,format=yuv420p[v]\" -map \"[v]\" -map 0:a -b:v " + config.VIDEO_BITRATE + " -b:a " + config.AUDIO_BITRATE + " \"final.mp4\"" +
                               finalize;

            // showcqt
            string showcqt = baseArguments + "-x --audio-format mp3 --audio-quality 0 -o \"raw\" " + url +
                             preprocessor +
                             title + state_cpu1 +
                             "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp3\" -filter_complex \"[0:a]showcqt=s=854x480[v]\" -map \"[v]\" -map \"0:a\" -b:v " + config.VIDEO_BITRATE + " -b:a " + config.AUDIO_BITRATE + " \"final.mp4\"" +
                             finalize;

            // showfreqs
            string showfreqs = baseArguments + "-x --audio-format mp3 --audio-quality 0 -o \"raw\" " + url +
                               preprocessor +
                               title + state_cpu1 +
                               "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp3\" -filter_complex \"[0:a]showfreqs=s=854x480:colors=00FF21|007F0E[v]\" -map \"[v]\" -map \"0:a\" -b:v " + config.VIDEO_BITRATE + " -b:a " + config.AUDIO_BITRATE + " \"final.mp4\"" +
                               finalize;

            // waves
            string waves = baseArguments + "-x --audio-format mp3 --audio-quality 0 -o \"raw\" " + url +
                           preprocessor +
                           title + state_cpu1 +
                           "\"..\\ffmpeg.exe\" -loglevel verbose -y -i \"tmp0.mp3\" -filter_complex \"[0:a]showwaves=s=854x480:mode=p2p:colors=00FF21|007F0E[v]\" -map \"[v]\" -map 0:a -pix_fmt yuv420p -b:v " + config.VIDEO_BITRATE + " -b:a " + config.AUDIO_BITRATE + " \"final.mp4\"" +
                           finalize;

            // (yt-dlp arguments)
            string ytdlpArgs = baseArguments + "--path \"" + config.DOWNLOAD_LOCATION + "\" " + ytdlpArguments + " " + url;
            //
            string ytdlpArgs_useDefaultLocation = baseArguments + "--path " + "\"..\\..\\Downloads\" " + ytdlpArguments + " " + url;

            #endregion

            // ensure user specifies valid url
            if (UrlTextbox.Text == "")
                MessageBox.Show("No URL was specified.");
            else
            {
                // ensure user cannot select non-formats
                if (format == "[Video]" || format == "[Audio]" || format == "[Image]" || format == "[Audio Visualizers]" || format == "[Custom]" || format == "")
                    MessageBox.Show("No format was specified.");
                else
                {
                    if (UseCpuCheckbox.Checked == false && UseGpuCheckbox.Checked == false)
                    {
                        // configure and execute download script
                        switch (format)
                        {
                            case "mp4": downloadScript = mp4; break;
                            case "mkv": downloadScript = mkv; break;
                            case "webm": downloadScript = webm; break;

                            case "mp3": downloadScript = mp3; break;
                            case "wav": downloadScript = wav; break;
                            case "ogg": downloadScript = ogg; break;
                            case "flac": downloadScript = flac; break;
                            case "opus": downloadScript = opus; break;

                            case "gif":
                                if (gifResolution == "" || gifFramerate == "")
                                {
                                    MessageBox.Show("No valid resolution and framerate values were specified.");
                                    return;
                                }
                                else
                                    downloadScript = gif; break;
                            case "png sequence": downloadScript = png_sequence; break;
                            case "jpg sequence": downloadScript = jpg_sequence; break;

                            case "vectorscope": downloadScript = vectorscope; break;
                            case "spectogram": downloadScript = spectogram; break;
                            case "histogram": downloadScript = histogram; break;
                            case "showcqt": downloadScript = showcqt; break;
                            case "showfreqs": downloadScript = showfreqs; break;
                            case "waves": downloadScript = waves; break;

                            case "(yt-dlp arguments)": downloadScript = useDefaultLocation ? ytdlpArgs_useDefaultLocation : ytdlpArgs; break;
                        }
                    }

                    if (UseCpuCheckbox.Checked)
                    {
                        // mp4
                        if (format != "mp4" && format != "mkv" && format != "webm")
                        {
                            MessageBox.Show("No CPU accelerated encoders are available for this format.\n(this feature only supports mp4, mkv, and webm)");
                            return;
                        }
                        switch (format)
                        {
                            case "mp4": downloadScript = mp4_useCpu; break;
                            case "mkv": downloadScript = mkv_useCpu; break;
                            case "webm": downloadScript = webm_useCpu; break;
                        }
                    }

                    if (UseGpuCheckbox.Checked)
                    {
                        // mp4
                        if (format != "mp4" && format != "mkv")
                        {
                            MessageBox.Show("No GPU accelerated encoders are available for this format.\n(this feature only supports mp4 and mkv)");
                            return;
                        }
                        switch (format)
                        {
                            case "mp4": downloadScript = mp4_useGpu; break;
                            case "mkv": downloadScript = mkv_useGpu; break;
                        }
                    }

                    if (UseTimeframeCheckbox.Checked == true && format == "(yt-dlp arguments)")
                    {
                        MessageBox.Show("You cannot trim this format.");
                        return;
                    }

                    // inject pause
                    if (KeepOutputCheckbox.Checked == true)
                        downloadScript += title + state_finished + "echo.\npause";

                    // start download
                    if (downloadScript != null)
                        CheckBat(true, false);
                }
            }
        }

        private void ViewAvailableFormatsButton_Click(object sender, EventArgs e)
        {
            // displays available formats of the specified url
            if (UrlTextbox.Text == "")
                MessageBox.Show("No URL was specified.");
            else
            {
                downloadScript = baseArguments + "--list-formats " + UrlTextbox.Text + title + state_finished + "echo.\npause";
                CheckBat(true, true);
            }
        }

        #endregion

        #region scriptExecutor

        private void CheckBat(bool start, bool isFormatDisplay)
        {
            bool isRunning = false;

            foreach (Process progOpenCheck in Process.GetProcesses())
                if (progOpenCheck.ProcessName.Contains("yt-dlp") == true || progOpenCheck.ProcessName.Contains("ffmpeg") == true)
                    isRunning = true;

            if (isRunning == false)
            {
                DownloadButton.ForeColor = Color.LimeGreen;
                if (start == true)
                    RunBat(isFormatDisplay);
            }
            else
                DownloadButton.ForeColor = Color.DarkSeaGreen;
        }

        private void RunBat(bool isFormatDisplay)
        {
            CleanFiles();

            // write and start batch script
            File.WriteAllText(WORKING_md_header, Properties.Resources.asciiBanner.Replace("__VERSION__", version));
            File.WriteAllText(WORKING_md, downloadScript);

            if (DisplayOutputCheckbox.Checked == true || isFormatDisplay == true)
                Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + WORKING_md);
            else
            {
                ProcessStartInfo runHidden = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + WORKING_md
                };

                Process.Start(runHidden);
            }

            DownloadButton.ForeColor = Color.DarkSeaGreen;
        }

        #endregion

        #region componentInteraction

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearConfigButton_Click(object sender, EventArgs e)
        {
            ClearSettings();
        }

        private void ClearLocationButton_Click(object sender, EventArgs e)
        {
            clearLocation();
        }

        private void YtdlpArgumentsLabel_MouseDoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/yt-dlp/yt-dlp");
        }

        private void YtdlpArgumentsTextbox_MouseDoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/yt-dlp/yt-dlp");
        }

        private void OpenLocationButton_Click(object sender, EventArgs e)
        {
            string format = "";
            switch (FormatCombobox.Text)
            {
                case "mp4": format = ".mp4"; break;
                case "mkv": format = ".mkv"; break;
                case "webm": format = ".mkv"; break;

                case "mp3": format = ".mp3"; break;
                case "wav": format = ".wav"; break;
                case "ogg": format = ".ogg"; break;
                case "flac": format = ".flac"; break;
                case "opus": format = ".opus"; break;

                case "gif": format = ".gif"; break;
                case "png sequence": format = ""; break;
                case "jpg sequence": format = ""; break;

                case "vectorscope": format = ".mp4"; break;
                case "spectogram": format = ".mp4"; break;
                case "histogram": format = ".mp4"; break;
                case "showcqt": format = ".mp4"; break;
                case "showfreqs": format = ".mp4"; break;
                case "waves": format = ".mp4"; break;
            }

            bool isDefaultLocation = config.DOWNLOAD_LOCATION == "" || useDefaultLocation == true;
            string file = (isDefaultLocation ? "Downloads" : config.DOWNLOAD_LOCATION) + "\\" + downloadName + format;

            if (File.Exists(file) == true)
                Process.Start("explorer.exe", "/select, " + file);
            else
                Process.Start("explorer.exe", config.DOWNLOAD_LOCATION == "" || useDefaultLocation ? "Downloads" : config.DOWNLOAD_LOCATION);
        }

        #endregion

        private void ChangeLocationButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog selectFolderDialog = new OpenFileDialog())
            {
                selectFolderDialog.Multiselect = false;
                selectFolderDialog.CheckFileExists = false;
                selectFolderDialog.CheckPathExists = true;
                selectFolderDialog.FileName = "Select a folder";
                selectFolderDialog.Filter = "Directories|Folders";
                selectFolderDialog.ShowDialog();

                if (selectFolderDialog.FileName != "")
                {
                    string folderPath = Path.GetDirectoryName(selectFolderDialog.FileName);
                    config.DOWNLOAD_LOCATION = folderPath;
                    useDefaultLocation = config.DOWNLOAD_LOCATION == "" ? true : false;

                    DirectoryLabel.Text = folderPath;
                    DirectoryLabel.ForeColor = Color.ForestGreen;
                    ProgramToolTip.SetToolTip(DirectoryLabel, "Currently selected download location [" + config.DOWNLOAD_LOCATION + "]");
                }
            }
        }

        private void clearLocation()
        {
            // clear selected location
            useDefaultLocation = true;
            config.DOWNLOAD_LOCATION = "";
            DirectoryLabel.Text = "";
        }

        #region formMouseDown

        private void MoveForm(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
                Process.Start("https://github.com/o7q/MediaDownloader");
            MoveForm(e);
        }

        private void TitlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        private void VersionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        #endregion

        #region storeComponentState

        private void UseConfigCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (UseConfigCheckbox.Checked == true)
                File.WriteAllText(CONFIG_lock, "1");
            else
                File.WriteAllText(CONFIG_lock, "0");
        }

        private void UrlTextbox_TextChanged(object sender, EventArgs e)
        {
            UrlTextbox.Text = omitCharacter(UrlTextbox.Text);
            config.URL = UrlTextbox.Text;
        }

        private void FilenameTextbox_TextChanged(object sender, EventArgs e)
        {
            FilenameTextbox.Text = omitCharacter(FilenameTextbox.Text);
            config.DOWNLOAD_NAME = FilenameTextbox.Text;
        }

        private void FormatCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.FORMAT_INDEX = FormatCombobox.SelectedIndex;
        }

        private void UseTimeframeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            config.USE_TIMEFRAME = UseTimeframeCheckbox.Checked;
        }

        private void TimeframeStartTextbox_TextChanged(object sender, EventArgs e)
        {
            config.TIMEFRAME_START = TimeframeStartTextbox.Text;
        }

        private void TimeframeEndTextbox_TextChanged(object sender, EventArgs e)
        {
            config.TIMEFRAME_END = TimeframeEndTextbox.Text;
        }

        private void VideoBitrateTextbox_TextChanged(object sender, EventArgs e)
        {
            config.VIDEO_BITRATE = VideoBitrateTextbox.Text;
        }

        private void AudioBitrateTextbox_TextChanged(object sender, EventArgs e)
        {
            config.AUDIO_BITRATE = AudioBitrateTextbox.Text;
        }

        private void GifResolutionTextbox_TextChanged(object sender, EventArgs e)
        {
            config.GIF_RESOLUTION = GifResolutionTextbox.Text;
        }

        private void GifFramerateTextbox_TextChanged(object sender, EventArgs e)
        {
            config.GIF_FRAMERATE = GifFramerateTextbox.Text;
        }

        private void UseGpuCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (UseGpuCheckbox.Checked == true)
                UseCpuCheckbox.Checked = false;
            config.USE_GPU_ENCODER = UseGpuCheckbox.Checked;
        }

        private void GpuEncoderTextbox_TextChanged(object sender, EventArgs e)
        {
            config.GPU_ENCODER = GpuEncoderTextbox.Text;
        }

        private void UseCpuCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (UseCpuCheckbox.Checked) UseGpuCheckbox.Checked = false;
            config.USE_CPU_ENCODER = UseCpuCheckbox.Checked;
        }

        private void YtdlpArgumentsTextbox_TextChanged(object sender, EventArgs e)
        {
            config.YTDLP_ARGUMENTS = YtdlpArgumentsTextbox.Text;
        }

        private void DisplayOutputCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DisplayOutputCheckbox.Checked == false && KeepOutputCheckbox.Checked == true)
                KeepOutputCheckbox.Checked = false;
            config.USE_DISPLAY_OUTPUT = DisplayOutputCheckbox.Checked;
        }

        private void KeepOutputCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DisplayOutputCheckbox.Checked == false && KeepOutputCheckbox.Checked == true)
                DisplayOutputCheckbox.Checked = true;
            config.USE_KEEP_OUTPUT = KeepOutputCheckbox.Checked;
        }

        #endregion

        private void WriteConfig()
        {
            if (UseConfigCheckbox.Checked == false) return;

            // write config to config.md
            var sb = new StringBuilder();
            foreach (var field in typeof(ConfigBase).GetFields())
            {
                object value = field.GetValue(config);
                if (value != null)
                    sb.Append(field.Name + "¶" + value.ToString());
                sb.Append("\n");
            }
            sb.Length--;
            string configFile = sb.ToString();

            File.WriteAllText(CONFIG_main, configFile);
        }

        private void ClearSettings()
        {
            UrlTextbox.Text = "";

            FilenameTextbox.Text = "";

            FormatCombobox.SelectedIndex = 4;

            UseTimeframeCheckbox.Checked = false;
            TimeframeStartTextbox.Text = "0:00";
            TimeframeEndTextbox.Text = "0:10";

            useDefaultLocation = true;
            config.DOWNLOAD_LOCATION = "";
            DirectoryLabel.Text = "";

            VideoBitrateTextbox.Text = "100M";
            AudioBitrateTextbox.Text = "320K";

            GifResolutionTextbox.Text = "400";
            GifFramerateTextbox.Text = "20";

            UseGpuCheckbox.Checked = false;
            GpuEncoderTextbox.Text = "h264_nvenc";

            UseCpuCheckbox.Checked = false;

            YtdlpArgumentsTextbox.Text = "";

            DisplayOutputCheckbox.Checked = true;
            KeepOutputCheckbox.Checked = false;
        }

        private void CleanFiles()
        {
            string workingFolder = "MediaDownloader\\working";

            // delete all files
            foreach (string file in Directory.GetFiles(workingFolder))
                File.Delete(file);

            // delete all folders
            foreach (string folder in Directory.GetDirectories(workingFolder))
                Directory.Delete(folder, true);
        }

        private void Program_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UseConfigCheckbox.Checked == true)
                WriteConfig();
            else
                File.WriteAllText(CONFIG_main, "");
        }
    }
}