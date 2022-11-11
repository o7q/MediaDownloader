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
            this.inputBox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.titlebarPanel = new System.Windows.Forms.Panel();
            this.bannerPicture = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.formatBox = new System.Windows.Forms.ComboBox();
            this.formatLabel = new System.Windows.Forms.Label();
            this.downloadButton = new System.Windows.Forms.Button();
            this.advancedLabel = new System.Windows.Forms.Label();
            this.viewAvailableFormatsButton = new System.Windows.Forms.Button();
            this.locationButton = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.clearLocationButton = new System.Windows.Forms.Button();
            this.applyCodecs = new System.Windows.Forms.CheckBox();
            this.useConfig = new System.Windows.Forms.CheckBox();
            this.resetConfig = new System.Windows.Forms.Button();
            this.gifQualityLabel = new System.Windows.Forms.Label();
            this.gifResolution = new System.Windows.Forms.TextBox();
            this.gifFramerate = new System.Windows.Forms.TextBox();
            this.rLabel = new System.Windows.Forms.Label();
            this.fLabel = new System.Windows.Forms.Label();
            this.programToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openLocationButton = new System.Windows.Forms.Button();
            this.useGpu = new System.Windows.Forms.CheckBox();
            this.codecLabel = new System.Windows.Forms.Label();
            this.gpuEncoder = new System.Windows.Forms.TextBox();
            this.timeframeStart = new System.Windows.Forms.TextBox();
            this.timeframeEnd = new System.Windows.Forms.TextBox();
            this.useTimeframe = new System.Windows.Forms.CheckBox();
            this.sLabel = new System.Windows.Forms.Label();
            this.eLabel = new System.Windows.Forms.Label();
            this.ytArgsBox = new System.Windows.Forms.RichTextBox();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.ytArgsLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.titlebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputBox.ForeColor = System.Drawing.Color.Silver;
            this.inputBox.Location = new System.Drawing.Point(7, 55);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(228, 20);
            this.inputBox.TabIndex = 2;
            this.inputBox.TextChanged += new System.EventHandler(this.inputBox_TextChanged);
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
            this.versionLabel.Location = new System.Drawing.Point(263, 24);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(38, 12);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "v3.7.0";
            this.versionLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.versionLabel_MouseDown);
            // 
            // minimizeButton
            // 
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.minimizeButton.Location = new System.Drawing.Point(301, 10);
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
            this.exitButton.Location = new System.Drawing.Point(328, 10);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "❌";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // formatBox
            // 
            this.formatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.formatBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formatBox.ForeColor = System.Drawing.Color.Silver;
            this.formatBox.FormattingEnabled = true;
            this.formatBox.ItemHeight = 13;
            this.formatBox.Items.AddRange(new object[] {
            "[Video]",
            "mp4",
            "webm",
            "gif [FFmpeg]",
            "gif (web) [FFmpeg]",
            "",
            "[Audio]",
            "mp3",
            "wav",
            "ogg [FFmpeg]",
            "",
            "[Custom]",
            "(yt-dlp arguments)"});
            this.formatBox.Location = new System.Drawing.Point(7, 93);
            this.formatBox.Name = "formatBox";
            this.formatBox.Size = new System.Drawing.Size(99, 21);
            this.formatBox.TabIndex = 4;
            this.formatBox.SelectedIndexChanged += new System.EventHandler(this.formatBox_SelectedIndexChanged);
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
            this.downloadButton.Location = new System.Drawing.Point(7, 124);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(120, 34);
            this.downloadButton.TabIndex = 6;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // advancedLabel
            // 
            this.advancedLabel.AutoSize = true;
            this.advancedLabel.BackColor = System.Drawing.Color.Transparent;
            this.advancedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advancedLabel.ForeColor = System.Drawing.Color.Brown;
            this.advancedLabel.Location = new System.Drawing.Point(126, 79);
            this.advancedLabel.Name = "advancedLabel";
            this.advancedLabel.Size = new System.Drawing.Size(70, 13);
            this.advancedLabel.TabIndex = 0;
            this.advancedLabel.Text = "More Options";
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
            this.locationButton.Location = new System.Drawing.Point(7, 158);
            this.locationButton.Name = "locationButton";
            this.locationButton.Size = new System.Drawing.Size(76, 23);
            this.locationButton.TabIndex = 7;
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
            this.directoryLabel.Location = new System.Drawing.Point(5, 182);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(0, 12);
            this.directoryLabel.TabIndex = 0;
            // 
            // clearLocationButton
            // 
            this.clearLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.clearLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearLocationButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.clearLocationButton.Location = new System.Drawing.Point(104, 158);
            this.clearLocationButton.Name = "clearLocationButton";
            this.clearLocationButton.Size = new System.Drawing.Size(23, 23);
            this.clearLocationButton.TabIndex = 9;
            this.clearLocationButton.Text = "❌";
            this.clearLocationButton.UseVisualStyleBackColor = false;
            this.clearLocationButton.Click += new System.EventHandler(this.clearLocationButton_Click);
            // 
            // applyCodecs
            // 
            this.applyCodecs.AutoSize = true;
            this.applyCodecs.BackColor = System.Drawing.Color.Transparent;
            this.applyCodecs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyCodecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyCodecs.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.applyCodecs.Location = new System.Drawing.Point(130, 153);
            this.applyCodecs.Name = "applyCodecs";
            this.applyCodecs.Size = new System.Drawing.Size(105, 16);
            this.applyCodecs.TabIndex = 15;
            this.applyCodecs.Text = "Apply Video Codecs";
            this.applyCodecs.UseVisualStyleBackColor = false;
            this.applyCodecs.CheckedChanged += new System.EventHandler(this.applyCodecs_CheckedChanged);
            // 
            // useConfig
            // 
            this.useConfig.AutoSize = true;
            this.useConfig.BackColor = System.Drawing.Color.Transparent;
            this.useConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.useConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useConfig.ForeColor = System.Drawing.Color.DarkCyan;
            this.useConfig.Location = new System.Drawing.Point(130, 168);
            this.useConfig.Name = "useConfig";
            this.useConfig.Size = new System.Drawing.Size(77, 16);
            this.useConfig.TabIndex = 16;
            this.useConfig.Text = "Save Options";
            this.useConfig.UseVisualStyleBackColor = false;
            this.useConfig.CheckedChanged += new System.EventHandler(this.useConfig_CheckedChanged);
            // 
            // resetConfig
            // 
            this.resetConfig.BackColor = System.Drawing.Color.Transparent;
            this.resetConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetConfig.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.resetConfig.Image = ((System.Drawing.Image)(resources.GetObject("resetConfig.Image")));
            this.resetConfig.Location = new System.Drawing.Point(204, 170);
            this.resetConfig.Name = "resetConfig";
            this.resetConfig.Size = new System.Drawing.Size(11, 11);
            this.resetConfig.TabIndex = 17;
            this.resetConfig.UseVisualStyleBackColor = false;
            this.resetConfig.Click += new System.EventHandler(this.resetConfig_Click);
            // 
            // gifQualityLabel
            // 
            this.gifQualityLabel.AutoSize = true;
            this.gifQualityLabel.BackColor = System.Drawing.Color.Transparent;
            this.gifQualityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifQualityLabel.ForeColor = System.Drawing.Color.Gold;
            this.gifQualityLabel.Location = new System.Drawing.Point(128, 125);
            this.gifQualityLabel.Name = "gifQualityLabel";
            this.gifQualityLabel.Size = new System.Drawing.Size(75, 12);
            this.gifQualityLabel.TabIndex = 0;
            this.gifQualityLabel.Text = "gif (web) Options";
            // 
            // gifResolution
            // 
            this.gifResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gifResolution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gifResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifResolution.ForeColor = System.Drawing.Color.Khaki;
            this.gifResolution.Location = new System.Drawing.Point(144, 139);
            this.gifResolution.Name = "gifResolution";
            this.gifResolution.Size = new System.Drawing.Size(37, 13);
            this.gifResolution.TabIndex = 13;
            this.gifResolution.TextChanged += new System.EventHandler(this.gifResolution_TextChanged);
            // 
            // gifFramerate
            // 
            this.gifFramerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gifFramerate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gifFramerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifFramerate.ForeColor = System.Drawing.Color.Khaki;
            this.gifFramerate.Location = new System.Drawing.Point(198, 139);
            this.gifFramerate.Name = "gifFramerate";
            this.gifFramerate.Size = new System.Drawing.Size(37, 13);
            this.gifFramerate.TabIndex = 14;
            this.gifFramerate.TextChanged += new System.EventHandler(this.gifFramerate_TextChanged);
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.BackColor = System.Drawing.Color.Transparent;
            this.rLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel.ForeColor = System.Drawing.Color.Khaki;
            this.rLabel.Location = new System.Drawing.Point(129, 139);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(15, 12);
            this.rLabel.TabIndex = 0;
            this.rLabel.Text = "R:";
            // 
            // fLabel
            // 
            this.fLabel.AutoSize = true;
            this.fLabel.BackColor = System.Drawing.Color.Transparent;
            this.fLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabel.ForeColor = System.Drawing.Color.Khaki;
            this.fLabel.Location = new System.Drawing.Point(184, 139);
            this.fLabel.Name = "fLabel";
            this.fLabel.Size = new System.Drawing.Size(14, 12);
            this.fLabel.TabIndex = 0;
            this.fLabel.Text = "F:";
            // 
            // programToolTip
            // 
            this.programToolTip.AutoPopDelay = 5000;
            this.programToolTip.InitialDelay = 500;
            this.programToolTip.ReshowDelay = 100;
            this.programToolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.programToolTip_Draw);
            // 
            // openLocationButton
            // 
            this.openLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.openLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openLocationButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.openLocationButton.Image = ((System.Drawing.Image)(resources.GetObject("openLocationButton.Image")));
            this.openLocationButton.Location = new System.Drawing.Point(82, 158);
            this.openLocationButton.Name = "openLocationButton";
            this.openLocationButton.Size = new System.Drawing.Size(23, 23);
            this.openLocationButton.TabIndex = 8;
            this.openLocationButton.UseVisualStyleBackColor = false;
            this.openLocationButton.Click += new System.EventHandler(this.openLocationButton_Click);
            // 
            // useGpu
            // 
            this.useGpu.AutoSize = true;
            this.useGpu.BackColor = System.Drawing.Color.Transparent;
            this.useGpu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.useGpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useGpu.ForeColor = System.Drawing.Color.YellowGreen;
            this.useGpu.Location = new System.Drawing.Point(238, 153);
            this.useGpu.Name = "useGpu";
            this.useGpu.Size = new System.Drawing.Size(114, 16);
            this.useGpu.TabIndex = 19;
            this.useGpu.Text = "Use GPU Acceleration";
            this.useGpu.UseVisualStyleBackColor = false;
            this.useGpu.CheckedChanged += new System.EventHandler(this.useGpu_CheckedChanged);
            // 
            // codecLabel
            // 
            this.codecLabel.AutoSize = true;
            this.codecLabel.BackColor = System.Drawing.Color.Transparent;
            this.codecLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codecLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.codecLabel.Location = new System.Drawing.Point(235, 168);
            this.codecLabel.Name = "codecLabel";
            this.codecLabel.Size = new System.Drawing.Size(42, 12);
            this.codecLabel.TabIndex = 0;
            this.codecLabel.Text = "Encoder:";
            // 
            // gpuEncoder
            // 
            this.gpuEncoder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gpuEncoder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gpuEncoder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpuEncoder.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.gpuEncoder.Location = new System.Drawing.Point(277, 168);
            this.gpuEncoder.Name = "gpuEncoder";
            this.gpuEncoder.Size = new System.Drawing.Size(64, 13);
            this.gpuEncoder.TabIndex = 20;
            this.gpuEncoder.TextChanged += new System.EventHandler(this.gpuEncoder_TextChanged);
            // 
            // timeframeStart
            // 
            this.timeframeStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeframeStart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeframeStart.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.timeframeStart.Location = new System.Drawing.Point(144, 107);
            this.timeframeStart.Name = "timeframeStart";
            this.timeframeStart.Size = new System.Drawing.Size(37, 13);
            this.timeframeStart.TabIndex = 11;
            this.timeframeStart.TextChanged += new System.EventHandler(this.timeframeStart_TextChanged);
            // 
            // timeframeEnd
            // 
            this.timeframeEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeframeEnd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeframeEnd.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.timeframeEnd.Location = new System.Drawing.Point(198, 107);
            this.timeframeEnd.Name = "timeframeEnd";
            this.timeframeEnd.Size = new System.Drawing.Size(37, 13);
            this.timeframeEnd.TabIndex = 12;
            this.timeframeEnd.TextChanged += new System.EventHandler(this.timeframeEnd_TextChanged);
            // 
            // useTimeframe
            // 
            this.useTimeframe.AutoSize = true;
            this.useTimeframe.BackColor = System.Drawing.Color.Transparent;
            this.useTimeframe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.useTimeframe.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useTimeframe.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.useTimeframe.Location = new System.Drawing.Point(130, 91);
            this.useTimeframe.Name = "useTimeframe";
            this.useTimeframe.Size = new System.Drawing.Size(111, 16);
            this.useTimeframe.TabIndex = 10;
            this.useTimeframe.Text = "Trim Length Between:";
            this.useTimeframe.UseVisualStyleBackColor = false;
            this.useTimeframe.CheckedChanged += new System.EventHandler(this.useTimeframe_CheckedChanged);
            // 
            // sLabel
            // 
            this.sLabel.AutoSize = true;
            this.sLabel.BackColor = System.Drawing.Color.Transparent;
            this.sLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLabel.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.sLabel.Location = new System.Drawing.Point(129, 107);
            this.sLabel.Name = "sLabel";
            this.sLabel.Size = new System.Drawing.Size(14, 12);
            this.sLabel.TabIndex = 0;
            this.sLabel.Text = "S:";
            // 
            // eLabel
            // 
            this.eLabel.AutoSize = true;
            this.eLabel.BackColor = System.Drawing.Color.Transparent;
            this.eLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eLabel.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.eLabel.Location = new System.Drawing.Point(183, 107);
            this.eLabel.Name = "eLabel";
            this.eLabel.Size = new System.Drawing.Size(14, 12);
            this.eLabel.TabIndex = 0;
            this.eLabel.Text = "E:";
            // 
            // ytArgsBox
            // 
            this.ytArgsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ytArgsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ytArgsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytArgsBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ytArgsBox.Location = new System.Drawing.Point(238, 107);
            this.ytArgsBox.Name = "ytArgsBox";
            this.ytArgsBox.Size = new System.Drawing.Size(103, 45);
            this.ytArgsBox.TabIndex = 18;
            this.ytArgsBox.Text = "";
            this.ytArgsBox.TextChanged += new System.EventHandler(this.ytArgsBox_TextChanged);
            this.ytArgsBox.DoubleClick += new System.EventHandler(this.ytArgsBox_DoubleClick);
            // 
            // fileNameBox
            // 
            this.fileNameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileNameBox.ForeColor = System.Drawing.Color.Silver;
            this.fileNameBox.Location = new System.Drawing.Point(237, 55);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(104, 20);
            this.fileNameBox.TabIndex = 3;
            this.fileNameBox.TextChanged += new System.EventHandler(this.fileNameBox_TextChanged);
            // 
            // ytArgsLabel
            // 
            this.ytArgsLabel.AutoSize = true;
            this.ytArgsLabel.BackColor = System.Drawing.Color.Transparent;
            this.ytArgsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytArgsLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.ytArgsLabel.Location = new System.Drawing.Point(234, 93);
            this.ytArgsLabel.Name = "ytArgsLabel";
            this.ytArgsLabel.Size = new System.Drawing.Size(76, 12);
            this.ytArgsLabel.TabIndex = 0;
            this.ytArgsLabel.Text = "yt-dlp Arguments";
            this.ytArgsLabel.DoubleClick += new System.EventHandler(this.ytArgsLabel_DoubleClick);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel.ForeColor = System.Drawing.Color.SeaGreen;
            this.fileNameLabel.Location = new System.Drawing.Point(233, 41);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(35, 13);
            this.fileNameLabel.TabIndex = 0;
            this.fileNameLabel.Text = "Name";
            // 
            // program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(349, 197);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.ytArgsLabel);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.ytArgsBox);
            this.Controls.Add(this.eLabel);
            this.Controls.Add(this.sLabel);
            this.Controls.Add(this.useTimeframe);
            this.Controls.Add(this.timeframeEnd);
            this.Controls.Add(this.timeframeStart);
            this.Controls.Add(this.gpuEncoder);
            this.Controls.Add(this.codecLabel);
            this.Controls.Add(this.useGpu);
            this.Controls.Add(this.openLocationButton);
            this.Controls.Add(this.fLabel);
            this.Controls.Add(this.rLabel);
            this.Controls.Add(this.gifFramerate);
            this.Controls.Add(this.gifResolution);
            this.Controls.Add(this.gifQualityLabel);
            this.Controls.Add(this.resetConfig);
            this.Controls.Add(this.useConfig);
            this.Controls.Add(this.applyCodecs);
            this.Controls.Add(this.clearLocationButton);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.locationButton);
            this.Controls.Add(this.viewAvailableFormatsButton);
            this.Controls.Add(this.advancedLabel);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.formatLabel);
            this.Controls.Add(this.formatBox);
            this.Controls.Add(this.titlebarPanel);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.inputBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "program";
            this.Text = "MediaDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.program_FormClosing);
            this.Load += new System.EventHandler(this.program_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.program_MouseMove);
            this.titlebarPanel.ResumeLayout(false);
            this.titlebarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Panel titlebarPanel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ComboBox formatBox;
        private System.Windows.Forms.Label formatLabel;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label advancedLabel;
        private System.Windows.Forms.Button viewAvailableFormatsButton;
        private System.Windows.Forms.Button locationButton;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Button clearLocationButton;
        private System.Windows.Forms.CheckBox applyCodecs;
        private System.Windows.Forms.CheckBox useConfig;
        private System.Windows.Forms.Button resetConfig;
        private System.Windows.Forms.Label gifQualityLabel;
        private System.Windows.Forms.TextBox gifResolution;
        private System.Windows.Forms.TextBox gifFramerate;
        private System.Windows.Forms.Label rLabel;
        private System.Windows.Forms.Label fLabel;
        private System.Windows.Forms.PictureBox bannerPicture;
        private System.Windows.Forms.ToolTip programToolTip;
        private System.Windows.Forms.Button openLocationButton;
        private System.Windows.Forms.CheckBox useGpu;
        private System.Windows.Forms.Label codecLabel;
        private System.Windows.Forms.TextBox gpuEncoder;
        private System.Windows.Forms.TextBox timeframeStart;
        private System.Windows.Forms.TextBox timeframeEnd;
        private System.Windows.Forms.CheckBox useTimeframe;
        private System.Windows.Forms.Label sLabel;
        private System.Windows.Forms.Label eLabel;
        private System.Windows.Forms.RichTextBox ytArgsBox;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.Label ytArgsLabel;
        private System.Windows.Forms.Label fileNameLabel;
    }
}