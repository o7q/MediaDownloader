using System;
using System.Diagnostics;
using System.Windows.Forms;

using static MediaDownloader.Global;
using static MediaDownloader.Tools.Forms;
using static MediaDownloader.Updater.UpdateChecker;

namespace MediaDownloader.Forms.SettingsForm
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            EnableTrustedUrlsCheckBox.Checked = CONFIG.TRUSTED_URLS_ENABLE;
            TrustedUrlsTextBox.Text = CONFIG.TRUSTED_URLS;

            EnableUpdateNotificationsCheckBox.Checked = CONFIG.NOTIFICATIONS_ENABLE;

            EnableHistoryCheckBox.Checked = CONFIG.HISTORY_ENABLE;

            PlayCompleteSoundCheckBox.Checked = CONFIG.COMPLETE_SOUND_ENABLE;
            CustomCompleteSoundTextBox.Text = CONFIG.COMPLETE_SOUND_PATH;
        }

        private void TitlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(Handle, e);
        }

        private void BannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(Handle, e);
        }

        private void ApplySettingsButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void ApplySettings()
        {
            CONFIG.TRUSTED_URLS_ENABLE = EnableTrustedUrlsCheckBox.Checked;
            CONFIG.TRUSTED_URLS = TrustedUrlsTextBox.Text;

            CONFIG.NOTIFICATIONS_ENABLE = EnableUpdateNotificationsCheckBox.Checked;

            CONFIG.HISTORY_ENABLE = EnableHistoryCheckBox.Checked;

            CONFIG.COMPLETE_SOUND_ENABLE = PlayCompleteSoundCheckBox.Checked;
            CONFIG.COMPLETE_SOUND_PATH = CustomCompleteSoundTextBox.Text;

            Close();
        }

        private void DiscardSettingsButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RunBootstrapperButton_Click(object sender, EventArgs e)
        {
            BootstrapForm.BootstrapForm bootstrapForm = new BootstrapForm.BootstrapForm(true, true);
            bootstrapForm.ShowDialog();
        }

        private void CheckForUpdatesButton_Click(object sender, EventArgs e)
        {
            var newVersionAvailable = CheckForNewUpdate(VERSION_INTERNAL);

            if (newVersionAvailable.Item1)
            {
                CustomMessageBox.CustomMessageBox customMessageBox = new CustomMessageBox.CustomMessageBox("A new update is available! Would you like to run the updater?", "OK", true);
                customMessageBox.ShowDialog();

                if (customMessageBox.Result == DialogResult.OK)
                {
                    Process.Start("MediaDownloader\\updater\\Updater.bat");
                    ApplySettings();
                }
            }
            else
            {
                CustomMessageBox.CustomMessageBox customMessageBox = new CustomMessageBox.CustomMessageBox("You are running the latest version!", "OK", true);
                customMessageBox.ShowDialog();
            }
        }

        private void ClearHistoryButton_Click(object sender, EventArgs e)
        {
            CustomMessageBox.CustomMessageBox customMessageBox = new CustomMessageBox.CustomMessageBox("Are you sure you want to clear history? This cannot be undone!", "I AM SURE", true);
            customMessageBox.ShowDialog();

            if (customMessageBox.Result == DialogResult.OK)
            {
                HISTORY.Clear();
            }
        }

        private void ClearQueueButton_Click(object sender, EventArgs e)
        {
            CustomMessageBox.CustomMessageBox customMessageBox = new CustomMessageBox.CustomMessageBox("Are you sure you want to clear the queue? This cannot be undone!", "I AM SURE", true);
            customMessageBox.ShowDialog();

            if (customMessageBox.Result == DialogResult.OK)
            {
                QUEUE.Clear();
            }
        }

        private void CustomSoundButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Wave Files (*.wav)|*.wav";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CustomCompleteSoundTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}