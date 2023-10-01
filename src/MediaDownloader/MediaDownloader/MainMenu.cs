using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Diagnostics;
using MediaDownloader.Tools.CustomMessageBox;
using static MediaDownloader.Global;
using static MediaDownloader.Data.Config.ConfigManager;
using static MediaDownloader.Data.QueueItem.QueueItemManager;
using static MediaDownloader.Data.QueueItem.QueueItemStructure;
using static MediaDownloader.Tools.Shell;
using static MediaDownloader.Tools.Forms;
using static MediaDownloader.Tools.FolderCompressor;
using static MediaDownloader.Media.Downloaders.Queuer;
using static MediaDownloader.Media.Downloaders.BulkQueuer;
using static MediaDownloader.Updater.UpdateChecker;
using static MediaDownloader.Updater.ResourceReader;

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
            UpdateListBox(QueueListBox, "MediaDownloader\\config\\queue_temp", false);
            UpdateNumericalListBox(HistoryListBox, "MediaDownloader\\config\\history_temp");

            UpdateVersionLabel();

            if (File.Exists("MediaDownloader\\config\\config.cfg"))
            {
                if (QueueListBox.Items.Count == 0)
                {
                    if (File.Exists("MediaDownloader\\config\\latest.mdq"))
                        LoadQueueItem("MediaDownloader\\config\\latest.mdq");
                }
                else
                    QueueListBox.SelectedIndex = CONFIG.QUEUE_SELECTED_INDEX;

                HistoryCheckBox.Checked = CONFIG.HISTORY_ENABLE;
                if (HistoryListBox.Items.Count != 0)
                    HistoryListBox.SelectedIndex = CONFIG.HISTORY_SELECTED_INDEX;

                if (CONFIG.MENU_EXPANDED_ENABLE)
                    ExpandMenu();
                else
                    CollapseMenu();
            }
            else
            {
                OutputNameAutoCheckBox.Checked = true;

                OutputTimeframeStartTextBox.Text = "0:00";
                OutputTimeframeEndTextBox.Text = "0:10";

                OutputResizeWidthTextBox.Text = "1920";
                OutputResizeHeightTextBox.Text = "1080";

                OutputFramerateTextBox.Text = "60";

                OutputVideoBitrateTextBox.Text = "100M";
                OutputAudioBitrateTextBox.Text = "320K";

                OutputFormatComboBox.SelectedIndex = 2;

                OutputDisplayCheckBox.Checked = true;
                HistoryCheckBox.Checked = true;
                CollapseMenu();
            }

            // update check
            var newVersionAvailable = CheckForNewUpdate(VERSION_INTERNAL);
            if (newVersionAvailable.Item1 && CONFIG.NOTIFICATIONS_ENABLE && !VERSION_INTERNAL.Contains("dev"))
            {
                VERSION_REMOTE = newVersionAvailable.Item2;
                NotificationPictureBox.Visible = true;
                NotificationLabel.Visible = true;
            }

            #region loadTooltips
            // bind tooltips
            string[] tooltipMap = {
                "BannerPicture", "MediaDownloader by o7q",
                "NotificationPictureBox", "Update available",
                "NotificationLabel", "Update available",
                "VersionLabel", "Version " + VERSION,

                "MinimizeButton", "Minimize",
                "CloseButton", "Close",

                "UrlTextBox", "URL to be downloaded",
                "OutputPlaylistCheckBox", "Enable playlist mode",

                "OutputNameTextBox", "Name for the download",
                "OutputNameAutoCheckBox", "Enable auto naming",

                "OutputFormatComboBox", "Media format for download",

                "ViewAvailableFormatsButton", "Display all the available media formats found on the server for the specified URL",

                "OutputTimeframeCheckBox", "Trim the download to a specific length with a start and end timestamp - Examples: \"0:00 - 0:10\" | \"1:25 - 2:30\" | \"2:30:40 - 3:05:15\"",
                "OutputTimeframeStartTextBox", "Trim start time (leave blank to trim from the start)",
                "OutputTimeframeEndTextBox", "Trim end time (leave blank to trim until the end)",
                "OutputTimeframeTrimFromStart", "Trim from the start",
                "OutputTimeframeTrimToEnd", "Trim to the end",

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

                "ResetSettingsButton", "Reset each setting to their default values on the current window",

                "MenuExpandButton", "Expand/Collapse Menu",

                "QueueListBox", "List of queued downloads",
                "QueueAddButton", "Add an item to the queue",
                "QueueRemoveButton", "Remove the selected item from the queue",
                "DownloadAllButton", "Download all items in the queue",

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
            if (ModifierKeys == Keys.Control || ModifierKeys == Keys.Shift)
            {
                IS_DOWNLOADING = false;
                ChangeDownloadButtonColors(false, DownloadButton, DownloadAllButton);
                return;
            }

            bool containsTrustedUrl = CONFIG.TRUSTED_URLS_ENABLE ? false : true;
            if (currentQueueItem.URL != null && CONFIG.TRUSTED_URLS_ENABLE)
            {
                string[] trustedUrls = CONFIG.TRUSTED_URLS.Split(',');
                for (int i = 0; i < trustedUrls.Length; i++)
                {
                    if (currentQueueItem.URL.IndexOf(trustedUrls[i], StringComparison.OrdinalIgnoreCase) >= 0)
                        containsTrustedUrl = true;
                }
            }

            if (IS_DOWNLOADING || currentQueueItem.URL == "" || currentQueueItem.URL == null || !containsTrustedUrl)
                return;

            Task.Run(() => StartDownload(currentQueueItem, OutputNameTextBox, DownloadButton, DownloadAllButton));
        }

        private void DownloadAllButton_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control || ModifierKeys == Keys.Shift)
            {
                IS_DOWNLOADING = false;
                ChangeDownloadButtonColors(false, DownloadButton, DownloadAllButton);
                return;
            }

            if (IS_DOWNLOADING || QueueListBox.Items.Count == 0)
                return;

            string[] queueList = new string[QueueListBox.Items.Count];
            int queueIndex = 0;
            foreach (string item in QueueListBox.Items)
            {
                queueList[queueIndex] = item.ToString();
                queueIndex++;
            }

            Task.Run(() => StartDownloadQueue(queueList, DownloadButton, DownloadAllButton, QueueProgressBarPanel, QueueProgressLabel));
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

            File.Delete("MediaDownloader\\config\\queue_temp\\" + currentQueueItem.OUTPUT_NAME + ".mdq");
            UpdateListBox(QueueListBox, "MediaDownloader\\config\\queue_temp", false);

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

            LoadQueueItem("MediaDownloader\\config\\history_temp\\" + HistoryListBox.SelectedItem + ".mdq");
        }

        private void HistoryRefreshButton_Click(object sender, EventArgs e)
        {
            UpdateNumericalListBox(HistoryListBox, "MediaDownloader\\config\\history_temp");
        }

        private void HistoryRemoveButton_Click(object sender, EventArgs e)
        {
            if (HistoryListBox.SelectedItems.Count == 0)
                return;

            File.Delete("MediaDownloader\\config\\history_temp\\" + HistoryListBox.SelectedItem + ".mdq");
            UpdateNumericalListBox(HistoryListBox, "MediaDownloader\\config\\history_temp");

            if (HistoryListBox.Items.Count == 0)
                CONFIG.HISTORY_SAVE_INDEX = 1;

            if (HistoryListBox.Items.Count >= 1)
                HistoryListBox.SelectedIndex = 0;
        }

        private void HistoryListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawListBox(HistoryListBox, e, Color.FromArgb(218, 112, 214));
        }

        private void SaveQueueItem()
        {
            WriteQueueItem(currentQueueItem, "MediaDownloader\\config\\queue_temp\\" + currentQueueItem.OUTPUT_NAME + ".mdq");
            UpdateListBox(QueueListBox, "MediaDownloader\\config\\queue_temp", false);
        }

        private void LoadQueueItem(string queueItemFile)
        {
            currentQueueItem = ReadQueueItem(queueItemFile);

            UrlTextBox.Text = currentQueueItem.URL;
            OutputPlaylistCheckBox.Checked = currentQueueItem.OUTPUT_PLAYLIST_ENABLE;

            OutputNameTextBox.Text = currentQueueItem.OUTPUT_NAME;
            OutputNameAutoCheckBox.Checked = currentQueueItem.OUTPUT_NAME_AUTO_ENABLE;

            OutputLocationTextBox.Text = currentQueueItem.OUTPUT_LOCATION;

            OutputFormatComboBox.Text = currentQueueItem.OUTPUT_FORMAT;

            OutputTimeframeCheckBox.Checked = currentQueueItem.OUTPUT_CHANGE_TIMEFRAME_ENABLE;
            OutputTimeframeStartTextBox.Text = currentQueueItem.OUTPUT_TIMEFRAME_START;
            OutputTimeframeEndTextBox.Text = currentQueueItem.OUTPUT_TIMEFRAME_END;
            OutputTimeframeTrimFromStart.Checked = currentQueueItem.OUTPUT_TIMEFRAME_TRIM_FROM_START_ENABLE;
            OutputTimeframeTrimToEnd.Checked = currentQueueItem.OUTPUT_TIMEFRAME_TRIM_TO_END_ENABLE;

            OutputVideoBitrateTextBox.Text = currentQueueItem.OUTPUT_BITRATE_VIDEO;
            OutputAudioBitrateTextBox.Text = currentQueueItem.OUTPUT_BITRATE_AUDIO;

            OutputResizeCheckBox.Checked = currentQueueItem.OUTPUT_CHANGE_RESOLUTION_ENABLE;
            OutputResizeWidthTextBox.Text = currentQueueItem.OUTPUT_RESOLUTION_WIDTH;
            OutputResizeHeightTextBox.Text = currentQueueItem.OUTPUT_RESOLUTION_HEIGHT;

            OutputFramerateCheckBox.Checked = currentQueueItem.OUTPUT_CHANGE_FRAMERATE_ENABLE;
            OutputFramerateTextBox.Text = currentQueueItem.OUTPUT_FRAMERATE;

            OutputYtdlpArgumentsTextBox.Text = currentQueueItem.OUTPUT_YTDLP_ARGUMENTS;
            OutputFfmpegArgumentsTextBox.Text = currentQueueItem.OUTPUT_FFMPEG_ARGUMENTS;

            OutputDisplayCheckBox.Checked = currentQueueItem.OUTPUT_DISPLAY_ENABLE;
            OutputPauseCheckBox.Checked = currentQueueItem.OUTPUT_PAUSE_ENABLE;
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
                case "mp4 (fast)":
                    downloadExtension = ".mp4";
                    break;
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
                case "png (thumbnail)":
                    downloadExtension = ".png";
                    break;
                case "jpg (thumbnail)":
                    downloadExtension = ".jpg";
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

        private void UrlTextBox_DoubleClick(object sender, EventArgs e)
        {
            if (UrlTextBox.Text != "")
                Process.Start(UrlTextBox.Text);
        }

        #region ConfigUpdate
        private void UrlTextBox_TextChanged(object sender, EventArgs e)
        {
            string[] playlistKeywords =
            {
                "playlist",
                "album"
            };

            bool containsKeyword = false;

            for (int i = 0; i < playlistKeywords.Length; i++)
            {
                if (UrlTextBox.Text.IndexOf(playlistKeywords[i], StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    containsKeyword = true;

                    OutputPlaylistCheckBox.Checked = true;

                    UrlLabel.Text = "URL (playlist detected)";
                    UrlLabel.Refresh();
                }
            }

            if (containsKeyword == false)
            {
                OutputPlaylistCheckBox.Checked = false;

                UrlLabel.Text = "URL";
                UrlLabel.Refresh();
            }

            currentQueueItem.URL = UrlTextBox.Text;
        }

        private void OutputNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (OutputNameTextBox.Text == "" && OutputPlaylistCheckBox.Checked == false)
                OutputNameAutoCheckBox.Checked = true;
            else
                if (OutputPlaylistCheckBox.Checked == false)
                    OutputNameAutoCheckBox.Checked = false;

            currentQueueItem.OUTPUT_NAME = OutputNameTextBox.Text;
        }

        private void OutputPlaylistCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OutputPlaylistCheckBox.Checked == true)
            {
                OutputNameAutoCheckBox.Checked = false;
                OutputNameAutoCheckBox.Enabled = false;

                OutputNameLabel.Text = "Folder Name";
            }
            else
            {
                OutputNameAutoCheckBox.Enabled = true;

                if (OutputNameTextBox.Text == "")
                    OutputNameAutoCheckBox.Checked = true;

                OutputNameLabel.Text = "Name";
            }

            currentQueueItem.OUTPUT_PLAYLIST_ENABLE = OutputPlaylistCheckBox.Checked;
        }

        string previousName = "";
        private void OutputNameAutoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OutputNameAutoCheckBox.Checked == true)
            {
                previousName = OutputNameTextBox.Text;
                OutputNameTextBox.Text = "";
            }
            else
                if (OutputNameTextBox.Text == "")
                OutputNameTextBox.Text = previousName;

            if (OutputNameAutoCheckBox.Checked == false && OutputNameTextBox.Text == "" && OutputPlaylistCheckBox.Checked == false)
                OutputNameAutoCheckBox.Checked = true;

            currentQueueItem.OUTPUT_NAME_AUTO_ENABLE = OutputNameAutoCheckBox.Checked;
        }

        int previousFormatSelectedIndex = 1;
        private void OutputFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (OutputFormatComboBox.Text)
            {
                case "mp4 (fast)":
                    OutputTimeframeCheckBox.Enabled = true;

                    OutputResizeCheckBox.Checked = false;
                    OutputResizeCheckBox.Enabled = false;
                    OutputResizeWidthTextBox.Enabled = false;
                    OutputResizeHeightTextBox.Enabled = false;

                    OutputFramerateCheckBox.Checked = false;
                    OutputFramerateCheckBox.Enabled = false;
                    OutputFramerateTextBox.Enabled = false;

                    OutputVideoBitrateTextBox.Enabled = false;
                    OutputAudioBitrateTextBox.Enabled = false;

                    OutputYtdlpArgumentsTextBox.Enabled = false;
                    OutputFfmpegArgumentsTextBox.Enabled = false;
                    break;

                case "mp4":
                case "mp4 (nvidia)":
                case "mp4 (amd)":
                case "webm":
                case "avi (uncompressed)":
                    OutputLocationTextBox.Enabled = true;
                    OutputLocationTextBox.Text = previousPathValue != "" ? previousPathValue : OutputLocationTextBox.Text;

                    OutputTimeframeCheckBox.Enabled = true;

                    OutputResizeCheckBox.Enabled = true;

                    OutputFramerateCheckBox.Enabled = true;

                    OutputVideoBitrateTextBox.Enabled = true;
                    OutputAudioBitrateTextBox.Enabled = true;

                    OutputYtdlpArgumentsTextBox.Enabled = false;
                    OutputFfmpegArgumentsTextBox.Enabled = false;
                    break;

                case "mp3":
                case "wav":
                case "ogg":
                case "aac":
                case "opus":
                case "wma":
                case "flac (lossless)":
                case "m4a (lossless)":
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
                    break;

                case "gif":
                case "png (sequence)":
                case "jpg (sequence)":
                    OutputLocationTextBox.Enabled = true;
                    OutputLocationTextBox.Text = previousPathValue;

                    OutputTimeframeCheckBox.Enabled = true;

                    OutputResizeCheckBox.Enabled = true;

                    OutputFramerateCheckBox.Enabled = true;

                    OutputVideoBitrateTextBox.Enabled = true;
                    OutputAudioBitrateTextBox.Enabled = false;

                    OutputYtdlpArgumentsTextBox.Enabled = false;
                    OutputFfmpegArgumentsTextBox.Enabled = false;
                    break;

                case "png (thumbnail)":
                case "jpg (thumbnail)":
                    OutputTimeframeCheckBox.Checked = false;
                    OutputTimeframeCheckBox.Enabled = false;
                    OutputTimeframeStartTextBox.Enabled = false;
                    OutputTimeframeEndTextBox.Enabled = false;
                    OutputTimeframeTrimFromStart.Checked = false;
                    OutputTimeframeTrimFromStart.Enabled = false;
                    OutputTimeframeTrimToEnd.Checked = false;
                    OutputTimeframeTrimToEnd.Enabled = false;

                    OutputResizeCheckBox.Enabled = true;

                    OutputFramerateCheckBox.Checked = false;
                    OutputFramerateCheckBox.Enabled = false;
                    OutputFramerateTextBox.Enabled = false;

                    OutputVideoBitrateTextBox.Enabled = false;
                    OutputAudioBitrateTextBox.Enabled = false;

                    OutputYtdlpArgumentsTextBox.Enabled = false;
                    OutputFfmpegArgumentsTextBox.Enabled = false;
                    break;

                case "(custom arguments)":
                    OutputTimeframeCheckBox.Checked = false;
                    OutputTimeframeCheckBox.Enabled = false;
                    OutputTimeframeStartTextBox.Enabled = false;
                    OutputTimeframeEndTextBox.Enabled = false;
                    OutputTimeframeTrimFromStart.Checked = false;
                    OutputTimeframeTrimFromStart.Enabled = false;
                    OutputTimeframeTrimToEnd.Checked = false;
                    OutputTimeframeTrimToEnd.Enabled = false;

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
                    break;

                default:
                    OutputFormatComboBox.SelectedIndex = previousFormatSelectedIndex;
                    break;
            }
            previousFormatSelectedIndex = OutputFormatComboBox.SelectedIndex;

            currentQueueItem.OUTPUT_FORMAT = OutputFormatComboBox.Text;
        }

        private void OutputTimeframeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OutputTimeframeCheckBox.Checked == true)
            {
                if (OutputTimeframeTrimFromStart.Checked == false)
                    OutputTimeframeStartTextBox.Enabled = true;
                if (OutputTimeframeTrimToEnd.Checked == false)
                    OutputTimeframeEndTextBox.Enabled = true;
                OutputTimeframeTrimFromStart.Enabled = true;
                OutputTimeframeTrimToEnd.Enabled = true;
            }
            else
            {
                OutputTimeframeStartTextBox.Enabled = false;
                OutputTimeframeEndTextBox.Enabled = false;
                OutputTimeframeTrimFromStart.Enabled = false;
                OutputTimeframeTrimToEnd.Enabled = false;
            }

            currentQueueItem.OUTPUT_CHANGE_TIMEFRAME_ENABLE = OutputTimeframeCheckBox.Checked;
        }

        private void OutputTimeframeStartTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_TIMEFRAME_START = OutputTimeframeStartTextBox.Text;
        }

        private void OutputTimeframeEndTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_TIMEFRAME_END = OutputTimeframeEndTextBox.Text;
        }

        private void OutputTimeframeTrimFromStart_CheckedChanged(object sender, EventArgs e)
        {
            OutputTimeframeStartTextBox.Enabled = !OutputTimeframeTrimFromStart.Checked;

            currentQueueItem.OUTPUT_TIMEFRAME_TRIM_FROM_START_ENABLE = OutputTimeframeTrimFromStart.Checked;
        }

        private void OutputTimeframeTrimToEnd_CheckedChanged(object sender, EventArgs e)
        {
            OutputTimeframeEndTextBox.Enabled = !OutputTimeframeTrimToEnd.Checked;

            currentQueueItem.OUTPUT_TIMEFRAME_TRIM_TO_END_ENABLE = OutputTimeframeTrimToEnd.Checked;
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

            currentQueueItem.OUTPUT_CHANGE_RESOLUTION_ENABLE = OutputResizeCheckBox.Checked;
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

            currentQueueItem.OUTPUT_CHANGE_FRAMERATE_ENABLE = OutputFramerateCheckBox.Checked;
        }

        private void OutputFramerateTextBox_TextChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_FRAMERATE = OutputFramerateTextBox.Text;
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

            if (OutputLocationTextBox.Text == "CONTROLLED BY FFMPEG ARGUMENTS" && OutputLocationTextBox.Enabled == true)
                OutputLocationTextBox.Text = "";

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

            currentQueueItem.OUTPUT_DISPLAY_ENABLE = OutputDisplayCheckBox.Checked;
        }

        private void OutputPauseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            currentQueueItem.OUTPUT_PAUSE_ENABLE = OutputPauseCheckBox.Checked;
        }

        private void ResetSettingsButton_Click(object sender, EventArgs e)
        {
            UrlTextBox.Text = "";
            OutputNameTextBox.Text = "";
            OutputLocationTextBox.Text = "";
            OutputFormatComboBox.Text = "mp4";
            OutputTimeframeCheckBox.Checked = false;
            OutputTimeframeStartTextBox.Text = "0:00";
            OutputTimeframeEndTextBox.Text = "0:10";
            OutputTimeframeTrimFromStart.Checked = false;
            OutputTimeframeTrimFromStart.Enabled = false;
            OutputTimeframeTrimToEnd.Checked = false;
            OutputTimeframeTrimToEnd.Enabled = false;
            OutputResizeCheckBox.Checked = false;
            OutputResizeWidthTextBox.Text = "1920";
            OutputResizeHeightTextBox.Text = "1080";
            OutputFramerateCheckBox.Checked = false;
            OutputFramerateTextBox.Text = "60";
            OutputVideoBitrateTextBox.Text = "100M";
            OutputAudioBitrateTextBox.Text = "320K";
            OutputYtdlpArgumentsTextBox.Text = "";
            OutputFfmpegArgumentsTextBox.Text = "";
            OutputDisplayCheckBox.Checked = true;
            OutputPauseCheckBox.Checked = false;
        }

        private void HistoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CONFIG.HISTORY_ENABLE = HistoryCheckBox.Checked;
        }
        #endregion

        private void MenuExpandButton_Click(object sender, EventArgs e)
        {
            if (!CONFIG.MENU_EXPANDED_ENABLE)
                ExpandMenu();
            else
                CollapseMenu();
        }

        private void ExpandMenu()
        {
            CONFIG.MENU_EXPANDED_ENABLE = true;

            MenuExpandButton.Location = new Point(662, 142);
            MenuExpandButton.Size = new Size(29, 102);
            MenuExpandButton.Text = "<<";

            QueueLabel.Visible = true;
            QueueDecorationPanel.Visible = true;

            QueueListBox.Visible = true;

            DownloadAllButton.Visible = true;

            QueueProgressLabel.Visible = true;
            QueueProgressBarPanel.Visible = true;
            QueueProgressPanel.Visible = true;
            QueueProgressDecorationPanel.Visible = true;

            QueueAddButton.Visible = true;
            QueueRemoveButton.Visible = true;

            HistoryLabel.Visible = true;
            HistoryDecorationPanel.Visible = true;

            HistoryListBox.Visible = true;

            HistoryCheckBox.Visible = true;
            HistoryPanel.Visible = true;
            HistoryDecoration2Panel.Visible = true;

            HistoryLoadButton.Visible = true;
            HistoryRefreshButton.Visible = true;
            HistoryRemoveButton.Visible = true;

            Size = new Size(691, 244);

            TitlebarPanel.Size = new Size(691, 35);

            CloseButton.Location = new Point(661, 5);
            MinimizeButton.Location = new Point(637, 5);

            UpdateVersionLabel();
        }

        private void CollapseMenu()
        {
            CONFIG.MENU_EXPANDED_ENABLE = false;

            MenuExpandButton.Location = new Point(379, 37);
            MenuExpandButton.Size = new Size(29, 207);
            MenuExpandButton.Text = ">>";

            QueueLabel.Visible = false;
            QueueDecorationPanel.Visible = false;

            QueueListBox.Visible = true;

            DownloadAllButton.Visible = false;

            QueueProgressLabel.Visible = false;
            QueueProgressBarPanel.Visible = false;
            QueueProgressPanel.Visible = false;
            QueueProgressDecorationPanel.Visible = false;

            QueueAddButton.Visible = false;
            QueueRemoveButton.Visible = false;

            HistoryLabel.Visible = false;
            HistoryDecorationPanel.Visible = false;

            HistoryListBox.Visible = false;

            HistoryCheckBox.Visible = false;
            HistoryPanel.Visible = false;
            HistoryDecoration2Panel.Visible = false;

            HistoryLoadButton.Visible = false;
            HistoryRefreshButton.Visible = false;
            HistoryRemoveButton.Visible = false;

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

            if (File.Exists("MediaDownloader\\config\\queue_temp\\" + currentQueueItem.OUTPUT_NAME + ".mdq"))
                WriteQueueItem(currentQueueItem, "MediaDownloader\\config\\queue_temp\\" + currentQueueItem.OUTPUT_NAME + ".mdq");
        }

        private void QueueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (QueueListBox.SelectedItems.Count == 0)
                return;

            previousPathValue = "";
            CONFIG.QUEUE_SELECTED_INDEX = QueueListBox.SelectedIndex;

            LoadQueueItem("MediaDownloader\\config\\queue_temp\\" + QueueListBox.SelectedItem + ".mdq");
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
            CloseProgram();
        }

        private void CloseProgram()
        {
            if (File.Exists("MediaDownloader\\config\\queue_temp\\" + currentQueueItem.OUTPUT_NAME + ".mdq"))
                WriteQueueItem(currentQueueItem, "MediaDownloader\\config\\queue_temp\\" + currentQueueItem.OUTPUT_NAME + ".mdq");

            WriteQueueItem(currentQueueItem, "MediaDownloader\\config\\latest.mdq");
            WriteConfig(CONFIG, "MediaDownloader\\config\\config.cfg");

            CompressFolder("MediaDownloader\\config\\queue_temp", "MediaDownloader\\config\\queue.pack");
            CompressFolder("MediaDownloader\\config\\history_temp", "MediaDownloader\\config\\history.pack");

            Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
                Process.Start("https://github.com/o7q/MediaDownloader");
            MoveForm(Handle, e);
        }

        private void TitlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(Handle, e);
        }

        private void VersionLabel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(Handle, e);
        }

        private void NotificationPictureBox_Click(object sender, EventArgs e)
        {
            RunUpdateDialog();
        }

        private void NotificationLabel_Click(object sender, EventArgs e)
        {
            RunUpdateDialog();
        }

        private void RunUpdateDialog()
        {
            string changelog = ReadRemoteResource("https://raw.githubusercontent.com/o7q/MediaDownloader/main/remote/changelog");

            CustomMessageBox customMessageBox = new CustomMessageBox("A newer version of MediaDownloader is available! (" + VERSION_REMOTE + ")\n\nChangelog:\n" + changelog + "\n\nWould you like to download/install it now?\n\nPress OK to continue\nPress CLOSE to cancel\n\n(you can disable this notification in the config)", "OK", true);
            customMessageBox.ShowDialog();

            if (customMessageBox.Result == DialogResult.OK)
            {
                Process.Start("MediaDownloader\\updater\\Updater.bat");
                CloseProgram();
            }
        }
    }
}