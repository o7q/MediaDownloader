using System;
using System.IO;
using System.Linq;
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
        const string ver = "v3.6.0";

        // batch configuration
        string srtArgs;
        bool useDefLoc;
        string selLoc;
        string mdScr;

        // redist check
        bool ytdlpCheck;
        bool ffmpegCheck;

        // asset dictionary
        string[] asset =
        {
            "mediadownloader\\c0_u", // 0
            "mediadownloader\\c1_f", // 1
            "mediadownloader\\c2_l", // 2
            "mediadownloader\\c3_aC", // 3
            "mediadownloader\\c4_uTF", // 4
            "mediadownloader\\c5_tS", // 5
            "mediadownloader\\c6_tE", // 6
            "mediadownloader\\c7_gR", // 7
            "mediadownloader\\c8_gF", // 8
            "mediadownloader\\c9_uG", // 9
            "mediadownloader\\c10_gE", // 10
            "mediadownloader\\cState", // 11
            "mediadownloader\\mdHead", // 12
            "mediadownloader\\md.bat", // 13
            "mediadownloader\\DO NOT PLACE ANY FILES HERE - THEY WILL BE REMOVED", // 14
            "mediadownloader\\yt-dlp.exe", // 15
            "mediadownloader\\ffmpeg.exe" // 16
        };

        // program events

        // program initialize component
        public program()
        {
            InitializeComponent();

            // create mediadownloader.bat and warning files
            try
            {
                File.WriteAllText(asset[13], "");
                File.WriteAllText(asset[14], "");
            }
            catch { }

            // configure default variables
            formatBox.SelectedIndex = 6;
            useDefLoc = true;

            // load configs
            if (File.Exists(asset[0])) try { inputBox.Text = File.ReadAllText(asset[0]); } catch { }
            if (File.Exists(asset[1])) try { formatBox.SelectedIndex = int.Parse(File.ReadAllText(asset[1])); } catch { }
            if (File.Exists(asset[2]))
            {
                try { selLoc = File.ReadAllText(asset[2]); } catch { }

                useDefLoc = selLoc != "" ? false : true;
                directoryLabel.Text = selLoc != "" ? selLoc : "";
            }
            if (File.Exists(asset[3])) try { applyCodecs.Checked = File.ReadAllText(asset[3]) == "1" ? true : false; } catch { }
            if (File.Exists(asset[4])) try { useTimeframe.Checked = File.ReadAllText(asset[4]) == "1" ? true : false; } catch { }
            if (File.Exists(asset[5])) try { timeframeStart.Text = File.ReadAllText(asset[5]); } catch { } else timeframeStart.Text = "0:00";
            if (File.Exists(asset[6])) try { timeframeEnd.Text = File.ReadAllText(asset[6]); } catch { } else timeframeEnd.Text = "0:10";
            if (File.Exists(asset[7])) try { gifResolution.Text = File.ReadAllText(asset[7]); } catch { } else gifResolution.Text = "400";
            if (File.Exists(asset[8])) try { gifFramerate.Text = File.ReadAllText(asset[8]); } catch { } else gifFramerate.Text = "20";
            if (File.Exists(asset[9])) try { useGpu.Checked = File.ReadAllText(asset[9]) == "1" ? true : false; } catch { }
            if (File.Exists(asset[10])) try { gpuEncoder.Text = File.ReadAllText(asset[10]); } catch { } else gpuEncoder.Text = "h264_nvenc";
            useConfig.Checked = File.Exists(asset[11]) ? true : false;

            // configure title
            title = "\ntitle MediaDownloader " + ver + "     ";

            // configure starting arguments
            srtArgs = "@echo off\ncd mediadownloader" + title + "[RUNNING]\ntype mdHead\necho    " + ver + "\necho" + strRep(" ", 71) + "by o7q\necho.\nyt-dlp.exe -vU --ffmpeg-location ffmpeg.exe ";

            #region tooltipDictionary

            // configure variables
            string urlTT = "URL to be downloaded";
            string formTT = "Media format for download";
            string timeSTT = "Trim start time";
            string timeETT = "Trim end time";
            string gifRTT = "Width resolution for gif (web) - Keeps ratio (ffmpeg args = r:-1)";
            string gifFTT = "Framerate for gif (web)";
            string encodeTT = "Encoder to be used - Examples: Nvidia = \"h264_nvenc\" | AMD = \"h264_amf\")";

            // components
            var component = new Control[] {
                bannerPicture, // 0
                versionLabel, // 1
                minimizeButton, // 2
                exitButton, // 3
                urlLabel, // 4
                inputBox, // 5
                formatLabel, // 6
                formatBox, // 7
                downloadButton, // 8
                locationButton, // 9
                openLocationButton, // 10
                clearLocationButton, // 11
                directoryLabel, // 12
                advancedLabel, // 13
                viewAvailableFormatsButton, // 14
                infoButton, // 15
                githubButton, // 16
                ytdlpGithubButton, // 17
                applyCodecs, // 18
                useConfig, // 19
                resetConfig, // 20
                useTimeframe, // 21
                sLabel, // 22
                timeframeStart, // 23
                eLabel, // 24
                timeframeEnd, // 25
                gifQualityLabel, // 26
                rLabel, // 27
                gifResolution, // 28
                fLabel, // 29
                gifFramerate, // 30
                useGpu, // 31
                codecLabel, // 32
                gpuEncoder // 33
            };

            // tooltips
            string[] tooltip = {
                "MediaDownloader by o7q", // 0
                "Running " + ver, // 1
                "Minimize", // 2
                "Close", // 3
                urlTT, // 4
                urlTT, // 5
                formTT, // 6
                formTT, // 7
                "Download from the URL with the specified arguments", // 8
                "Change folder location for download", // 9
                "Open the selected download location in Windows Explorer", // 10
                "Reset the selected download location", // 11
                "Currently selected download location [" + selLoc + "]", // 12
                "More extensive options",  // 13
                "Display all the available media formats found on the server for the specified URL", // 14
                "Display info about MediaDownloader", // 15
                "Open the MediaDownloader github repository in the default web browser", // 16
                "Open the yt-dlp github repository in the default web browser", // 17
                "Apply valid video codecs after the video is downloaded (encodes using ffmpeg on the CPU) - This can fix problems with importing videos into some software - (this feature is very slow and it only supports mp4 and webm, does not work while \"Use GPU Acceleration\" is enabled)", // 18
                "Save all current component states to config files - If enabled, then on program startup all component states will be restored", // 19
                "Clear all component states", // 20
                "Trim the download to a specific length with a start and end timestamp - Examples: \"0:00 - 0:10\" | \"1:25 - 2:30\" | \"2:30:40 - 3:05:15\"", // 21
                timeSTT, // 22
                timeSTT, // 23
                timeETT, // 24
                timeETT, // 25
                "Quality settings for gif (web)", // 26
                gifRTT, // 27
                gifRTT, // 28
                gifFTT, // 29
                gifFTT, // 30
                "Enable GPU accelerated encoding - (encodes using ffmpeg, this feature only supports mp4, does not work while \"Apply Codecs\" is enabled)", // 31
                encodeTT, // 32
                encodeTT // 33
            };

            #endregion

            // configure tooltips
            for (int i = 0; i <= 33; i++) programToolTip.SetToolTip(component[i], tooltip[i]);

            // check if the custom directory is missing
            if (!Directory.Exists(selLoc) && useDefLoc == false)
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
        }

        // draw tooltips
        private void programToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        // program load
        private void program_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                DialogResult prompt = MessageBox.Show("An instance of MediaDownloader is already running.\nHaving two or more instances of MediaDownloader running simultaneously can cause issues (file corruption, malfunctioning).\n\nAre you sure you want to continue?", "", MessageBoxButtons.YesNo);
                if (prompt == DialogResult.No) Environment.Exit(0);
            }

            if (!Directory.Exists("mediadownloader")) Directory.CreateDirectory("mediadownloader");

            // install redists from scoop
            if (File.Exists("..\\..\\yt-dlp\\current\\yt-dlp.exe"))
            {
                try
                {
                    if (File.Exists("mediadownloader\\yt-dlp.exe")) File.Delete("mediadownloader\\yt-dlp.exe");
                    File.Copy("..\\..\\yt-dlp\\current\\yt-dlp.exe", "mediadownloader\\yt-dlp.exe");
                }
                catch (Exception ex) { MessageBox.Show("Error while installing \"yt-dlp\" from scoop!\n\nFull Error:\n" + ex); }
            }
            if (File.Exists("..\\..\\ffmpeg\\current\\bin\\ffmpeg.exe"))
            {
                try
                {
                    if (File.Exists("mediadownloader\\ffmpeg.exe")) File.Delete("mediadownloader\\ffmpeg.exe");
                    File.Copy("..\\..\\ffmpeg\\current\\bin\\ffmpeg.exe", "mediadownloader\\ffmpeg.exe");
                }
                catch (Exception ex) { MessageBox.Show("Error while installing \"ffmpeg\" from scoop!\n\nFull Error:\n" + ex); }
            }

            // check if redists exist
            if (File.Exists(asset[15])) ytdlpCheck = true; else progChckFail("yt-dlp.exe");
            if (File.Exists(asset[16])) ffmpegCheck = true; else progChckFail("ffmpeg.exe");
            if (ytdlpCheck && ffmpegCheck) Directory.CreateDirectory("Downloads");
        }

        // program closing handler
        private void program_FormClosing(object sender, FormClosingEventArgs e)
        {
            clnFiles();
        }

        // program mousemove
        private void program_MouseMove(object sender, MouseEventArgs e)
        {
            chkBat(false);
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

        // info button
        private void infoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Resources.infoText);
        }

        // mediadownloader github button
        private void githubButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/o7q/MediaDownloader");
        }

        // yt-dlp github button
        private void ytdlpGithubButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/yt-dlp/yt-dlp");
        }

        // configuration components

        // use config checkbox
        private void useConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked != true) return;
            try { for (int i = 0; i <= 11; i++) File.WriteAllText(asset[i], ""); } catch { }
            string[] configOut = { inputBox.Text, formatBox.SelectedIndex.ToString(), selLoc, applyCodecs.Checked == true ? "1" : "", useTimeframe.Checked == true ? "1" : "", timeframeStart.Text, timeframeEnd.Text, gifResolution.Text, gifFramerate.Text, useGpu.Checked == true ? "1" : "", gpuEncoder.Text };
            if (useConfig.Checked == true) for (int i = 0; i <= 11; i++) try { File.WriteAllText(asset[i], configOut[i]); } catch { }
        }

        // reset config button
        private void resetConfig_Click(object sender, EventArgs e)
        {
            // default configs
            inputBox.Text = "";
            formatBox.SelectedIndex = 6;
            useDefLoc = true;
            directoryLabel.Text = "";
            applyCodecs.Checked = false;
            useTimeframe.Checked = false;
            timeframeStart.Text = "0:00";
            timeframeEnd.Text = "0:10";
            gifResolution.Text = "400";
            gifFramerate.Text = "20";
            useGpu.Checked = false;
            gpuEncoder.Text = "h264_nvenc";

            // store default configs
            string[] configDef = { "", "6", "", "", "", "0:00", "0:10", "400", "20", "", "h264_nvenc" };
            if (useConfig.Checked == true) for (int i = 0; i <= 11; i++) try { File.WriteAllText(asset[i], configDef[i]); } catch { }
        }

        // input box checkbox
        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[0], inputBox.Text); } catch { }
        }

        // format box combobox
        private void formatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[1], formatBox.SelectedIndex.ToString()); } catch { }
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

                if (useConfig.Checked == true) try { File.WriteAllText(asset[2], selLoc); } catch { }
            }
        }

        // open location button
        private void openLocationButton_Click(object sender, EventArgs e)
        {
            try { Process.Start("explorer.exe", selLoc == "" || useDefLoc == true ? "Downloads" : selLoc); } catch { }
        }

        // clear location button
        private void clearLocationButton_Click(object sender, EventArgs e)
        {
            clrLoc();
        }

        // apply codecs checkbox
        private void applyCodecs_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[3], applyCodecs.Checked == true ? "1" : ""); } catch { }
            if (applyCodecs.Checked == true) useGpu.Checked = false;
        }

        // use timeframe checkbox
        private void useTimeframe_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[4], useTimeframe.Checked == true ? "1" : ""); } catch { }
        }

        // timeframe start textbox
        private void timeframeStart_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[5], timeframeStart.Text); } catch { }
        }

        // timeframe end textbox
        private void timeframeEnd_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[6], timeframeEnd.Text); } catch { }
        }

        // gif resolution textbox
        private void gifResolution_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[7], gifResolution.Text); } catch { }
        }

        // gif framerate textbox
        private void gifFramerate_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[8], gifFramerate.Text); } catch { }
        }

        // use gpu checkbox
        private void useGpu_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[9], useGpu.Checked == true ? "1" : ""); } catch { }
            if (useGpu.Checked == true) applyCodecs.Checked = false;
        }

        // gpu encoder textbox
        private void gpuEncoder_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[10], gpuEncoder.Text); } catch { }
        }

        // execute buttons

        // download button
        private void downloadButton_Click(object sender, EventArgs e)
        {
            #region scriptDictionary

            // configure variables
            string url = inputBox.Text;
            int form = formatBox.SelectedIndex;
            string timeS = timeframeStart.Text;
            string timeE = timeframeEnd.Text;
            string gifR = gifResolution.Text;
            string gifF = gifFramerate.Text;
            string gEncode = gpuEncoder.Text;
            string bVA = " -b:v 100M -b:a 320K ";
            string ePass = "ENCODING - PASS";
            string pState1 = "[" + ePass + "1]\n";
            string pState2 = "[" + ePass + "2]\n";
            string pState3 = "[GPU " + ePass + "1]\n";
            string pState4 = "[TRIMMING]\n";
            string dID = DateTime.Now.ToString("[Mdy-hms]");

            // (raw) video
            string rawVideo = srtArgs + "--path \"" + selLoc + "\" " + url;
            string rawVideo_useDefLoc = srtArgs + "--path " + @"..\Downloads " + url;

            // mp4
            string mp4 = srtArgs + "--remux-video mp4 -o \"download" + dID + ".mp4\" --path \"" + selLoc + "\" " + url;
            string mp4_useDefLoc = srtArgs + "--remux-video mp4 -o \"download" + dID + ".mp4\" --path " + @"..\Downloads " + url;
            string mp4_useDefLoc_applyCodecs = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + pState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v h264 -c:a aac" + bVA + @"..\Downloads\download" + dID + ".mp4\n" + @"del /f tmp0.mp4";
            string mp4_useDefLoc_useGpu = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + pState3 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v " + gEncode + " -c:a aac" + bVA + @"..\Downloads\download" + dID + ".mp4\n" + @"del / f tmp0.mp4";
            string mp4_applyCodecs = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + pState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v h264 -c:a aac" + bVA + "\"" + selLoc + @"\download" + dID + ".mp4\"\n" + @"del /f tmp0.mp4";
            string mp4_useGpu = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + pState3 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:v " + gEncode + " -c:a aac" + bVA + "\"" + selLoc + @"\download" + dID + ".mp4\"\n" + @"del /f tmp0.mp4"; ;

            // webm
            string webm = srtArgs + "--remux-video webm -o \"download" + dID + ".webm\" --path \"" + selLoc + "\" " + url;
            string webm_useDefLoc = srtArgs + "--remux-video webm -o \"download" + dID + ".webm\" --path " + @"..\Downloads " + url;
            string webm_useDefLoc_applyCodecs = srtArgs + "--remux-video webm -o \"tmp0.webm\" " + url + title + pState1 + "ffmpeg.exe -loglevel verbose -i tmp0.webm -c:v vp9 -c:a libvorbis" + bVA + @"..\Downloads\download" + dID + ".webm\n" + @"del /f tmp0.webm";
            string webm_applyCodecs = srtArgs + "--remux-video webm -o \"tmp0.webm\" " + url + title + pState1 + "ffmpeg.exe -loglevel verbose -i tmp0.webm -c:v vp9 -c:a libvorbis" + bVA + "\"" + selLoc + @"\download" + dID + ".webm\"\n" + @"del /f tmp0.webm";

            // gif
            string gif = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + pState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 \"" + selLoc + @"\download" + dID + ".gif\"\n" + @"del /f tmp0.mp4";
            string gif_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + pState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 " + @"..\Downloads\download" + dID + ".gif\n" + @"del /f tmp0.mp4";

            // gif (web)
            string gifWeb = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + pState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + " \"" + selLoc + @"\download" + dID + ".gif\"\n" + @"del /f tmp0.mp4";
            string gifWeb_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + pState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + @" ..\Downloads\download" + dID + ".gif\n" + @"del /f tmp0.mp4";

            // (raw) audio
            string rawAudio = srtArgs + "-x -o \"download" + dID + ".opus\" --path \"" + selLoc + "\" " + url;
            string rawAudio_useDefLoc = srtArgs + "-x -o \"download" + dID + ".opus\" --path " + @"..\Downloads " + url;

            // mp3
            string mp3 = srtArgs + "-x -o \"download" + dID + ".mp3\" --audio-format mp3 --path \"" + selLoc + "\" " + url;
            string mp3_useDefLoc = srtArgs + "-x -o \"download" + dID + ".mp3\" --audio-format mp3 --path " + @"..\Downloads " + url;

            // wav
            string wav = srtArgs + "-x -o \"download" + dID + ".wav\" --audio-format wav --path \"" + selLoc + "\" " + url;
            string wav_useDefLoc = srtArgs + "-x -o \"download" + dID + ".wav\" --audio-format wav --path " + @"..\Downloads " + url;

            // ogg
            string ogg = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + pState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:a libmp3lame tmp1.mp3" + title + pState2 + "ffmpeg.exe -loglevel verbose -i tmp1.mp3 -c:a libvorbis \"" + selLoc + @"\download" + dID + ".ogg\"" + "\ndel /f tmp0.mp4" + "\ndel /f tmp1.mp3";
            string ogg_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + pState1 + "ffmpeg.exe -loglevel verbose -i tmp0.mp4 -c:a libmp3lame tmp1.mp3" + title + pState2 + "ffmpeg.exe -loglevel verbose -i tmp1.mp3 -c:a libvorbis " + @"..\Downloads\download" + dID + ".ogg" + "\ndel /f tmp0.mp4" + "\ndel /f tmp1.mp3";

            #endregion

            // ensure user specifies valid url
            if (inputBox.Text == "") MessageBox.Show("No URL was specified.");
            else
            {
                // ensure user cannot select non-formats
                if (form == 0 || form == 6 || form == 7 || form == 12 || form == 13) MessageBox.Show("No format was specified.");
                else
                {
                    // configure and execute download script
                    if (applyCodecs.Checked == true)
                    {
                        // invalid formats
                        if (form == 1 || form == 4 || form == 5 || form == 8 || form == 9 || form == 10 || form == 11 || form == 14)
                        {
                            MessageBox.Show("No video codecs are available for this format.\n(this feature only supports mp4 and webm)");
                            return;
                        }

                        // mp4
                        if (form == 2) mdScr = useDefLoc ? mp4_useDefLoc_applyCodecs : mp4_applyCodecs;

                        // webm
                        if (form == 3) mdScr = useDefLoc ? webm_useDefLoc_applyCodecs : webm_applyCodecs;
                    }

                    if (useGpu.Checked == true)
                    {
                        // mp4
                        if (form != 2)
                        {
                            MessageBox.Show("No GPU accelerated encoders are available for this format.\n(this feature only supports mp4)");
                            return;
                        }
                        else mdScr = useDefLoc ? mp4_useDefLoc_useGpu : mp4_useGpu;
                    }

                    if (applyCodecs.Checked != true && useGpu.Checked != true)
                    {
                        // (raw) video
                        if (form == 1) mdScr = useDefLoc ? rawVideo_useDefLoc : rawVideo;

                        // mp4
                        if (form == 2) mdScr = useDefLoc ? mp4_useDefLoc : mp4;

                        // webm
                        if (form == 3) mdScr = useDefLoc ? webm_useDefLoc : webm;

                        // gif
                        if (form == 4) mdScr = useDefLoc ? gif_useDefLoc : gif;

                        // gif (web)
                        if (form == 5)
                        {
                            if (gifR == "" || gifF == "")
                            {
                                MessageBox.Show("No valid resolution and framerate values were specified.");
                                return;
                            }
                            else mdScr = useDefLoc ? gifWeb_useDefLoc : gifWeb;
                        }

                        // (raw) audio
                        if (form == 8) mdScr = useDefLoc ? rawAudio_useDefLoc : rawAudio;

                        // mp3
                        if (form == 9) mdScr = useDefLoc ? mp3_useDefLoc : mp3;

                        // wav
                        if (form == 10) mdScr = useDefLoc ? wav_useDefLoc : wav;

                        // ogg
                        if (form == 11) mdScr = useDefLoc ? ogg_useDefLoc : ogg;
                    }

                    // trimmer
                    if (useTimeframe.Checked == true)
                    {
                        string fExt = null;
                        if (form == 1 || form == 3) fExt = ".webm";
                        if (form == 2) fExt = ".mp4";
                        if (form == 4 || form == 5) fExt = ".gif";
                        if (form == 8) fExt = ".opus";
                        if (form == 9) fExt = ".mp3";
                        if (form == 10) fExt = ".wav";
                        if (form == 11) fExt = ".ogg";
                        if (fExt == null) return;

                        if (useDefLoc == true) mdScr += title + pState4 + "ffmpeg.exe -loglevel verbose -i \"..\\Downloads\\" + "download" + dID + fExt + "\" -ss " + timeS + " -to " + timeE + bVA + "\"..\\Downloads\\" + "download_trim" + dID + fExt + "\"\ndel /f \"..\\Downloads\\" + "download" + dID + fExt + "\""; else mdScr += title + pState4 + "ffmpeg.exe -loglevel verbose -i \"" + selLoc + "\\download" + dID + fExt + "\" -ss " + timeS + " -to " + timeE + bVA + "\"" + selLoc + "\\download_trim" + dID + fExt + "\"\ndel /f \"" + selLoc + "\\download" + dID + fExt + "\"";
                    }

                    if (mdScr != null) chkBat(true);
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
                chkBat(true);
            }
        }

        // functions

        // check batch function
        private void chkBat(bool srt, bool progOpen = false)
        {
            foreach (Process progOpenCheck in Process.GetProcesses()) if (progOpenCheck.ProcessName.Contains("yt-dlp") || progOpenCheck.ProcessName.Contains("ffmpeg")) progOpen = true;
            if (progOpen == false)
            {
                downloadButton.ForeColor = System.Drawing.Color.LimeGreen;
                if (srt == true) runBat();
            }
            else downloadButton.ForeColor = System.Drawing.Color.DarkSeaGreen;
        }

        // run batch function
        private void runBat()
        {
            clnFiles();

            // write and start batch script
            try { File.WriteAllText(asset[12], Properties.Resources.asciiBanner); } catch { }
            try { File.WriteAllText(asset[13], mdScr); } catch { }
            try { Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\mediadownloader\\md.bat"); } catch { }

            downloadButton.ForeColor = System.Drawing.Color.DarkSeaGreen;
        }

        // clean files function
        private void clnFiles()
        {
            string[] asset_fix = asset.Select(x => x.Replace("mediadownloader\\", "")).ToArray();
            if (Directory.Exists("mediadownloader"))
            {
                string[] files = Directory.GetFiles("mediadownloader");
                foreach (string file in files)
                {
                    var f = new FileInfo(file).Name;
                    try { if (f != asset_fix[0] & f != asset_fix[1] & f != asset_fix[2] & f != asset_fix[3] & f != asset_fix[4] & f != asset_fix[5] & f != asset_fix[6] & f != asset_fix[7] & f != asset_fix[8] & f != asset_fix[9] & f != asset_fix[10] & f != asset_fix[11] & /*f != asset_fix[12] & f != asset_fix[13] & */f != asset_fix[14] & f != asset_fix[15] & f != asset_fix[16]) File.Delete(file); } catch { }
                }
            }

            // delete configs if use config is disabled
            try { if (useConfig.Checked == false) for (int i = 0; i <= 11; i++) File.Delete(asset[i]); } catch { }
        }

        // clear location function
        private void clrLoc()
        {
            // clears selected location
            useDefLoc = true;
            selLoc = "";
            directoryLabel.Text = "";

            if (useConfig.Checked == true) File.WriteAllText(asset[2], selLoc);
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

        // string repeater function
        string strRep(string charIn, int amount, string output = "")
        {
            for (int i = 0; i <= amount; i++) output += charIn;
            return output;
        }

        // program check fail function
        private void progChckFail(string errMsg)
        {
            MessageBox.Show("\"" + errMsg + "\" was not found! Exiting MediaDownloader.\n\nMake sure you have \"yt-dlp.exe\" and \"ffmpeg.exe\" in a folder named \"mediadownloader\" next to \"MediaDownloader.exe\".\nIf you are using scoop please make sure you have installed everything correctly.");
            try
            {
                File.Delete(asset[13]);
                File.Delete(asset[14]);
            }
            catch { }
            Environment.Exit(1);
        }

        // titlebar panel sender
        private void titlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mvFrm(e);
        }

        // banner picture sender
        private void bannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            mvFrm(e);
        }

        // version label sender
        private void versionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            mvFrm(e);
        }
    }
}