namespace MediaDownloader
{
    partial class program
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(program));
            this.urlTextbox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.titlebarPanel = new System.Windows.Forms.Panel();
            this.bannerPicture = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.formatCombobox = new System.Windows.Forms.ComboBox();
            this.formatLabel = new System.Windows.Forms.Label();
            this.downloadButton = new System.Windows.Forms.Button();
            this.viewAvailableFormatsButton = new System.Windows.Forms.Button();
            this.locationButton = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.clearLocationButton = new System.Windows.Forms.Button();
            this.useCpuCheckbox = new System.Windows.Forms.CheckBox();
            this.useConfig = new System.Windows.Forms.CheckBox();
            this.resetConfig = new System.Windows.Forms.Button();
            this.gifQualityLabel = new System.Windows.Forms.Label();
            this.gifResolutionTextbox = new System.Windows.Forms.TextBox();
            this.gifFramerateTextbox = new System.Windows.Forms.TextBox();
            this.gifResolutionLabel = new System.Windows.Forms.Label();
            this.gifFramerateLabel = new System.Windows.Forms.Label();
            this.programToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openLocationButton = new System.Windows.Forms.Button();
            this.useGpuCheckbox = new System.Windows.Forms.CheckBox();
            this.codecLabel = new System.Windows.Forms.Label();
            this.gpuEncoderTextbox = new System.Windows.Forms.TextBox();
            this.useTimeframeCheckbox = new System.Windows.Forms.CheckBox();
            this.timeframeStartLabel = new System.Windows.Forms.Label();
            this.timeframeEndLabel = new System.Windows.Forms.Label();
            this.ytdlpArgumentsTextbox = new System.Windows.Forms.RichTextBox();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.ytdlpArgumentsLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.displayOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.advancedLabel = new System.Windows.Forms.Label();
            this.keepOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.videoBitrateTextbox = new System.Windows.Forms.TextBox();
            this.bitrateLabel = new System.Windows.Forms.Label();
            this.audioBitrateTextbox = new System.Windows.Forms.TextBox();
            this.videoBitrateLabel = new System.Windows.Forms.Label();
            this.audioBitrateLabel = new System.Windows.Forms.Label();
            this.timeframeEndTextbox = new System.Windows.Forms.TextBox();
            this.timeframeStartTextbox = new System.Windows.Forms.TextBox();
            this.titlebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // urlTextbox
            // 
            this.urlTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.urlTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.urlTextbox.ForeColor = System.Drawing.Color.Silver;
            this.urlTextbox.Location = new System.Drawing.Point(7, 55);
            this.urlTextbox.Name = "urlTextbox";
            this.urlTextbox.Size = new System.Drawing.Size(228, 20);
            this.urlTextbox.TabIndex = 2;
            this.urlTextbox.TextChanged += new System.EventHandler(this.urlTextbox_TextChanged);
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.BackColor = System.Drawing.Color.Transparent;
            this.urlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(75)))));
            this.urlLabel.Location = new System.Drawing.Point(3, 41);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(29, 13);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "URL";
            // 
            // titlebarPanel
            // 
            this.titlebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(16)))));
            this.titlebarPanel.Controls.Add(this.bannerPicture);
            this.titlebarPanel.Controls.Add(this.versionLabel);
            this.titlebarPanel.Controls.Add(this.minimizeButton);
            this.titlebarPanel.Controls.Add(this.exitButton);
            this.titlebarPanel.Location = new System.Drawing.Point(-9, -5);
            this.titlebarPanel.Name = "titlebarPanel";
            this.titlebarPanel.Size = new System.Drawing.Size(362, 40);
            this.titlebarPanel.TabIndex = 0;
            this.titlebarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebarPanel_MouseDown);
            // 
            // bannerPicture
            // 
            this.bannerPicture.BackColor = System.Drawing.Color.Transparent;
            this.bannerPicture.Image = ((System.Drawing.Image)(resources.GetObject("bannerPicture.Image")));
            this.bannerPicture.Location = new System.Drawing.Point(11, 5);
            this.bannerPicture.Name = "bannerPicture";
            this.bannerPicture.Size = new System.Drawing.Size(158, 33);
            this.bannerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bannerPicture.TabIndex = 0;
            this.bannerPicture.TabStop = false;
            this.bannerPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bannerPicture_MouseDown);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.versionLabel.Location = new System.Drawing.Point(261, 25);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(38, 12);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "v0.0.0";
            this.versionLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.versionLabel_MouseDown);
            // 
            // minimizeButton
            // 
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.minimizeButton.Location = new System.Drawing.Point(299, 10);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(25, 25);
            this.minimizeButton.TabIndex = 0;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exitButton.Location = new System.Drawing.Point(326, 10);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "❌";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // formatCombobox
            // 
            this.formatCombobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.formatCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formatCombobox.ForeColor = System.Drawing.Color.Silver;
            this.formatCombobox.FormattingEnabled = true;
            this.formatCombobox.ItemHeight = 13;
            this.formatCombobox.Items.AddRange(new object[] {
            "[Video]",
            "mp4",
            "mkv",
            "webm",
            "",
            "[Audio]",
            "mp3",
            "wav",
            "ogg",
            "flac",
            "opus",
            "",
            "[Image]",
            "gif",
            "png sequence",
            "jpg sequence",
            "",
            "[Audio Visualizers]",
            "vectorscope",
            "spectogram",
            "histogram",
            "showcqt",
            "showfreqs",
            "waves",
            "",
            "[Custom]",
            "(yt-dlp arguments)"});
            this.formatCombobox.Location = new System.Drawing.Point(7, 93);
            this.formatCombobox.Name = "formatCombobox";
            this.formatCombobox.Size = new System.Drawing.Size(99, 21);
            this.formatCombobox.TabIndex = 4;
            this.formatCombobox.SelectedIndexChanged += new System.EventHandler(this.formatCombobox_SelectedIndexChanged);
            // 
            // formatLabel
            // 
            this.formatLabel.AutoSize = true;
            this.formatLabel.BackColor = System.Drawing.Color.Transparent;
            this.formatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.formatLabel.Location = new System.Drawing.Point(3, 79);
            this.formatLabel.Name = "formatLabel";
            this.formatLabel.Size = new System.Drawing.Size(39, 13);
            this.formatLabel.TabIndex = 0;
            this.formatLabel.Text = "Format";
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.downloadButton.Image = ((System.Drawing.Image)(resources.GetObject("downloadButton.Image")));
            this.downloadButton.Location = new System.Drawing.Point(7, 145);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(120, 34);
            this.downloadButton.TabIndex = 9;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // viewAvailableFormatsButton
            // 
            this.viewAvailableFormatsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.viewAvailableFormatsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewAvailableFormatsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAvailableFormatsButton.ForeColor = System.Drawing.Color.Silver;
            this.viewAvailableFormatsButton.Location = new System.Drawing.Point(106, 93);
            this.viewAvailableFormatsButton.Name = "viewAvailableFormatsButton";
            this.viewAvailableFormatsButton.Size = new System.Drawing.Size(21, 21);
            this.viewAvailableFormatsButton.TabIndex = 5;
            this.viewAvailableFormatsButton.Text = "?";
            this.viewAvailableFormatsButton.UseVisualStyleBackColor = false;
            this.viewAvailableFormatsButton.Click += new System.EventHandler(this.viewAvailableFormatsButton_Click);
            // 
            // locationButton
            // 
            this.locationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.locationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.locationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.locationButton.Location = new System.Drawing.Point(7, 179);
            this.locationButton.Name = "locationButton";
            this.locationButton.Size = new System.Drawing.Size(76, 23);
            this.locationButton.TabIndex = 10;
            this.locationButton.Text = "Change Folder";
            this.locationButton.UseVisualStyleBackColor = false;
            this.locationButton.Click += new System.EventHandler(this.locationButton_Click);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.BackColor = System.Drawing.Color.Transparent;
            this.directoryLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.directoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.directoryLabel.Location = new System.Drawing.Point(4, 202);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(114, 12);
            this.directoryLabel.TabIndex = 0;
            this.directoryLabel.Text = "DOWNLOAD_LOCATION";
            // 
            // clearLocationButton
            // 
            this.clearLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.clearLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearLocationButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.clearLocationButton.Location = new System.Drawing.Point(104, 179);
            this.clearLocationButton.Name = "clearLocationButton";
            this.clearLocationButton.Size = new System.Drawing.Size(23, 23);
            this.clearLocationButton.TabIndex = 12;
            this.clearLocationButton.Text = "❌";
            this.clearLocationButton.UseVisualStyleBackColor = false;
            this.clearLocationButton.Click += new System.EventHandler(this.clearLocationButton_Click);
            // 
            // useCpuCheckbox
            // 
            this.useCpuCheckbox.AutoSize = true;
            this.useCpuCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.useCpuCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.useCpuCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useCpuCheckbox.ForeColor = System.Drawing.Color.MediumPurple;
            this.useCpuCheckbox.Location = new System.Drawing.Point(131, 172);
            this.useCpuCheckbox.Name = "useCpuCheckbox";
            this.useCpuCheckbox.Size = new System.Drawing.Size(106, 16);
            this.useCpuCheckbox.TabIndex = 19;
            this.useCpuCheckbox.Text = "Encode Video (CPU)";
            this.useCpuCheckbox.UseVisualStyleBackColor = false;
            this.useCpuCheckbox.CheckedChanged += new System.EventHandler(this.useCpuCheckbox_CheckedChanged);
            // 
            // useConfig
            // 
            this.useConfig.AutoSize = true;
            this.useConfig.BackColor = System.Drawing.Color.Transparent;
            this.useConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.useConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.useConfig.Location = new System.Drawing.Point(238, 77);
            this.useConfig.Name = "useConfig";
            this.useConfig.Size = new System.Drawing.Size(77, 16);
            this.useConfig.TabIndex = 23;
            this.useConfig.Text = "Save Options";
            this.useConfig.UseVisualStyleBackColor = false;
            this.useConfig.CheckedChanged += new System.EventHandler(this.useConfig_CheckedChanged);
            // 
            // resetConfig
            // 
            this.resetConfig.BackColor = System.Drawing.Color.Transparent;
            this.resetConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resetConfig.Image = ((System.Drawing.Image)(resources.GetObject("resetConfig.Image")));
            this.resetConfig.Location = new System.Drawing.Point(313, 79);
            this.resetConfig.Name = "resetConfig";
            this.resetConfig.Size = new System.Drawing.Size(11, 11);
            this.resetConfig.TabIndex = 24;
            this.resetConfig.UseVisualStyleBackColor = false;
            this.resetConfig.Click += new System.EventHandler(this.resetConfig_Click);
            // 
            // gifQualityLabel
            // 
            this.gifQualityLabel.AutoSize = true;
            this.gifQualityLabel.BackColor = System.Drawing.Color.Transparent;
            this.gifQualityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifQualityLabel.ForeColor = System.Drawing.Color.Gold;
            this.gifQualityLabel.Location = new System.Drawing.Point(129, 118);
            this.gifQualityLabel.Name = "gifQualityLabel";
            this.gifQualityLabel.Size = new System.Drawing.Size(46, 12);
            this.gifQualityLabel.TabIndex = 0;
            this.gifQualityLabel.Text = "gif Quality";
            // 
            // gifResolutionTextbox
            // 
            this.gifResolutionTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gifResolutionTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gifResolutionTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifResolutionTextbox.ForeColor = System.Drawing.Color.Khaki;
            this.gifResolutionTextbox.Location = new System.Drawing.Point(145, 130);
            this.gifResolutionTextbox.Name = "gifResolutionTextbox";
            this.gifResolutionTextbox.Size = new System.Drawing.Size(35, 13);
            this.gifResolutionTextbox.TabIndex = 15;
            this.gifResolutionTextbox.TextChanged += new System.EventHandler(this.gifResolutionTextbox_TextChanged);
            // 
            // gifFramerateTextbox
            // 
            this.gifFramerateTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gifFramerateTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gifFramerateTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifFramerateTextbox.ForeColor = System.Drawing.Color.Khaki;
            this.gifFramerateTextbox.Location = new System.Drawing.Point(199, 130);
            this.gifFramerateTextbox.Name = "gifFramerateTextbox";
            this.gifFramerateTextbox.Size = new System.Drawing.Size(35, 13);
            this.gifFramerateTextbox.TabIndex = 16;
            this.gifFramerateTextbox.TextChanged += new System.EventHandler(this.gifFramerateTextbox_TextChanged);
            // 
            // gifResolutionLabel
            // 
            this.gifResolutionLabel.AutoSize = true;
            this.gifResolutionLabel.BackColor = System.Drawing.Color.Transparent;
            this.gifResolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifResolutionLabel.ForeColor = System.Drawing.Color.Khaki;
            this.gifResolutionLabel.Location = new System.Drawing.Point(128, 130);
            this.gifResolutionLabel.Name = "gifResolutionLabel";
            this.gifResolutionLabel.Size = new System.Drawing.Size(15, 12);
            this.gifResolutionLabel.TabIndex = 0;
            this.gifResolutionLabel.Text = "R:";
            // 
            // gifFramerateLabel
            // 
            this.gifFramerateLabel.AutoSize = true;
            this.gifFramerateLabel.BackColor = System.Drawing.Color.Transparent;
            this.gifFramerateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifFramerateLabel.ForeColor = System.Drawing.Color.Khaki;
            this.gifFramerateLabel.Location = new System.Drawing.Point(183, 130);
            this.gifFramerateLabel.Name = "gifFramerateLabel";
            this.gifFramerateLabel.Size = new System.Drawing.Size(14, 12);
            this.gifFramerateLabel.TabIndex = 0;
            this.gifFramerateLabel.Text = "F:";
            // 
            // programToolTip
            // 
            this.programToolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.programToolTip_Draw);
            // 
            // openLocationButton
            // 
            this.openLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.openLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openLocationButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.openLocationButton.Image = ((System.Drawing.Image)(resources.GetObject("openLocationButton.Image")));
            this.openLocationButton.Location = new System.Drawing.Point(82, 179);
            this.openLocationButton.Name = "openLocationButton";
            this.openLocationButton.Size = new System.Drawing.Size(23, 23);
            this.openLocationButton.TabIndex = 11;
            this.openLocationButton.UseVisualStyleBackColor = false;
            this.openLocationButton.Click += new System.EventHandler(this.openLocationButton_Click);
            // 
            // useGpuCheckbox
            // 
            this.useGpuCheckbox.AutoSize = true;
            this.useGpuCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.useGpuCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.useGpuCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useGpuCheckbox.ForeColor = System.Drawing.Color.YellowGreen;
            this.useGpuCheckbox.Location = new System.Drawing.Point(131, 143);
            this.useGpuCheckbox.Name = "useGpuCheckbox";
            this.useGpuCheckbox.Size = new System.Drawing.Size(106, 16);
            this.useGpuCheckbox.TabIndex = 17;
            this.useGpuCheckbox.Text = "Encode Video (GPU)";
            this.useGpuCheckbox.UseVisualStyleBackColor = false;
            this.useGpuCheckbox.CheckedChanged += new System.EventHandler(this.useGpuCheckbox_CheckedChanged);
            // 
            // codecLabel
            // 
            this.codecLabel.AutoSize = true;
            this.codecLabel.BackColor = System.Drawing.Color.Transparent;
            this.codecLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codecLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.codecLabel.Location = new System.Drawing.Point(128, 158);
            this.codecLabel.Name = "codecLabel";
            this.codecLabel.Size = new System.Drawing.Size(42, 12);
            this.codecLabel.TabIndex = 0;
            this.codecLabel.Text = "Encoder:";
            // 
            // gpuEncoderTextbox
            // 
            this.gpuEncoderTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gpuEncoderTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gpuEncoderTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpuEncoderTextbox.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.gpuEncoderTextbox.Location = new System.Drawing.Point(171, 158);
            this.gpuEncoderTextbox.Name = "gpuEncoderTextbox";
            this.gpuEncoderTextbox.Size = new System.Drawing.Size(64, 13);
            this.gpuEncoderTextbox.TabIndex = 18;
            this.gpuEncoderTextbox.TextChanged += new System.EventHandler(this.gpuEncoderTextbox_TextChanged);
            // 
            // useTimeframeCheckbox
            // 
            this.useTimeframeCheckbox.AutoSize = true;
            this.useTimeframeCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.useTimeframeCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.useTimeframeCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useTimeframeCheckbox.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.useTimeframeCheckbox.Location = new System.Drawing.Point(7, 114);
            this.useTimeframeCheckbox.Name = "useTimeframeCheckbox";
            this.useTimeframeCheckbox.Size = new System.Drawing.Size(111, 16);
            this.useTimeframeCheckbox.TabIndex = 6;
            this.useTimeframeCheckbox.Text = "Trim Length Between:";
            this.useTimeframeCheckbox.UseVisualStyleBackColor = false;
            this.useTimeframeCheckbox.CheckedChanged += new System.EventHandler(this.useTimeframeCheckbox_CheckedChanged);
            // 
            // timeframeStartLabel
            // 
            this.timeframeStartLabel.AutoSize = true;
            this.timeframeStartLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeframeStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeframeStartLabel.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.timeframeStartLabel.Location = new System.Drawing.Point(4, 130);
            this.timeframeStartLabel.Name = "timeframeStartLabel";
            this.timeframeStartLabel.Size = new System.Drawing.Size(14, 12);
            this.timeframeStartLabel.TabIndex = 0;
            this.timeframeStartLabel.Text = "S:";
            // 
            // timeframeEndLabel
            // 
            this.timeframeEndLabel.AutoSize = true;
            this.timeframeEndLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeframeEndLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeframeEndLabel.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.timeframeEndLabel.Location = new System.Drawing.Point(67, 130);
            this.timeframeEndLabel.Name = "timeframeEndLabel";
            this.timeframeEndLabel.Size = new System.Drawing.Size(14, 12);
            this.timeframeEndLabel.TabIndex = 0;
            this.timeframeEndLabel.Text = "E:";
            // 
            // ytdlpArgumentsTextbox
            // 
            this.ytdlpArgumentsTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ytdlpArgumentsTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ytdlpArgumentsTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytdlpArgumentsTextbox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ytdlpArgumentsTextbox.Location = new System.Drawing.Point(240, 104);
            this.ytdlpArgumentsTextbox.Name = "ytdlpArgumentsTextbox";
            this.ytdlpArgumentsTextbox.Size = new System.Drawing.Size(100, 56);
            this.ytdlpArgumentsTextbox.TabIndex = 20;
            this.ytdlpArgumentsTextbox.Text = "";
            this.ytdlpArgumentsTextbox.TextChanged += new System.EventHandler(this.ytdlpArgumentsTextbox_TextChanged);
            this.ytdlpArgumentsTextbox.DoubleClick += new System.EventHandler(this.ytArgsBox_DoubleClick);
            // 
            // nameTextbox
            // 
            this.nameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextbox.ForeColor = System.Drawing.Color.Silver;
            this.nameTextbox.Location = new System.Drawing.Point(238, 55);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(103, 20);
            this.nameTextbox.TabIndex = 3;
            this.nameTextbox.TextChanged += new System.EventHandler(this.nameTextbox_TextChanged);
            // 
            // ytdlpArgumentsLabel
            // 
            this.ytdlpArgumentsLabel.AutoSize = true;
            this.ytdlpArgumentsLabel.BackColor = System.Drawing.Color.Transparent;
            this.ytdlpArgumentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytdlpArgumentsLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.ytdlpArgumentsLabel.Location = new System.Drawing.Point(238, 90);
            this.ytdlpArgumentsLabel.Name = "ytdlpArgumentsLabel";
            this.ytdlpArgumentsLabel.Size = new System.Drawing.Size(76, 12);
            this.ytdlpArgumentsLabel.TabIndex = 0;
            this.ytdlpArgumentsLabel.Text = "yt-dlp Arguments";
            this.ytdlpArgumentsLabel.DoubleClick += new System.EventHandler(this.ytArgsLabel_DoubleClick);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.ForeColor = System.Drawing.Color.SeaGreen;
            this.nameLabel.Location = new System.Drawing.Point(234, 41);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // displayOutputCheckbox
            // 
            this.displayOutputCheckbox.AutoSize = true;
            this.displayOutputCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.displayOutputCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.displayOutputCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayOutputCheckbox.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.displayOutputCheckbox.Location = new System.Drawing.Point(239, 172);
            this.displayOutputCheckbox.Name = "displayOutputCheckbox";
            this.displayOutputCheckbox.Size = new System.Drawing.Size(52, 16);
            this.displayOutputCheckbox.TabIndex = 21;
            this.displayOutputCheckbox.Text = "Display";
            this.displayOutputCheckbox.UseVisualStyleBackColor = false;
            this.displayOutputCheckbox.CheckedChanged += new System.EventHandler(this.displayOutputCheckbox_CheckedChanged);
            // 
            // advancedLabel
            // 
            this.advancedLabel.AutoSize = true;
            this.advancedLabel.BackColor = System.Drawing.Color.Transparent;
            this.advancedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advancedLabel.ForeColor = System.Drawing.Color.Brown;
            this.advancedLabel.Location = new System.Drawing.Point(127, 79);
            this.advancedLabel.Name = "advancedLabel";
            this.advancedLabel.Size = new System.Drawing.Size(70, 13);
            this.advancedLabel.TabIndex = 0;
            this.advancedLabel.Text = "More Options";
            // 
            // keepOutputCheckbox
            // 
            this.keepOutputCheckbox.AutoSize = true;
            this.keepOutputCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.keepOutputCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keepOutputCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keepOutputCheckbox.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.keepOutputCheckbox.Location = new System.Drawing.Point(293, 172);
            this.keepOutputCheckbox.Name = "keepOutputCheckbox";
            this.keepOutputCheckbox.Size = new System.Drawing.Size(42, 16);
            this.keepOutputCheckbox.TabIndex = 22;
            this.keepOutputCheckbox.Text = "Keep";
            this.keepOutputCheckbox.UseVisualStyleBackColor = false;
            this.keepOutputCheckbox.CheckedChanged += new System.EventHandler(this.keepOutputCheckbox_CheckedChanged);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.BackColor = System.Drawing.Color.Transparent;
            this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.ForeColor = System.Drawing.Color.DarkCyan;
            this.outputLabel.Location = new System.Drawing.Point(236, 161);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(84, 12);
            this.outputLabel.TabIndex = 0;
            this.outputLabel.Text = "Output Log Options";
            // 
            // videoBitrateTextbox
            // 
            this.videoBitrateTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoBitrateTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.videoBitrateTextbox.ForeColor = System.Drawing.Color.Goldenrod;
            this.videoBitrateTextbox.Location = new System.Drawing.Point(145, 104);
            this.videoBitrateTextbox.Name = "videoBitrateTextbox";
            this.videoBitrateTextbox.Size = new System.Drawing.Size(35, 13);
            this.videoBitrateTextbox.TabIndex = 13;
            this.videoBitrateTextbox.TextChanged += new System.EventHandler(this.videoBitrateTextbox_TextChanged);
            // 
            // bitrateLabel
            // 
            this.bitrateLabel.AutoSize = true;
            this.bitrateLabel.BackColor = System.Drawing.Color.Transparent;
            this.bitrateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bitrateLabel.ForeColor = System.Drawing.Color.Orange;
            this.bitrateLabel.Location = new System.Drawing.Point(128, 92);
            this.bitrateLabel.Name = "bitrateLabel";
            this.bitrateLabel.Size = new System.Drawing.Size(81, 12);
            this.bitrateLabel.TabIndex = 0;
            this.bitrateLabel.Text = "Bitrate for Encoder";
            // 
            // audioBitrateTextbox
            // 
            this.audioBitrateTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.audioBitrateTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.audioBitrateTextbox.ForeColor = System.Drawing.Color.Goldenrod;
            this.audioBitrateTextbox.Location = new System.Drawing.Point(199, 104);
            this.audioBitrateTextbox.Name = "audioBitrateTextbox";
            this.audioBitrateTextbox.Size = new System.Drawing.Size(35, 13);
            this.audioBitrateTextbox.TabIndex = 14;
            this.audioBitrateTextbox.TextChanged += new System.EventHandler(this.audioBitrateTextbox_TextChanged);
            // 
            // videoBitrateLabel
            // 
            this.videoBitrateLabel.AutoSize = true;
            this.videoBitrateLabel.BackColor = System.Drawing.Color.Transparent;
            this.videoBitrateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoBitrateLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.videoBitrateLabel.Location = new System.Drawing.Point(129, 104);
            this.videoBitrateLabel.Name = "videoBitrateLabel";
            this.videoBitrateLabel.Size = new System.Drawing.Size(15, 12);
            this.videoBitrateLabel.TabIndex = 0;
            this.videoBitrateLabel.Text = "V:";
            // 
            // audioBitrateLabel
            // 
            this.audioBitrateLabel.AutoSize = true;
            this.audioBitrateLabel.BackColor = System.Drawing.Color.Transparent;
            this.audioBitrateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioBitrateLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.audioBitrateLabel.Location = new System.Drawing.Point(183, 104);
            this.audioBitrateLabel.Name = "audioBitrateLabel";
            this.audioBitrateLabel.Size = new System.Drawing.Size(15, 12);
            this.audioBitrateLabel.TabIndex = 0;
            this.audioBitrateLabel.Text = "A:";
            // 
            // timeframeEndTextbox
            // 
            this.timeframeEndTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeframeEndTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeframeEndTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeframeEndTextbox.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.timeframeEndTextbox.Location = new System.Drawing.Point(81, 130);
            this.timeframeEndTextbox.Name = "timeframeEndTextbox";
            this.timeframeEndTextbox.Size = new System.Drawing.Size(45, 13);
            this.timeframeEndTextbox.TabIndex = 8;
            this.timeframeEndTextbox.TextChanged += new System.EventHandler(this.timeframeEndTextbox_TextChanged);
            // 
            // timeframeStartTextbox
            // 
            this.timeframeStartTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeframeStartTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeframeStartTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeframeStartTextbox.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.timeframeStartTextbox.Location = new System.Drawing.Point(18, 130);
            this.timeframeStartTextbox.Name = "timeframeStartTextbox";
            this.timeframeStartTextbox.Size = new System.Drawing.Size(46, 13);
            this.timeframeStartTextbox.TabIndex = 7;
            this.timeframeStartTextbox.TextChanged += new System.EventHandler(this.timeframeStartTextbox_TextChanged);
            // 
            // program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BackgroundImage = global::MediaDownloader.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(347, 214);
            this.Controls.Add(this.audioBitrateLabel);
            this.Controls.Add(this.videoBitrateLabel);
            this.Controls.Add(this.audioBitrateTextbox);
            this.Controls.Add(this.bitrateLabel);
            this.Controls.Add(this.videoBitrateTextbox);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.keepOutputCheckbox);
            this.Controls.Add(this.displayOutputCheckbox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.ytdlpArgumentsLabel);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.resetConfig);
            this.Controls.Add(this.useConfig);
            this.Controls.Add(this.ytdlpArgumentsTextbox);
            this.Controls.Add(this.timeframeEndLabel);
            this.Controls.Add(this.timeframeStartLabel);
            this.Controls.Add(this.useTimeframeCheckbox);
            this.Controls.Add(this.timeframeEndTextbox);
            this.Controls.Add(this.timeframeStartTextbox);
            this.Controls.Add(this.gpuEncoderTextbox);
            this.Controls.Add(this.codecLabel);
            this.Controls.Add(this.useGpuCheckbox);
            this.Controls.Add(this.openLocationButton);
            this.Controls.Add(this.gifFramerateLabel);
            this.Controls.Add(this.gifResolutionLabel);
            this.Controls.Add(this.gifFramerateTextbox);
            this.Controls.Add(this.gifResolutionTextbox);
            this.Controls.Add(this.gifQualityLabel);
            this.Controls.Add(this.useCpuCheckbox);
            this.Controls.Add(this.clearLocationButton);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.locationButton);
            this.Controls.Add(this.viewAvailableFormatsButton);
            this.Controls.Add(this.advancedLabel);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.formatLabel);
            this.Controls.Add(this.formatCombobox);
            this.Controls.Add(this.titlebarPanel);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.urlTextbox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "program";
            this.Text = "MediaDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.program_FormClosing);
            this.Load += new System.EventHandler(this.program_Load);
            this.titlebarPanel.ResumeLayout(false);
            this.titlebarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlTextbox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Panel titlebarPanel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ComboBox formatCombobox;
        private System.Windows.Forms.Label formatLabel;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button viewAvailableFormatsButton;
        private System.Windows.Forms.Button locationButton;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Button clearLocationButton;
        private System.Windows.Forms.CheckBox useCpuCheckbox;
        private System.Windows.Forms.CheckBox useConfig;
        private System.Windows.Forms.Button resetConfig;
        private System.Windows.Forms.Label gifQualityLabel;
        private System.Windows.Forms.TextBox gifResolutionTextbox;
        private System.Windows.Forms.TextBox gifFramerateTextbox;
        private System.Windows.Forms.Label gifResolutionLabel;
        private System.Windows.Forms.Label gifFramerateLabel;
        private System.Windows.Forms.PictureBox bannerPicture;
        private System.Windows.Forms.ToolTip programToolTip;
        private System.Windows.Forms.Button openLocationButton;
        private System.Windows.Forms.CheckBox useGpuCheckbox;
        private System.Windows.Forms.Label codecLabel;
        private System.Windows.Forms.TextBox gpuEncoderTextbox;
        private System.Windows.Forms.CheckBox useTimeframeCheckbox;
        private System.Windows.Forms.Label timeframeStartLabel;
        private System.Windows.Forms.Label timeframeEndLabel;
        private System.Windows.Forms.RichTextBox ytdlpArgumentsTextbox;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label ytdlpArgumentsLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.CheckBox displayOutputCheckbox;
        private System.Windows.Forms.Label advancedLabel;
        private System.Windows.Forms.CheckBox keepOutputCheckbox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox videoBitrateTextbox;
        private System.Windows.Forms.Label bitrateLabel;
        private System.Windows.Forms.TextBox audioBitrateTextbox;
        private System.Windows.Forms.Label videoBitrateLabel;
        private System.Windows.Forms.Label audioBitrateLabel;
        private System.Windows.Forms.TextBox timeframeEndTextbox;
        private System.Windows.Forms.TextBox timeframeStartTextbox;
    }
}