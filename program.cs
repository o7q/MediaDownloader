using System;
using System.IO;
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
                string mediadownloader = "hello! you found the secret message. c:";
                File.WriteAllText("mediadownloader.bat", mediadownloader);
            }
            catch
            {
                // do nothing
            }

            // create downloads directory
            try
            {
                Directory.CreateDirectory("Downloads");
                selectedLocation = "Downloads";
            }
            catch
            {
                // do nothing
            }

            formatbox.SelectedIndex = 4;
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            // delete mediadownloader.bat
            try
            {
                File.Delete("mediadownloader.bat");
            }
            catch
            {
                // do nothing
            }

            Application.Exit();
        }

        private void minimizebutton_Click(object sender, EventArgs e)
        {
            // minimize button
            this.WindowState = FormWindowState.Minimized;
        }

        private void titlebarpanel_MouseMove(object sender, MouseEventArgs e)
        {
            // allows mousedown to move form
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void titlelabel_MouseMove(object sender, MouseEventArgs e)
        {
            // allows mousedown to move form
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void byo7qlabel_MouseMove(object sender, MouseEventArgs e)
        {
            // allows mousedown to move form
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void logo_MouseMove(object sender, MouseEventArgs e)
        {
            // allows mousedown to move form
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void versionlabel_MouseMove(object sender, MouseEventArgs e)
        {
            // allows mousedown to move form
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void downloadbutton_Click(object sender, EventArgs e)
        {
            // downloads url specified with format selected
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
                    // (raw)
                    if (formatbox.SelectedIndex == 1)
                    {
                        string url = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                        File.WriteAllText("mediadownloader.bat", url);
                        Process.Start("mediadownloader.bat");
                    }
                    else
                    {
                        // do nothing
                    }

                    // mp4
                    if (formatbox.SelectedIndex == 2)
                    {
                        string url = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video mp4 --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                        File.WriteAllText("mediadownloader.bat", url);
                        Process.Start("mediadownloader.bat");
                    }
                    else
                    {
                        // do nothing
                    }

                    // webm
                    if (formatbox.SelectedIndex == 3)
                    {
                        string url = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --remux-video webm --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                        File.WriteAllText("mediadownloader.bat", url);
                        Process.Start("mediadownloader.bat");
                    }
                    else
                    {
                        // do nothing
                    }

                    // (raw)
                    if (formatbox.SelectedIndex == 6)
                    {
                        string url = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                        File.WriteAllText("mediadownloader.bat", url);
                        Process.Start("mediadownloader.bat");
                    }
                    else
                    {
                        // do nothing
                    }

                    // mp3
                    if (formatbox.SelectedIndex == 7)
                    {
                        string url = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format mp3 --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                        File.WriteAllText("mediadownloader.bat", url);
                        Process.Start("mediadownloader.bat");
                    }
                    else
                    {
                        // do nothing
                    }

                    // wav
                    if (formatbox.SelectedIndex == 8)
                    {
                        string url = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format wav --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                        File.WriteAllText("mediadownloader.bat", url);
                        Process.Start("mediadownloader.bat");
                    }
                    else
                    {
                        // do nothing
                    }

                    // m4a
                    if (formatbox.SelectedIndex == 9)
                    {
                        string url = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe -x --audio-format m4a --path " + "\"" + selectedLocation + "\"" + " " + inputbox.Text;
                        File.WriteAllText("mediadownloader.bat", url);
                        Process.Start("mediadownloader.bat");
                    }
                    else
                    {
                        // do nothing
                    }

                    // (Use Custom Arguments)
                    if (formatbox.SelectedIndex == 12)
                    {
                        string url = "@echo off\ncolor 8\nyt-dlp.exe --ffmpeg-location ffmpeg.exe --path " + "\"" + selectedLocation + "\"" + " " + customargsbox.Text + " " + inputbox.Text + "\nPAUSE";
                        File.WriteAllText("mediadownloader.bat", url);
                        Process.Start("mediadownloader.bat");
                    }
                    else
                    {
                        // do nothing
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
                File.WriteAllText("mediadownloader.bat", url);
                Process.Start("mediadownloader.bat");
            }
        }

        private void githubbutton_Click(object sender, EventArgs e)
        {
            // opens yt-dlp github page in the default web browser
            System.Diagnostics.Process.Start("https://github.com/yt-dlp/yt-dlp");
        }

        private void infobutton_Click(object sender, EventArgs e)
        {
            // opens info panel
            MessageBox.Show("MediaDownloader v2.3 by o7q\nPowered by yt-dlp and ffmpeg\n\nMediaDownloader is licensed under GPL-3.0-only\nyt-dlp is licensed under Unlicense\nffmpeg is licensed under LGPL-2.1\n\nIf the program stops functioning you may need to download a new version of yt-dlp from the yt-dlp github page.\n\nTo update yt-dlp:\n1. While in the MediaDownloader UI, click on 'yt-dlp GitHub'\n2. Click on the releases tab and download 'yt-dlp.exe'\n3. Replace 'yt-dlp.exe' that is next to 'MediaDownloader.exe' with the new 'yt-dlp.exe'");
        }

        private void program_FormClosing(object sender, FormClosingEventArgs e)
        {
            // delete mediadownloader.bat on program close
            try
            {
                File.Delete("mediadownloader.bat");
            }
            catch
            {
                // do nothing
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
    }
}