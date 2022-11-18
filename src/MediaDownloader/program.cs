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
        const string ver = "v3.8.0";

        // shortcut strings
        const string md = "mediadownloader";
        const string md2 = md + "\\";
        const string mdc = md2 + "config\\";

        // redist check
        bool ytdlpCheck;
        bool ffmpegCheck;

        // batch configuration
        string srtArgs;
        bool useDefLoc;
        string selLoc;
        string mdScr;

        // info state
        int toggle;

        // asset dictionary
        string[] asset =
        {
            mdc + "c0_u", // 0 (url)
            mdc + "c1_fN", // 1 (filename)
            mdc + "c2_f", // 2 (format)
            mdc + "c3_l", // 3 (location)
            mdc + "c4_uTF", // 4 (use time frame)
            mdc + "c5_tS", // 5 (time start)
            mdc + "c6_tE", // 6 (time end)
            mdc + "c7_gR", // 7 (gif resolution)
            mdc + "c8_gF", // 8 (gif framerate)
            mdc + "c9_uG", // 9 (use gpu)
            mdc + "c10_gE", // 10 (gpu encoder)
            mdc + "c11_cYA", // 11 (custom yt-dlp arguments)
            mdc + "c12_dO", // 12 (display output)
            mdc + "c13_kO", // 13 (keep output)
            mdc + "c14_aC", // 14 (apply codecs)
            mdc + "c_switch", // 15 (config switch)
            mdc + "c_base", // 16 (config base)
            md2 + "md_header", // 17
            md2 + "md.bat", // 18
            md2 + "DO NOT PLACE ANY FILES HERE - THEY WILL BE REMOVED", // 19
            md2 + "yt-dlp.exe", // 20
            md2 + "ffmpeg.exe" // 21
        };

        // program events

        // program initialize component
        public program()
        {
            InitializeComponent();

            // create root files
            if (!Directory.Exists(md)) try { Directory.CreateDirectory(md); } catch { }
            try { File.WriteAllText(asset[19], ""); } catch { }

            // configure default variables
            formatBox.SelectedIndex = 5;
            useDefLoc = true;

            // load configs
            if (File.Exists(asset[0])) try { inputBox.Text = File.ReadAllText(asset[0]); } catch { }
            if (File.Exists(asset[1])) try { fileNameBox.Text = File.ReadAllText(asset[1]); } catch { }
            if (File.Exists(asset[2])) try { formatBox.SelectedIndex = int.Parse(File.ReadAllText(asset[2])); } catch { }
            if (File.Exists(asset[3]))
            {
                try { selLoc = File.ReadAllText(asset[3]); } catch { }

                useDefLoc = selLoc != "" ? false : true;
                directoryLabel.Text = selLoc != "" ? selLoc : "";
            }
            if (File.Exists(asset[4])) try { useTimeframe.Checked = File.ReadAllText(asset[4]) == "1" ? true : false; } catch { }
            if (File.Exists(asset[5])) try { timeframeStart.Text = File.ReadAllText(asset[5]); } catch { } else timeframeStart.Text = "0:00";
            if (File.Exists(asset[6])) try { timeframeEnd.Text = File.ReadAllText(asset[6]); } catch { } else timeframeEnd.Text = "0:10";
            if (File.Exists(asset[7])) try { gifResolution.Text = File.ReadAllText(asset[7]); } catch { } else gifResolution.Text = "400";
            if (File.Exists(asset[8])) try { gifFramerate.Text = File.ReadAllText(asset[8]); } catch { } else gifFramerate.Text = "20";
            if (File.Exists(asset[9])) try { useGpu.Checked = File.ReadAllText(asset[9]) == "1" ? true : false; } catch { }
            if (File.Exists(asset[10])) try { gpuEncoder.Text = File.ReadAllText(asset[10]); } catch { } else gpuEncoder.Text = "h264_nvenc";
            if (File.Exists(asset[11])) try { ytArgsBox.Text = File.ReadAllText(asset[11]); } catch { }
            if (File.Exists(asset[12])) try { displayOutput.Checked = File.ReadAllText(asset[12]) == "1" ? true : false; } catch { }
            if (File.Exists(asset[13])) try { keepOutput.Checked = File.ReadAllText(asset[13]) == "1" ? true : false; } catch { }
            if (File.Exists(asset[14])) try { applyCodecs.Checked = File.ReadAllText(asset[14]) == "1" ? true : false; } catch { }
            useConfig.Checked = File.Exists(asset[15]) ? true : false;

            // configure title
            title = "\ntitle MediaDownloader " + ver + "     ";

            // configure starting arguments
            srtArgs = "@echo off\ncd mediadownloader" + title + "[RUNNING]\ntype md_header\necho    " + ver + "\necho" + strRep(" ", 71) + "by o7q\necho.\nyt-dlp.exe -vU --ffmpeg-location ffmpeg.exe ";

            #region tooltipDictionary

            // configure variables
            string urlTT = "URL to be downloaded";
            string nameTT = "File name for the download";
            string formTT = "Media format for download";
            string timeSTT = "Trim start time";
            string timeETT = "Trim end time";
            string gifRTT = "Width resolution for gif (web) - Keeps ratio (FFmpeg args = r:-1)";
            string gifFTT = "Framerate for gif (web)";
            string encodeTT = "Encoder to be used - Examples: Nvidia = \"h264_nvenc\" | AMD = \"h264_amf\")";
            string cstmArgTT = "Custom arguments for yt-dlp (double-click to open the yt-dlp GitHub repository)";

            // components
            var component = new Control[] {
                bannerPicture, // 0
                versionLabel, // 1
                minimizeButton, // 2
                exitButton, // 3
                urlLabel, // 4
                inputBox, // 5
                fileNameLabel, // 6
                fileNameBox, // 7
                formatLabel, // 8
                formatBox, // 9
                viewAvailableFormatsButton, // 10
                downloadButton, // 11
                locationButton, // 12
                openLocationButton, // 13
                clearLocationButton, // 14
                directoryLabel, // 15
                advancedLabel, // 16
                useConfig, // 17
                resetConfig, // 18
                useTimeframe, // 19
                sLabel, // 20
                timeframeStart, // 21
                eLabel, // 22
                timeframeEnd, // 23
                gifQualityLabel, // 24
                rLabel, // 25
                gifResolution, // 26
                fLabel, // 27
                gifFramerate, // 28
                useGpu, // 29
                codecLabel, // 30
                gpuEncoder, // 31
                ytArgsLabel, // 32
                ytArgsBox, // 33
                outputLabel, // 34
                displayOutput, // 35
                keepOutput, // 36
                applyCodecs // 37
            };

            // tooltips
            string[] tooltip = {
                "MediaDownloader by o7q (double-click for info)", // 0
                "Running " + ver, // 1
                "Minimize", // 2
                "Close", // 3
                urlTT, // 4
                urlTT, // 5
                nameTT, // 6
                nameTT, // 7
                formTT, // 8
                formTT, // 9
                "Display all the available media formats found on the server for the specified URL", // 10
                "Download from the URL using the configured options", // 11
                "Change the folder location for download", // 12
                "Open the selected download location in the file explorer", // 13
                "Reset the selected download location", // 14
                "Currently selected download location [" + selLoc + "]", // 15
                "More extensive options",  // 16
                "Save all current component states to config files - If enabled, then on program startup all component states will be restored", // 17
                "Clear all component states", // 18
                "Trim the download to a specific length with a start and end timestamp - Examples: \"0:00 - 0:10\" | \"1:25 - 2:30\" | \"2:30:40 - 3:05:15\"", // 19
                timeSTT, // 20
                timeSTT, // 21
                timeETT, // 22
                timeETT, // 23
                "Quality settings for gif (web)", // 24
                gifRTT, // 25
                gifRTT, // 26
                gifFTT, // 27
                gifFTT, // 28
                "Enable GPU accelerated video encoding - This can fix problems with importing or viewing videos in some software (encodes on the GPU using FFmpeg, this feature only supports mp4, does not work while \"Encode Video (CPU)\" is enabled)", // 29
                encodeTT, // 30
                encodeTT, // 31
                cstmArgTT, // 32
                cstmArgTT, // 33
                "Output log options", // 34
                "Display the verbose log while downloading in a separate command prompt window", // 35
                "Causes the command prompt to stay open after the download finishes (helpful for debugging)", // 36
                "Enable video encoding - This can fix problems with importing or viewing videos in some software - (encodes on the CPU using FFmpeg, this feature is very slow and it only supports mp4 and webm, does not work while \"Encode Video (GPU)\" is enabled)", // 37
            };

            #endregion

            // configure tooltips
            for (int i = 0; i <= 37; i++) programToolTip.SetToolTip(component[i], tooltip[i]);

            // check if the custom directory is missing
            if (!Directory.Exists(selLoc) && !useDefLoc)
            {
                clrLoc();
                directoryLabel.ForeColor = System.Drawing.Color.Brown;
                directoryLabel.Text = "Directory no longer exists";
                programToolTip.SetToolTip(directoryLabel, "The previous directory no longer exists");
            }

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
            chkBat(false, false);
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
                    if (File.Exists(asset[20])) File.Delete(asset[20]);
                    File.Copy("..\\..\\yt-dlp\\current\\yt-dlp.exe", asset[20]);
                }
                catch (Exception ex) { MessageBox.Show("Error while installing \"yt-dlp\" from scoop!\n\nFull Error:\n" + ex); }
            }
            if (File.Exists("..\\..\\ffmpeg\\current\\bin\\ffmpeg.exe"))
            {
                try
                {
                    if (File.Exists(asset[21])) File.Delete(asset[21]);
                    File.Copy("..\\..\\ffmpeg\\current\\bin\\ffmpeg.exe", asset[21]);
                }
                catch (Exception ex) { MessageBox.Show("Error while installing \"ffmpeg\" from scoop!\n\nFull Error:\n" + ex); }
            }

            // check if redists exist
            if (File.Exists(asset[20])) ytdlpCheck = true; else progChckFail("yt-dlp.exe");
            if (File.Exists(asset[21])) ffmpegCheck = true; else progChckFail("ffmpeg.exe");
            if (ytdlpCheck && ffmpegCheck)
            {
                // configure default configs
                try { Directory.CreateDirectory("Downloads"); } catch { }
                try { Directory.CreateDirectory(md2 + "config"); } catch { }
                if (!File.Exists(asset[15])) displayOutput.Checked = true;
                if (!File.Exists(asset[16]))
                {
                    useConfig.Checked = true;
                }
                try { File.WriteAllText(asset[16], ""); } catch { }
            }
        }

        // program closing handler
        private void program_FormClosing(object sender, FormClosingEventArgs e)
        {
            clnFiles();
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
            clnFiles();
            Application.Exit();
        }

        // configuration components

        // use config checkbox
        private void useConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (!useConfig.Checked) return;
            try { for (int i = 0; i <= 15; i++) File.WriteAllText(asset[i], ""); } catch { }
            string[] configOut = { inputBox.Text /*0 (url)*/, fileNameBox.Text /*1 (filename)*/, formatBox.SelectedIndex.ToString() /*2 (format)*/, selLoc /*3 (location)*/, useTimeframe.Checked ? "1" : "" /*4 (use time frame)*/, timeframeStart.Text /*5 (time start)*/, timeframeEnd.Text /*6 (time end)*/, gifResolution.Text /*7 (gif resolution)*/, gifFramerate.Text /*8 (gif framerate)*/, useGpu.Checked ? "1" : "" /*9 (use gpu)*/, gpuEncoder.Text /*10 (gpu encoder)*/, ytArgsBox.Text /*11 (custom yt-dlp arguments)*/, displayOutput.Checked ? "1" : "" /*12 (display output)*/, keepOutput.Checked ? "1" : "" /*13 (keep output)*/, applyCodecs.Checked ? "1" : "" /*14 (apply codecs)*/ };
            if (useConfig.Checked) for (int i = 0; i <= 15; i++) try { File.WriteAllText(asset[i], configOut[i]); } catch { }
        }

        // reset config button
        private void resetConfig_Click(object sender, EventArgs e)
        {
            // default configs
            inputBox.Text = "";
            fileNameBox.Text = "";
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

            // store default configs
            string[] configIndex = { "", "", "5", "", "", "0:00", "0:10", "400", "20", "", "h264_nvenc", "", "1", "", "", "" };
            if (useConfig.Checked) for (int i = 0; i <= 15; i++) try { File.WriteAllText(asset[i], configIndex[i]); } catch { }
        }

        // input textbox
        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[0], inputBox.Text); } catch { }
        }

        // filename textbox
        private void fileNameBox_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[1], fileNameBox.Text); } catch { }
        }

        // format combobox
        private void formatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[2], formatBox.SelectedIndex.ToString()); } catch { }
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

                if (useConfig.Checked) try { File.WriteAllText(asset[3], selLoc); } catch { }
            }
        }

        // open location button
        private void openLocationButton_Click(object sender, EventArgs e)
        {
            try { Process.Start("explorer.exe", selLoc == "" || useDefLoc ? "Downloads" : selLoc); } catch { }
        }

        // clear location button
        private void clearLocationButton_Click(object sender, EventArgs e)
        {
            clrLoc();
        }

        // use timeframe checkbox
        private void useTimeframe_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[4], useTimeframe.Checked ? "1" : ""); } catch { }
        }

        // timeframe start textbox
        private void timeframeStart_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[5], timeframeStart.Text); } catch { }
        }

        // timeframe end textbox
        private void timeframeEnd_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[6], timeframeEnd.Text); } catch { }
        }

        // gif resolution textbox
        private void gifResolution_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[7], gifResolution.Text); } catch { }
        }

        // gif framerate textbox
        private void gifFramerate_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[8], gifFramerate.Text); } catch { }
        }

        // use gpu checkbox
        private void useGpu_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[9], useGpu.Checked ? "1" : ""); } catch { }
            if (useGpu.Checked) applyCodecs.Checked = false;
        }

        // gpu encoder textbox
        private void gpuEncoder_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[10], gpuEncoder.Text); } catch { }
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
            if (useConfig.Checked) try { File.WriteAllText(asset[11], ytArgsBox.Text); } catch { }
        }

        // display output checkbox
        private void displayOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[12], displayOutput.Checked ? "1" : ""); } catch { }
            if (!displayOutput.Checked && keepOutput.Checked) keepOutput.Checked = false;
        }

        // keep output checkbox
        private void keepOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[13], keepOutput.Checked ? "1" : ""); } catch { }
            if (!displayOutput.Checked && keepOutput.Checked) displayOutput.Checked = true;
        }

        // apply codecs checkbox
        private void applyCodecs_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked) try { File.WriteAllText(asset[14], applyCodecs.Checked ? "1" : ""); } catch { }
            if (applyCodecs.Checked) useGpu.Checked = false;
        }

        // execute buttons

        // download button
        private void downloadButton_Click(object sender, EventArgs e)
        {
            #region scriptDictionary

            // configure variables
            string url = inputBox.Text;
            string name = fileNameBox.Text == "" ? "download" : fileNameBox.Text;
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

            // mp4
            string mp4 = srtArgs + "--remux-video mp4 -o \"" + name + dID + ".mp4\" --path \"" + selLoc + "\" " + url;
            string mp4_useDefLoc = srtArgs + "--remux-video mp4 -o \"" + name + dID + ".mp4\" --path " + "\"..\\Downloads\" " + url;
            string mp4_useDefLoc_applyCodecs = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v h264 -c:a aac" + bVA + "\"..\\Downloads\\" + name + dID + ".mp4\"\n" + "del /f tmp0.mp4";
            string mp4_useDefLoc_useGpu = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState3 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v " + gEncode + " -c:a aac" + bVA + "\"..\\Downloads\\" + name + dID + ".mp4\"\n" + "del / f tmp0.mp4";
            string mp4_applyCodecs = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v h264 -c:a aac" + bVA + "\"" + selLoc + "\\" + name + dID + ".mp4\"\n" + "del /f tmp0.mp4";
            string mp4_useGpu = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState3 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v " + gEncode + " -c:a aac" + bVA + "\"" + selLoc + "\\" + name + dID + ".mp4\"\n" + "del /f tmp0.mp4"; ;

            // webm
            string webm = srtArgs + "--remux-video webm -o \"" + name + dID + ".webm\" --path \"" + selLoc + "\" " + url;
            string webm_useDefLoc = srtArgs + "--remux-video webm -o \"" + name + dID + ".webm\" --path " + "\"..\\Downloads\" " + url;
            string webm_useDefLoc_applyCodecs = srtArgs + "--remux-video webm -o \"tmp0.webm\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.webm -c:v vp9 -c:a libvorbis" + bVA + "\"..\\Downloads\\" + name + dID + ".webm\"\n" + "del /f tmp0.webm";
            string webm_applyCodecs = srtArgs + "--remux-video webm -o \"tmp0.webm\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.webm -c:v vp9 -c:a libvorbis" + bVA + "\"" + selLoc + "\\" + name + dID + ".webm\"\n" + "del /f tmp0.webm";

            // gif
            string gif = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 \"" + selLoc + "\\" + name + dID + ".gif\"\n" + "del /f tmp0.mp4";
            string gif_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 " + "\"..\\Downloads\\" + name + dID + ".gif\"\n" + "del /f tmp0.mp4";

            // gif (web)
            string gifWeb = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + " \"" + selLoc + "\\" + name + dID + ".gif\"\n" + "del /f tmp0.mp4";
            string gifWeb_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + " \"..\\Downloads\\" + name + dID + ".gif\"\n" + "del /f tmp0.mp4";

            // mp3
            string mp3 = srtArgs + "-x -o \"" + name + dID + ".mp3\" --audio-format mp3 --path \"" + selLoc + "\" " + url;
            string mp3_useDefLoc = srtArgs + "-x -o \"" + name + dID + ".mp3\" --audio-format mp3 --path " + "\"..\\Downloads\" " + url;

            // wav
            string wav = srtArgs + "-x -o \"" + name + dID + ".wav\" --audio-format wav --path \"" + selLoc + "\" " + url;
            string wav_useDefLoc = srtArgs + "-x -o \"" + name + dID + ".wav\" --audio-format wav --path " + "\"..\\Downloads\" " + url;

            // ogg
            string ogg = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:a libmp3lame tmp1.mp3" + title + dState2 + "ffmpeg.exe -loglevel verbose -i tmp1.mp3 -c:a libvorbis \"" + selLoc + "\\" + name + dID + ".ogg\"" + "\ndel /f tmp0.mp4" + "\ndel /f tmp1.mp3";
            string ogg_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + dState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:a libmp3lame tmp1.mp3" + title + dState2 + "ffmpeg.exe -loglevel verbose -i tmp1.mp3 -c:a libvorbis " + "\"..\\Downloads\\" + name + dID + ".ogg\"" + "\ndel /f tmp0.mp4" + "\ndel /f tmp1.mp3";

            // (yt-dlp arguments)
            string ytdlpArgs = srtArgs + "--path \"" + selLoc + "\" " + ytArgs + " " + url;
            string ytdlpArgs_useDefLoc = srtArgs + "--path " + "\"..\\Downloads\" " + ytArgs + " " + url;

            #endregion

            // ensure user specifies valid url
            if (inputBox.Text == "") MessageBox.Show("No URL was specified.");
            else
            {
                // ensure user cannot select non-formats
                if (form == 0 || form == 5 || form == 6 || form == 10 || form == 11) MessageBox.Show("No format was specified.");
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
                            case 4: if (gifR == "" || gifF == "") { MessageBox.Show("No valid resolution and framerate values were specified."); return; } else mdScr = useDefLoc ? gifWeb_useDefLoc : gifWeb; break;
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
                        for (int i = 0; i <= 9; i++) if (form == i) fExt = fExtIndex[i - 1];
                        if (form == 12) { MessageBox.Show("Trimming cannot be used with with format."); return; }
                        if (fExt == null) return;

                        if (useDefLoc) mdScr += title + dState4 + "ffmpeg.exe -loglevel verbose -i \"..\\Downloads\\" + name + dID + fExt + "\" -ss " + timeS + " -to " + timeE + bVA + "\"..\\Downloads\\" + name + "_trim" + dID + fExt + "\"\ndel /f \"..\\Downloads\\" + name + dID + fExt + "\""; else mdScr += title + dState4 + "ffmpeg.exe -loglevel verbose -i \"" + selLoc + "\\" + name + dID + fExt + "\" -ss " + timeS + " -to " + timeE + bVA + "\"" + selLoc + "\\" + name + "_trim" + dID + fExt + "\"\ndel /f \"" + selLoc + "\\" + name + dID + fExt + "\"";
                    }

                    // inject pause
                    if (keepOutput.Checked) mdScr += title + dState5 + "echo.\npause";

                    // start download
                    if (mdScr != null) chkBat(true, false);
                }
            }
        }

        // view available formats button
        private void viewAvailableFormatsButton_Click(object sender, EventArgs e)
        {
            // displays available formats of the specified url
            if (inputBox.Text == "") MessageBox.Show("No URL was specified.");
            else
            {
                mdScr = srtArgs + "--list-formats " + inputBox.Text + "\necho.\npause";
                chkBat(true, true);
            }
        }

        // functions

        // check batch function
        private void chkBat(bool srt, bool isFormatDisplay, bool progOpen = false)
        {
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
            clnFiles();

            // write and start batch script
            try { File.WriteAllText(asset[17], Properties.Resources.asciiBanner); } catch { }
            try { File.WriteAllText(asset[18], mdScr); } catch { }
            if (displayOutput.Checked || omitHidden == true) try { Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\mediadownloader\\md.bat"); } catch { }           
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
        private void clnFiles()
        {
            string[] asset_fix = asset.Select(x => x.Replace(md2, "")).ToArray();
            if (Directory.Exists(md))
            {
                string[] files = Directory.GetFiles(md);
                foreach (string file in files)
                {
                    var f = new FileInfo(file).Name;
                    bool fIndex = true;
                    for (int i = 0; i <= 16; i++) if (f == asset_fix[i]) { fIndex = false; break; }
                    for (int i = 19; i <= 21; i++) if (f == asset_fix[i]) { fIndex = false; break; }
                    if (fIndex) try { File.Delete(file); } catch { }
                }
            }

            // delete configs if use config is disabled
            try { if (!useConfig.Checked) for (int i = 0; i <= 15; i++) File.Delete(asset[i]); } catch { }
        }

        // clear location function
        private void clrLoc()
        {
            // clears selected location
            useDefLoc = true;
            selLoc = ""; directoryLabel.Text = "";

            if (useConfig.Checked) File.WriteAllText(asset[3], selLoc);
        }

        // program check fail function
        private void progChckFail(string errMsg)
        {
            MessageBox.Show("\"" + errMsg + "\" was not found! Exiting MediaDownloader.\n\nMake sure you have \"yt-dlp.exe\" and \"ffmpeg.exe\" in a folder named \"mediadownloader\" next to \"MediaDownloader.exe\".\nIf you are using scoop please make sure you have installed everything correctly.");
            Environment.Exit(1);
        }

        // string repeater function
        string strRep(string charIn, int amount, string output = "")
        {
            for (int i = 0; i <= amount; i++) output += charIn;
            return output;
        }

        // move form on mousedown function
        private void mvFrm(MouseEventArgs e)
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
            mvFrm(e);
        }

        // banner picture sender
        private void bannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2 && toggle == 0) { MessageBox.Show(Properties.Resources.infoText); toggle = 1; } else if (e.Button == MouseButtons.Left && e.Clicks == 2 && toggle == 1) { Process.Start("https://github.com/o7q/MediaDownloader"); toggle = 0; }
            mvFrm(e);
        }

        // version label sender
        private void versionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            mvFrm(e);
        }
    }
}