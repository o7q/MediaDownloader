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
    public partial class program : Form
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

        public program()
        {
            InitializeComponent();
        }

        ConfigBase config = new ConfigBase();

        // program load
        private void program_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("MediaDownloader");

            if (useConfig.Checked == false)
                clearSettings();

            if (File.Exists(CONFIG_lock) == true)
            {
                if (File.ReadAllText(CONFIG_lock) == "1")
                    useConfig.Checked = true;
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
                        case "URL": urlTextbox.Text = configSettingPair[1]; break;
                        case "DOWNLOAD_NAME": nameTextbox.Text = configSettingPair[1]; break;
                        case "FORMAT_INDEX": formatCombobox.SelectedIndex = int.Parse(configSettingPair[1]); break;
                        case "DOWNLOAD_LOCATION": config.DOWNLOAD_LOCATION = configSettingPair[1]; break;
                        case "USE_TIMEFRAME": useTimeframeCheckbox.Checked = bool.Parse(configSettingPair[1]); break;
                        case "TIMEFRAME_START": timeframeStartTextbox.Text = configSettingPair[1]; break;
                        case "TIMEFRAME_END": timeframeEndTextbox.Text = configSettingPair[1]; break;
                        case "GIF_RESOLUTION": gifResolutionTextbox.Text = configSettingPair[1]; break;
                        case "GIF_FRAMERATE": gifFramerateTextbox.Text = configSettingPair[1]; break;
                        case "USE_GPU_ENCODER": useGpuCheckbox.Checked = bool.Parse(configSettingPair[1]); break;
                        case "GPU_ENCODER": gpuEncoderTextbox.Text = configSettingPair[1]; break;
                        case "YTDLP_ARGUMENTS": ytdlpArgumentsTextbox.Text = configSettingPair[1]; break;
                        case "USE_DISPLAY_OUTPUT": displayOutputCheckbox.Checked = bool.Parse(configSettingPair[1]); break;
                        case "USE_KEEP_OUTPUT": keepOutputCheckbox.Checked = bool.Parse(configSettingPair[1]); break;
                        case "USE_CPU_ENCODER": useCpuCheckbox.Checked = bool.Parse(configSettingPair[1]); break;
                    }
                }
            }
            #endregion

            #region loadTooltips
            // bind tooltips
            string[] tooltipMap = {
                "bannerPicture", "MediaDownloader by o7q",
                "versionLabel", "Running " + version,
                "minimizeButton", "Minimize",
                "exitButton", "Close",
                "urlLabel", "URL to be downloaded",
                "urlTextbox", "URL to be downloaded",
                "fileNameLabel", "File name for the download",
                "nameTextbox", "File name for the download",
                "formatLabel", "Media format for download",
                "formatCombobox", "Media format for download",
                "viewAvailableFormatsButton", "Display all the available media formats found on the server for the specified URL",
                "downloadButton", "Download from the URL using the configured options",
                "locationButton", "Change the folder location for download",
                "openLocationButton", "Open the selected download location in the file explorer",
                "clearLocationButton", "Reset the selected download location",
                "directoryLabel", "Currently selected download location [" + config.DOWNLOAD_LOCATION + "]",
                "advancedLabel", "More extensive options",
                "useConfig", "Save all current component states to config files - If enabled, then on program startup all component states will be restored",
                "resetConfig", "Clear all component states",
                "useTimeframeCheckbox", "Trim the download to a specific length with a start and end timestamp - Examples: \"0:00 - 0:10\" | \"1:25 - 2:30\" | \"2:30:40 - 3:05:15\"",
                "timeframeStartLabel", "Trim start time",
                "timeframeStartTextbox", "Trim start time",
                "timeframeEndLabel", "Trim end time",
                "timeframeEndTextbox", "Trim end time",
                "gifQualityLabel", "Quality settings for gif",
                "gifResolutionLabel", "Width resolution for gif - Keeps ratio (FFmpeg args = r:-1)",
                "gifResolutionTextbox", "Width resolution for gif - Keeps ratio (FFmpeg args = r:-1)",
                "gifFramerateLabel", "Framerate for gif",
                "gifFramerateTextbox", "Framerate for gif",
                "useGpuCheckbox", "Enable GPU accelerated video encoding - This can fix problems with importing or viewing videos in some software (encodes on the GPU using FFmpeg, this feature only supports mp4, does not work while \"Encode Video (CPU)\" is enabled)",
                "codecLabel", "Encoder to be used - Examples: Nvidia = \"h264_nvenc\" | AMD = \"h264_amf\")",
                "gpuEncoderTextbox", "Encoder to be used - Examples: Nvidia = \"h264_nvenc\" | AMD = \"h264_amf\")",
                "ytdlpArgumentsLabel", "Custom arguments for yt-dlp (double-click to open the yt-dlp GitHub repository)",
                "ytdlpArgumentsTextbox", "Custom arguments for yt-dlp (double-click to open the yt-dlp GitHub repository)",
                "outputLabel", "Output log options",
                "displayOutputCheckbox", "Display the verbose log while downloading in a separate command prompt window",
                "keepOutputCheckbox", "Causes the command prompt to stay open after the download finishes (helpful for debugging)",
                "useCpuCheckbox", "Enable video encoding - This can fix problems with importing or viewing videos in some software - (encodes on the CPU using FFmpeg, this feature is very slow and it only supports mp4, does not work while \"Encode Video (GPU)\" is enabled)"
            };

            // load tooltips
            for (int i = 0; i < tooltipMap.Length; i += 2)
                programToolTip.SetToolTip(Controls.Find(tooltipMap[i], true)[0], tooltipMap[i + 1]);

            // configure tooltip draw
            programToolTip.AutoPopDelay = 10000;
            programToolTip.OwnerDraw = true;
            programToolTip.BackColor = Color.FromArgb(32, 32, 32);
            programToolTip.ForeColor = Color.FromArgb(150, 150, 150);
            #endregion

            if (config.DOWNLOAD_LOCATION == "" || config.DOWNLOAD_LOCATION == null)
            {
                useDefaultLocation = true;
                directoryLabel.Text = "";
            }
            else
            {
                useDefaultLocation = false;
                directoryLabel.Text = config.DOWNLOAD_LOCATION;
            }

            // configure title
            title = "\ntitle MediaDownloader " + version + "     ";
            versionLabel.Text = version;

            // configure starting arguments
            baseArguments = "@echo off\ncd \"MediaDownloader\\working\"" + title + state_downloading + "type \"md_header\"\necho.\necho.\n\"..\\yt-dlp.exe\" -vU --ffmpeg-location \"..\\ffmpeg.exe\" ";

            // check if the custom directory is missing
            if (Directory.Exists(config.DOWNLOAD_LOCATION) == false && useDefaultLocation == false)
            {
                clearLocation();
                directoryLabel.ForeColor = Color.Brown;
                directoryLabel.Text = "Directory no longer exists";
                programToolTip.SetToolTip(directoryLabel, "The previous directory no longer exists");
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
            if (File.Exists(scoop_ytdlp))
            {
                try
                {
                    if (File.Exists(REDIST_ytdlp)) File.Delete(REDIST_ytdlp);
                    File.Copy(scoop_ytdlp, REDIST_ytdlp);
                }
                catch (Exception ex) { installError("yt-dlp.exe", ex); }
            }
            if (File.Exists(scoop_ffmpeg))
            {
                try
                {
                    if (File.Exists(REDIST_ffmpeg)) File.Delete(REDIST_ffmpeg);
                    File.Copy(scoop_ffmpeg, REDIST_ffmpeg);
                }
                catch (Exception ex) { installError("ffmpeg.exe", ex); }
            }

            // check if redists exist
            if (File.Exists(REDIST_ytdlp)) ytdlpCheck = true; else redistError("yt-dlp.exe");
            if (File.Exists(REDIST_ffmpeg)) ffmpegCheck = true; else redistError("ffmpeg.exe");
            if (ytdlpCheck && ffmpegCheck)
            {
                // configure default configs
                Directory.CreateDirectory("Downloads");
                Directory.CreateDirectory("MediaDownloader\\config");
                Directory.CreateDirectory("MediaDownloader\\working");
                if (File.Exists(CONFIG_base) == false) useConfig.Checked = true;
                File.WriteAllText(CONFIG_base, "");
            }
            #endregion

            // configure and start scanClock
            System.Timers.Timer scanClock = new System.Timers.Timer();
            scanClock.Elapsed += new ElapsedEventHandler(redistScan);
            scanClock.Interval = 1000;
            scanClock.Enabled = true;
        }

        // draw tooltips
        private void programToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        // do tick
        private void redistScan(object source, ElapsedEventArgs e)
        {
            checkBat(false, false);
        }

        #region download

        private void downloadButton_Click(object sender, EventArgs e)
        {
            #region scriptDictionary

            // configure variables
            string url = urlTextbox.Text;
            string name = nameTextbox.Text == "" ? "download" : nameTextbox.Text;
            int format = formatCombobox.SelectedIndex;
            string timeframeStart = timeframeStartTextbox.Text;
            string timeframeEnd = timeframeEndTextbox.Text;
            string gifResolution = gifResolutionTextbox.Text;
            string gifFramerate = gifFramerateTextbox.Text;
            string ytdlpArguments = ytdlpArgumentsTextbox.Text;
            string gpuEncoder = gpuEncoderTextbox.Text;
            string dID = DateTime.Now.ToString("[M-d-y_hms]");

            downloadName = name + " " + dID;

            // process format
            string fileExtension = null;
            switch (formatCombobox.SelectedIndex)
            {
                case 1: fileExtension = ".mp4"; break;
                case 2: fileExtension = ".gif"; break;
                case 5: fileExtension = ".mp3"; break;
                case 6: fileExtension = ".wav"; break;
                case 7: fileExtension = ".ogg"; break;
            }

            string preprocessor;
            string finalize;

            if (useDefaultLocation == true)
                finalize = "\ncopy \"final" + fileExtension + "\" \"..\\..\\Downloads\\" + downloadName + fileExtension + "\" /y";
            else
                finalize = "\ncopy \"final" + fileExtension + "\" \"" + config.DOWNLOAD_LOCATION + "\\" + downloadName + fileExtension + "\" /y";

            if (useTimeframeCheckbox.Checked == true)
                preprocessor = title + state_preprocess + "..\\ffmpeg.exe -loglevel verbose -i raw.mp4 -ss " + timeframeStart + " -to " + timeframeEnd + baseQuality + "tmp0.mp4";
            else
                preprocessor = title + state_preprocess + "rename \"raw.mp4\" \"tmp0.mp4\"";

            // mp4
            string mp4 = baseArguments + "--remux-video mp4 -o \"raw.mp4\" " + url +
                         preprocessor +
                         "\nrename \"tmp0.mp4\" \"final.mp4\"" +
                         finalize;
            //
            string mp4_useCpu = baseArguments + "--remux-video mp4 -o \"raw.mp4\" " + url +
                                preprocessor +
                                title + state_cpu1 + "\"..\\ffmpeg.exe\" -loglevel verbose -i \"tmp0.mp4\" -c:v h264 -c:a aac" + baseQuality + "\"final.mp4\"" +
                                finalize;
            //
            string mp4_useGpu = baseArguments + "--remux-video mp4 -o \"raw.mp4\" " + url +
                                preprocessor +
                                title + state_gpu1 + "\"..\\ffmpeg.exe\" -loglevel verbose -i \"tmp0.mp4\" -c:v " + gpuEncoder + " -c:a aac" + baseQuality + "\"final.mp4\"" +
                                finalize;

            // gif
            string gif = baseArguments + "--remux-video mp4 -o \"raw.mp4\" " + url +
                         preprocessor +
                         title + state_cpu1 +
                         "\"..\\ffmpeg.exe\" -loglevel verbose -i \"tmp0.mp4\" -vf \"scale=trunc(" + gifResolution + "/2)*2:-2\" -r " + gifFramerate + " \"tmp1.mp4\"" +
                         title + state_cpu2 +
                         "\"..\\ffmpeg.exe\" -loglevel verbose -i \"tmp1.mp4\" -vf palettegen \"tmp1_palette.png\"" +
                         title + state_cpu3 +
                         "\"..\\ffmpeg.exe\" -loglevel verbose -i \"tmp1.mp4\" -i \"tmp1_palette.png\" -lavfi \"paletteuse\" \"final.gif\"" +
                         finalize;

            // mp3
            string mp3 = baseArguments + "--remux-video mp4 -o \"raw.mp4\" " + url +
                         preprocessor +
                         title + state_cpu1 +
                         "\"..\\ffmpeg.exe\" -loglevel verbose -i \"tmp0.mp4\" -vn -c:a mp3 \"final.mp3\"" +
                         finalize;

            // wav
            string wav = baseArguments + "--remux-video mp4 -o \"raw.mp4\" " + url +
                         preprocessor +
                         title + state_cpu1 +
                         "\"..\\ffmpeg.exe\" -loglevel verbose -i \"tmp0.mp4\" -vn -c:a pcm_s16le \"final.wav\"" +
                         finalize;

            // ogg
            string ogg = baseArguments + "--remux-video mp4 -o \"raw.mp4\" " + url +
                         preprocessor +
                         title + state_cpu1 +
                         "\"..\\ffmpeg.exe\" -loglevel verbose -i \"tmp0.mp4\" -vn -c:a libvorbis \"final.ogg\"" +
                         finalize;

            // (yt-dlp arguments)
            string ytdlpArgs = baseArguments + "--path \"" + config.DOWNLOAD_LOCATION + "\" " + ytdlpArguments + " " + url;
            //
            string ytdlpArgs_useDefaultLocation = baseArguments + "--path " + "\"..\\..\\Downloads\" " + ytdlpArguments + " " + url;

            #endregion

            // ensure user specifies valid url
            if (urlTextbox.Text == "")
                MessageBox.Show("No URL was specified.");
            else
            {
                // ensure user cannot select non-formats
                if (format == 0 || format == 3 || format == 4 || format == 8 || format == 9)
                    MessageBox.Show("No format was specified.");
                else
                {
                    if (useCpuCheckbox.Checked == false && useGpuCheckbox.Checked == false)
                    {
                        // configure and execute download script
                        switch (format)
                        {
                            // mp4
                            case 1: downloadScript = mp4; break;
                            // gif
                            case 2:
                                if (gifResolution == "" || gifFramerate == "")
                                {
                                    MessageBox.Show("No valid resolution and framerate values were specified.");
                                    return;
                                }
                                else
                                    downloadScript = gif; break;
                            // mp3
                            case 5: downloadScript = mp3; break;
                            // wav
                            case 6: downloadScript = wav; break;
                            // ogg
                            case 7: downloadScript = ogg; break;
                            // (yt-dlp arguments)
                            case 10: downloadScript = useDefaultLocation ? ytdlpArgs_useDefaultLocation : ytdlpArgs; break;
                        }
                    }

                    if (useCpuCheckbox.Checked)
                    {
                        // mp4
                        if (format != 1)
                        {
                            MessageBox.Show("No CPU accelerated encoders are available for this format.\n(this feature only supports mp4)");
                            return;
                        }
                        else
                            downloadScript = mp4_useCpu;
                    }

                    if (useGpuCheckbox.Checked)
                    {
                        // mp4
                        if (format != 1)
                        {
                            MessageBox.Show("No GPU accelerated encoders are available for this format.\n(this feature only supports mp4)");
                            return;
                        }
                        else
                            downloadScript = mp4_useGpu;
                    }

                    if (useTimeframeCheckbox.Checked == true && format == 10)
                    {
                        MessageBox.Show("You cannot trim this format.");
                        return;
                    }

                    // inject pause
                    if (keepOutputCheckbox.Checked)
                        downloadScript += title + state_finished + "echo.\npause";

                    // start download
                    if (downloadScript != null)
                        checkBat(true, false);
                }
            }
        }

        private void viewAvailableFormatsButton_Click(object sender, EventArgs e)
        {
            // displays available formats of the specified url
            if (urlTextbox.Text == "")
                MessageBox.Show("No URL was specified.");
            else
            {
                downloadScript = baseArguments + "--list-formats " + urlTextbox.Text + title + state_finished + "echo.\npause";
                checkBat(true, true);
            }
        }

        #endregion

        #region run

        private void checkBat(bool start, bool isFormatDisplay)
        {
            bool isRunning = false;

            foreach (Process progOpenCheck in Process.GetProcesses())
                if (progOpenCheck.ProcessName.Contains("yt-dlp") || progOpenCheck.ProcessName.Contains("ffmpeg"))
                    isRunning = true;

            if (isRunning == false)
            {
                downloadButton.ForeColor = Color.LimeGreen;
                if (start)
                    runBat(isFormatDisplay);
            }
            else
                downloadButton.ForeColor = Color.DarkSeaGreen;
        }

        private void runBat(bool isFormatDisplay)
        {
            cleanFiles();

            // write and start batch script
            File.WriteAllText(WORKING_md_header, Properties.Resources.asciiBanner.Replace("__VERSION__", version));
            File.WriteAllText(WORKING_md, downloadScript);

            if (displayOutputCheckbox.Checked == true || isFormatDisplay == true)
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

            downloadButton.ForeColor = Color.DarkSeaGreen;
        }

        #endregion

        #region componentInteraction

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetConfig_Click(object sender, EventArgs e)
        {
            clearSettings();
        }

        private void clearLocationButton_Click(object sender, EventArgs e)
        {
            clearLocation();
        }

        private void ytArgsLabel_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/yt-dlp/yt-dlp");
        }

        private void ytArgsBox_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/yt-dlp/yt-dlp");
        }

        private void openLocationButton_Click(object sender, EventArgs e)
        {
            string[] formats = { "", ".mp4", ".gif", "", "", ".mp3", ".wav", ".ogg", "", "", "" };

            bool isDefaultLocation = config.DOWNLOAD_LOCATION == "" || useDefaultLocation == true;
            string file = (isDefaultLocation ? "Downloads" : config.DOWNLOAD_LOCATION) + "\\" + downloadName + formats[formatCombobox.SelectedIndex];

            if (File.Exists(file))
                Process.Start("explorer.exe", "/select, " + file);
            else
                Process.Start("explorer.exe", config.DOWNLOAD_LOCATION == "" || useDefaultLocation ? "Downloads" : config.DOWNLOAD_LOCATION);
        }

        #endregion

        private void locationButton_Click(object sender, EventArgs e)
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

                    directoryLabel.Text = folderPath;
                    directoryLabel.ForeColor = Color.ForestGreen;
                    programToolTip.SetToolTip(directoryLabel, "Currently selected download location [" + config.DOWNLOAD_LOCATION + "]");
                }
            }
        }

        private void clearLocation()
        {
            // clear selected location
            useDefaultLocation = true;
            config.DOWNLOAD_LOCATION = "";
            directoryLabel.Text = "";
        }

        #region formMouseDown

        private void moveForm(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void bannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
                Process.Start("https://github.com/o7q/MediaDownloader");
            moveForm(e);
        }

        private void titlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            moveForm(e);
        }

        private void versionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            moveForm(e);
        }

        #endregion

        #region storeComponentState

        private void useConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true)
                File.WriteAllText(CONFIG_lock, "1");
            else
                File.WriteAllText(CONFIG_lock, "0");
        }

        private void urlTextbox_TextChanged(object sender, EventArgs e)
        {
            urlTextbox.Text = omitCharacter(urlTextbox.Text);
            config.URL = urlTextbox.Text;
        }

        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {
            nameTextbox.Text = omitCharacter(nameTextbox.Text);
            config.DOWNLOAD_NAME = nameTextbox.Text;
        }

        private void formatCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.FORMAT_INDEX = formatCombobox.SelectedIndex;
        }

        private void useTimeframeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            config.USE_TIMEFRAME = useTimeframeCheckbox.Checked;
        }

        private void timeframeStartTextbox_TextChanged(object sender, EventArgs e)
        {
            config.TIMEFRAME_START = timeframeStartTextbox.Text;
        }

        private void timeframeEndTextbox_TextChanged(object sender, EventArgs e)
        {
            config.TIMEFRAME_END = timeframeEndTextbox.Text;
        }

        private void gifResolutionTextbox_TextChanged(object sender, EventArgs e)
        {
            config.GIF_RESOLUTION = gifResolutionTextbox.Text;
        }

        private void gifFramerateTextbox_TextChanged(object sender, EventArgs e)
        {
            config.GIF_FRAMERATE = gifFramerateTextbox.Text;
        }

        private void useGpuCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (useGpuCheckbox.Checked)
                useCpuCheckbox.Checked = false;
            config.USE_GPU_ENCODER = useGpuCheckbox.Checked;
        }

        private void gpuEncoderTextbox_TextChanged(object sender, EventArgs e)
        {
            config.GPU_ENCODER = gpuEncoderTextbox.Text;
        }

        private void ytdlpArgumentsTextbox_TextChanged(object sender, EventArgs e)
        {
            config.YTDLP_ARGUMENTS = ytdlpArgumentsTextbox.Text;
        }

        private void displayOutputCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (displayOutputCheckbox.Checked == false && keepOutputCheckbox.Checked == true)
                keepOutputCheckbox.Checked = false;
            config.USE_DISPLAY_OUTPUT = displayOutputCheckbox.Checked;
        }

        private void keepOutputCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (displayOutputCheckbox.Checked == false && keepOutputCheckbox.Checked == true)
                displayOutputCheckbox.Checked = true;
            config.USE_KEEP_OUTPUT = keepOutputCheckbox.Checked;
        }

        private void useCpuCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (useCpuCheckbox.Checked) useGpuCheckbox.Checked = false;
            config.USE_CPU_ENCODER = useCpuCheckbox.Checked;
        }

        #endregion

        private void writeConfig()
        {
            if (useConfig.Checked == false) return;

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
            string a = sb.ToString();

            File.WriteAllText(CONFIG_main, a);
        }

        private void clearSettings()
        {
            urlTextbox.Text = "";
            nameTextbox.Text = "";
            formatCombobox.SelectedIndex = 3;
            directoryLabel.Text = "";
            useTimeframeCheckbox.Checked = false;
            timeframeStartTextbox.Text = "0:00";
            timeframeEndTextbox.Text = "0:10";
            gifResolutionTextbox.Text = "400";
            gifFramerateTextbox.Text = "20";
            useGpuCheckbox.Checked = false;
            gpuEncoderTextbox.Text = "h264_nvenc";
            ytdlpArgumentsTextbox.Text = "";
            displayOutputCheckbox.Checked = true;
            keepOutputCheckbox.Checked = false;
            useCpuCheckbox.Checked = false;

            useDefaultLocation = true;
        }

        private void cleanFiles()
        {
            string[] files = Directory.GetFiles("MediaDownloader\\working");
            foreach (string file in files)
                File.Delete(file);
        }

        private void program_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (useConfig.Checked == true)
                writeConfig();
            else
                File.WriteAllText(CONFIG_main, "");
        }
    }
}