namespace MediaDownloader.Forms.SettingsForm
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.TitlebarPanel = new System.Windows.Forms.Panel();
            this.BannerPicture = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.HistorySettingsPanel = new System.Windows.Forms.Panel();
            this.ClearHistoryButton = new System.Windows.Forms.Button();
            this.HistorySettingsLabel = new System.Windows.Forms.Label();
            this.EnableHistoryCheckBox = new System.Windows.Forms.CheckBox();
            this.QueueSettingsPanel = new System.Windows.Forms.Panel();
            this.ClearQueueButton = new System.Windows.Forms.Button();
            this.QueueSettings = new System.Windows.Forms.Label();
            this.UrlSettingsPanel = new System.Windows.Forms.Panel();
            this.TrustedUrlsLabel = new System.Windows.Forms.Label();
            this.TrustedUrlsTextBox = new System.Windows.Forms.TextBox();
            this.UrlSettingsLabel = new System.Windows.Forms.Label();
            this.EnableTrustedUrlsCheckBox = new System.Windows.Forms.CheckBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.InternalVersionLabel = new System.Windows.Forms.Label();
            this.UpdateSettingsLabel = new System.Windows.Forms.Label();
            this.CheckForUpdatesButton = new System.Windows.Forms.Button();
            this.UpdateSettingsButton = new System.Windows.Forms.Panel();
            this.RunBootstrapperButton = new System.Windows.Forms.Button();
            this.EnableUpdateNotificationsCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplySettingsButton = new System.Windows.Forms.Button();
            this.DiscardSettingsButton = new System.Windows.Forms.Button();
            this.SoundSettingsPanel = new System.Windows.Forms.Panel();
            this.CustomSoundLabel = new System.Windows.Forms.Label();
            this.CustomCompleteSoundTextBox = new System.Windows.Forms.TextBox();
            this.CustomSoundButton = new System.Windows.Forms.Button();
            this.SoundSettingsLabel = new System.Windows.Forms.Label();
            this.PlayCompleteSoundCheckBox = new System.Windows.Forms.CheckBox();
            this.TitlebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerPicture)).BeginInit();
            this.HistorySettingsPanel.SuspendLayout();
            this.QueueSettingsPanel.SuspendLayout();
            this.UrlSettingsPanel.SuspendLayout();
            this.UpdateSettingsButton.SuspendLayout();
            this.SoundSettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlebarPanel
            // 
            this.TitlebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TitlebarPanel.Controls.Add(this.BannerPicture);
            this.TitlebarPanel.Controls.Add(this.CloseButton);
            this.TitlebarPanel.Location = new System.Drawing.Point(0, 0);
            this.TitlebarPanel.Name = "TitlebarPanel";
            this.TitlebarPanel.Size = new System.Drawing.Size(287, 22);
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
            this.CloseButton.Location = new System.Drawing.Point(265, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(22, 22);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HistorySettingsPanel
            // 
            this.HistorySettingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.HistorySettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HistorySettingsPanel.Controls.Add(this.ClearHistoryButton);
            this.HistorySettingsPanel.Controls.Add(this.HistorySettingsLabel);
            this.HistorySettingsPanel.Controls.Add(this.EnableHistoryCheckBox);
            this.HistorySettingsPanel.Location = new System.Drawing.Point(159, 29);
            this.HistorySettingsPanel.Name = "HistorySettingsPanel";
            this.HistorySettingsPanel.Size = new System.Drawing.Size(123, 70);
            this.HistorySettingsPanel.TabIndex = 9;
            // 
            // ClearHistoryButton
            // 
            this.ClearHistoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.ClearHistoryButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.ClearHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearHistoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearHistoryButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ClearHistoryButton.Location = new System.Drawing.Point(6, 39);
            this.ClearHistoryButton.Name = "ClearHistoryButton";
            this.ClearHistoryButton.Size = new System.Drawing.Size(70, 21);
            this.ClearHistoryButton.TabIndex = 10;
            this.ClearHistoryButton.Text = "Clear History";
            this.ClearHistoryButton.UseVisualStyleBackColor = false;
            this.ClearHistoryButton.Click += new System.EventHandler(this.ClearHistoryButton_Click);
            // 
            // HistorySettingsLabel
            // 
            this.HistorySettingsLabel.AutoSize = true;
            this.HistorySettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistorySettingsLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.HistorySettingsLabel.Location = new System.Drawing.Point(2, 3);
            this.HistorySettingsLabel.Name = "HistorySettingsLabel";
            this.HistorySettingsLabel.Size = new System.Drawing.Size(116, 16);
            this.HistorySettingsLabel.TabIndex = 0;
            this.HistorySettingsLabel.Text = "History Settings";
            // 
            // EnableHistoryCheckBox
            // 
            this.EnableHistoryCheckBox.AutoSize = true;
            this.EnableHistoryCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableHistoryCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.EnableHistoryCheckBox.Location = new System.Drawing.Point(5, 20);
            this.EnableHistoryCheckBox.Name = "EnableHistoryCheckBox";
            this.EnableHistoryCheckBox.Size = new System.Drawing.Size(105, 19);
            this.EnableHistoryCheckBox.TabIndex = 9;
            this.EnableHistoryCheckBox.Text = "Enable History";
            this.EnableHistoryCheckBox.UseVisualStyleBackColor = true;
            // 
            // QueueSettingsPanel
            // 
            this.QueueSettingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.QueueSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QueueSettingsPanel.Controls.Add(this.ClearQueueButton);
            this.QueueSettingsPanel.Controls.Add(this.QueueSettings);
            this.QueueSettingsPanel.Location = new System.Drawing.Point(159, 104);
            this.QueueSettingsPanel.Name = "QueueSettingsPanel";
            this.QueueSettingsPanel.Size = new System.Drawing.Size(123, 52);
            this.QueueSettingsPanel.TabIndex = 11;
            // 
            // ClearQueueButton
            // 
            this.ClearQueueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.ClearQueueButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.ClearQueueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearQueueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearQueueButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ClearQueueButton.Location = new System.Drawing.Point(6, 23);
            this.ClearQueueButton.Name = "ClearQueueButton";
            this.ClearQueueButton.Size = new System.Drawing.Size(70, 21);
            this.ClearQueueButton.TabIndex = 11;
            this.ClearQueueButton.Text = "Clear Queue";
            this.ClearQueueButton.UseVisualStyleBackColor = false;
            this.ClearQueueButton.Click += new System.EventHandler(this.ClearQueueButton_Click);
            // 
            // QueueSettings
            // 
            this.QueueSettings.AutoSize = true;
            this.QueueSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueueSettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.QueueSettings.Location = new System.Drawing.Point(2, 3);
            this.QueueSettings.Name = "QueueSettings";
            this.QueueSettings.Size = new System.Drawing.Size(112, 16);
            this.QueueSettings.TabIndex = 0;
            this.QueueSettings.Text = "Queue Settings";
            // 
            // UrlSettingsPanel
            // 
            this.UrlSettingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.UrlSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UrlSettingsPanel.Controls.Add(this.TrustedUrlsLabel);
            this.UrlSettingsPanel.Controls.Add(this.TrustedUrlsTextBox);
            this.UrlSettingsPanel.Controls.Add(this.UrlSettingsLabel);
            this.UrlSettingsPanel.Controls.Add(this.EnableTrustedUrlsCheckBox);
            this.UrlSettingsPanel.Location = new System.Drawing.Point(5, 117);
            this.UrlSettingsPanel.Name = "UrlSettingsPanel";
            this.UrlSettingsPanel.Size = new System.Drawing.Size(150, 84);
            this.UrlSettingsPanel.TabIndex = 4;
            // 
            // TrustedUrlsLabel
            // 
            this.TrustedUrlsLabel.AutoSize = true;
            this.TrustedUrlsLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TrustedUrlsLabel.Location = new System.Drawing.Point(1, 40);
            this.TrustedUrlsLabel.Name = "TrustedUrlsLabel";
            this.TrustedUrlsLabel.Size = new System.Drawing.Size(76, 13);
            this.TrustedUrlsLabel.TabIndex = 0;
            this.TrustedUrlsLabel.Text = "Trusted URLs:";
            // 
            // TrustedUrlsTextBox
            // 
            this.TrustedUrlsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TrustedUrlsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrustedUrlsTextBox.ForeColor = System.Drawing.Color.Silver;
            this.TrustedUrlsTextBox.Location = new System.Drawing.Point(4, 55);
            this.TrustedUrlsTextBox.Name = "TrustedUrlsTextBox";
            this.TrustedUrlsTextBox.Size = new System.Drawing.Size(139, 20);
            this.TrustedUrlsTextBox.TabIndex = 5;
            // 
            // UrlSettingsLabel
            // 
            this.UrlSettingsLabel.AutoSize = true;
            this.UrlSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrlSettingsLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.UrlSettingsLabel.Location = new System.Drawing.Point(2, 3);
            this.UrlSettingsLabel.Name = "UrlSettingsLabel";
            this.UrlSettingsLabel.Size = new System.Drawing.Size(97, 16);
            this.UrlSettingsLabel.TabIndex = 0;
            this.UrlSettingsLabel.Text = "URL Settings";
            // 
            // EnableTrustedUrlsCheckBox
            // 
            this.EnableTrustedUrlsCheckBox.AutoSize = true;
            this.EnableTrustedUrlsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableTrustedUrlsCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.EnableTrustedUrlsCheckBox.Location = new System.Drawing.Point(5, 20);
            this.EnableTrustedUrlsCheckBox.Name = "EnableTrustedUrlsCheckBox";
            this.EnableTrustedUrlsCheckBox.Size = new System.Drawing.Size(143, 19);
            this.EnableTrustedUrlsCheckBox.TabIndex = 4;
            this.EnableTrustedUrlsCheckBox.Text = "Enable Trusted URLs";
            this.EnableTrustedUrlsCheckBox.UseVisualStyleBackColor = true;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.VersionLabel.Location = new System.Drawing.Point(1, 87);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(132, 12);
            this.VersionLabel.TabIndex = 0;
            this.VersionLabel.Text = "MediaDownloader v0.0.0";
            // 
            // InternalVersionLabel
            // 
            this.InternalVersionLabel.AutoSize = true;
            this.InternalVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InternalVersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InternalVersionLabel.Location = new System.Drawing.Point(1, 99);
            this.InternalVersionLabel.Name = "InternalVersionLabel";
            this.InternalVersionLabel.Size = new System.Drawing.Size(76, 12);
            this.InternalVersionLabel.TabIndex = 0;
            this.InternalVersionLabel.Text = "Internal: v0.0.0.0";
            // 
            // UpdateSettingsLabel
            // 
            this.UpdateSettingsLabel.AutoSize = true;
            this.UpdateSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateSettingsLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.UpdateSettingsLabel.Location = new System.Drawing.Point(2, 3);
            this.UpdateSettingsLabel.Name = "UpdateSettingsLabel";
            this.UpdateSettingsLabel.Size = new System.Drawing.Size(118, 16);
            this.UpdateSettingsLabel.TabIndex = 0;
            this.UpdateSettingsLabel.Text = "Update Settings";
            // 
            // CheckForUpdatesButton
            // 
            this.CheckForUpdatesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.CheckForUpdatesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.CheckForUpdatesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckForUpdatesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckForUpdatesButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.CheckForUpdatesButton.Location = new System.Drawing.Point(5, 40);
            this.CheckForUpdatesButton.Name = "CheckForUpdatesButton";
            this.CheckForUpdatesButton.Size = new System.Drawing.Size(99, 21);
            this.CheckForUpdatesButton.TabIndex = 7;
            this.CheckForUpdatesButton.Text = "Check for Updates";
            this.CheckForUpdatesButton.UseVisualStyleBackColor = false;
            this.CheckForUpdatesButton.Click += new System.EventHandler(this.CheckForUpdatesButton_Click);
            // 
            // UpdateSettingsButton
            // 
            this.UpdateSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.UpdateSettingsButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpdateSettingsButton.Controls.Add(this.RunBootstrapperButton);
            this.UpdateSettingsButton.Controls.Add(this.InternalVersionLabel);
            this.UpdateSettingsButton.Controls.Add(this.EnableUpdateNotificationsCheckBox);
            this.UpdateSettingsButton.Controls.Add(this.VersionLabel);
            this.UpdateSettingsButton.Controls.Add(this.CheckForUpdatesButton);
            this.UpdateSettingsButton.Controls.Add(this.UpdateSettingsLabel);
            this.UpdateSettingsButton.Location = new System.Drawing.Point(5, 205);
            this.UpdateSettingsButton.Name = "UpdateSettingsButton";
            this.UpdateSettingsButton.Size = new System.Drawing.Size(150, 117);
            this.UpdateSettingsButton.TabIndex = 6;
            // 
            // RunBootstrapperButton
            // 
            this.RunBootstrapperButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.RunBootstrapperButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.RunBootstrapperButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunBootstrapperButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunBootstrapperButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.RunBootstrapperButton.Location = new System.Drawing.Point(5, 64);
            this.RunBootstrapperButton.Name = "RunBootstrapperButton";
            this.RunBootstrapperButton.Size = new System.Drawing.Size(99, 21);
            this.RunBootstrapperButton.TabIndex = 8;
            this.RunBootstrapperButton.Text = "Run Bootstrapper";
            this.RunBootstrapperButton.UseVisualStyleBackColor = false;
            this.RunBootstrapperButton.Click += new System.EventHandler(this.RunBootstrapperButton_Click);
            // 
            // EnableUpdateNotificationsCheckBox
            // 
            this.EnableUpdateNotificationsCheckBox.AutoSize = true;
            this.EnableUpdateNotificationsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableUpdateNotificationsCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.EnableUpdateNotificationsCheckBox.Location = new System.Drawing.Point(4, 20);
            this.EnableUpdateNotificationsCheckBox.Name = "EnableUpdateNotificationsCheckBox";
            this.EnableUpdateNotificationsCheckBox.Size = new System.Drawing.Size(135, 19);
            this.EnableUpdateNotificationsCheckBox.TabIndex = 6;
            this.EnableUpdateNotificationsCheckBox.Text = "Enable Notifications";
            this.EnableUpdateNotificationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // ApplySettingsButton
            // 
            this.ApplySettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(51)))));
            this.ApplySettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(102)))));
            this.ApplySettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplySettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplySettingsButton.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.ApplySettingsButton.Location = new System.Drawing.Point(222, 160);
            this.ApplySettingsButton.Name = "ApplySettingsButton";
            this.ApplySettingsButton.Size = new System.Drawing.Size(60, 28);
            this.ApplySettingsButton.TabIndex = 12;
            this.ApplySettingsButton.Text = "Apply";
            this.ApplySettingsButton.UseVisualStyleBackColor = false;
            this.ApplySettingsButton.Click += new System.EventHandler(this.ApplySettingsButton_Click);
            // 
            // DiscardSettingsButton
            // 
            this.DiscardSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.DiscardSettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.DiscardSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DiscardSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscardSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DiscardSettingsButton.Location = new System.Drawing.Point(159, 160);
            this.DiscardSettingsButton.Name = "DiscardSettingsButton";
            this.DiscardSettingsButton.Size = new System.Drawing.Size(60, 28);
            this.DiscardSettingsButton.TabIndex = 13;
            this.DiscardSettingsButton.Text = "Cancel";
            this.DiscardSettingsButton.UseVisualStyleBackColor = false;
            this.DiscardSettingsButton.Click += new System.EventHandler(this.DiscardSettingsButton_Click);
            // 
            // SoundSettingsPanel
            // 
            this.SoundSettingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.SoundSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SoundSettingsPanel.Controls.Add(this.CustomSoundLabel);
            this.SoundSettingsPanel.Controls.Add(this.CustomCompleteSoundTextBox);
            this.SoundSettingsPanel.Controls.Add(this.CustomSoundButton);
            this.SoundSettingsPanel.Controls.Add(this.SoundSettingsLabel);
            this.SoundSettingsPanel.Controls.Add(this.PlayCompleteSoundCheckBox);
            this.SoundSettingsPanel.Location = new System.Drawing.Point(5, 29);
            this.SoundSettingsPanel.Name = "SoundSettingsPanel";
            this.SoundSettingsPanel.Size = new System.Drawing.Size(150, 83);
            this.SoundSettingsPanel.TabIndex = 1;
            // 
            // CustomSoundLabel
            // 
            this.CustomSoundLabel.AutoSize = true;
            this.CustomSoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomSoundLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.CustomSoundLabel.Location = new System.Drawing.Point(3, 40);
            this.CustomSoundLabel.Name = "CustomSoundLabel";
            this.CustomSoundLabel.Size = new System.Drawing.Size(142, 12);
            this.CustomSoundLabel.TabIndex = 0;
            this.CustomSoundLabel.Text = "Custom Sound: (blank for default)";
            // 
            // CustomCompleteSoundTextBox
            // 
            this.CustomCompleteSoundTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CustomCompleteSoundTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomCompleteSoundTextBox.ForeColor = System.Drawing.Color.Silver;
            this.CustomCompleteSoundTextBox.Location = new System.Drawing.Point(26, 55);
            this.CustomCompleteSoundTextBox.Name = "CustomCompleteSoundTextBox";
            this.CustomCompleteSoundTextBox.Size = new System.Drawing.Size(116, 20);
            this.CustomCompleteSoundTextBox.TabIndex = 3;
            // 
            // CustomSoundButton
            // 
            this.CustomSoundButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.CustomSoundButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.CustomSoundButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomSoundButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomSoundButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.CustomSoundButton.Image = global::MediaDownloader.Properties.Resources.folder_gray;
            this.CustomSoundButton.Location = new System.Drawing.Point(6, 55);
            this.CustomSoundButton.Name = "CustomSoundButton";
            this.CustomSoundButton.Size = new System.Drawing.Size(20, 20);
            this.CustomSoundButton.TabIndex = 2;
            this.CustomSoundButton.UseVisualStyleBackColor = false;
            this.CustomSoundButton.Click += new System.EventHandler(this.CustomSoundButton_Click);
            // 
            // SoundSettingsLabel
            // 
            this.SoundSettingsLabel.AutoSize = true;
            this.SoundSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoundSettingsLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.SoundSettingsLabel.Location = new System.Drawing.Point(2, 3);
            this.SoundSettingsLabel.Name = "SoundSettingsLabel";
            this.SoundSettingsLabel.Size = new System.Drawing.Size(111, 16);
            this.SoundSettingsLabel.TabIndex = 0;
            this.SoundSettingsLabel.Text = "Sound Settings";
            // 
            // PlayCompleteSoundCheckBox
            // 
            this.PlayCompleteSoundCheckBox.AutoSize = true;
            this.PlayCompleteSoundCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayCompleteSoundCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.PlayCompleteSoundCheckBox.Location = new System.Drawing.Point(5, 20);
            this.PlayCompleteSoundCheckBox.Name = "PlayCompleteSoundCheckBox";
            this.PlayCompleteSoundCheckBox.Size = new System.Drawing.Size(144, 19);
            this.PlayCompleteSoundCheckBox.TabIndex = 1;
            this.PlayCompleteSoundCheckBox.Text = "Play Complete Sound";
            this.PlayCompleteSoundCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(287, 328);
            this.Controls.Add(this.SoundSettingsPanel);
            this.Controls.Add(this.DiscardSettingsButton);
            this.Controls.Add(this.ApplySettingsButton);
            this.Controls.Add(this.UpdateSettingsButton);
            this.Controls.Add(this.UrlSettingsPanel);
            this.Controls.Add(this.QueueSettingsPanel);
            this.Controls.Add(this.HistorySettingsPanel);
            this.Controls.Add(this.TitlebarPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "MediaDownloader Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.TitlebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BannerPicture)).EndInit();
            this.HistorySettingsPanel.ResumeLayout(false);
            this.HistorySettingsPanel.PerformLayout();
            this.QueueSettingsPanel.ResumeLayout(false);
            this.QueueSettingsPanel.PerformLayout();
            this.UrlSettingsPanel.ResumeLayout(false);
            this.UrlSettingsPanel.PerformLayout();
            this.UpdateSettingsButton.ResumeLayout(false);
            this.UpdateSettingsButton.PerformLayout();
            this.SoundSettingsPanel.ResumeLayout(false);
            this.SoundSettingsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlebarPanel;
        private System.Windows.Forms.PictureBox BannerPicture;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel HistorySettingsPanel;
        private System.Windows.Forms.Label HistorySettingsLabel;
        private System.Windows.Forms.CheckBox EnableHistoryCheckBox;
        private System.Windows.Forms.Button ClearHistoryButton;
        private System.Windows.Forms.Panel QueueSettingsPanel;
        private System.Windows.Forms.Button ClearQueueButton;
        private System.Windows.Forms.Label QueueSettings;
        private System.Windows.Forms.Panel UrlSettingsPanel;
        private System.Windows.Forms.Label UrlSettingsLabel;
        private System.Windows.Forms.CheckBox EnableTrustedUrlsCheckBox;
        private System.Windows.Forms.TextBox TrustedUrlsTextBox;
        private System.Windows.Forms.Label TrustedUrlsLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label InternalVersionLabel;
        private System.Windows.Forms.Label UpdateSettingsLabel;
        private System.Windows.Forms.Button CheckForUpdatesButton;
        private System.Windows.Forms.Panel UpdateSettingsButton;
        private System.Windows.Forms.CheckBox EnableUpdateNotificationsCheckBox;
        private System.Windows.Forms.Button RunBootstrapperButton;
        private System.Windows.Forms.Button ApplySettingsButton;
        private System.Windows.Forms.Button DiscardSettingsButton;
        private System.Windows.Forms.Panel SoundSettingsPanel;
        private System.Windows.Forms.Label SoundSettingsLabel;
        private System.Windows.Forms.CheckBox PlayCompleteSoundCheckBox;
        private System.Windows.Forms.Button CustomSoundButton;
        private System.Windows.Forms.TextBox CustomCompleteSoundTextBox;
        private System.Windows.Forms.Label CustomSoundLabel;
    }
}