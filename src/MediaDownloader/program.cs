using System;
using System.IO;
using System.Linq;
using System.Timers;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MediaDownloader
{
    public partial class program : Form
    {
        // configure mouse window events
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;

        // grab dlls for mousedown
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // create global variables

        // program attributes
        string title;
        const string ver = "v3.8.5";

        // shortcut strings
        const string md = "mediadownloader";
        const string md2 = md + "\\";
        const string mdc = md2 + "config\\";

        // redist check
        bool ytdlpCheck;
        bool ffmpegCheck;

        // batch configuration
        string filename = "";
        string baseArgs;
        bool useDefLoc;
        string selLoc;
        string mdScr;

        #region assetDictionary
        string config_url = mdc + "c_url";
        string config_name = mdc + "c_name";
        string config_format = mdc + "c_format";
        string config_location = mdc + "c_location";
        string config_useTimeFrame = mdc + "c_useTimeFrame";
        string config_timeFrameStart = mdc + "c_timeFrameStart";
        string config_timeFrameEnd = mdc + "c_timeFrameEnd";
        string config_gifResolution = mdc + "c_gifResolution";
        string config_gifFramerate = mdc + "c_gifFramerate";
        string config_useGpu = mdc + "c_useGpu";
        string config_gpuEncoder = mdc + "c_gpuEncoder";
        string config_customYtdlpArguments = mdc + "c_customYtdlpArguments";
        string config_displayOutput = mdc + "c_displayOutput";
        string config_keepOutput = mdc + "c_keepOutput";
        string config_applyCodecs = mdc + "c_applyCodecs";

        string configBase_main = mdc + "b_main";
        string configBase_switch = mdc + "b_switch";

        string main_mdBat = md2 + "md.bat";
        string main_mdHead = md2 + "md_header";
        string main_warn = md2 + "DO NOT PLACE ANY FILES HERE - THEY WILL BE REMOVED";
        string main_ytDlp = md2 + "yt-dlp.exe";
        string main_Ffmpeg = md2 + "ffmpeg.exe";
        #endregion

        // program events

        // program initialize component
        public program()
        {
            InitializeComponent();

            // create root files
            if (!Directory.Exists(md)) Directory.CreateDirectory(md);
            File.WriteAllText(main_warn, "");

            // configure default variables
            formatBox.SelectedIndex = 5;
            useDefLoc = true;

            #region load configs
            if (File.Exists(config_url)) urlBox.Text = File.ReadAllText(config_url);
            if (File.Exists(config_name)) nameBox.Text = File.ReadAllText(config_name);
            if (File.Exists(config_format)) formatBox.SelectedIndex = int.Parse(File.ReadAllText(config_format));
            if (File.Exists(config_location))
            {
                selLoc = File.ReadAllText(config_location);

                useDefLoc = selLoc != "" ? false : true;
                directoryLabel.Text = selLoc != "" ? selLoc : "";
            }
            if (File.Exists(config_useTimeFrame)) useTimeframe.Checked = File.ReadAllText(config_useTimeFrame) == "1" ? true : false;
            if (File.Exists(config_timeFrameStart)) timeframeStart.Text = File.ReadAllText(config_timeFrameStart); else timeframeStart.Text = "0:00";
            if (File.Exists(config_timeFrameEnd)) timeframeEnd.Text = File.ReadAllText(config_timeFrameEnd); else timeframeEnd.Text = "0:10";
            if (File.Exists(config_gifResolution)) gifResolution.Text = File.ReadAllText(config_gifResolution); else gifResolution.Text = "400";
            if (File.Exists(config_gifFramerate)) gifFramerate.Text = File.ReadAllText(config_gifFramerate); else gifFramerate.Text = "20";
            if (File.Exists(config_useGpu)) useGpu.Checked = File.ReadAllText(config_useGpu) == "1" ? true : false;
            if (File.Exists(config_gpuEncoder)) gpuEncoder.Text = File.ReadAllText(config_gpuEncoder); else gpuEncoder.Text = "h264_nvenc";
            if (File.Exists(config_customYtdlpArguments)) ytArgsBox.Text = File.ReadAllText(config_customYtdlpArguments);
            if (File.Exists(config_displayOutput)) displayOutput.Checked = File.ReadAllText(config_displayOutput) == "1" ? true : false;
            if (File.Exists(config_keepOutput)) keepOutput.Checked = File.ReadAllText(config_keepOutput) == "1" ? true : false;
            if (File.Exists(config_applyCodecs)) applyCodecs.Checked = File.ReadAllText(config_applyCodecs) == "1" ? true : false;
            useConfig.Checked = File.Exists(configBase_switch) ? true : false;
            #endregion

            // configure title
            title = "\ntitle MediaDownloader " + ver + "     ";

            // configure starting arguments
            baseArgs = "@echo off\ncd mediadownloader" + title + "[RUNNING]\ntype md_header\necho    " + ver + "\necho" + repeatString(" ", 72) + "by o7q\necho.\nyt-dlp.exe -vU --ffmpeg-location ffmpeg.exe ";

            #region tooltipDictionary
            // configure repetitive tooltips
            string urlTT = "URL to be downloaded";
            string nameTT = "File name for the download";
            string formTT = "Media format for download";
            string timeSTT = "Trim start time";
            string timeETT = "Trim end time";
            string gifRTT = "Width resolution for gif (web) - Keeps ratio (FFmpeg args = r:-1)";
            string gifFTT = "Framerate for gif (web)";
            string encodeTT = "Encoder to be used - Examples: Nvidia = \"h264_nvenc\" | AMD = \"h264_amf\")";
            string cstmArgTT = "Custom arguments for yt-dlp (double-click to open the yt-dlp GitHub repository)";

            // bind tooltips
            string[] tooltipMap = {
                "bannerPicture", "MediaDownloader by o7q (double-click for info)",
                "versionLabel", "Running " + ver,
                "minimizeButton", "Minimize",
                "exitButton", "Close",
                "urlLabel", urlTT,
                "inputBox", urlTT,
                "fileNameLabel", nameTT,
                "fileNameBox", nameTT,
                "formatLabel", formTT,
                "formatBox", formTT,
                "viewAvailableFormatsButton", "Display all the available media formats found on the server for the specified URL",
                "downloadButton", "Download from the URL using the configured options",
                "locationButton", "Change the folder location for download",
                "openLocationButton", "Open the selected download location in the file explorer",
                "clearLocationButton", "Reset the selected download location",
                "directoryLabel", "Currently selected download location [" + selLoc + "]",
                "advancedLabel", "More extensive options",
                "useConfig", "Save all current component states to config files - If enabled, then on program startup all component states will be restored",
                "resetConfig", "Clear all component states",
                "useTimeframe", "Trim the download to a specific length with a start and end timestamp - Examples: \"0:00 - 0:10\" | \"1:25 - 2:30\" | \"2:30:40 - 3:05:15\"",
                "sLabel", timeSTT,
                "timeframeStart", timeSTT,
                "eLabel", timeETT,
                "timeframeEnd", timeETT,
                "gifQualityLabel", "Quality settings for gif (web)",
                "rLabel", gifRTT,
                "gifResolution", gifRTT,
                "fLabel", gifFTT,
                "gifFramerate", gifFTT,
                "useGpu", "Enable GPU accelerated video encoding - This can fix problems with importing or viewing videos in some software (encodes on the GPU using FFmpeg, this feature only supports mp4, does not work while \"Encode Video (CPU)\" is enabled)",
                "codecLabel", encodeTT,
                "gpuEncoder", encodeTT,
                "ytArgsLabel", cstmArgTT,
                "ytArgsBox", cstmArgTT,
                "outputLabel", "Output log options",
                "displayOutput", "Display the verbose log while downloading in a separate command prompt window",
                "keepOutput", "Causes the command prompt to stay open after the download finishes (helpful for debugging)",
                "applyCodecs", "Enable video encoding - This can fix problems with importing or viewing videos in some software - (encodes on the CPU using FFmpeg, this feature is very slow and it only supports mp4 and webm, does not work while \"Encode Video (GPU)\" is enabled)"
            };
            #endregion

            // configure tooltips
            for (int i = 0; i < tooltipMap.Length; i += 2)
                programToolTip.SetToolTip(Controls.Find(tooltipMap[i], true)[0], tooltipMap[i + 1]);

            // check if the custom directory is missing
            if (!Directory.Exists(selLoc) && !useDefLoc)
            {
                clearLocation();
                directoryLabel.ForeColor = System.Drawing.Color.Brown;
                directoryLabel.Text = "Directory no longer exists";
                programToolTip.SetToolTip(directoryLabel, "The previous directory no longer exists");
            }

            versionLabel.Text = ver;

            // configure tooltip draw
            programToolTip.AutoPopDelay = 10000;
            programToolTip.OwnerDraw = true;
            programToolTip.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            programToolTip.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);

            // configure and start tickClock
            System.Timers.Timer tickClock = new System.Timers.Timer();
            tickClock.Elapsed += new ElapsedEventHandler(doTick);
            tickClock.Interval = 1000;
            tickClock.Enabled = true;
        }

        // draw tooltips
        private void programToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        // do tick
        private void doTick(object source, ElapsedEventArgs e)
        {
            checkBat(false, false);
        }

        // program load
        private void program_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                DialogResult prompt = MessageBox.Show("An instance of MediaDownloader is already running.\nHaving two or more instances of MediaDownloader running simultaneously can cause issues (file corruption, malfunctioning).\n\nAre you sure you want to continue?", "", MessageBoxButtons.YesNo);
                if (prompt == DialogResult.No) Environment.Exit(0);
            }

            // install redists from scoop
            if (File.Exists("..\\..\\yt-dlp\\current\\yt-dlp.exe"))
            {
                try
                {
                    if (File.Exists(main_ytDlp)) File.Delete(main_ytDlp);
                    File.Copy("..\\..\\yt-dlp\\current\\yt-dlp.exe", main_ytDlp);
                }
                catch (Exception ex) { MessageBox.Show("Error while installing \"yt-dlp\" from scoop!\n\nFull Error:\n" + ex); }
            }
            if (File.Exists("..\\..\\ffmpeg\\current\\bin\\ffmpeg.exe"))
            {
                try
                {
                    if (File.Exists(main_Ffmpeg)) File.Delete(main_Ffmpeg);
                    File.Copy("..\\..\\ffmpeg\\current\\bin\\ffmpeg.exe", main_Ffmpeg);
                }
                catch (Exception ex) { MessageBox.Show("Error while installing \"ffmpeg\" from scoop!\n\nFull Error:\n" + ex); }
            }

            // check if redists exist
            if (File.Exists(main_ytDlp)) ytdlpCheck = true; else programCheckFail("yt-dlp.exe");
            if (File.Exists(main_Ffmpeg)) ffmpegCheck = true; else programCheckFail("ffmpeg.exe");
            if (ytdlpCheck && ffmpegCheck)
            {
                // configure default configs
                Directory.CreateDirectory("Downloads");
                Directory.CreateDirectory(md2 + "config");
                if (!File.Exists(configBase_switch)) displayOutput.Checked = true;
                if (!File.Exists(configBase_main)) useConfig.Checked = true;
                File.WriteAllText(configBase_main, "");
            }
        }

        // program closing handler
        private void program_FormClosing(object sender, FormClosingEventArgs e)
        {
            cleanFiles();
        }

        // components

        // minimize button
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // exit button
        private void exitButton_Click(object sender, EventArgs e)
        {
            cleanFiles();
            Application.Exit();
        }

        // configuration components

        // use config checkbox
        private void useConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (!useConfig.Checked) return;

            File.WriteAllText(config_url, urlBox.Text);
            File.WriteAllText(config_name, nameBox.Text);
            File.WriteAllText(config_format, formatBox.SelectedIndex.ToString());
            File.WriteAllText(config_location, selLoc);
            File.WriteAllText(config_useTimeFrame, useTimeframe.Checked ? "1" : "");
            File.WriteAllText(config_timeFrameStart, timeframeStart.Text);
            File.WriteAllText(config_timeFrameEnd, timeframeEnd.Text);
            File.WriteAllText(config_gifResolution, gifResolution.Text);
            File.WriteAllText(config_gifFramerate, gifFramerate.Text);
            File.WriteAllText(config_useGpu, useGpu.Checked ? "1" : "");
            File.WriteAllText(config_gpuEncoder, gpuEncoder.Text);
            File.WriteAllText(config_customYtdlpArguments, ytArgsBox.Text);
            File.WriteAllText(config_displayOutput, displayOutput.Checked ? "1" : "");
            File.WriteAllText(config_keepOutput, keepOutput.Checked ? "1" : "");
            File.WriteAllText(config_applyCodecs, applyCodecs.Checked ? "1" : "");

            File.WriteAllText(configBase_switch, "");
        }

        // reset config button
        private void resetConfig_Click(object sender, EventArgs e)
        {
            // default configs
            urlBox.Text = "";
            nameBox.Text = "";
            formatBox.SelectedIndex = 5;
            useDefLoc = true;
            directoryLabel.Text = "";
            useTimeframe.Checked = false;
            timeframeStart.Text = "0:00";
            timeframeEnd.Text = "0:10";
            gifResolution.Text = "400";
            gifFramerate.Text = "20";
            useGpu.Checked = false;
            gpuEncoder.Text = "h264_nvenc";
            ytArgsBox.Text = "";
            displayOutput.Checked = true;
            keepOutput.Checked = false;
            applyCodecs.Checked = false;
        }

        // url textbox
        private void urlBox_TextChanged(object sender, EventArgs e)
        {
            urlBox.Text = omitCharacter(urlBox.Text);
            if (useConfig.Checked) File.WriteAllText(config_url, urlBox.Text);
        }

        // name textbox
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            nameBox.Text = omitCharacter(nameBox.Text);
            if (useConfig.Checked) File.WriteAllText(config_name, nameBox.Text);
        }

        // format combobox
        private void formatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_format, formatBox.SelectedIndex.ToString());
        }

        // change location button
        private void locationButton_Click(object sender, EventArgs e)
        {
            // opens file location browser, update variables, and write config
            FolderBrowserDialog selectLocation = new FolderBrowserDialog();
            selectLocation.Description = "Select a Folder";
            if (selectLocation.ShowDialog() == DialogResult.OK)
            {
                selLoc = selectLocation.SelectedPath;
                useDefLoc = selLoc == "" ? true : false;

                directoryLabel.Text = selLoc;
                programToolTip.SetToolTip(directoryLabel, "Currently selected download location [" + selLoc + "]");
                directoryLabel.ForeColor = System.Drawing.Color.ForestGreen;

                if (useConfig.Checked)
                    File.WriteAllText(config_location, selLoc);
            }
        }

        // open location button
        private void openLocationButton_Click(object sender, EventArgs e)
        {
            string[] formats = { "", ".mp4", ".webm", ".gif", ".gif", "", "", ".mp3", ".wav", ".ogg", "", "", "" };
            if (File.Exists((selLoc == "" || useDefLoc ? "Downloads" : selLoc) + "\\" + filename + formats[formatBox.SelectedIndex]))
                Process.Start("explorer.exe", "/select, " + (selLoc == "" || useDefLoc ? "Downloads" : selLoc) + "\\" + filename + formats[formatBox.SelectedIndex]);
            else
                Process.Start("explorer.exe", selLoc == "" || useDefLoc ? "Downloads" : selLoc);
        }

        // clear location button
        private void clearLocationButton_Click(object sender, EventArgs e)
        {
            clearLocation();
        }

        // use timeframe checkbox
        private void useTimeframe_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_useTimeFrame, useTimeframe.Checked ? "1" : "");
        }

        // timeframe start textbox
        private void timeframeStart_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_timeFrameStart, timeframeStart.Text);
        }

        // timeframe end textbox
        private void timeframeEnd_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_timeFrameEnd, timeframeEnd.Text);
        }

        // gif resolution textbox
        private void gifResolution_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_gifResolution, gifResolution.Text);
        }

        // gif framerate textbox
        private void gifFramerate_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_gifFramerate, gifFramerate.Text);
        }

        // use gpu checkbox
        private void useGpu_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_useGpu, useGpu.Checked ? "1" : "");
            if (useGpu.Checked) applyCodecs.Checked = false;
        }

        // gpu encoder textbox
        private void gpuEncoder_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_gpuEncoder, gpuEncoder.Text);
        }

        // yt-dlp arguments label double-click
        private void ytArgsLabel_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/yt-dlp/yt-dlp");
        }

        // yt-dlp arguments textbox double-click
        private void ytArgsBox_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/yt-dlp/yt-dlp");
        }

        // yt-dlp arguments textbox
        private void ytArgsBox_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_customYtdlpArguments, ytArgsBox.Text);
        }

        // display output checkbox
        private void displayOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_displayOutput, displayOutput.Checked ? "1" : "");
            if (!displayOutput.Checked && keepOutput.Checked) keepOutput.Checked = false;
        }

        // keep output checkbox
        private void keepOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_keepOutput, keepOutput.Checked ? "1" : "");
            if (!displayOutput.Checked && keepOutput.Checked) displayOutput.Checked = true;
        }

        // apply codecs checkbox
        private void applyCodecs_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) File.WriteAllText(config_applyCodecs, applyCodecs.Checked ? "1" : "");
            if (applyCodecs.Checked) useGpu.Checked = false;
        }

        // execute buttons

        // download button
        private void downloadButton_Click(object sender, EventArgs e)
        {
            #region scriptDictionary

            // configure variables
            string url = urlBox.Text;
            string name = nameBox.Text == "" ? "download" : nameBox.Text;
            int form = formatBox.SelectedIndex;
            string timeS = timeframeStart.Text;
            string timeE = timeframeEnd.Text;
            string gifR = gifResolution.Text;
            string gifF = gifFramerate.Text;
            string ytArgs = ytArgsBox.Text;
            string gEncode = gpuEncoder.Text;
            string bVA = " -b:v 100M -b:a 320K ";
            string ePass = "ENCODING - PASS";
            string dState1 = "[CPU " + ePass + "1]\n";
            string dState2 = "[CPU " + ePass + "2]\n";
            string dState3 = "[GPU " + ePass + "1]\n";
            string dState4 = "[TRIMMING]\n";
            string dState5 = "[FINISHED]\n";
            string dID = DateTime.Now.ToString("[Mdy-hms]");

            filename = name + dID;

            // mp4
            string mp4 = baseArgs + "--remux-video mp4 -o \"" + filename + ".mp4\" --path \"" + selLoc + "\" " + url;
            string mp4_useDefLoc = baseArgs + "--remux-video mp4 -o \"" + filename + ".mp4\" --path " + "\"..\\Downloads\" " + url;
            string mp4_useDefLoc_applyCodecs = baseArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v h264 -c:a aac" + bVA + "\"..\\Downloads\\" + filename + ".mp4\"\n" + "del /f tmp0.mp4";
            string mp4_useDefLoc_useGpu = baseArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState3 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v " + gEncode + " -c:a aac" + bVA + "\"..\\Downloads\\" + filename + ".mp4\"\n" + "del / f tmp0.mp4";
            string mp4_applyCodecs = baseArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v h264 -c:a aac" + bVA + "\"" + selLoc + "\\" + filename + ".mp4\"\n" + "del /f tmp0.mp4";
            string mp4_useGpu = baseArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState3 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v " + gEncode + " -c:a aac" + bVA + "\"" + selLoc + "\\" + filename + ".mp4\"\n" + "del /f tmp0.mp4"; ;

            // webm
            string webm = baseArgs + "--remux-video webm -o \"" + filename + ".webm\" --path \"" + selLoc + "\" " + url;
            string webm_useDefLoc = baseArgs + "--remux-video webm -o \"" + filename + ".webm\" --path " + "\"..\\Downloads\" " + url;
            string webm_useDefLoc_applyCodecs = baseArgs + "--remux-video webm -o \"tmp0.webm\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.webm -c:v vp9 -c:a libvorbis" + bVA + "\"..\\Downloads\\" + filename + ".webm\"\n" + "del /f tmp0.webm";
            string webm_applyCodecs = baseArgs + "--remux-video webm -o \"tmp0.webm\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.webm -c:v vp9 -c:a libvorbis" + bVA + "\"" + selLoc + "\\" + filename + ".webm\"\n" + "del /f tmp0.webm";

            // gif
            string gif = baseArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 \"" + selLoc + "\\" + filename + ".gif\"\n" + "del /f tmp0.mp4";
            string gif_useDefLoc = baseArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 " + "\"..\\Downloads\\" + filename + ".gif\"\n" + "del /f tmp0.mp4";

            // gif (web)
            string gifWeb = baseArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + " \"" + selLoc + "\\" + filename + ".gif\"\n" + "del /f tmp0.mp4";
            string gifWeb_useDefLoc = baseArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + " \"..\\Downloads\\" + filename + ".gif\"\n" + "del /f tmp0.mp4";

            // mp3
            string mp3 = baseArgs + "-x -o \"" + filename + ".mp3\" --audio-format mp3 --path \"" + selLoc + "\" " + url;
            string mp3_useDefLoc = baseArgs + "-x -o \"" + filename + ".mp3\" --audio-format mp3 --path " + "\"..\\Downloads\" " + url;

            // wav
            string wav = baseArgs + "-x -o \"" + filename + ".wav\" --audio-format wav --path \"" + selLoc + "\" " + url;
            string wav_useDefLoc = baseArgs + "-x -o \"" + filename + ".wav\" --audio-format wav --path " + "\"..\\Downloads\" " + url;

            // ogg
            string ogg = baseArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:a libmp3lame tmp1.mp3" + title + dState2 + "ffmpeg.exe -loglevel verbose -i tmp1.mp3 -c:a libvorbis \"" + selLoc + "\\" + filename + ".ogg\"" + "\ndel /f tmp0.mp4" + "\ndel /f tmp1.mp3";
            string ogg_useDefLoc = baseArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:a libmp3lame tmp1.mp3" + title + dState2 + "ffmpeg.exe -loglevel verbose -i tmp1.mp3 -c:a libvorbis " + "\"..\\Downloads\\" + filename + ".ogg\"" + "\ndel /f tmp0.mp4" + "\ndel /f tmp1.mp3";

            // (yt-dlp arguments)
            string ytdlpArgs = baseArgs + "--path \"" + selLoc + "\" " + ytArgs + " " + url;
            string ytdlpArgs_useDefLoc = baseArgs + "--path " + "\"..\\Downloads\" " + ytArgs + " " + url;

            #endregion

            // ensure user specifies valid url
            if (urlBox.Text == "") MessageBox.Show("No URL was specified.");
            else
            {
                // ensure user cannot select non-formats
                if (form == 0 || form == 5 || form == 6 || form == 10 || form == 11)
                    MessageBox.Show("No format was specified.");
                else
                {
                    if (!applyCodecs.Checked && !useGpu.Checked)
                    {
                        // configure and execute download script
                        switch (form)
                        {
                            // mp4
                            case 1: mdScr = useDefLoc ? mp4_useDefLoc : mp4; break;
                            // webm
                            case 2: mdScr = useDefLoc ? webm_useDefLoc : webm; break;
                            // gif
                            case 3: mdScr = useDefLoc ? gif_useDefLoc : gif; break;
                            // gif (web)
                            case 4: if (gifR == "" || gifF == "") { MessageBox.Show("No valid resolution and framerate values were specified."); return; }
                                    else mdScr = useDefLoc ? gifWeb_useDefLoc : gifWeb; break;
                            // mp3
                            case 7: mdScr = useDefLoc ? mp3_useDefLoc : mp3; break;
                            // wav
                            case 8: mdScr = useDefLoc ? wav_useDefLoc : wav; break;
                            // ogg
                            case 9: mdScr = useDefLoc ? ogg_useDefLoc : ogg; break;
                            // (yt-dlp arguments)
                            case 12: mdScr = useDefLoc ? ytdlpArgs_useDefLoc : ytdlpArgs; break;
                        }
                    }

                    if (applyCodecs.Checked)
                    {
                        switch (form)
                        {
                            // invalid formats
                            case 3: case 4: case 7: case 8: case 9: case 12: MessageBox.Show("No video codecs are available for this format.\n(this feature only supports mp4 and webm)"); return;
                            // mp4
                            case 1: mdScr = useDefLoc ? mp4_useDefLoc_applyCodecs : mp4_applyCodecs; break;
                            // webm
                            case 2: mdScr = useDefLoc ? webm_useDefLoc_applyCodecs : webm_applyCodecs; break;
                        }
                    }

                    if (useGpu.Checked)
                    {
                        // mp4
                        if (form != 1) { MessageBox.Show("No GPU accelerated encoders are available for this format.\n(this feature only supports mp4)"); return; } else mdScr = useDefLoc ? mp4_useDefLoc_useGpu : mp4_useGpu;
                    }

                    // inject trimmer
                    if (useTimeframe.Checked)
                    {
                        // process format
                        string fExt = null;
                        string[] fExtIndex = { ".mp4", ".webm", ".gif", ".gif", "", "", ".mp3", ".wav", ".ogg" };
                        for (int i = 0; i <= 9; i++)
                            if (form == i)
                                fExt = fExtIndex[i - 1];
                        if (form == 12) { MessageBox.Show("Trimming cannot be used with with format."); return; }
                        if (fExt == null) return;

                        if (useDefLoc)
                            mdScr += title + dState4 + "ffmpeg.exe -loglevel verbose -i \"..\\Downloads\\" + filename + fExt + "\" -ss " + timeS + " -to " + timeE + bVA + "\"..\\Downloads\\" + name + "_trim" + dID + fExt + "\"\ndel /f \"..\\Downloads\\" + filename + fExt + "\""; else mdScr += title + dState4 + "ffmpeg.exe -loglevel verbose -i \"" + selLoc + "\\" + filename + fExt + "\" -ss " + timeS + " -to " + timeE + bVA + "\"" + selLoc + "\\" + name + "_trim" + dID + fExt + "\"\ndel /f \"" + selLoc + "\\" + filename + fExt + "\"";
                        filename = name + "_trim" + dID;
                    }

                    // inject pause
                    if (keepOutput.Checked) mdScr += title + dState5 + "echo.\npause";

                    // start download
                    if (mdScr != null) checkBat(true, false);
                }
            }
        }

        // view available formats button
        private void viewAvailableFormatsButton_Click(object sender, EventArgs e)
        {
            // displays available formats of the specified url
            if (urlBox.Text == "") MessageBox.Show("No URL was specified.");
            else
            {
                mdScr = baseArgs + "--list-formats " + urlBox.Text + "\necho.\npause";
                checkBat(true, true);
            }
        }

        // functions

        // check batch function
        private void checkBat(bool srt, bool isFormatDisplay)
        {
            bool progOpen = false;

            foreach (Process progOpenCheck in Process.GetProcesses()) if (progOpenCheck.ProcessName.Contains("yt-dlp") || progOpenCheck.ProcessName.Contains("ffmpeg")) progOpen = true;
            if (!progOpen)
            {
                downloadButton.ForeColor = System.Drawing.Color.LimeGreen;
                if (srt) runBat(isFormatDisplay);
            }
            else downloadButton.ForeColor = System.Drawing.Color.DarkSeaGreen;
        }

        // run batch function
        private void runBat(bool omitHidden)
        {
            cleanFiles();

            // write and start batch script
            File.WriteAllText(main_mdHead, Properties.Resources.asciiBanner);
            File.WriteAllText(main_mdBat, mdScr);
            if (displayOutput.Checked || omitHidden == true) Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\mediadownloader\\md.bat");        
            else
            {
                ProcessStartInfo runHidden = new ProcessStartInfo();
                runHidden.WindowStyle = ProcessWindowStyle.Hidden;
                runHidden.FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\mediadownloader\\md.bat";

                Process.Start(runHidden);
            }

            downloadButton.ForeColor = System.Drawing.Color.DarkSeaGreen;
        }

        // clean files function
        private void cleanFiles()
        {
            string[] files = Directory.GetFiles(md);
            foreach (string file in files)
            {
                var name = new FileInfo(file).Name;
                if (name != "yt-dlp.exe" && name != "ffmpeg.exe" && name != "DO NOT PLACE ANY FILES HERE - THEY WILL BE REMOVED")
                    File.Delete(file);
            }

            // delete configs if use config is disabled
            if (!useConfig.Checked)
            {
                File.Delete(config_url);
                File.Delete(config_name);
                File.Delete(config_format);
                File.Delete(config_location);
                File.Delete(config_useTimeFrame);
                File.Delete(config_timeFrameStart);
                File.Delete(config_timeFrameEnd);
                File.Delete(config_gifResolution);
                File.Delete(config_gifFramerate);
                File.Delete(config_useGpu);
                File.Delete(config_gpuEncoder);
                File.Delete(config_customYtdlpArguments);
                File.Delete(config_displayOutput);
                File.Delete(config_keepOutput);
                File.Delete(config_applyCodecs);

                File.Delete(configBase_switch);
            }
        }

        // clear location function
        private void clearLocation()
        {
            // clears selected location
            useDefLoc = true;
            selLoc = ""; directoryLabel.Text = "";

            if (useConfig.Checked) File.WriteAllText(config_location, selLoc);
        }

        // program check fail function
        private void programCheckFail(string errMsg)
        {
            MessageBox.Show("\"" + errMsg + "\" was not found! Exiting MediaDownloader.\n\nMake sure you have \"yt-dlp.exe\" and \"ffmpeg.exe\" in a folder named \"mediadownloader\" next to \"MediaDownloader.exe\".\nIf you are using scoop please make sure you have installed everything correctly.");
            Environment.Exit(1);
        }

        // omit bad characters function
        string omitCharacter(string input)
        {
            string[] invalidChars = { "0x7f" };
            for (int i = 0; i < invalidChars.Length; i++)
            {
                char badChar = (char)Convert.ToUInt32(invalidChars[i], 16);
                if (input.Contains(badChar))
                    input = input.Replace(badChar.ToString(), "");
            }

            return input;
        }

        // string repeater function
        string repeatString(string charIn, int amount)
        {
            string output = "";
            for (int i = 0; i <= amount; i++) output += charIn;
            return output;
        }

        // move form on mousedown function
        private void moveForm(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // titlebar panel sender
        private void titlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            moveForm(e);
        }

        // banner picture sender
        int toggle;
        private void bannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2 && toggle == 0)
                { MessageBox.Show(Properties.Resources.infoText); toggle = 1; }
            else if (e.Button == MouseButtons.Left && e.Clicks == 2 && toggle == 1)
                { Process.Start("https://github.com/o7q/MediaDownloader"); toggle = 0; }
            moveForm(e);
        }

        // version label sender
        private void versionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            moveForm(e);
        }
    }
}