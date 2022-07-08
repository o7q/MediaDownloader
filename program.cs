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
        // configure window
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

        public program()
        {
            InitializeComponent();   
            
            // create mediadownloader.bat
            try
            {
                string mediadownloader = "Hey! You found the secret message. c:";
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
                selectedLocation = "Downloads";
            }
            catch
            {
                // ignore
            }

            formatBox.SelectedIndex = 4;
            useDefLoc = true;
        }
        private void program_Load(object sender, EventArgs e)
        {
            if (File.Exists("mediadownloader\\yt-dlp.exe"))
            {
                // continue loading
            }
            else
            {
                MessageBox.Show("\"yt-dlp.exe\" not found! Exiting MediaDownloader.");

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
                MessageBox.Show("\"ffmpeg.exe\" not found! Exiting MediaDownloader.");

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
        public void MoveForm(MouseEventArgs e)
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

        // buttons
        private void infoButton_Click(object sender, EventArgs e)
        {
            // opens info panel
            MessageBox.Show("MediaDownloader by o7q\nPowered by yt-dlp and ffmpeg\n\nMediaDownloader is licensed under GPL-3.0-only\nyt-dlp is licensed under Unlicense\nffmpeg is licensed under LGPL-2.1\n\nIf the program stops functioning you may need to download a new version of yt-dlp from the yt-dlp github page.\n\nTo update yt-dlp:\n1. Click on the \"yt-dlp GitHub\" button within MediaDownloader\n2. Click on the releases tab and download \"yt-dlp.exe\"\n3. Replace the \"yt-dlp.exe\" that is inside the \"mediadownloader\" directory with the new \"yt-dlp.exe\"");
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            // delete mediadownloader.bat
            try
            {
                File.Delete("mediadownloader\\mediadownloader.bat");
                File.Delete("mediadownloader\\temp_download0.mp4");
                File.Delete("mediadownloader\\temp_download0.webm");
                File.Delete("mediadownloader\\temp_download1.mp3");
            }
            catch
            {
                // ignore
            }

            Application.Exit();
        }

        // call moveform
        private void titlebarpanel_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        private void titlelabel_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        private void byo7qlabel_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        private void logo_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        private void versionlabel_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        private void program_FormClosing(object sender, FormClosingEventArgs e)
        {
            // delete mediadownloader.bat on program close
            try
            {
                File.Delete("mediadownloader\\mediadownloader.bat");
                File.Delete("mediadownloader\\temp_download0.mp4");
                File.Delete("mediadownloader\\temp_download1.mp3");
            }
            catch
            {
                // ignore
            }
        }

        // download config buttons
        private void locationButton_Click(object sender, EventArgs e)
        {
            // opens file location browser
            FolderBrowserDialog selectLocation = new FolderBrowserDialog();
            selectLocation.Description = "Select Location";
            if (selectLocation.ShowDialog() == DialogResult.OK)
            {
                selectedLocation = selectLocation.SelectedPath;
                directoryLabel.Text = selectedLocation;
                if (selectedLocation == "Downloads")
                {
                    useDefLoc = true;
                }
                else
                {
                    useDefLoc = false;
                }
            }
        }

        private void clearLocationButton_Click(object sender, EventArgs e)
        {
            // clears selected location
            selectedLocation = "Downloads";
            directoryLabel.Text = "";
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            // ensure user specifies valid url
            if (inputBox.Text == "")
            {
                MessageBox.Show("Please specify a valid URL");
            }
            else
            {
                // ensure user cannot select non-formats
                int formatSelection = formatBox.SelectedIndex;

                if(formatSelection == 0 || formatSelection == 4 || formatSelection == 5 || formatSelection == 10 || formatSelection == 11)
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
                        if (formatBox.SelectedIndex == 1 || formatBox.SelectedIndex == 6 || formatBox.SelectedIndex == 7 || formatBox.SelectedIndex == 8 || formatBox.SelectedIndex == 9 || formatBox.SelectedIndex == 12)
                        {
                            MessageBox.Show("No video codecs are available for this format");
                        }

                        // mp4
                        if (formatBox.SelectedIndex == 2)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + inputBox.Text + "\nffmpeg.exe -i temp_download0.mp4 -c:v h264 -c:a aac " + @"..\Downloads\converted_download_" + randomString + ".mp4" + "\"" + "\n" + @"del /f temp_download0.mp4";
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
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + inputBox.Text + "\nffmpeg.exe -i temp_download0.mp4 -c:v h264 -c:a aac " + selectedLocation + @"\converted_download_" + randomString + ".mp4" + "\"" + "\n" + @"del /f temp_download0.mp4";
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
                        if (formatBox.SelectedIndex == 3)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm -o \"temp_download0\" " + inputBox.Text + "\nffmpeg.exe -i temp_download0.webm -c:v vp9 -c:a libvorbis " + @"..\Downloads\converted_download_" + randomString + ".webm" + "\"" + "\n" + @"del /f temp_download0.webm";
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
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm -o \"temp_download0\" " + inputBox.Text + "\nffmpeg.exe -i temp_download0.webm -c:v vp9 -c:a libvorbis " + selectedLocation + @"\converted_download_" + randomString + ".webm" + "\"" + "\n" + @"del /f temp_download0.webm";
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
                        if (formatBox.SelectedIndex == 1)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path " + @"..\Downloads " + inputBox.Text;
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
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path " + "\"" + selectedLocation + "\"" + " " + inputBox.Text;
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
                        if (formatBox.SelectedIndex == 2)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 --path " + @"..\Downloads " + inputBox.Text;
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
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 --path " + "\"" + selectedLocation + "\"" + " " + inputBox.Text;
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
                        if (formatBox.SelectedIndex == 3)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm --path " + @"..\Downloads " + inputBox.Text;
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
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm --path " + "\"" + selectedLocation + "\"" + " " + inputBox.Text;
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

                        // (raw) audio
                        if (formatBox.SelectedIndex == 6)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --path " + @"..\Downloads " + inputBox.Text;
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
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --path " + "\"" + selectedLocation + "\"" + " " + inputBox.Text;
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
                        if (formatBox.SelectedIndex == 7)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format mp3 --path " + @"..\Downloads " + inputBox.Text;
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
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format mp3 --path " + "\"" + selectedLocation + "\"" + " " + inputBox.Text;
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
                        if (formatBox.SelectedIndex == 8)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format wav --path " + @"..\Downloads " + inputBox.Text;
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
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format wav --path " + "\"" + selectedLocation + "\"" + " " + inputBox.Text;
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
                        else

                        // ogg
                        if (formatBox.SelectedIndex == 9)
                        {
                            if (useDefLoc == true)
                            {
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + inputBox.Text + "\nffmpeg.exe -i temp_download0.mp4 -c:a libmp3lame temp_download1.mp3" + "\nffmpeg.exe -i temp_download1.mp3 -c:a libvorbis " + @"..\Downloads\converted_download_" + randomString + ".ogg" + "\ndel /f temp_download0.mp4" + "\ndel /f temp_download1.mp3";                         
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
                                string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download0\" " + inputBox.Text + "\nffmpeg.exe -i temp_download0.mp4 -c:a libmp3lame temp_download1.mp3" + "\nffmpeg.exe -i temp_download1.mp3 -c:a libvorbis " + selectedLocation + @"\converted_download_" + randomString + ".ogg" + "\ndel /f temp_download0.mp4" + "\ndel /f temp_download1.mp3";
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

                        // (Use Custom Arguments)
                        if (formatBox.SelectedIndex == 12)
                        {
                            string script = "@echo off\ncolor 8\ncd mediadownloader\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path " + "\"" + selectedLocation + "\"" + " " + customArgsBox.Text + " " + inputBox.Text + "\nPAUSE";
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
    }
}