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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // grab dlls for mousedown
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // create global variables

        // batch configuration
        string srtArgs = "@echo off\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe ";
        string selLoc;
        string mdScr;

        // use default location
        bool useDefLoc;

        // redist check
        bool ytdlpCheck;
        bool ffmpegCheck;

        // asset dictionary
        string[] asset = { "mediadownloader\\cfg0", "mediadownloader\\cfg1", "mediadownloader\\cfg2", "mediadownloader\\cfg3", "mediadownloader\\cfg4", "mediadownloader\\cfg5", "mediadownloader\\cfg6", "mediadownloader\\cfg_sw", "mediadownloader\\md.bat", "mediadownloader\\DO NOT PLACE ANY FILES HERE - THEY WILL BE REMOVED", "mediadownloader\\yt-dlp.exe", "mediadownloader\\ffmpeg.exe" };

        // program events

        // form initialize component
        public program()
        {
            InitializeComponent();

            // try to create mediadownloader.bat and warning files
            try
            {
                File.WriteAllText(asset[8], "");
                File.WriteAllText(asset[9], "");
            }
            catch
            {
                // skip
            }

            // configure default variables
            formatBox.SelectedIndex = 6;
            useDefLoc = true;

            // load config0
            if (File.Exists(asset[0]))
            {
                string config0 = File.ReadAllText(asset[0]);
                inputBox.Text = config0;
            }

            // load config1
            if (File.Exists(asset[1]))
            {
                string config1_string = File.ReadAllText(asset[1]);
                int config1 = int.Parse(config1_string);
                formatBox.SelectedIndex = config1;
            }

            // load config2
            if (File.Exists(asset[2]))
            {
                string config2 = File.ReadAllText(asset[2]);
                selLoc = config2;

                useDefLoc = selLoc != "" ? false : true;
                directoryLabel.Text = selLoc != "" ? selLoc : "";
            }

            // load config3
            if (File.Exists(asset[3]))
            {
                string config3 = File.ReadAllText(asset[3]);
                customArgsBox.Text = config3;
            }

            // load config4
            if (File.Exists(asset[4]))
            {
                string config4 = File.ReadAllText(asset[4]);
                applyCodecs.Checked = config4 == "1" ? true : false;
            }

            // load config5
            if (File.Exists(asset[5]))
            {
                string config5 = File.ReadAllText(asset[5]);
                gifResolution.Text = config5;
            }
            else
            {
                int R = 400;
                string R_string = R.ToString();
                gifResolution.Text = R_string;
            }

            // load config6
            if (File.Exists(asset[6]))
            {
                string config6 = File.ReadAllText(asset[6]);
                gifFramerate.Text = config6;
            }
            else
            {
                int F = 20;
                string F_string = F.ToString();
                gifFramerate.Text = F_string;
            }

            // load config_switch
            useConfig.Checked = File.Exists(asset[7]) ? true : false;

            // configure tooltips
            programToolTip.SetToolTip(minimizeButton, "Minimize");
            programToolTip.SetToolTip(exitButton, "Close");
            programToolTip.SetToolTip(inputBox, "URL to be downloaded");
            programToolTip.SetToolTip(formatBox, "Media format for download");
            programToolTip.SetToolTip(downloadButton, "Download from the URL with the specified arguments");
            programToolTip.SetToolTip(locationButton, "Change folder location for download");
            programToolTip.SetToolTip(openLocationButton, "Open the selected download location in Windows Explorer");
            programToolTip.SetToolTip(clearLocationButton, "Reset the selected download location");
            programToolTip.SetToolTip(directoryLabel, "Currently selected download location");
            programToolTip.SetToolTip(viewAvailableFormatsButton, "Display all the available media formats found on the server for the specified URL");
            programToolTip.SetToolTip(githubButton, "Open the MediaDownloader github repository in the default web browser");
            programToolTip.SetToolTip(infoButton, "Display info about MediaDownloader");
            programToolTip.SetToolTip(ytdlpGithubButton, "Open the yt-dlp github repository in the default web browser");
            programToolTip.SetToolTip(applyCodecs, "Uses ffmpeg to apply valid video codecs after the video is downloaded - This can fix problems with importing videos into some software - (this feature is very slow and it only supports mp4 and webm)");
            programToolTip.SetToolTip(useConfig, "Save all current component states to config files - If enabled, then on program startup all component states will be restored");
            programToolTip.SetToolTip(resetConfig, "Clear all component states");
            programToolTip.SetToolTip(customArgsBox, "Custom arguments for yt-dlp (not for ffmpeg)");
            string rTT = "Width resolution for gif (web) - Keeps ratio (ffmpeg args = r:-1)";
            programToolTip.SetToolTip(rLabel, rTT);
            programToolTip.SetToolTip(gifResolution, rTT);
            string fTT = "Framerate for gif (web)";
            programToolTip.SetToolTip(fLabel, fTT);
            programToolTip.SetToolTip(gifFramerate, fTT);

            // configure tooltip draw
            programToolTip.OwnerDraw = true;
            programToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            programToolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
        }

        // form load
        private void program_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                DialogResult prompt = MessageBox.Show("An instance of MediaDownloader is already running.\nHaving two or more instances of MediaDownloader running simultaneously can cause issues (file corruption, malfunctioning).\n\nAre you sure you want to continue?", "", MessageBoxButtons.YesNo);
                if (prompt == DialogResult.Yes)
                {
                    // continue
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            if (File.Exists(asset[10]))
            {
                ytdlpCheck = true;

                // continue
            }
            else
            {
                MessageBox.Show("\"yt-dlp.exe\" not found! Exiting MediaDownloader.");

                // delete mediadownloader.bat and warn file
                try
                {
                    File.Delete(asset[8]);
                    File.Delete(asset[9]);
                }
                catch
                {
                    // skip
                }

                Environment.Exit(1);
            }

            if (File.Exists(asset[11]))
            {
                ffmpegCheck = true;

                // continue
            }
            else
            {
                MessageBox.Show("\"ffmpeg.exe\" not found! Exiting MediaDownloader.");

                // delete mediadownloader.bat and
                try
                {
                    File.Delete(asset[8]);
                    File.Delete(asset[9]);
                }
                catch
                {
                    // skip
                }

                Environment.Exit(1);
            }

            if (ytdlpCheck && ffmpegCheck)
            {
                // create downloads directory
                try
                {
                    Directory.CreateDirectory("Downloads");
                }
                catch
                {
                    // skip
                }
            }
        }

        // draw tooltips
        private void programToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
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
            // read from infoText and open info panel
            string infoText = Properties.Resources.infoText;
            MessageBox.Show(infoText);
        }

        // mediadownloader github button
        private void githubButton_Click(object sender, EventArgs e)
        {
            // open mediadownloader github page in the default web browser
            Process.Start("https://github.com/o7q/MediaDownloader");
        }

        // yt-dlp github button
        private void ytdlpGithubButton_Click(object sender, EventArgs e)
        {
            // open yt-dlp github page in the default web browser
            Process.Start("https://github.com/yt-dlp/yt-dlp");
        }

        // configuration components

        // use config checkbox
        private void useConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true)
            {
                File.WriteAllText(asset[7], "");

                File.WriteAllText(asset[0], "");
                File.WriteAllText(asset[1], "");
                File.WriteAllText(asset[2], "");
                File.WriteAllText(asset[3], "");
                File.WriteAllText(asset[4], "");
                File.WriteAllText(asset[5], "");
                File.WriteAllText(asset[6], "");

                // write config0
                string config0 = inputBox.Text;
                File.WriteAllText(asset[0], config0);

                // write config1
                int config1_int = formatBox.SelectedIndex;
                string config1 = config1_int.ToString();
                File.WriteAllText(asset[1], config1);

                // write config2
                string config2 = selLoc;
                File.WriteAllText(asset[2], config2);

                // write config3
                string config3 = customArgsBox.Text;
                File.WriteAllText(asset[3], config3);

                // write config4
                string config4 = applyCodecs.Checked == true ? "1" : "";
                File.WriteAllText(asset[4], config4);

                // write config5
                string config5 = gifResolution.Text;
                File.WriteAllText(asset[5], config5);

                // write config6
                string config6 = gifFramerate.Text;
                File.WriteAllText(asset[6], config6);
            }
        }

        // input box checkbox
        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            // on change write to config0
            if (useConfig.Checked == true)
            {
                string config0 = inputBox.Text;
                File.WriteAllText(asset[0], config0);
            }
        }

        // format box combobox
        private void formatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // on change write to config1
            if (useConfig.Checked == true)
            {
                int config1_int = formatBox.SelectedIndex;
                string config1 = config1_int.ToString();
                File.WriteAllText(asset[1], config1);
            }
        }

        // custom arguments textbox
        private void customArgsBox_TextChanged(object sender, EventArgs e)
        {
            // on change write to config3
            if (useConfig.Checked == true)
            {
                string config3 = customArgsBox.Text;
                File.WriteAllText(asset[3], config3);
            }
        }

        // apply codecs checkbox
        private void applyCodecs_CheckedChanged(object sender, EventArgs e)
        {
            // on change write to config4
            if (useConfig.Checked == true)
            {
                string config4 = applyCodecs.Checked == true ? "1" : "";
                File.WriteAllText(asset[4], config4);
            }
        }

        // gif resolution textbox
        private void gifResolution_TextChanged(object sender, EventArgs e)
        {
            // on change write to config5
            if (useConfig.Checked == true)
            {
                string config5 = gifResolution.Text;
                File.WriteAllText(asset[5], config5);
            }
        }

        // gif framerate textbox
        private void gifFramerate_TextChanged(object sender, EventArgs e)
        {
            // on change write to config6
            if (useConfig.Checked == true)
            {
                string config6 = gifFramerate.Text;
                File.WriteAllText(asset[6], config6);
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

            // reset configs
            if (useConfig.Checked == true)
            {
                File.WriteAllText(asset[0], "");
                int config1_int = 6;
                string config1 = config1_int.ToString();
                File.WriteAllText(asset[1], config1);
                File.WriteAllText(asset[2], "");
                File.WriteAllText(asset[3], "");
                File.WriteAllText(asset[4], "");
                File.WriteAllText(asset[5], "400");
                File.WriteAllText(asset[6], "20");
            }
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
                directoryLabel.Text = selLoc;
                useDefLoc = selLoc == "" ? true : false;

                if (useConfig.Checked == true)
                {
                    // on change write to config2
                    string config2 = selLoc;
                    File.WriteAllText(asset[2], config2);
                }
            }
        }

        // open location button
        private void openLocationButton_Click(object sender, EventArgs e)
        {
            string location = selLoc == "" || useDefLoc == true ? "Downloads" : selLoc;
            Process.Start("explorer.exe", location);
        }

        // clear location button
        private void clearLocationButton_Click(object sender, EventArgs e)
        {
            // clears selected location
            useDefLoc = true;
            selLoc = "";
            directoryLabel.Text = "";

            if (useConfig.Checked == true)
            {
                string config2 = selLoc;
                File.WriteAllText(asset[2], config2);
            }
        }

        // view available formats button
        private void viewAvailableFormatsButton_Click(object sender, EventArgs e)
        {
            // displays available formats of the specified url
            if (inputBox.Text == "")
            {
                MessageBox.Show("Please specify a URL.");
            }
            else
            {
                mdScr = srtArgs + "--list-formats " + inputBox.Text + "\necho.\npause";
                runBat();
            }
        }

        // download button
        private void downloadButton_Click(object sender, EventArgs e)
        {
            // configure variables
            string url = inputBox.Text;
            string customArgs = customArgsBox.Text;
            string gifR = gifResolution.Text;
            string gifF = gifFramerate.Text;
            int form = formatBox.SelectedIndex;

            // generate a random id
            string numbers = "1234567890";
            var stringNumbers = new char[8];
            var randomNumbers = new Random();
            for (int i = 0; i < stringNumbers.Length; i++)
            {
                stringNumbers[i] = numbers[randomNumbers.Next(numbers.Length)];
            }
            string rndId = new String(stringNumbers);

            #region scriptDictionary

            // (raw) video
            string rawVideo = srtArgs + "--path \"" + selLoc + "\" " + url;
            string rawVideo_useDefLoc = srtArgs + "--path " + @"..\Downloads " + url;

            // mp4
            string mp4 = srtArgs + "--remux-video mp4 --path \"" + selLoc + "\" " + url;
            string mp4_useDefLoc = srtArgs + "--remux-video mp4 --path " + @"..\Downloads " + url;
            string mp4_applyCodecs = srtArgs + "--remux-video mp4 -o \"tmp_dl0.mp4\" " + url + "\nffmpeg.exe -i tmp_dl0.mp4 -c:v h264 -c:a aac \"" + selLoc + @"\converted_download_" + rndId + ".mp4\"\n" + @"del /f tmp_dl0.mp4";
            string mp4_applyCodecs_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp_dl0.mp4\" " + url + "\nffmpeg.exe -i tmp_dl0.mp4 -c:v h264 -c:a aac " + @"..\Downloads\converted_download_" + rndId + ".mp4\n" + @"del /f tmp_dl0.mp4";

            // webm
            string webm = srtArgs + "--remux-video webm --path \"" + selLoc + "\" " + url;
            string webm_useDefLoc = srtArgs + "--remux-video webm --path " + @"..\Downloads " + url;
            string webm_applyCodecs = srtArgs + "--remux-video webm -o \"tmp_dl0.webm\" " + url + "\nffmpeg.exe -i tmp_dl0.webm -c:v vp9 -c:a libvorbis \"" + selLoc + @"\converted_download_" + rndId + ".webm\"\n" + @"del /f tmp_dl0.webm";
            string webm_applyCodecs_useDefLoc = srtArgs + "--remux-video webm -o \"tmp_dl0.webm\" " + url + "\nffmpeg.exe -i tmp_dl0.webm -c:v vp9 -c:a libvorbis " + @"..\Downloads\converted_download_" + rndId + ".webm\n" + @"del /f tmp_dl0.webm";

            // gif
            string gif = srtArgs + "--remux-video mp4 -o \"tmp_dl0.mp4\" " + url + "\nffmpeg.exe -i tmp_dl0.mp4 \"" + selLoc + @"\converted_download_" + rndId + ".gif\"\n" + @"del /f tmp_dl0.mp4";
            string gif_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp_dl0.mp4\" " + url + "\nffmpeg.exe -i tmp_dl0.mp4 " + @"..\Downloads\converted_download_" + rndId + ".gif\n" + @"del /f tmp_dl0.mp4";

            // gif (web)
            string gifWeb = srtArgs + "--remux-video mp4 -o \"tmp_dl0.mp4\" " + url + "\nffmpeg.exe -i tmp_dl0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + " \"" + selLoc + @"\converted_download_" + rndId + ".gif\"\n" + @"del /f tmp_dl0.mp4";
            string gifWeb_useDefLoc = "--remux-video mp4 -o \"tmp_dl0.mp4\" " + url + "\nffmpeg.exe -i tmp_dl0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + @" ..\Downloads\converted_download_" + rndId + ".gif\n" + @"del /f tmp_dl0.mp4";

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
            string ogg = srtArgs + "--remux-video mp4 -o \"tmp_dl0.mp4\" " + url + "\nffmpeg.exe -i tmp_dl0.mp4 -c:a libmp3lame tmp_dl1.mp3" + "\nffmpeg.exe -i tmp_dld1.mp3 -c:a libvorbis \"" + selLoc + @"\converted_download_" + rndId + ".ogg\"" + "\ndel /f tmp_dl0.mp4" + "\ndel /f tmp_dl1.mp3";
            string ogg_useDefLoc = srtArgs + "--remux-video mp4 -o \"tmp_dl0.mp4\" " + url + "\nffmpeg.exe -i tmp_dl0.mp4 -c:a libmp3lame tmp_dl1.mp3" + "\nffmpeg.exe -i tmp_dl1.mp3 -c:a libvorbis " + @"..\Downloads\converted_download_" + rndId + ".ogg" + "\ndel /f tmp_dl0.mp4" + "\ndel /f tmp_dl1.mp3";

            // (Custom Arguments)
            string customArguments = srtArgs + "--path \"" + selLoc + "\"" + " " + customArgs + " " + url;
            string customArguments_useDefLoc = srtArgs + "--path " + @"..\Downloads " + customArgs + " " + url;

            #endregion

            // ensure user specifies valid url
            if (inputBox.Text == "")
            {
                MessageBox.Show("Please specify a URL.");
            }
            else
            {
                // ensure user cannot select non-formats
                if (form == 0 || form == 6 || form == 7 || form == 12 || form == 13)
                {
                    MessageBox.Show("Please select a format.");
                }
                else
                {
                    // configure and execute download script
                    if (applyCodecs.Checked == true)
                    {
                        // invalid formats
                        if (form == 1 || form == 4 || form == 5 || form == 8 || form == 9 || form == 10 || form == 11 || form == 14)
                        {
                            MessageBox.Show("No video codecs are available for this format.");
                        }

                        // mp4
                        if (form == 2)
                        {
                            mdScr = useDefLoc == true ? mp4_applyCodecs_useDefLoc : mp4_applyCodecs;
                        }

                        // webm
                        if (form == 3)
                        {
                            mdScr = useDefLoc == true ? webm_applyCodecs_useDefLoc : webm_applyCodecs;
                        }
                    }
                    else
                    {
                        // (raw) video
                        if (form == 1)
                        {
                            mdScr = useDefLoc == true ? rawVideo_useDefLoc : rawVideo;
                        }

                        // mp4
                        if (form == 2)
                        {
                            mdScr = useDefLoc == true ? mp4_useDefLoc : mp4;
                        }

                        // webm
                        if (form == 3)
                        {
                            mdScr = useDefLoc == true ? webm_useDefLoc : webm;
                        }

                        // gif
                        if (form == 4)
                        {
                            mdScr = useDefLoc == true ? gif_useDefLoc : gif;
                        }

                        // gif (web)
                        if (form == 5)
                        {
                            if (gifR == "" || gifF == "")
                            {
                                MessageBox.Show("Please provide valid resolution and framerate values.");
                            }
                            else
                            {
                                mdScr = useDefLoc == true ? gifWeb_useDefLoc : gifWeb;
                            }
                        }

                        // (raw) audio
                        if (form == 8)
                        {
                            mdScr = useDefLoc == true ? rawAudio_useDefLoc : rawAudio;
                        }

                        // mp3
                        if (form == 9)
                        {
                            mdScr = useDefLoc == true ? mp3_useDefLoc : mp3;
                        }

                        // wav
                        if (form == 10)
                        {
                            mdScr = useDefLoc == true ? wav_useDefLoc : wav;
                        }

                        // ogg
                        if (form == 11)
                        {
                            mdScr = useDefLoc == true ? ogg_useDefLoc : ogg;
                        }

                        // (Custom DL Arguments)
                        if (form == 14)
                        {
                            mdScr = useDefLoc == true ? customArguments_useDefLoc : customArguments;
                        }
                    }

                    runBat();
                }
            }
        }

        // functions

        // move form on mousedown function
        private void mvFrm(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // run batch function
        private void runBat()
        {
            // write batch script
            try
            {
                File.WriteAllText(asset[8], mdScr);
            }
            catch
            {
                // skip
            }

            // start batch script
            string batchScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            batchScript += "\\mediadownloader\\md.bat";
            Process.Start(batchScript);
        }

        // clean files function
        private void clnFiles()
        {
            // clean temp files
            string[] asset_fix = asset.Select(x => x.Replace("mediadownloader\\", "")).ToArray();
            if (Directory.Exists("mediadownloader"))
            {
                string[] files = Directory.GetFiles("mediadownloader");
                foreach (string file in files)
                {
                    var f = new FileInfo(file).Name; 
                    if (f != asset_fix[0] & f != asset_fix[1] & f != asset_fix[2] & f != asset_fix[3] & f != asset_fix[4] & f != asset_fix[5] & f != asset_fix[6] & f != asset_fix[7] & /*f != asset_fix[8] & */f != asset_fix[9] & f != asset_fix[10] & f != asset_fix[11])
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch
                        {
                            // skip
                        }
                    }
                }
            }

            // delete configs on use config disabled
            if (useConfig.Checked == false)
            {
                try
                {
                    File.Delete(asset[7]);

                    File.Delete(asset[0]);
                    File.Delete(asset[1]);
                    File.Delete(asset[2]);
                    File.Delete(asset[3]);
                    File.Delete(asset[4]);
                    File.Delete(asset[5]);
                    File.Delete(asset[6]);
                }
                catch
                {
                    // skip
                }
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
            mvFrm(e);
        }

        // version label sender
        private void versionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            mvFrm(e);
        }
    }
}