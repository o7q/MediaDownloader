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
        const string ver = "v3.5.1";

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
            "mediadownloader\\cfg0", // 0
            "mediadownloader\\cfg1", // 1
            "mediadownloader\\cfg2", // 2
            "mediadownloader\\cfg3", // 3
            "mediadownloader\\cfg4", // 4
            "mediadownloader\\cfg5", // 5
            "mediadownloader\\cfg6", // 6
            "mediadownloader\\cfg7", // 7
            "mediadownloader\\cfg8", // 8
            "mediadownloader\\cfg_sw", // 9
            "mediadownloader\\md.bat", // 10
            "mediadownloader\\mdAscii", // 11
            "mediadownloader\\DO NOT PLACE ANY FILES HERE - THEY WILL BE REMOVED", // 12
            "mediadownloader\\yt-dlp.exe", // 13
            "mediadownloader\\ffmpeg.exe" // 14
        };

        // program events

        // program initialize component
        public program()
        {
            InitializeComponent();

            // create mediadownloader.bat and warning files
            try
            {
                File.WriteAllText(asset[10], "");
                File.WriteAllText(asset[12], "");
            }
            catch { }

            // configure default variables
            formatBox.SelectedIndex = 6;
            useDefLoc = true;

            // load config0
            if (File.Exists(asset[0])) inputBox.Text = File.ReadAllText(asset[0]);

            // load config1
            if (File.Exists(asset[1])) formatBox.SelectedIndex = int.Parse(File.ReadAllText(asset[1]));

            // load config2
            if (File.Exists(asset[2]))
            {
                selLoc = File.ReadAllText(asset[2]);

                useDefLoc = selLoc != "" ? false : true;
                directoryLabel.Text = selLoc != "" ? selLoc : "";
            }

            // load config3
            if (File.Exists(asset[3])) customArgsBox.Text = File.ReadAllText(asset[3]);

            // load config4
            if (File.Exists(asset[4])) applyCodecs.Checked = File.ReadAllText(asset[4]) == "1" ? true : false;

            // load config5
            if (File.Exists(asset[5])) gifResolution.Text = File.ReadAllText(asset[5]); else gifResolution.Text = "400";

            // load config6
            if (File.Exists(asset[6])) gifFramerate.Text = File.ReadAllText(asset[6]); else gifFramerate.Text = "20";

            // load config7
            if (File.Exists(asset[7])) useGpu.Checked = File.ReadAllText(asset[7]) == "1" ? true : false;

            // load config8
            if (File.Exists(asset[8])) gpuEncoder.Text = File.ReadAllText(asset[8]); else gpuEncoder.Text = "h264_nvenc";

            // load config_switch
            useConfig.Checked = File.Exists(asset[9]) ? true : false;

            // configure title
            title = "\ntitle MediaDownloader " + ver + "     ";

            // configure starting arguments
            srtArgs = "@echo off\ncd mediadownloader" + title + "[RUNNING]\ntype mdAscii\necho    " + ver + "\necho" + strRep(" ", 72) + "by o7q\necho.\nyt-dlp.exe --ffmpeg-location ffmpeg.exe ";

            // configure tooltips
            programToolTip.SetToolTip(bannerPicture, "MediaDownloader by o7q");
            programToolTip.SetToolTip(versionLabel, "Running " + ver);
            programToolTip.SetToolTip(minimizeButton, "Minimize");
            programToolTip.SetToolTip(exitButton, "Close");
            string urlTT = "URL to be downloaded";
            programToolTip.SetToolTip(urlLabel, urlTT);
            programToolTip.SetToolTip(inputBox, urlTT);
            string formTT = "Media format for download";
            programToolTip.SetToolTip(formatLabel, formTT);
            programToolTip.SetToolTip(formatBox, formTT);
            programToolTip.SetToolTip(downloadButton, "Download from the URL with the specified arguments");
            programToolTip.SetToolTip(locationButton, "Change folder location for download");
            programToolTip.SetToolTip(openLocationButton, "Open the selected download location in Windows Explorer");
            programToolTip.SetToolTip(clearLocationButton, "Reset the selected download location");
            programToolTip.SetToolTip(directoryLabel, "Currently selected download location [" + selLoc + "]");
            programToolTip.SetToolTip(advancedLabel, "Slightly more advanced settings");
            programToolTip.SetToolTip(viewAvailableFormatsButton, "Display all the available media formats found on the server for the specified URL");
            programToolTip.SetToolTip(infoButton, "Display info about MediaDownloader");
            programToolTip.SetToolTip(githubButton, "Open the MediaDownloader github repository in the default web browser");
            programToolTip.SetToolTip(ytdlpGithubButton, "Open the yt-dlp github repository in the default web browser");
            programToolTip.SetToolTip(applyCodecs, "Apply valid video codecs after the video is downloaded (encodes using ffmpeg on the CPU) - This can fix problems with importing videos into some software - (this feature is very slow and it only supports mp4 and webm, does not work while \"Use GPU Acceleration\" is enabled)");
            programToolTip.SetToolTip(useConfig, "Save all current component states to config files - If enabled, then on program startup all component states will be restored");
            programToolTip.SetToolTip(resetConfig, "Clear all component states");
            string cstmArgTT = "Custom arguments for yt-dlp (not for ffmpeg)";
            programToolTip.SetToolTip(customArgsLabel, cstmArgTT);
            programToolTip.SetToolTip(customArgsBox, cstmArgTT);
            programToolTip.SetToolTip(gifQualityLabel, "Quality settings for gif (web)");
            string rTT = "Width resolution for gif (web) - Keeps ratio (ffmpeg args = r:-1)";
            programToolTip.SetToolTip(rLabel, rTT);
            programToolTip.SetToolTip(gifResolution, rTT);
            string fTT = "Framerate for gif (web)";
            programToolTip.SetToolTip(fLabel, fTT);
            programToolTip.SetToolTip(gifFramerate, fTT);
            programToolTip.SetToolTip(useGpu, "Enable GPU accelerated encoding - (encodes using ffmpeg, this feature only supports mp4, does not work while \"Apply Codecs\" is enabled)");
            string cTT = "Encoder to be used - Examples: Nvidia = \"h264_nvenc\" | AMD = \"h264_amf\")";
            programToolTip.SetToolTip(codecLabel, cTT);
            programToolTip.SetToolTip(gpuEncoder, cTT);

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
            programToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            programToolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
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

            if (File.Exists(asset[13])) ytdlpCheck = true; else progChckFail("yt-dlp.exe");
            if (File.Exists(asset[14])) ffmpegCheck = true; else progChckFail("ffmpeg.exe");
            if (ytdlpCheck && ffmpegCheck) Directory.CreateDirectory("Downloads");
        }

        // program activated
        private void program_Activated(object sender, EventArgs e)
        {
            downloadButton.ForeColor = System.Drawing.Color.LimeGreen;
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
            if (useConfig.Checked == true)
            {
                try { for (int i = 0; i < 10; i++) File.WriteAllText(asset[i], ""); } catch { }

                // write config0
                try { File.WriteAllText(asset[0], inputBox.Text); } catch { }

                // write config1
                try { File.WriteAllText(asset[1], formatBox.SelectedIndex.ToString()); } catch { }

                // write config2
                try { File.WriteAllText(asset[2], selLoc); } catch { }

                // write config3
                try { File.WriteAllText(asset[3], customArgsBox.Text); } catch { }

                // write config4
                try { File.WriteAllText(asset[4], applyCodecs.Checked == true ? "1" : ""); } catch { }

                // write config5
                try { File.WriteAllText(asset[5], gifResolution.Text); } catch { }

                // write config6
                try { File.WriteAllText(asset[6], gifFramerate.Text); } catch { }

                // write config7
                try { File.WriteAllText(asset[7], useGpu.Checked == true ? "1" : ""); } catch { }

                // write config8
                try { File.WriteAllText(asset[8], gpuEncoder.Text); } catch { }
            }
        }

        // reset config button
        private void resetConfig_Click(object sender, EventArgs e)
        {
            // reset config0
            inputBox.Text = "";

            // reset config1
            formatBox.SelectedIndex = 6;

            // reset config2
            useDefLoc = true;
            directoryLabel.Text = "";

            // reset config3
            customArgsBox.Text = "";

            // reset config4
            applyCodecs.Checked = false;

            // reset config5
            gifResolution.Text = "400";

            // reset config6
            gifFramerate.Text = "20";

            // reset config7
            useGpu.Checked = false;

            // reset config8
            gpuEncoder.Text = "h264_nvenc";

            // default configs
            string[] configDef = { "", "6", "", "", "", "400", "20", "", "h264_nvenc" };
            if (useConfig.Checked == true) for (int i = 0; i < 9; i++) try { File.WriteAllText(asset[i], configDef[i]); } catch { }
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

        // custom arguments textbox
        private void customArgsBox_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[3], customArgsBox.Text); } catch { }
        }

        // apply codecs checkbox
        private void applyCodecs_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[4], applyCodecs.Checked == true ? "1" : ""); } catch { }
            if (applyCodecs.Checked == true) useGpu.Checked = false;
        }

        // gif resolution textbox
        private void gifResolution_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[5], gifResolution.Text); } catch { }
        }

        // gif framerate textbox
        private void gifFramerate_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[6], gifFramerate.Text); } catch { }
        }

        // use gpu checkbox
        private void useGpu_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[7], useGpu.Checked == true ? "1" : ""); } catch { }
            if (useGpu.Checked == true) applyCodecs.Checked = false;
        }

        // gpu encoder textbox
        private void gpuEncoder_TextChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true) try { File.WriteAllText(asset[8], gpuEncoder.Text); } catch { }
        }

        // execute buttons

        // view available formats button
        private void viewAvailableFormatsButton_Click(object sender, EventArgs e)
        {
            // displays available formats of the specified url
            if (inputBox.Text == "") MessageBox.Show("Please specify a URL.");
            else
            {
                mdScr = srtArgs + "--list-formats " + inputBox.Text + "\necho.\npause";
                runBat();
            }
        }

        // download button
        private void downloadButton_Click(object sender, EventArgs e)
        {
            #region scriptDictionary

            // configure variables
            string url = inputBox.Text;
            int form = formatBox.SelectedIndex;
            string customArgs = customArgsBox.Text;
            string gifR = gifResolution.Text;
            string gifF = gifFramerate.Text;
            string gEncode = gpuEncoder.Text;
            string BrVA = " -b:v 100M -b:a 320K ";
            string encodePass = "ENCODING - PASS";
            string ffStage1 = "[" + encodePass + "1]\n";
            string ffStage2 = "[" + encodePass + "2]\n";
            string GPU_ffStage1 = "[GPU " + encodePass + "1]\n";
            string dID = DateTime.Now.ToString("[Mdy-hms]");

            // (raw) video
            string rawVideo = srtArgs + "--path \"" + selLoc + "\" " + url;
            string rawVideo_useDefLoc = srtArgs + "--path " + @"..\Downloads " + url;

            // mp4
            string mp4 = srtArgs + "--remux-video mp4 --path \"" + selLoc + "\" " + url;
            string mp4_useDefLoc = srtArgs + "--remux-video mp4 --path " + @"..\Downloads " + url;
            string mp4_useDefLoc_applyCodecs = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + ffStage1 + "ffmpeg.exe -i tmp0.mp4 -c:v h264 -c:a aac" + BrVA + @"..\Downloads\converted_download" + dID + ".mp4\n" + @"del /f tmp0.mp4";
            string mp4_useDefLoc_useGpu = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + GPU_ffStage1 + "ffmpeg.exe -i tmp0.mp4 -c:v " + gEncode + " -c:a aac" + BrVA + @"..\Downloads\converted_download" + dID + ".mp4\n" + @"del / f tmp0.mp4";
            string mp4_applyCodecs = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + ffStage1 + "ffmpeg.exe -i tmp0.mp4 -c:v h264 -c:a aac" + BrVA + "\"" + selLoc + @"\converted_download" + dID + ".mp4\"\n" + @"del /f tmp0.mp4";
            string mp4_useGpu = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + GPU_ffStage1 + "ffmpeg.exe -i tmp0.mp4 -c:v " + gEncode + " -c:a aac" + BrVA + "\"" + selLoc + @"\converted_download" + dID + ".mp4\"\n" + @"del /f tmp0.mp4"; ;

            // webm
            string webm = srtArgs + "--remux-video webm --path \"" + selLoc + "\" " + url;
            string webm_useDefLoc = srtArgs + "--remux-video webm --path " + @"..\Downloads " + url;
            string webm_useDefLoc_applyCodecs = srtArgs + "--remux-video webm -o \"tmp0.webm\" " + url + title + ffStage1 + "ffmpeg.exe -i tmp0.webm -c:v vp9 -c:a libvorbis" + BrVA + @"..\Downloads\converted_download" + dID + ".webm\n" + @"del /f tmp0.webm";
            string webm_applyCodecs = srtArgs + "--remux-video webm -o \"tmp0.webm\" " + url + title + ffStage1 + "ffmpeg.exe -i tmp0.webm -c:v vp9 -c:a libvorbis" + BrVA + "\"" + selLoc + @"\converted_download" + dID + ".webm\"\n" + @"del /f tmp0.webm";

            // gif
            string gif = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + ffStage1 + "ffmpeg.exe -i tmp0.mp4 \"" + selLoc + @"\converted_download" + dID + ".gif\"\n" + @"del /f tmp0.mp4";
            string gif_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + ffStage1 + "ffmpeg.exe -i tmp0.mp4 " + @"..\Downloads\converted_download" + dID + ".gif\n" + @"del /f tmp0.mp4";

            // gif (web)
            string gifWeb = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + ffStage1 + "ffmpeg.exe -i tmp0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + " \"" + selLoc + @"\converted_download" + dID + ".gif\"\n" + @"del /f tmp0.mp4";
            string gifWeb_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + ffStage1 + "ffmpeg.exe -i tmp0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + @" ..\Downloads\converted_download" + dID + ".gif\n" + @"del /f tmp0.mp4";

            // (raw) audio
            string rawAudio = srtArgs + "-x --path \"" + selLoc + "\" " + url;
            string rawAudio_useDefLoc = srtArgs + "-x --path " + @"..\Downloads " + url;

            // mp3
            string mp3 = srtArgs + "-x --audio-format mp3 --path \"" + selLoc + "\" " + url;
            string mp3_useDefLoc = srtArgs + "-x --audio-format mp3 --path " + @"..\Downloads " + url;

            // wav
            string wav = srtArgs + "-x --audio-format wav --path \"" + selLoc + "\" " + url;
            string wav_useDefLoc = srtArgs + "-x --audio-format wav --path " + @"..\Downloads " + url;

            // ogg
            string ogg = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + ffStage1 + "ffmpeg.exe -i tmp0.mp4 -c:a libmp3lame tmp1.mp3" + title + ffStage2 + "ffmpeg.exe -i tmp1.mp3 -c:a libvorbis \"" + selLoc + @"\converted_download" + dID + ".ogg\"" + "\ndel /f tmp0.mp4" + "\ndel /f tmp1.mp3";
            string ogg_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp0.mp4\" " + url + title + ffStage1 + "ffmpeg.exe -i tmp0.mp4 -c:a libmp3lame tmp1.mp3" + title + ffStage2 + "ffmpeg.exe -i tmp1.mp3 -c:a libvorbis " + @"..\Downloads\converted_download" + dID + ".ogg" + "\ndel /f tmp0.mp4" + "\ndel /f tmp1.mp3";

            // (Custom Arguments)
            string customArguments = srtArgs + "--path \"" + selLoc + "\"" + " " + customArgs + " " + url;
            string customArguments_useDefLoc = srtArgs + "--path " + @"..\Downloads " + customArgs + " " + url;

            #endregion

            // ensure user specifies valid url
            if (inputBox.Text == "") MessageBox.Show("Please specify a URL.");
            else
            {
                // ensure user cannot select non-formats
                if (form == 0 || form == 6 || form == 7 || form == 12 || form == 13) MessageBox.Show("Please select a format.");
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
                                MessageBox.Show("Please provide valid resolution and framerate values.");
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

                        // (Custom DL Arguments)
                        if (form == 14) mdScr = useDefLoc ? customArguments_useDefLoc : customArguments;
                    }

                    if (mdScr != null)
                    {
                        bool progOpen = false;
                        foreach (Process progOpenCheck in Process.GetProcesses()) progOpen = progOpenCheck.ProcessName.Contains("yt-dlp") || progOpenCheck.ProcessName.Contains("ffmpeg") ? true : false;
                        if (progOpen == false) runBat(); else downloadButton.ForeColor = System.Drawing.Color.DarkSeaGreen;
                    }
                }
            }
        }

        // functions

        // run batch function
        private void runBat()
        {
            clnFiles();

            // write and start batch script
            try { File.WriteAllText(asset[11], Properties.Resources.asciiBanner); } catch { }
            try { File.WriteAllText(asset[10], mdScr); } catch { }
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
                    try { if (f != asset_fix[0] & f != asset_fix[1] & f != asset_fix[2] & f != asset_fix[3] & f != asset_fix[4] & f != asset_fix[5] & f != asset_fix[6] & f != asset_fix[7] & f != asset_fix[8] & f != asset_fix[9] & /*f != asset_fix[10] & f != asset_fix[11] & */f != asset_fix[12] & f != asset_fix[13] & f != asset_fix[14]) File.Delete(file); } catch { }
                }
            }

            // delete configs if use config is disabled
            try { if (useConfig.Checked == false) for (int i = 0; i < 10; i++) File.Delete(asset[i]); } catch { }
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
        string strRep(string charIn, int amount)
        {
            string output = "";
            for (int i = 0; i < amount; i++) output += charIn;
            return output;
        }

        // program check fail function
        private void progChckFail(string errMsg)
        {
            MessageBox.Show("\"" + errMsg + "\" not found! Exiting MediaDownloader.");
            try
            {
                File.Delete(asset[10]);
                File.Delete(asset[12]);
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