using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using static MediaDownloader.Data.Storage;
using static MediaDownloader.Data.Structure.QueueItemStructure;
using static MediaDownloader.Tools.Forms;
using static MediaDownloader.Tools.Shell;
using static MediaDownloader.Managers.ConfigManager;
using static MediaDownloader.Managers.QueueItemManager;
using static MediaDownloader.Managers.Media.DownloadManager;

namespace MediaDownloader
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        QueueItemBase currentQueueItem = new QueueItemBase();

        private void Program_Load(object sender, EventArgs e)
        {
            UpdateListBox(QueueListBox, "MediaDownloader\\config\\queue", false);
            UpdateListBox(HistoryListBox, "MediaDownloader\\config\\history", true);

            UpdateVersionLabel();

            if (File.Exists("MediaDownloader\\config\\config.md"))
            {
                CONFIG = ReadConfig();
                if (QueueListBox.Items.Count == 0)
                {
                    if (File.Exists("MediaDownloader\\config\\latest.mdq"))
                        LoadQueueItem("MediaDownloader\\config\\latest.mdq");
                }
                else
                    QueueListBox.SelectedIndex = CONFIG.QUEUE_SELECTED_INDEX;

                if (HistoryListBox.Items.Count != 0)
                    HistoryListBox.SelectedIndex = CONFIG.HISTORY_SELECTED_INDEX;

                HistoryCheckBox.Checked = CONFIG.HISTORY_ENABLE;

                if (CONFIG.MENU_ENABLE_EXPANDED)
                    ExpandMenu();
                else
                    CollapseMenu();
            }
            else
            {
                OutputTimeframeStartTextBox.Text = "0:00";
                OutputTimeframeEndTextBox.Text = "0:10";

                OutputResizeWidthTextBox.Text = "1920";
                OutputResizeHeightTextBox.Text = "1080";

                OutputFramerateTextBox.Text = "60";

                OutputVideoBitrateTextBox.Text = "100M";
                OutputAudioBitrateTextBox.Text = "320K";

                OutputDisplayCheckBox.Checked = true;

                HistoryCheckBox.Checked = true;

                CollapseMenu();
            }

            #region loadTooltips
            // bind tooltips
            string[] tooltipMap = {
                "BannerPicture", "MediaDownloader by o7q",
                "VersionLabel", "Version " + VERSION,

                "MinimizeButton", "Minimize",
                "CloseButton", "Close",

                "UrlTextBox", "URL to be downloaded",
                "OutputNameTextBox", "File name for the download",

                "OutputFormatComboBox", "Media format for download",

                "ViewAvailableFormatsButton", "Display all the available media formats found on the server for the specified URL",

                "OutputTimeframeCheckBox", "Trim the download to a specific length with a start and end timestamp - Examples: \"0:00 - 0:10\" | \"1:25 - 2:30\" | \"2:30:40 - 3:05:15\"",
                "OutputTimeframeStartTextBox", "Trim start time",
                "OutputTimeframeEndTextBox", "Trim end time",

                "DownloadButton", "Download from the URL using the configured options",

                "OutputChangeLocationButton", "Change the folder location for download",
                "OutputOpenLocationButton", "Open the selected download location in the file explorer",
                "OutputClearLocationButton", "Reset the selected download location",
                "OutputLocationTextBox", "Currently selected download location",

                "OutputResizeCheckBox", "Enable resizing for video",
                "OutputResizeWidthTextBox", "Width for video",
                "OutputResizeHeightTextBox", "Height for video",

                "OutputFramerateCheckBox", "Enable framerate change for video",
                "OutputFramerateTextBox", "Framerate for video",

                "OutputVideoBitrateTextBox", "Bitrate for video - Examples: \"100M\" | \"900K\" (M = MB/s, K = KB/s)",
                "OutputAudioBitrateTextBox", "Bitrate for audio - Examples: \"320K\" | \"10K\" (M = MB/s, K = KB/s)",

                "OutputYtdlpArgumentsTextBox", "Custom arguments for yt-dlp (double-click to open the yt-dlp GitHub repository for information)",
                "OutputFfmpegArgumentsTextBox", "Custom arguments for ffmpeg (this option will control the output directory, you will have to provide the output directory within these arguments, double-click to open the ffmpeg documentation for information)",

                "OutputDisplayCheckBox", "Display the verbose log while downloading in a separate command prompt window",
                "OutputPauseCheckBox", "Cause the command prompt to stay open after each stage finishes (helpful for debugging)",

                "MenuExpandButton", "Expand/Collapse Menu",

                "QueueListBox", "List of queued downloads",
                "QueueAddButton", "Add an item to the queue",
                "QueueRemoveButton", "Remove the selected item from the queue",
                "DownloadAllButton", "Download all items in the queue",
                "QueueProgressBar", "Queue progress bar",

                "HistoryListBox", "List of previous downloads",
                "HistoryLoadButton", "Load the config from the selected item",
                "HistoryRefreshButton", "Refresh the history list",
                "HistoryRemoveButton", "Remove the selected item from history",
                "HistoryCheckBox", "Enable and disable the saving of history"
            };

            // load tooltips
            for (int i = 0; i < tooltipMap.Length; i += 2)
                ProgramToolTip.SetToolTip(Controls.Find(tooltipMap[i], true)[0], tooltipMap[i + 1]);

            // configure tooltip draw
            ProgramToolTip.AutoPopDelay = 10000;
            ProgramToolTip.InitialDelay = 500;
            ProgramToolTip.ReshowDelay = 100;
            ProgramToolTip.OwnerDraw = true;
            ProgramToolTip.BackColor = Color.FromArgb(32, 32, 32);
            ProgramToolTip.ForeColor = Color.FromArgb(150, 150, 150);
            #endregion
        }

        private void ProgramToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (IS_DOWNLOADING)
                return;

            if (currentQueueItem.OUTPUT_NAME == "" || currentQueueItem.OUTPUT_NAME == null)
                OutputNameTextBox.Text = "download " + DateTime.Now.ToString("[M-d-y_hms]");

            Task.Run(() => StartDownload(currentQueueItem, DownloadButton, DownloadAllButton));
        }

        private void DownloadAllButton_Click(object sender, EventArgs e)
        {
            if (IS_DOWNLOADING)
                return;

            QueueProgressBar.Value = 0;

            string[] queueList = new string[QueueListBox.Items.Count];
            int queueIndex = 0;
            foreach (string item in QueueListBox.Items)
            {
                queueList[queueIndex] = item.ToString();
                queueIndex++;
            }

            Task.Run(() => StartDownloadQueue(queueList, DownloadButton, DownloadAllButton, QueueProgressBar));
        }

        private void QueueAddButton_Click(object sender, EventArgs e)
        {
            if (OutputNameTextBox.Text == "")
                return;
            SaveQueueItem();
        }

        private void QueueRemoveButton_Click(object sender, EventArgs e)
        {
            if (QueueListBox.SelectedItems.Count == 0)
                return;

            File.Delete("MediaDownloader\\config\\queue\\" + currentQueueItem.OUTPUT_NAME + ".mdq");
            UpdateListBox(QueueListBox, "MediaDownloader\\config\\queue", false);

            if (QueueListBox.Items.Count >= 1)
                QueueListBox.SelectedIndex = 0;
        }

        private void HistoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HistoryListBox.Items.Count == 0)
                return;

            CONFIG.HISTORY_SELECTED_INDEX = HistoryListBox.SelectedIndex;
        }

        private void HistoryLoadButton_Click(object sender, EventArgs e)
        {
            if (HistoryListBox.SelectedItems.Count == 0)
                return;

            LoadQueueItem("MediaDownloader\\config\\history\\" + HistoryListBox.SelectedItem + ".mdq");
        }

        private void HistoryRefreshButton_Click(object sender, EventArgs e)
        {
            UpdateListBox(HistoryListBox, "MediaDownloader\\config\\history", true);
        }

        private void HistoryRemoveButton_Click(object sender, EventArgs e)
        {
            if (HistoryListBox.SelectedItems.Count == 0)
                return;

            File.Delete("MediaDownloader\\config\\history\\" + HistoryListBox.SelectedItem + ".mdq");
            UpdateListBox(HistoryListBox, "MediaDownloader\\config\\history", true);

            if (HistoryListBox.Items.Count == 0)
                CONFIG.HISTORY_SAVE_INDEX = 0;

            if (HistoryListBox.Items.Count >= 1)
                HistoryListBox.SelectedIndex = 0;
        }

        private void HistoryListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawListBox(HistoryListBox, e, Color.FromArgb(218, 112, 214));
        }

        private void SaveQueueItem()
        {
            WriteQueueItem(currentQueueItem, "MediaDownloader\\config\\queue\\" + currentQueueItem.OUTPUT_NAME + ".mdq");
            UpdateListBox(QueueListBox, "MediaDownloader\\config\\queue", false);
        }

        private void LoadQueueItem(string queueItemFile)
        {
            currentQueueItem = ReadQueueItem(queueItemFile);

            UrlTextBox.Text = currentQueueItem.URL;

            OutputNameTextBox.Text = currentQueueItem.OUTPUT_NAME;
            OutputLocationTextBox.Text = currentQueueItem.OUTPUT_LOCATION;

            OutputFormatComboBox.Text = currentQueueItem.OUTPUT_FORMAT;

            OutputVideoBitrateTextBox.Text = currentQueueItem.OUTPUT_BITRATE_VIDEO;
            OutputAudioBitrateTextBox.Text = currentQueueItem.OUTPUT_BITRATE_AUDIO;

            OutputResizeCheckBox.Checked = currentQueueItem.OUTPUT_ENABLE_CHANGE_RESOLUTION;
            OutputResizeWidthTextBox.Text = currentQueueItem.OUTPUT_RESOLUTION_WIDTH;
            OutputResizeHeightTextBox.Text = currentQueueItem.OUTPUT_RESOLUTION_HEIGHT;

            OutputFramerateCheckBox.Checked = currentQueueItem.OUTPUT_ENABLE_CHANGE_FRAMERATE;
            OutputFramerateTextBox.Text = currentQueueItem.OUTPUT_FRAMERATE;

            OutputTimeframeCheckBox.Checked = currentQueueItem.OUTPUT_ENABLE_CHANGE_TIMEFRAME;
            OutputTimeframeStartTextBox.Text = currentQueueItem.OUTPUT_TIMEFRAME_START;
            OutputTimeframeEndTextBox.Text = currentQueueItem.OUTPUT_TIMEFRAME_END;

            OutputYtdlpArgumentsTextBox.Text = currentQueueItem.OUTPUT_YTDLP_ARGUMENTS;
            OutputFfmpegArgumentsTextBox.Text = currentQueueItem.OUTPUT_FFMPEG_ARGUMENTS;

            OutputDisplayCheckBox.Checked = currentQueueItem.OUTPUT_ENABLE_DISPLAY;
            OutputPauseCheckBox.Checked = currentQueueItem.OUTPUT_ENABLE_PAUSE;
        }

        private void OutputChangeLocationButton_Click(object sender, EventArgs e)
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
                    OutputLocationTextBox.Text = folderPath;
                }
            }
        }

        private void OutputOpenLocationButton_Click(object sender, EventArgs e)
        {
            string downloadExtension = "";
            switch (currentQueueItem.OUTPUT_FORMAT)
            {
                case "mp4":
                    downloadExtension = ".mp4";
                    break;
                case "mp4 (nvidia)":
                    downloadExtension = ".mp4";
                    break;
                case "mp4 (amd)":
                    downloadExtension = ".mp4";
                    break;
                case "webm":
                    downloadExtension = ".webm";
                    break;
                case "avi (uncompressed)":
                    downloadExtension = ".avi";
                    break;
                case "mp3":
                    downloadExtension = ".mp3";
                    break;
                case "wav":
                    downloadExtension = ".wav";
                    break;
                case "ogg":
                    downloadExtension = ".ogg";
                    break;
                case "aac":
                    downloadExtension = ".aac";
                    break;
                case "opus":
                    downloadExtension = ".opus";
                    break;
                case "wma":
                    downloadExtension = ".wma";
                    break;
                case "flac (lossless)":
                    downloadExtension = ".flac";
                    break;
                case "m4a (lossless)":
                    downloadExtension = ".m4a";
                    break;
                case "gif":
                    downloadExtension = ".gif";
                    break;
                case "png (sequence)":
                    downloadExtension = "";
                    break;
                case "jpg (sequence)":
                    downloadExtension = "";
                    break;
            }

            string downloadLocation = currentQueueItem.OUTPUT_LOCATION == "" || currentQueueItem.OUTPUT_LOCATION == null ? "Downloads" : currentQueueItem.OUTPUT_LOCATION;
            if (File.Exists(downloadLocation + "\\" + currentQueueItem.OUTPUT_NAME + downloadExtension))
                Process.Start("explorer.exe", "/select, " + downloadLocation + "\\" + currentQueueItem.OUTPUT_NAME + downloadExtension);
            else if (Directory.Exists(downloadLocation + "\\" + currentQueueItem.OUTPUT_NAME))
                Process.Start("explorer.exe", downloadLocation + "\\" + currentQueueItem.OUTPUT_NAME);
            else
                Process.Start("explorer.exe", downloadLocation);
        }

        private void OutputClearLocationButton_Click(object sender, EventArgs e)
        {
            OutputLocationTextBox.Text = "";
        }

        private void ViewAvailableFormatsButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => StartProcess("MediaDownloader\\redist\\yt-dlp\\yt-dlp.exe", "-q --ffmpeg-location \"MediaDownloader\\redist\\ffmpeg\\ffmpeg.exe\" --list-formats " + currentQueueItem.URL, "MediaDownloader " + VERSION + "   [DEBUG  :  FORMAT LIST]", true, true));
        }

        #region ConfigUpdate
        private void UrlTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.URL = UrlTextBox.Text;
        }

        private void OutputNameTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_NAME = OutputNameTextBox.Text;
        }

        private void OutputFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (OutputFormatComboBox.Text)
            {
                case "":
                case "[Video]":
                case "[Audio]":
                case "[Image]":
                case "[Custom]":
                    DownloadButton.Enabled = false;
                    DownloadAllButton.Enabled = false;

                    OutputLocationTextBox.Enabled = false;
                    OutputLocationTextBox.Text = previousPathValue != "" ? previousPathValue : OutputLocationTextBox.Text;

                    OutputTimeframeCheckBox.Enabled = false;
                    OutputTimeframeStartTextBox.Enabled = false;
                    OutputTimeframeEndTextBox.Enabled = false;

                    OutputResizeCheckBox.Enabled = false;
                    OutputResizeWidthTextBox.Enabled = false;
                    OutputResizeHeightTextBox.Enabled = false;

                    OutputFramerateCheckBox.Enabled = false;
                    OutputFramerateTextBox.Enabled = false;

                    OutputVideoBitrateTextBox.Enabled = false;
                    OutputAudioBitrateTextBox.Enabled = false;

                    OutputYtdlpArgumentsTextBox.Enabled = false;
                    OutputFfmpegArgumentsTextBox.Enabled = false;

                    OutputDisplayCheckBox.Enabled = false;
                    OutputPauseCheckBox.Enabled = false;
                    break;

                case "mp4 (fast)":
                case "mp4":
                case "mp4 (nvidia)":
                case "mp4 (amd)":
                case "webm":
                case "avi (uncompressed)":
                    DownloadButton.Enabled = true;
                    DownloadAllButton.Enabled = true;

                    OutputLocationTextBox.Enabled = true;
                    OutputLocationTextBox.Text = previousPathValue != "" ? previousPathValue : OutputLocationTextBox.Text;

                    OutputTimeframeCheckBox.Enabled = true;

                    OutputResizeCheckBox.Enabled = true;

                    OutputFramerateCheckBox.Enabled = true;

                    OutputVideoBitrateTextBox.Enabled = true;
                    OutputAudioBitrateTextBox.Enabled = true;

                    OutputYtdlpArgumentsTextBox.Enabled = false;
                    OutputFfmpegArgumentsTextBox.Enabled = false;

                    OutputDisplayCheckBox.Enabled = true;
                    OutputPauseCheckBox.Enabled = true;
                    break;

                case "mp3":
                case "wav":
                case "ogg":
                case "aac":
                case "opus":
                case "wma":
                case "flac (lossless)":
                case "m4a (lossless)":
                    DownloadButton.Enabled = true;
                    DownloadAllButton.Enabled = true;

                    OutputLocationTextBox.Enabled = true;
                    OutputLocationTextBox.Text = previousPathValue != "" ? previousPathValue : OutputLocationTextBox.Text;

                    OutputTimeframeCheckBox.Enabled = true;

                    OutputResizeCheckBox.Checked = false;
                    OutputResizeCheckBox.Enabled = false;
                    OutputResizeWidthTextBox.Enabled = false;
                    OutputResizeHeightTextBox.Enabled = false;

                    OutputFramerateCheckBox.Checked = false;
                    OutputFramerateCheckBox.Enabled = false;
                    OutputFramerateTextBox.Enabled = false;

                    OutputVideoBitrateTextBox.Enabled = false;
                    OutputAudioBitrateTextBox.Enabled = true;

                    OutputYtdlpArgumentsTextBox.Enabled = false;
                    OutputFfmpegArgumentsTextBox.Enabled = false;

                    OutputDisplayCheckBox.Enabled = true;
                    OutputPauseCheckBox.Enabled = true;
                    break;

                case "gif":
                case "png (sequence)":
                case "jpg (sequence)":
                    DownloadButton.Enabled = true;
                    DownloadAllButton.Enabled = true;

                    OutputLocationTextBox.Enabled = true;
                    OutputLocationTextBox.Text = previousPathValue;

                    OutputTimeframeCheckBox.Enabled = true;

                    OutputResizeCheckBox.Enabled = true;

                    OutputFramerateCheckBox.Enabled = true;

                    OutputVideoBitrateTextBox.Enabled = true;
                    OutputAudioBitrateTextBox.Enabled = false;

                    OutputYtdlpArgumentsTextBox.Enabled = false;
                    OutputFfmpegArgumentsTextBox.Enabled = false;

                    OutputDisplayCheckBox.Enabled = true;
                    OutputPauseCheckBox.Enabled = true;
                    break;

                case "(custom arguments)":
                    DownloadButton.Enabled = true;
                    DownloadAllButton.Enabled = true;

                    OutputTimeframeCheckBox.Checked = false;
                    OutputTimeframeCheckBox.Enabled = false;
                    OutputTimeframeStartTextBox.Enabled = false;
                    OutputTimeframeEndTextBox.Enabled = false;

                    OutputResizeCheckBox.Checked = false;
                    OutputResizeCheckBox.Enabled = false;
                    OutputResizeWidthTextBox.Enabled = false;
                    OutputResizeHeightTextBox.Enabled = false;

                    OutputFramerateCheckBox.Checked = false;
                    OutputFramerateCheckBox.Enabled = false;
                    OutputFramerateTextBox.Enabled = false;

                    OutputVideoBitrateTextBox.Enabled = false;
                    OutputAudioBitrateTextBox.Enabled = false;

                    OutputYtdlpArgumentsTextBox.Enabled = true;
                    OutputFfmpegArgumentsTextBox.Enabled = true;

                    OutputDisplayCheckBox.Enabled = true;
                    OutputPauseCheckBox.Enabled = true;
                    break;
            }

            currentQueueItem.OUTPUT_FORMAT = OutputFormatComboBox.Text;
        }

        private void OutputLocationTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_LOCATION = OutputLocationTextBox.Text;
        }

        private void OutputVideoBitrateTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_BITRATE_VIDEO = OutputVideoBitrateTextBox.Text;
        }

        private void OutputAudioBitrateTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_BITRATE_AUDIO = OutputAudioBitrateTextBox.Text;
        }

        private void OutputResizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OutputResizeCheckBox.Checked == true)
            {
                OutputResizeWidthTextBox.Enabled = true;
                OutputResizeHeightTextBox.Enabled = true;
            }
            else
            {
                OutputResizeWidthTextBox.Enabled = false;
                OutputResizeHeightTextBox.Enabled = false;
            }

            currentQueueItem.OUTPUT_ENABLE_CHANGE_RESOLUTION = OutputResizeCheckBox.Checked;
        }

        private void OutputResizeWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_RESOLUTION_WIDTH = OutputResizeWidthTextBox.Text;
        }

        private void OutputResizeHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_RESOLUTION_HEIGHT = OutputResizeHeightTextBox.Text;
        }

        private void OutputFramerateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OutputFramerateCheckBox.Checked == true)
                OutputFramerateTextBox.Enabled = true;
            else
                OutputFramerateTextBox.Enabled = false;

            currentQueueItem.OUTPUT_ENABLE_CHANGE_FRAMERATE = OutputFramerateCheckBox.Checked;
        }

        private void OutputFramerateTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_FRAMERATE = OutputFramerateTextBox.Text;
        }

        private void OutputTimeframeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OutputTimeframeCheckBox.Checked == true)
            {
                OutputTimeframeStartTextBox.Enabled = true;
                OutputTimeframeEndTextBox.Enabled = true;
            }
            else
            {
                OutputTimeframeStartTextBox.Enabled = false;
                OutputTimeframeEndTextBox.Enabled = false;
            }

            currentQueueItem.OUTPUT_ENABLE_CHANGE_TIMEFRAME = OutputTimeframeCheckBox.Checked;
        }

        private void OutputTimeframeStartTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_TIMEFRAME_START = OutputTimeframeStartTextBox.Text;
        }

        private void OutputTimeframeEndTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_TIMEFRAME_END = OutputTimeframeEndTextBox.Text;
        }

        private void OutputYtdlpArgumentsTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_YTDLP_ARGUMENTS = OutputYtdlpArgumentsTextBox.Text;
        }

        string previousPathValue = "";
        bool ffmpegArgumentsAlreadyChanged = false;
        private void OutputFfmpegArgumentsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentQueueItem.OUTPUT_FORMAT == "(custom arguments)")
            {
                if (ffmpegArgumentsAlreadyChanged == false)
                    previousPathValue = currentQueueItem.OUTPUT_LOCATION;
                ffmpegArgumentsAlreadyChanged = true;

                if (OutputFfmpegArgumentsTextBox.Text != "")
                {
                    OutputLocationTextBox.Enabled = false;
                    OutputLocationTextBox.Text = "CONTROLLED BY FFMPEG ARGUMENTS";
                }
                else
                {
                    OutputLocationTextBox.Enabled = true;
                    OutputLocationTextBox.Text = previousPathValue;
                    ffmpegArgumentsAlreadyChanged = false;
                }
            }

            currentQueueItem.OUTPUT_FFMPEG_ARGUMENTS = OutputFfmpegArgumentsTextBox.Text;
        }

        private void OutputDisplayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OutputDisplayCheckBox.Checked == false)
            {
                OutputPauseCheckBox.Checked = false;
                OutputPauseCheckBox.Enabled = false;
            }
            else
                OutputPauseCheckBox.Enabled = true;

            currentQueueItem.OUTPUT_ENABLE_DISPLAY = OutputDisplayCheckBox.Checked;
        }

        private void OutputPauseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_ENABLE_PAUSE = OutputPauseCheckBox.Checked;
        }

        private void HistoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CONFIG.HISTORY_ENABLE = HistoryCheckBox.Checked;
        }
        #endregion

        private void MenuExpandButton_Click(object sender, EventArgs e)
        {
            if (!CONFIG.MENU_ENABLE_EXPANDED)
                ExpandMenu();
            else
                CollapseMenu();
        }

        private void ExpandMenu()
        {
            CONFIG.MENU_ENABLE_EXPANDED = true;

            MenuExpandButton.Location = new Point(662, 142);
            MenuExpandButton.Size = new Size(29, 102);
            MenuExpandButton.Text = "<<";

            QueueListBox.Visible = true;
            QueueProgressBar.Visible = true;

            DownloadAllButton.Visible = true;

            QueueAddButton.Visible = true;
            QueueRemoveButton.Visible = true;

            QueueLabel.Visible = true;
            QueueDecorationPanel.Visible = true;

            HistoryListBox.Visible = true;

            HistoryCheckBox.Visible = true;
            HistoryPanel.Visible = true;
            HistoryDecoration2Panel.Visible = true;

            HistoryLoadButton.Visible = true;
            HistoryRefreshButton.Visible = true;
            HistoryRemoveButton.Visible = true;

            HistoryLabel.Visible = true;
            HistoryDecorationPanel.Visible = true;

            Size = new Size(691, 244);

            TitlebarPanel.Size = new Size(691, 35);

            CloseButton.Location = new Point(661, 5);
            MinimizeButton.Location = new Point(637, 5);

            UpdateVersionLabel();
        }

        private void CollapseMenu()
        {
            CONFIG.MENU_ENABLE_EXPANDED = false;

            MenuExpandButton.Location = new Point(379, 37);
            MenuExpandButton.Size = new Size(29, 207);
            MenuExpandButton.Text = ">>";

            QueueListBox.Visible = false;
            QueueProgressBar.Visible = false;

            DownloadAllButton.Visible = false;

            QueueAddButton.Visible = false;
            QueueRemoveButton.Visible = false;

            QueueLabel.Visible = false;
            QueueDecorationPanel.Visible = false;

            HistoryListBox.Visible = false;

            HistoryCheckBox.Visible = false;
            HistoryPanel.Visible = false;
            HistoryDecoration2Panel.Visible = false;

            HistoryLoadButton.Visible = false;
            HistoryRefreshButton.Visible = false;
            HistoryRemoveButton.Visible = false;

            HistoryLabel.Visible = false;
            HistoryDecorationPanel.Visible = false;

            Size = new Size(408, 244);

            TitlebarPanel.Size = new Size(408, 35);

            CloseButton.Location = new Point(378, 5);
            MinimizeButton.Location = new Point(354, 5);

            UpdateVersionLabel();
        }

        private void UpdateVersionLabel()
        {
            VersionLabel.Text = VERSION;
            VersionLabel.Location = new Point(TitlebarPanel.Width - (55 + VersionLabel.Width), VersionLabel.Location.Y);
        }

        private void QueueListBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (QueueListBox.SelectedItems.Count == 0)
                return;

            if (File.Exists("MediaDownloader\\config\\queue\\" + currentQueueItem.OUTPUT_NAME + ".mdq"))
                WriteQueueItem(currentQueueItem, "MediaDownloader\\config\\queue\\" + currentQueueItem.OUTPUT_NAME + ".mdq");
        }

        private void QueueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (QueueListBox.SelectedItems.Count == 0)
                return;

            previousPathValue = "";
            CONFIG.QUEUE_SELECTED_INDEX = QueueListBox.SelectedIndex;

            LoadQueueItem("MediaDownloader\\config\\queue\\" + QueueListBox.SelectedItem + ".mdq");
        }

        private void QueueListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawListBox(QueueListBox, e, Color.FromArgb(147, 112, 219));
        }

        private void OutputYtdlpArgumentsTextBox_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/yt-dlp/yt-dlp#usage-and-options");
        }

        private void OutputFfmpegArgumentsTextBox_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://ffmpeg.org/ffmpeg.html");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (File.Exists("MediaDownloader\\config\\queue\\" + currentQueueItem.OUTPUT_NAME + ".mdq"))
                WriteQueueItem(currentQueueItem, "MediaDownloader\\config\\queue\\" + currentQueueItem.OUTPUT_NAME + ".mdq");

            WriteQueueItem(currentQueueItem, "MediaDownloader\\config\\latest.mdq");
            WriteConfig(CONFIG);

            Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void TitlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(Handle, e);
        }

        private void BannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
                Process.Start("https://github.com/o7q/MediaDownloader");
            MoveForm(Handle, e);
        }

        private void VersionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(Handle, e);
        }
    }
}