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

        // set default location
        string selectedLocation;

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

            formatbox.SelectedIndex = 4;
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
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

        private void minimizebutton_Click(object sender, EventArgs e)
        {
            // minimize button
            this.WindowState = FormWindowState.Minimized;
        }

        public void MoveForm(MouseEventArgs e)
        {
            // function move form on mousedown
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

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

        private void downloadbutton_Click(object sender, EventArgs e)
        {
            // ensure user specifies valid url
            if (inputbox.Text == "")
            {
                MessageBox.Show("Please specify a valid URL");
            }
            else
            {
                // ensure user cannot select non-formats
                int formatSelection = formatbox.SelectedIndex;

                if(formatSelection == 0 || formatSelection == 4 || formatSelection == 5 || formatSelection == 10 || formatSelection == 11)
                {
                    MessageBox.Show("Please select a valid format");
                }
                else
                {
                    // configure and execute download script
                    if (applycodecs.Checked == true)
                    {
                        // invalid formats
                        if (formatbox.SelectedIndex == 1 || formatbox.SelectedIndex == 6 || formatbox.SelectedIndex == 7 || formatbox.SelectedIndex == 8 || formatbox.SelectedIndex == 9 || formatbox.SelectedIndex == 12)
                        {
                            MessageBox.Show("No video codecs are available for this format");
                        }

                        // mp4
                        if (formatbox.SelectedIndex == 2)
                        {
                            if (selectedLocation == "Downloads")
                            {
                                // generate random id
                                var numbers = "1234567890";
                                var stringNumbers = new char[8];
                                var randomNumbers = new Random();
                                for (int i = 0; i < stringNumbers.Length; i++)
                                {
                                    stringNumbers[i] = numbers[randomNumbers.Next(numbers.Length)];
                                }
                                var randomString = new String(stringNumbers);

                                string script = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 -o \"temp_download\" " + inputbox.Text + "\nffmpeg.exe -i temp_download.mp4 -c:v h264 -c:a aac " + "\"" + selectedLocation + @"\converted_download_" + randomString + ".mp4" + "\"" + "\n" + @"del /f temp_download.mp4" + "\npause";
                                try
                                {
                                    File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                                }
                                catch
                                {
                                    // ignore
                                }

                                string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                                mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                                Process.Start(mediadownloaderScript);
                            }
                        }

                        // webm
                        if (formatbox.SelectedIndex == 3)
                        {
                            // generate random id
                            var numbers = "1234567890";
                            var stringNumbers = new char[8];
                            var randomNumbers = new Random();
                            for (int i = 0; i < stringNumbers.Length; i++)
                            {
                                stringNumbers[i] = numbers[randomNumbers.Next(numbers.Length)];
                            }
                            var randomString = new String(stringNumbers);
                            
                            string script = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm -o \"temp_download\" --path Downloads " + inputbox.Text + "\nffmpeg.exe -i Downloads" + @"\temp_download.webm -c:v vp9 -c:a libvorbis " + "\"" + selectedLocation + @"\converted_download_" + randomString + ".webm" + "\"" + "\n" + @"del /f Downloads\temp_download.webm";
                            try
                            {
                                File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                            }
                            catch
                            {
                                // ignore
                            }

                            string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                            Process.Start(mediadownloaderScript);
                        }
                    }
                    else
                    {
                        // (raw) video
                        if (formatbox.SelectedIndex == 1)
                        {
                            string script = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                            try
                            {
                                File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                            }
                            catch
                            {
                                // ignore
                            }

                            string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                            Process.Start(mediadownloaderScript);
                        }

                        // mp4
                        if (formatbox.SelectedIndex == 2)
                        {
                            string script = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                            try
                            {
                                File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                            }
                            catch
                            {
                                // ignore
                            }

                            string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                            Process.Start(mediadownloaderScript);
                        }

                        // webm
                        if (formatbox.SelectedIndex == 3)
                        {
                            string script = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                            try
                            {
                                File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                            }
                            catch
                            {
                                // ignore
                            }

                            string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                            Process.Start(mediadownloaderScript);
                        }

                        // (raw) audio
                        if (formatbox.SelectedIndex == 6)
                        {
                            string script = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                            try
                            {
                                File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                            }
                            catch
                            {
                                // ignore
                            }

                            string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                            Process.Start(mediadownloaderScript);
                        }

                        // mp3
                        if (formatbox.SelectedIndex == 7)
                        {
                            string script = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format mp3 --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                            try
                            {
                                File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                            }
                            catch
                            {
                                // ignore
                            }

                            string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                            Process.Start(mediadownloaderScript);
                        }

                        // wav
                        if (formatbox.SelectedIndex == 8)
                        {
                            string script = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format wav --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                            try
                            {
                                File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                            }
                            catch
                            {
                                // ignore
                            }

                            string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                            Process.Start(mediadownloaderScript);
                        }
                        else

                        // m4a
                        if (formatbox.SelectedIndex == 9)
                        {
                            string script = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format m4a --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                            try
                            {
                                File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                            }
                            catch
                            {
                                // ignore
                            }

                            string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                            Process.Start(mediadownloaderScript);
                        }

                        // (Use Custom Arguments)
                        if (formatbox.SelectedIndex == 12)
                        {
                            string script = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path " + "\"" + selectedLocation + "\"" + " " + customargsbox.Text + " " + inputbox.Text + "\nPAUSE";
                            try
                            {
                                File.WriteAllText("mediadownloader\\mediadownloader.bat", script);
                            }
                            catch
                            {
                                // ignore
                            }

                            string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                            Process.Start(mediadownloaderScript);
                        }
                    }
                }
            }
        }

        private void viewavailableformatsbutton_Click(object sender, EventArgs e)
        {
            // displays available formats of the specified url
            if (inputbox.Text == "")
            {
                MessageBox.Show("Please specify a valid URL");
            }
            else
            {
                string url = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --list-formats " + inputbox.Text + "\nPAUSE";
                File.WriteAllText("mediadownloader\\mediadownloader.bat", url);

                string mediadownloaderScript = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                mediadownloaderScript += "\\mediadownloader\\mediadownloader.bat";
                Process.Start(mediadownloaderScript);
            }
        }

        private void githubbutton_Click(object sender, EventArgs e)
        {
            // opens mediadownloader github page in the default web browser
            System.Diagnostics.Process.Start("https://github.com/o7q/MediaDownloader");
        }

        private void infobutton_Click(object sender, EventArgs e)
        {
            // opens info panel
            MessageBox.Show("MediaDownloader by o7q\nPowered by yt-dlp and ffmpeg\n\nMediaDownloader is licensed under GPL-3.0-only\nyt-dlp is licensed under Unlicense\nffmpeg is licensed under LGPL-2.1\n\nIf the program stops functioning you may need to download a new version of yt-dlp from the yt-dlp github page.\n\nTo update yt-dlp:\n1. Click on the \"yt-dlp GitHub\" button within MediaDownloader\n2. Click on the releases tab and download \"yt-dlp.exe\"\n3. Replace \"yt-dlp.exe\" that is next to \"MediaDownloader.exe\" with the new \"yt-dlp.exe\"");
        }

        private void program_FormClosing(object sender, FormClosingEventArgs e)
        {
            // delete mediadownloader.bat on program close
            try
            {
                File.Delete("mediadownloader\\mediadownloader.bat");
            }
            catch
            {
                // ignore
            }
        }

        private void locationButton_Click(object sender, EventArgs e)
        {
            // opens file location browser
            FolderBrowserDialog selectLocation = new FolderBrowserDialog();
            selectLocation.Description = "Select Location";
            if (selectLocation.ShowDialog() == DialogResult.OK)
            {
                selectedLocation = selectLocation.SelectedPath;
                directoryLabel.Text = selectedLocation;
            }
        }

        private void clearLocationButton_Click(object sender, EventArgs e)
        {
            // clears selected location
            selectedLocation = "Downloads";
            directoryLabel.Text = "";
        }

        private void ytdlpgithubbutton_Click(object sender, EventArgs e)
        {
            // opens yt-dlp github page in the default web browser
            System.Diagnostics.Process.Start("https://github.com/yt-dlp/yt-dlp");
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

        private void button1_Click(object sender, EventArgs e)
        {
            string a = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            a += "\\mediadownloader\\scriptlauncher.exe";
            Process.Start(a);
        }
    }
}