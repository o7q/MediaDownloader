using System;
using System.IO;
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

        // create variables
        string selectedLocation;
        bool useDefLoc;

        // program events

        // form initialize component
        public program()
        {
            InitializeComponent();

            // create mediadownloader.bat
            try
            {
                string mediadownloader = "";
                File.WriteAllText("mediadownloader\\mediadownloader.bat", mediadownloader);
            }
            catch
            {
                // ignore
            }

            // create downloads directory
            try
            {
                Directory.CreateDirectory("Downloads");
                selectedLocation = "";
            }
            catch
            {
                // ignore
            }

            // configure default variables
            formatBox.SelectedIndex = 6;
            useDefLoc = true;

            // load config0
            if (File.Exists("mediadownloader\\config0"))
            {
                string config0 = File.ReadAllText("mediadownloader\\config0");
                inputBox.Text = config0;
            }

            // load config1
            if (File.Exists("mediadownloader\\config1"))
            {
                string config1_string = File.ReadAllText("mediadownloader\\config1");
                int config1 = int.Parse(config1_string);
                formatBox.SelectedIndex = config1;
            }

            // load config2
            if (File.Exists("mediadownloader\\config2"))
            {
                string config2 = File.ReadAllText("mediadownloader\\config2");
                selectedLocation = config2;
                if (selectedLocation != "")
                {
                    useDefLoc = false;
                    directoryLabel.Text = config2;
                }
            }

            // load config3
            if (File.Exists("mediadownloader\\config3"))
            {
                string config3 = File.ReadAllText("mediadownloader\\config3");
                customArgsBox.Text = config3;
            }

            // load config4
            if (File.Exists("mediadownloader\\config4"))
            {
                string config4 = File.ReadAllText("mediadownloader\\config4");
                if (config4 == "1")
                {
                    applyCodecs.Checked = true;
                }
            }

            // load config5
            if (File.Exists("mediadownloader\\config5"))
            {
                string config5 = File.ReadAllText("mediadownloader\\config5");
                gifResolution.Text = config5;
            }
            else
            {
                int R = 500;
                string R_string = R.ToString();
                gifResolution.Text = R_string;
            }

            // load config6
            if (File.Exists("mediadownloader\\config6"))
            {
                string config6 = File.ReadAllText("mediadownloader\\config6");
                gifFramerate.Text = config6;
            }
            else
            {
                int F = 15;
                string F_string = F.ToString();
                gifFramerate.Text = F_string;
            }

            // load config_switch
            if (File.Exists("mediadownloader\\config_switch"))
            {
                useConfig.Checked = true;
            }

            // configure tooltips
            programToolTip.SetToolTip(minimizeButton, "Minimize");
            programToolTip.SetToolTip(exitButton, "Close");
            programToolTip.SetToolTip(inputBox, "URL to be downloaded");
            programToolTip.SetToolTip(formatBox, "Media format for download");
            programToolTip.SetToolTip(downloadButton, "Download from the URL with the specified arguments");
            programToolTip.SetToolTip(locationButton, "Location for download");
            programToolTip.SetToolTip(clearLocationButton, "Reset the selected download location");
            programToolTip.SetToolTip(directoryLabel, "Currently selected download location");
            programToolTip.SetToolTip(viewAvailableFormatsButton, "Display all the available media formats found on the server for the specified URL");
            programToolTip.SetToolTip(githubButton, "Open the MediaDownloader github repository in the default web browser");
            programToolTip.SetToolTip(infoButton, "Display info about MediaDownloader");
            programToolTip.SetToolTip(ytdlpGithubButton, "Open the yt-dlp github repository in the default web browser");
            programToolTip.SetToolTip(applyCodecs, "Uses ffmpeg to apply valid video codecs after the video is downloaded\nThis can fix problems with importing videos into some software\n(only supports mp4 and webm)");
            programToolTip.SetToolTip(useConfig, "Save all current component states to config files\nIf enabled, then on program startup all component states will be restored");
            programToolTip.SetToolTip(resetConfig, "Clear all component states");
            programToolTip.SetToolTip(customArgsBox, "Custom arguments for yt-dlp (not for ffmpeg)");
            programToolTip.SetToolTip(gifResolution, "Width resolution for gif (web)\nKeeps ratio (ffmpeg args = r:-1)");
            programToolTip.SetToolTip(gifFramerate, "Framerate for gif (web)");
        }

        // form load
        private void program_Load(object sender, EventArgs e)
        {
            if (File.Exists("mediadownloader\\yt-dlp.exe"))
            {
                // continue loading
            }
            else
            {
                MessageBox.Show("\"yt-dlp.exe\" not found! Exiting MediaDownloader");

                // delete mediadownloader.bat
                try
                {
                    File.Delete("mediadownloader\\mediadownloader.bat");
                }
                catch
                {
                    // ignore
                }

                Application.Exit();
            }

            if (File.Exists("mediadownloader\\ffmpeg.exe"))
            {
                // continue loading
            }
            else
            {
                MessageBox.Show("\"ffmpeg.exe\" not found! Exiting MediaDownloader");

                // delete mediadownloader.bat
                try
                {
                    File.Delete("mediadownloader\\mediadownloader.bat");
                }
                catch
                {
                    // ignore
                }

                Application.Exit();
            }
        }

        // functions
        private void MoveForm(MouseEventArgs e)
        {
            // function move form on mousedown
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void mdBatch()
        {
            string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
            Process.Start(mediadownloaderScript);
        }

        private void delProgFiles()
        {
            // delete mediadownloader.bat and configs
            try
            {
                File.Delete("mediadownloader\\mediadownloader.bat");

                // clean up temps
                File.Delete("mediadownloader\\temp_download0.mp4");
                File.Delete("mediadownloader\\temp_download0.webm");
                File.Delete("mediadownloader\\temp_download1.mp3");
                File.Delete("mediadownloader\\temp_download0");
                File.Delete("mediadownloader\\temp_download1");

                if (useConfig.Checked == false)
                {
                    File.Delete("mediadownloader\\config_switch");

                    File.Delete("mediadownloader\\config0");
                    File.Delete("mediadownloader\\config1");
                    File.Delete("mediadownloader\\config2");
                    File.Delete("mediadownloader\\config3");
                    File.Delete("mediadownloader\\config4");
                    File.Delete("mediadownloader\\config5");
                    File.Delete("mediadownloader\\config6");
                }
            }
            catch
            {
                // ignore
            }
        }

        // buttons
        private void infoButton_Click(object sender, EventArgs e)
        {
            // opens info panel
            MessageBox.Show("MediaDownloader by o7q\nPowered by yt-dlp and ffmpeg\n\nMediaDownloader is licensed under GPL-3.0-only\nyt-dlp is licensed under Unlicense\nffmpeg is licensed under LGPL-2.1\n\nIf the program stops functioning you may need to download a new version of yt-dlp from the yt-dlp GitHub page\n\nTo update yt-dlp:\n1. Click on the \"yt-dlp GitHub\" button within MediaDownloader\n2. Click on the releases tab and download \"yt-dlp.exe\"\n3. Replace \"yt-dlp.exe\" that is inside the \"mediadownloader\" directory with the new \"yt-dlp.exe\"");
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            // opens mediadownloader github page in the default web browser
            System.Diagnostics.Process.Start("https://github.com/o7q/MediaDownloader");
        }

        private void ytdlpGithubButton_Click(object sender, EventArgs e)
        {
            // opens yt-dlp github page in the default web browser
            System.Diagnostics.Process.Start("https://github.com/yt-dlp/yt-dlp");
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            // minimize button
            this.WindowState = FormWindowState.Minimized;
        }

        // program closing handler
        private void exitButton_Click(object sender, EventArgs e)
        {
            delProgFiles();

            Application.Exit();
        }

        private void program_FormClosing(object sender, FormClosingEventArgs e)
        {
            delProgFiles();
        }

        // call moveform
        private void titlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        private void bannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        private void versionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        // configuration
        private void useConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (useConfig.Checked == true)
            {
                File.WriteAllText("mediadownloader\\config_switch", "");

                File.WriteAllText("mediadownloader\\config0", "");
                File.WriteAllText("mediadownloader\\config1", "");
                File.WriteAllText("mediadownloader\\config2", "");
                File.WriteAllText("mediadownloader\\config3", "");
                File.WriteAllText("mediadownloader\\config4", "");
                File.WriteAllText("mediadownloader\\config5", "");
                File.WriteAllText("mediadownloader\\config6", "");

                // write config0
                string config0 = inputBox.Text;
                File.WriteAllText("mediadownloader\\config0", config0);

                // write config1
                int config1_int = formatBox.SelectedIndex;
                string config1 = config1_int.ToString();
                File.WriteAllText("mediadownloader\\config1", config1);

                // write config2
                string config2 = selectedLocation;
                File.WriteAllText("mediadownloader\\config2", config2);

                // write config3
                string config3 = customArgsBox.Text;
                File.WriteAllText("mediadownloader\\config3", config3);

                // write config4
                if (applyCodecs.Checked == true)
                {
                    File.WriteAllText("mediadownloader\\config4", "1");
                }
                else
                {
                    File.WriteAllText("mediadownloader\\config4", "");
                }

                // write config5
                string config5 = gifResolution.Text;
                File.WriteAllText("mediadownloader\\config5", config5);

                // write config6
                string config6 = gifFramerate.Text;
                File.WriteAllText("mediadownloader\\config6", config6);
            }
        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            // on change write to config0
            if (useConfig.Checked == true)
            {
                string config0 = inputBox.Text;
                File.WriteAllText("mediadownloader\\config0", config0);
            }
        }

        private void formatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // on change write to config1
            if (useConfig.Checked == true)
            {
                int config1_int = formatBox.SelectedIndex;
                string config1 = config1_int.ToString();
                File.WriteAllText("mediadownloader\\config1", config1);
            }
        }

        private void customArgsBox_TextChanged(object sender, EventArgs e)
        {
            // on change write to config3
            if (useConfig.Checked == true)
            {
                string config3 = customArgsBox.Text;
                File.WriteAllText("mediadownloader\\config3", config3);
            }
        }

        private void applyCodecs_CheckedChanged(object sender, EventArgs e)
        {
            // on change write to config4
            if (applyCodecs.Checked == true)
            {
                File.WriteAllText("mediadownloader\\config4", "1");
            }
            else
            {
                File.WriteAllText("mediadownloader\\config4", "");
            }
        }

        private void gifResolution_TextChanged(object sender, EventArgs e)
        {
            // on change write to config5
            if (useConfig.Checked == true)
            {
                string config5 = gifResolution.Text;
                File.WriteAllText("mediadownloader\\config5", config5);
            }
        }

        private void gifFramerate_TextChanged(object sender, EventArgs e)
        {
            // on change write to config6
            if (useConfig.Checked == true)
            {
                string config6 = gifFramerate.Text;
                File.WriteAllText("mediadownloader\\config6", config6);
            }
        }

        private void resetConfig_Click(object sender, EventArgs e)
        {
            // clear config0
            File.WriteAllText("mediadownloader\\config0", "");
            inputBox.Text = "";

            // clear config1
            int config1_int = 6;
            string config1 = config1_int.ToString();
            File.WriteAllText("mediadownloader\\config1", config1);
            formatBox.SelectedIndex = 6;

            // clear config2
            File.WriteAllText("mediadownloader\\config2", "");
            useDefLoc = true;
            directoryLabel.Text = "";

            // clear config3
            File.WriteAllText("mediadownloader\\config3", "");
            customArgsBox.Text = "";

            // clear config4
            File.WriteAllText("mediadownloader\\config4", "");
            applyCodecs.Checked = false;

            // clear config5
            File.WriteAllText("mediadownloader\\config5", "");
            gifResolution.Text = "500";

            // clear config6
            File.WriteAllText("mediadownloader\\config6", "");
            gifFramerate.Text = "15";
        }

        // configure download buttons
        private void locationButton_Click(object sender, EventArgs e)
        {
            // opens file location browser, update variables, and write config
            FolderBrowserDialog selectLocation = new FolderBrowserDialog();
            selectLocation.Description = "Select Location";
            if (selectLocation.ShowDialog() == DialogResult.OK)
            {
                selectedLocation = selectLocation.SelectedPath;
                directoryLabel.Text = selectedLocation;
                if (selectedLocation == "")
                {
                    useDefLoc = true;
                }
                else
                {
                    useDefLoc = false;
                }

                if (useConfig.Checked == true)
                {
                    // on change write to config2
                    string config2 = selectedLocation;
                    File.WriteAllText("mediadownloader\\config2", config2);
                }
            }
        }

        private void clearLocationButton_Click(object sender, EventArgs e)
        {
            // clears selected location
            useDefLoc = true;
            selectedLocation = "";
            directoryLabel.Text = "";

            string config2 = selectedLocation;
            File.WriteAllText("mediadownloader\\config2", config2);

        }

        private void viewAvailableFormatsButton_Click(object sender, EventArgs e)
        {
            // displays available formats of the specified url
            if (inputBox.Text == "")
            {
                MessageBox.Show("Please specify a valid URL");
            }
            else
            {
                string url = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --list-formats " + inputBox.Text + "\nPAUSE";
                File.WriteAllText("mediadownloader\\mediadownloader.bat", url);

                mdBatch();
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            // download button

            // ensure user specifies valid url
            if (inputBox.Text == "")
            {
                MessageBox.Show("Please specify a valid URL");
            }
            else
            {
                // ensure user cannot select non-formats
                string url = inputBox.Text;
                int format = formatBox.SelectedIndex;
                string gifR = gifResolution.Text;
                string gifF = gifFramerate.Text;

                if (format == 0 || format == 6 || format == 7 || format == 12 || format == 13)
                {
                    MessageBox.Show("Please select a valid format");
                }
                else
                {
                    // generate a random id
                    var numbers = "1234567890";
                    var stringNumbers = new char[8];
                    var randomNumbers = new Random();
                    for (int i = 0; i < stringNumbers.Length; i++)
                    {
                        stringNumbers[i] = numbers[randomNumbers.Next(numbers.Length)];
                    }
                    var randomString = new String(stringNumbers);

                    // configure and execute download script
                    if (applyCodecs.Checked == true)
                    {
                        // invalid formats
                        if (format == 1 || format == 4 || format == 5 || format == 8 || format == 9 || format == 10 || format == 11 || format == 14)
                        {
                            MessageBox.Show("No video codecs are available for this format");
                        }

                        // mp4
                        if (format == 2)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + url + "\nffmpeg.exe -i temp_download0.mp4 -c:v h264 -c:a aac " + @"..\Downloads\converted_download_" + randomString + ".mp4\n" + @"del /f temp_download0.mp4";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + url + "\nffmpeg.exe -i temp_download0.mp4 -c:v h264 -c:a aac \"" + selectedLocation + @"\converted_download_" + randomString + ".mp4\"\n" + @"del /f temp_download0.mp4";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }

                        // webm
                        if (format == 3)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm -o \"temp_download0\" " + url + "\nffmpeg.exe -i temp_download0.webm -c:v vp9 -c:a libvorbis " + @"..\Downloads\converted_download_" + randomString + ".webm\n" + @"del /f temp_download0.webm";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm -o \"temp_download0\" " + url + "\nffmpeg.exe -i temp_download0.webm -c:v vp9 -c:a libvorbis \"" + selectedLocation + @"\converted_download_" + randomString + ".webm\"\n" + @"del /f temp_download0.webm";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }
                    }
                    else
                    {
                        // (raw) video
                        if (format == 1)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path " + @"..\Downloads " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path \"" + selectedLocation + "\" " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }

                        // mp4
                        if (format == 2)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 --path " + @"..\Downloads " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 --path \"" + selectedLocation + "\" " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }

                        // webm
                        if (format == 3)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm --path " + @"..\Downloads " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm --path \"" + selectedLocation + "\" " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }

                        // gif
                        if (format == 4)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + url + "\nffmpeg.exe -i temp_download0.mp4 " + @"..\Downloads\converted_download_" + randomString + ".gif\n" + @"del /f temp_download0.mp4";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + url + "\nffmpeg.exe -i temp_download0.mp4 \"" + selectedLocation + @"\converted_download_" + randomString + ".gif\"\n" + @"del /f temp_download0.mp4";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }

                        // gif (web)
                        if (format == 5)
                        {
                            if (gifResolution.Text == "" || gifFramerate.Text == "")
                            {
                                MessageBox.Show("Please provide valid resolution and framerate values");
                            }
                            else
                            {
                                if (useDefLoc == true)
                                {
                                    string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + url + "\nffmpeg.exe -i temp_download0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + @" ..\Downloads\converted_download_" + randomString + ".gif\n" + @"del /f temp_download0.mp4";
                                    try
                                    {
                                        File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                    }
                                    catch
                                    {
                                        // ignore
                                    }

                                    mdBatch();
                                }
                                else
                                {
                                    string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + url + "\nffmpeg.exe -i temp_download0.mp4 -vf scale=" + gifR + ":-1 -r " + gifF + " \"" + selectedLocation + @"\converted_download_" + randomString + ".gif\"\n" + @"del /f temp_download0.mp4";
                                    try
                                    {
                                        File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                    }
                                    catch
                                    {
                                        // ignore
                                    }

                                    mdBatch();
                                }
                            }
                        }

                        // (raw) audio
                        if (format == 8)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --path " + @"..\Downloads " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --path \"" + selectedLocation + "\" " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }

                        // mp3
                        if (format == 9)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format mp3 --path " + @"..\Downloads " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format mp3 --path \"" + selectedLocation + "\" " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }

                        // wav
                        if (format == 10)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format wav --path " + @"..\Downloads " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format wav --path \"" + selectedLocation + "\" " + url;
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }

                        // ogg
                        if (format == 11)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + url + "\nffmpeg.exe -i temp_download0.mp4 -c:a libmp3lame temp_download1.mp3" + "\nffmpeg.exe -i temp_download1.mp3 -c:a libvorbis " + @"..\Downloads\converted_download_" + randomString + ".ogg" + "\ndel /f temp_download0.mp4" + "\ndel /f temp_download1.mp3";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + url + "\nffmpeg.exe -i temp_download0.mp4 -c:a libmp3lame temp_download1.mp3" + "\nffmpeg.exe -i temp_download1.mp3 -c:a libvorbis \"" + selectedLocation + @"\converted_download_" + randomString + ".ogg\"" + "\ndel /f temp_download0.mp4" + "\ndel /f temp_download1.mp3";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }

                        // (Custom DL Arguments)
                        if (format == 14)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path " + @"..\Downloads " + customArgsBox.Text + " " + url + "\npause";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                            else
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path \"" + selectedLocation + "\"" + " " + customArgsBox.Text + " " + url + "\npause";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                mdBatch();
                            }
                        }
                    }
                }
            }
        }
    }
}