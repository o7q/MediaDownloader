using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

using MediaDownloader.Properties;
using static MediaDownloader.Tools.Forms;
using static MediaDownloader.Tools.SetupTools.Bootstrapper;

namespace MediaDownloader.Forms.BootstrapForm
{
    public partial class BootstrapForm : Form
    {
        public DialogResult Result { get; private set; }

        bool installYtdlp = false;
        bool installFfmpeg = false;

        int installIndex = 0;

        public BootstrapForm(bool installYtdlp_, bool installFfmpeg_)
        {
            InitializeComponent();

            installYtdlp = installYtdlp_;
            installFfmpeg = installFfmpeg_;
        }

        private void BootstrapForm_Load(object sender, EventArgs e)
        {
            SuccessLabel.Text = "";

            if (!installYtdlp)
            {
                YtdlpErrorPictureBox.Image = Resources.checkmark;

                YtdlpErrorLabel.Text = "(found)";
                YtdlpErrorLabel.ForeColor = Color.DarkSeaGreen;

                installIndex++;
            }
            if (!installFfmpeg)
            {
                FfmpegErrorPictureBox.Image = Resources.checkmark;

                FfmpegErrorLabel.Text = "(found)";
                FfmpegErrorLabel.ForeColor = Color.DarkSeaGreen;

                installIndex++;
            }
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            if (installIndex == 2)
            {
                Result = DialogResult.OK;
                Close();
            }
            else
            {
                if (installYtdlp)
                {
                    Task.Run(() => StartYtdlpInstall());
                }
                if (installFfmpeg)
                {
                    Task.Run(() => StartFfmpegInstall());
                }

                InstallButton.Enabled = false;
                CancelInstallButton.Enabled = false;
            }
        }

        private void StartYtdlpInstall()
        {
            YtdlpErrorPictureBox.Image = Resources.loading_icon;
            InstallYtdlp(YtdlpErrorLabel);
            YtdlpErrorPictureBox.Image = Resources.checkmark;

            installIndex++;

            if (installIndex == 2)
            {
                Invoke((MethodInvoker)delegate
                {
                    InstallButton.Text = "Continue";
                    InstallButton.Enabled = true;

                    SuccessLabel.Text = "All files downloaded successfully!";
                });
            }
        }

        private void StartFfmpegInstall()
        {
            FfmpegErrorPictureBox.Image = Resources.loading_icon;
            InstallFFmpeg(FfmpegErrorLabel);
            FfmpegErrorPictureBox.Image = Resources.checkmark;

            installIndex++;

            if (installIndex == 2)
            {
                Invoke((MethodInvoker)delegate
                {
                    InstallButton.Text = "Continue";
                    InstallButton.Enabled = true;

                    SuccessLabel.Text = "All files downloaded successfully!";
                });
            }
        }

        private void CancelInstallButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Cancel;
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Cancel;
            Close();
        }

        private void TitlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(Handle, e);
        }

        private void BannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(Handle, e);
        }
    }
}