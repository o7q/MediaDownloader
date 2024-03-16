namespace MediaDownloader.Setup.BootstrapForm
{
    partial class BootstrapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BootstrapForm));
            this.TitlebarPanel = new System.Windows.Forms.Panel();
            this.BannerPicture = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.BottomBarPanel = new System.Windows.Forms.Panel();
            this.SuccessLabel = new System.Windows.Forms.Label();
            this.CancelInstallButton = new System.Windows.Forms.Button();
            this.InstallButton = new System.Windows.Forms.Button();
            this.YtdlpLabel = new System.Windows.Forms.Label();
            this.FfmpegLabel = new System.Windows.Forms.Label();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.FfmpegErrorLabel = new System.Windows.Forms.Label();
            this.YtdlpErrorLabel = new System.Windows.Forms.Label();
            this.FfmpegErrorPictureBox = new System.Windows.Forms.PictureBox();
            this.YtdlpErrorPictureBox = new System.Windows.Forms.PictureBox();
            this.TitlebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerPicture)).BeginInit();
            this.BottomBarPanel.SuspendLayout();
            this.ContainerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FfmpegErrorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YtdlpErrorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlebarPanel
            // 
            this.TitlebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TitlebarPanel.Controls.Add(this.BannerPicture);
            this.TitlebarPanel.Controls.Add(this.CloseButton);
            this.TitlebarPanel.Location = new System.Drawing.Point(0, 0);
            this.TitlebarPanel.Name = "TitlebarPanel";
            this.TitlebarPanel.Size = new System.Drawing.Size(351, 22);
            this.TitlebarPanel.TabIndex = 0;
            this.TitlebarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlebarPanel_MouseDown);
            // 
            // BannerPicture
            // 
            this.BannerPicture.BackColor = System.Drawing.Color.Transparent;
            this.BannerPicture.Image = global::MediaDownloader.Properties.Resources.banner_hq;
            this.BannerPicture.Location = new System.Drawing.Point(0, 0);
            this.BannerPicture.Name = "BannerPicture";
            this.BannerPicture.Size = new System.Drawing.Size(112, 22);
            this.BannerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BannerPicture.TabIndex = 0;
            this.BannerPicture.TabStop = false;
            this.BannerPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BannerPicture_MouseDown);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CloseButton.Location = new System.Drawing.Point(329, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(22, 22);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.MessageLabel.Location = new System.Drawing.Point(4, 28);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(277, 32);
            this.MessageLabel.TabIndex = 0;
            this.MessageLabel.Text = "The following redistributables are missing.\r\nDo you want to download them automat" +
    "ically?\r\n";
            // 
            // BottomBarPanel
            // 
            this.BottomBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BottomBarPanel.Controls.Add(this.SuccessLabel);
            this.BottomBarPanel.Controls.Add(this.CancelInstallButton);
            this.BottomBarPanel.Controls.Add(this.InstallButton);
            this.BottomBarPanel.Location = new System.Drawing.Point(0, 184);
            this.BottomBarPanel.Name = "BottomBarPanel";
            this.BottomBarPanel.Size = new System.Drawing.Size(351, 41);
            this.BottomBarPanel.TabIndex = 1;
            // 
            // SuccessLabel
            // 
            this.SuccessLabel.AutoSize = true;
            this.SuccessLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.SuccessLabel.Location = new System.Drawing.Point(7, 13);
            this.SuccessLabel.Name = "SuccessLabel";
            this.SuccessLabel.Size = new System.Drawing.Size(163, 13);
            this.SuccessLabel.TabIndex = 0;
            this.SuccessLabel.Text = "All files downloaded successfully!";
            // 
            // CancelInstallButton
            // 
            this.CancelInstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.CancelInstallButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.CancelInstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelInstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelInstallButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.CancelInstallButton.Location = new System.Drawing.Point(177, 7);
            this.CancelInstallButton.Name = "CancelInstallButton";
            this.CancelInstallButton.Size = new System.Drawing.Size(79, 27);
            this.CancelInstallButton.TabIndex = 1;
            this.CancelInstallButton.Text = "Cancel";
            this.CancelInstallButton.UseVisualStyleBackColor = false;
            this.CancelInstallButton.Click += new System.EventHandler(this.CancelInstallButton_Click);
            // 
            // InstallButton
            // 
            this.InstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.InstallButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.InstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.InstallButton.Location = new System.Drawing.Point(259, 7);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(79, 27);
            this.InstallButton.TabIndex = 2;
            this.InstallButton.Text = "Yes";
            this.InstallButton.UseVisualStyleBackColor = false;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // YtdlpLabel
            // 
            this.YtdlpLabel.AutoSize = true;
            this.YtdlpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.YtdlpLabel.ForeColor = System.Drawing.Color.Silver;
            this.YtdlpLabel.Location = new System.Drawing.Point(5, 5);
            this.YtdlpLabel.Name = "YtdlpLabel";
            this.YtdlpLabel.Size = new System.Drawing.Size(40, 16);
            this.YtdlpLabel.TabIndex = 0;
            this.YtdlpLabel.Text = "yt-dlp";
            // 
            // FfmpegLabel
            // 
            this.FfmpegLabel.AutoSize = true;
            this.FfmpegLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FfmpegLabel.ForeColor = System.Drawing.Color.Silver;
            this.FfmpegLabel.Location = new System.Drawing.Point(5, 25);
            this.FfmpegLabel.Name = "FfmpegLabel";
            this.FfmpegLabel.Size = new System.Drawing.Size(48, 16);
            this.FfmpegLabel.TabIndex = 0;
            this.FfmpegLabel.Text = "ffmpeg";
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ContainerPanel.Controls.Add(this.InfoLabel);
            this.ContainerPanel.Controls.Add(this.FfmpegErrorLabel);
            this.ContainerPanel.Controls.Add(this.YtdlpErrorLabel);
            this.ContainerPanel.Controls.Add(this.FfmpegErrorPictureBox);
            this.ContainerPanel.Controls.Add(this.YtdlpErrorPictureBox);
            this.ContainerPanel.Controls.Add(this.YtdlpLabel);
            this.ContainerPanel.Controls.Add(this.FfmpegLabel);
            this.ContainerPanel.Location = new System.Drawing.Point(6, 65);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(339, 112);
            this.ContainerPanel.TabIndex = 0;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.ForeColor = System.Drawing.Color.Gray;
            this.InfoLabel.Location = new System.Drawing.Point(5, 43);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(330, 12);
            this.InfoLabel.TabIndex = 0;
            this.InfoLabel.Text = "* These files will be downloaded in a subdirectory next to MediaDownloader.exe";
            // 
            // FfmpegErrorLabel
            // 
            this.FfmpegErrorLabel.AutoSize = true;
            this.FfmpegErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FfmpegErrorLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.FfmpegErrorLabel.Location = new System.Drawing.Point(70, 25);
            this.FfmpegErrorLabel.Name = "FfmpegErrorLabel";
            this.FfmpegErrorLabel.Size = new System.Drawing.Size(58, 15);
            this.FfmpegErrorLabel.TabIndex = 0;
            this.FfmpegErrorLabel.Text = "(missing)";
            // 
            // YtdlpErrorLabel
            // 
            this.YtdlpErrorLabel.AutoSize = true;
            this.YtdlpErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YtdlpErrorLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.YtdlpErrorLabel.Location = new System.Drawing.Point(62, 5);
            this.YtdlpErrorLabel.Name = "YtdlpErrorLabel";
            this.YtdlpErrorLabel.Size = new System.Drawing.Size(58, 15);
            this.YtdlpErrorLabel.TabIndex = 0;
            this.YtdlpErrorLabel.Text = "(missing)";
            // 
            // FfmpegErrorPictureBox
            // 
            this.FfmpegErrorPictureBox.Image = global::MediaDownloader.Properties.Resources.crossmark;
            this.FfmpegErrorPictureBox.Location = new System.Drawing.Point(53, 26);
            this.FfmpegErrorPictureBox.Name = "FfmpegErrorPictureBox";
            this.FfmpegErrorPictureBox.Size = new System.Drawing.Size(17, 16);
            this.FfmpegErrorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FfmpegErrorPictureBox.TabIndex = 0;
            this.FfmpegErrorPictureBox.TabStop = false;
            // 
            // YtdlpErrorPictureBox
            // 
            this.YtdlpErrorPictureBox.Image = global::MediaDownloader.Properties.Resources.crossmark;
            this.YtdlpErrorPictureBox.Location = new System.Drawing.Point(45, 6);
            this.YtdlpErrorPictureBox.Name = "YtdlpErrorPictureBox";
            this.YtdlpErrorPictureBox.Size = new System.Drawing.Size(17, 16);
            this.YtdlpErrorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.YtdlpErrorPictureBox.TabIndex = 0;
            this.YtdlpErrorPictureBox.TabStop = false;
            // 
            // BootstrapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(351, 225);
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.TitlebarPanel);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.BottomBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BootstrapForm";
            this.Text = "MediaDownloader Setup";
            this.Load += new System.EventHandler(this.BootstrapForm_Load);
            this.TitlebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BannerPicture)).EndInit();
            this.BottomBarPanel.ResumeLayout(false);
            this.BottomBarPanel.PerformLayout();
            this.ContainerPanel.ResumeLayout(false);
            this.ContainerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FfmpegErrorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YtdlpErrorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TitlebarPanel;
        private System.Windows.Forms.PictureBox BannerPicture;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Panel BottomBarPanel;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.Button CancelInstallButton;
        private System.Windows.Forms.Label YtdlpLabel;
        private System.Windows.Forms.Label FfmpegLabel;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.PictureBox YtdlpErrorPictureBox;
        private System.Windows.Forms.PictureBox FfmpegErrorPictureBox;
        private System.Windows.Forms.Label YtdlpErrorLabel;
        private System.Windows.Forms.Label FfmpegErrorLabel;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label SuccessLabel;
    }
}