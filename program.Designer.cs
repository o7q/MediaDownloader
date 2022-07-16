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
            this.customArgsBox = new System.Windows.Forms.RichTextBox();
            this.customArgsLabel = new System.Windows.Forms.Label();
            this.githubButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.locationButton = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.clearLocationButton = new System.Windows.Forms.Button();
            this.applyCodecs = new System.Windows.Forms.CheckBox();
            this.ytdlpGithubButton = new System.Windows.Forms.Button();
            this.useConfig = new System.Windows.Forms.CheckBox();
            this.resetConfig = new System.Windows.Forms.Button();
            this.gifQualityLabel = new System.Windows.Forms.Label();
            this.gifResolution = new System.Windows.Forms.TextBox();
            this.gifFramerate = new System.Windows.Forms.TextBox();
            this.rLabel = new System.Windows.Forms.Label();
            this.fLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
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
            this.inputBox.Size = new System.Drawing.Size(334, 20);
            this.inputBox.TabIndex = 2;
            this.inputBox.TextChanged += new System.EventHandler(this.inputBox_TextChanged);
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.BackColor = System.Drawing.Color.Transparent;
            this.urlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(75)))));
            this.urlLabel.Location = new System.Drawing.Point(5, 42);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(24, 12);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "URL";
            // 
            // titlebarPanel
            // 
            this.titlebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
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
            this.bannerPicture.Image = global::MediaDownloader.Properties.Resources.banner;
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
            this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.versionLabel.Location = new System.Drawing.Point(263, 24);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(38, 12);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "v3.1.0";
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
            "(raw video)",
            "mp4",
            "webm",
            "gif (convert)",
            "gif (web) (convert)",
            "",
            "[Audio]",
            "(raw audio)",
            "mp3",
            "wav",
            "ogg (convert)",
            "",
            "[Custom]",
            "(Custom Arguments)"});
            this.formatBox.Location = new System.Drawing.Point(7, 93);
            this.formatBox.Name = "formatBox";
            this.formatBox.Size = new System.Drawing.Size(121, 21);
            this.formatBox.TabIndex = 3;
            this.formatBox.SelectedIndexChanged += new System.EventHandler(this.formatBox_SelectedIndexChanged);
            // 
            // formatLabel
            // 
            this.formatLabel.AutoSize = true;
            this.formatLabel.BackColor = System.Drawing.Color.Transparent;
            this.formatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.formatLabel.Location = new System.Drawing.Point(4, 80);
            this.formatLabel.Name = "formatLabel";
            this.formatLabel.Size = new System.Drawing.Size(35, 12);
            this.formatLabel.TabIndex = 0;
            this.formatLabel.Text = "Format";
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.downloadButton.Location = new System.Drawing.Point(7, 124);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(121, 34);
            this.downloadButton.TabIndex = 4;
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
            this.advancedLabel.Location = new System.Drawing.Point(128, 79);
            this.advancedLabel.Name = "advancedLabel";
            this.advancedLabel.Size = new System.Drawing.Size(56, 13);
            this.advancedLabel.TabIndex = 0;
            this.advancedLabel.Text = "Advanced";
            // 
            // viewAvailableFormatsButton
            // 
            this.viewAvailableFormatsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.viewAvailableFormatsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewAvailableFormatsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAvailableFormatsButton.ForeColor = System.Drawing.Color.IndianRed;
            this.viewAvailableFormatsButton.Location = new System.Drawing.Point(130, 93);
            this.viewAvailableFormatsButton.Name = "viewAvailableFormatsButton";
            this.viewAvailableFormatsButton.Size = new System.Drawing.Size(51, 28);
            this.viewAvailableFormatsButton.TabIndex = 7;
            this.viewAvailableFormatsButton.Text = "View Raw Formats";
            this.viewAvailableFormatsButton.UseVisualStyleBackColor = false;
            this.viewAvailableFormatsButton.Click += new System.EventHandler(this.viewAvailableFormatsButton_Click);
            // 
            // customArgsBox
            // 
            this.customArgsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customArgsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customArgsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customArgsBox.ForeColor = System.Drawing.Color.LightCoral;
            this.customArgsBox.Location = new System.Drawing.Point(236, 93);
            this.customArgsBox.Name = "customArgsBox";
            this.customArgsBox.Size = new System.Drawing.Size(105, 60);
            this.customArgsBox.TabIndex = 14;
            this.customArgsBox.Text = "";
            this.customArgsBox.TextChanged += new System.EventHandler(this.customArgsBox_TextChanged);
            // 
            // customArgsLabel
            // 
            this.customArgsLabel.AutoSize = true;
            this.customArgsLabel.BackColor = System.Drawing.Color.Transparent;
            this.customArgsLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.customArgsLabel.Location = new System.Drawing.Point(233, 78);
            this.customArgsLabel.Name = "customArgsLabel";
            this.customArgsLabel.Size = new System.Drawing.Size(112, 13);
            this.customArgsLabel.TabIndex = 0;
            this.customArgsLabel.Text = "Custom DL Arguments";
            // 
            // githubButton
            // 
            this.githubButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.githubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.githubButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.githubButton.ForeColor = System.Drawing.Color.IndianRed;
            this.githubButton.Location = new System.Drawing.Point(183, 93);
            this.githubButton.Name = "githubButton";
            this.githubButton.Size = new System.Drawing.Size(51, 28);
            this.githubButton.TabIndex = 8;
            this.githubButton.Text = "MediaD GitHub";
            this.githubButton.UseVisualStyleBackColor = false;
            this.githubButton.Click += new System.EventHandler(this.githubButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoButton.ForeColor = System.Drawing.Color.Coral;
            this.infoButton.Location = new System.Drawing.Point(130, 124);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(51, 28);
            this.infoButton.TabIndex = 9;
            this.infoButton.Text = "Info";
            this.infoButton.UseVisualStyleBackColor = false;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // locationButton
            // 
            this.locationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.locationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.locationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.locationButton.Location = new System.Drawing.Point(7, 158);
            this.locationButton.Name = "locationButton";
            this.locationButton.Size = new System.Drawing.Size(98, 23);
            this.locationButton.TabIndex = 5;
            this.locationButton.Text = "Change Location";
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
            this.directoryLabel.TabIndex = 20;
            // 
            // clearLocationButton
            // 
            this.clearLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.clearLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearLocationButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.clearLocationButton.Location = new System.Drawing.Point(105, 158);
            this.clearLocationButton.Name = "clearLocationButton";
            this.clearLocationButton.Size = new System.Drawing.Size(23, 23);
            this.clearLocationButton.TabIndex = 6;
            this.clearLocationButton.Text = "X";
            this.clearLocationButton.UseVisualStyleBackColor = false;
            this.clearLocationButton.Click += new System.EventHandler(this.clearLocationButton_Click);
            // 
            // applyCodecs
            // 
            this.applyCodecs.AutoSize = true;
            this.applyCodecs.BackColor = System.Drawing.Color.Transparent;
            this.applyCodecs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyCodecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyCodecs.ForeColor = System.Drawing.Color.IndianRed;
            this.applyCodecs.Location = new System.Drawing.Point(130, 152);
            this.applyCodecs.Name = "applyCodecs";
            this.applyCodecs.Size = new System.Drawing.Size(105, 16);
            this.applyCodecs.TabIndex = 11;
            this.applyCodecs.Text = "Apply Video Codecs";
            this.applyCodecs.UseVisualStyleBackColor = false;
            this.applyCodecs.CheckedChanged += new System.EventHandler(this.applyCodecs_CheckedChanged);
            // 
            // ytdlpGithubButton
            // 
            this.ytdlpGithubButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ytdlpGithubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ytdlpGithubButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytdlpGithubButton.ForeColor = System.Drawing.Color.IndianRed;
            this.ytdlpGithubButton.Location = new System.Drawing.Point(183, 124);
            this.ytdlpGithubButton.Name = "ytdlpGithubButton";
            this.ytdlpGithubButton.Size = new System.Drawing.Size(51, 28);
            this.ytdlpGithubButton.TabIndex = 10;
            this.ytdlpGithubButton.Text = "yt-dlp GitHub";
            this.ytdlpGithubButton.UseVisualStyleBackColor = false;
            this.ytdlpGithubButton.Click += new System.EventHandler(this.ytdlpGithubButton_Click);
            // 
            // useConfig
            // 
            this.useConfig.AutoSize = true;
            this.useConfig.BackColor = System.Drawing.Color.Transparent;
            this.useConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.useConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useConfig.ForeColor = System.Drawing.Color.DarkCyan;
            this.useConfig.Location = new System.Drawing.Point(130, 167);
            this.useConfig.Name = "useConfig";
            this.useConfig.Size = new System.Drawing.Size(77, 16);
            this.useConfig.TabIndex = 12;
            this.useConfig.Text = "Save Options";
            this.useConfig.UseVisualStyleBackColor = false;
            this.useConfig.CheckedChanged += new System.EventHandler(this.useConfig_CheckedChanged);
            // 
            // resetConfig
            // 
            this.resetConfig.BackColor = System.Drawing.Color.Transparent;
            this.resetConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetConfig.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.resetConfig.Location = new System.Drawing.Point(206, 169);
            this.resetConfig.Name = "resetConfig";
            this.resetConfig.Size = new System.Drawing.Size(11, 11);
            this.resetConfig.TabIndex = 13;
            this.resetConfig.Text = "x";
            this.resetConfig.UseVisualStyleBackColor = false;
            this.resetConfig.Click += new System.EventHandler(this.resetConfig_Click);
            // 
            // gifQualityLabel
            // 
            this.gifQualityLabel.AutoSize = true;
            this.gifQualityLabel.BackColor = System.Drawing.Color.Transparent;
            this.gifQualityLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.gifQualityLabel.Location = new System.Drawing.Point(234, 154);
            this.gifQualityLabel.Name = "gifQualityLabel";
            this.gifQualityLabel.Size = new System.Drawing.Size(82, 13);
            this.gifQualityLabel.TabIndex = 0;
            this.gifQualityLabel.Text = "gif (web) Quality";
            // 
            // gifResolution
            // 
            this.gifResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gifResolution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gifResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifResolution.ForeColor = System.Drawing.Color.LightCoral;
            this.gifResolution.Location = new System.Drawing.Point(250, 169);
            this.gifResolution.Name = "gifResolution";
            this.gifResolution.Size = new System.Drawing.Size(31, 13);
            this.gifResolution.TabIndex = 15;
            this.gifResolution.TextChanged += new System.EventHandler(this.gifResolution_TextChanged);
            // 
            // gifFramerate
            // 
            this.gifFramerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gifFramerate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gifFramerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifFramerate.ForeColor = System.Drawing.Color.LightCoral;
            this.gifFramerate.Location = new System.Drawing.Point(299, 169);
            this.gifFramerate.Name = "gifFramerate";
            this.gifFramerate.Size = new System.Drawing.Size(31, 13);
            this.gifFramerate.TabIndex = 16;
            this.gifFramerate.TextChanged += new System.EventHandler(this.gifFramerate_TextChanged);
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.BackColor = System.Drawing.Color.Transparent;
            this.rLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.rLabel.Location = new System.Drawing.Point(235, 169);
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
            this.fLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.fLabel.Location = new System.Drawing.Point(285, 169);
            this.fLabel.Name = "fLabel";
            this.fLabel.Size = new System.Drawing.Size(14, 12);
            this.fLabel.TabIndex = 0;
            this.fLabel.Text = "F:";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.BackColor = System.Drawing.Color.Transparent;
            this.xLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.xLabel.Location = new System.Drawing.Point(217, 167);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(12, 13);
            this.xLabel.TabIndex = 0;
            this.xLabel.Text = "x";
            // 
            // program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(349, 197);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.fLabel);
            this.Controls.Add(this.rLabel);
            this.Controls.Add(this.gifFramerate);
            this.Controls.Add(this.gifResolution);
            this.Controls.Add(this.gifQualityLabel);
            this.Controls.Add(this.resetConfig);
            this.Controls.Add(this.useConfig);
            this.Controls.Add(this.ytdlpGithubButton);
            this.Controls.Add(this.applyCodecs);
            this.Controls.Add(this.clearLocationButton);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.locationButton);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.githubButton);
            this.Controls.Add(this.customArgsLabel);
            this.Controls.Add(this.customArgsBox);
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
        private System.Windows.Forms.RichTextBox customArgsBox;
        private System.Windows.Forms.Label customArgsLabel;
        private System.Windows.Forms.Button githubButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Button locationButton;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Button clearLocationButton;
        private System.Windows.Forms.CheckBox applyCodecs;
        private System.Windows.Forms.Button ytdlpGithubButton;
        private System.Windows.Forms.CheckBox useConfig;
        private System.Windows.Forms.Button resetConfig;
        private System.Windows.Forms.Label gifQualityLabel;
        private System.Windows.Forms.TextBox gifResolution;
        private System.Windows.Forms.TextBox gifFramerate;
        private System.Windows.Forms.Label rLabel;
        private System.Windows.Forms.Label fLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.PictureBox bannerPicture;
    }
}