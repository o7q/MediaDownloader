namespace MediaDownloader
{
    partial class Program
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Program));
            this.UrlTextbox = new System.Windows.Forms.TextBox();
            this.UrlLabel = new System.Windows.Forms.Label();
            this.TitlebarPanel = new System.Windows.Forms.Panel();
            this.BannerPicture = new System.Windows.Forms.PictureBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.FormatCombobox = new System.Windows.Forms.ComboBox();
            this.FormatLabel = new System.Windows.Forms.Label();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.ViewAvailableFormatsButton = new System.Windows.Forms.Button();
            this.ChangeLocationButton = new System.Windows.Forms.Button();
            this.DirectoryLabel = new System.Windows.Forms.Label();
            this.ClearLocationButton = new System.Windows.Forms.Button();
            this.UseCpuCheckbox = new System.Windows.Forms.CheckBox();
            this.UseConfigCheckbox = new System.Windows.Forms.CheckBox();
            this.ClearConfigButton = new System.Windows.Forms.Button();
            this.GifQualityLabel = new System.Windows.Forms.Label();
            this.GifResolutionTextbox = new System.Windows.Forms.TextBox();
            this.GifFramerateTextbox = new System.Windows.Forms.TextBox();
            this.GifResolutionLabel = new System.Windows.Forms.Label();
            this.GifFramerateLabel = new System.Windows.Forms.Label();
            this.ProgramToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OpenLocationButton = new System.Windows.Forms.Button();
            this.UseGpuCheckbox = new System.Windows.Forms.CheckBox();
            this.CodecLabel = new System.Windows.Forms.Label();
            this.GpuEncoderTextbox = new System.Windows.Forms.TextBox();
            this.UseTimeframeCheckbox = new System.Windows.Forms.CheckBox();
            this.TimeframeStartLabel = new System.Windows.Forms.Label();
            this.TimeframeEndLabel = new System.Windows.Forms.Label();
            this.YtdlpArgumentsTextbox = new System.Windows.Forms.RichTextBox();
            this.FilenameTextbox = new System.Windows.Forms.TextBox();
            this.YtdlpArgumentsLabel = new System.Windows.Forms.Label();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.DisplayOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.MoreOptionsLabel = new System.Windows.Forms.Label();
            this.KeepOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.VideoBitrateTextbox = new System.Windows.Forms.TextBox();
            this.BitrateLabel = new System.Windows.Forms.Label();
            this.AudioBitrateTextbox = new System.Windows.Forms.TextBox();
            this.VideoBitrateLabel = new System.Windows.Forms.Label();
            this.AudioBitrateLabel = new System.Windows.Forms.Label();
            this.TimeframeEndTextbox = new System.Windows.Forms.TextBox();
            this.TimeframeStartTextbox = new System.Windows.Forms.TextBox();
            this.TitlebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // UrlTextbox
            // 
            this.UrlTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UrlTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UrlTextbox.ForeColor = System.Drawing.Color.Silver;
            this.UrlTextbox.Location = new System.Drawing.Point(7, 55);
            this.UrlTextbox.Name = "UrlTextbox";
            this.UrlTextbox.Size = new System.Drawing.Size(228, 20);
            this.UrlTextbox.TabIndex = 2;
            this.UrlTextbox.TextChanged += new System.EventHandler(this.UrlTextbox_TextChanged);
            // 
            // UrlLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.BackColor = System.Drawing.Color.Transparent;
            this.UrlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrlLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(75)))));
            this.UrlLabel.Location = new System.Drawing.Point(3, 41);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(29, 13);
            this.UrlLabel.TabIndex = 0;
            this.UrlLabel.Text = "URL";
            // 
            // TitlebarPanel
            // 
            this.TitlebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(16)))));
            this.TitlebarPanel.Controls.Add(this.BannerPicture);
            this.TitlebarPanel.Controls.Add(this.VersionLabel);
            this.TitlebarPanel.Controls.Add(this.MinimizeButton);
            this.TitlebarPanel.Controls.Add(this.ExitButton);
            this.TitlebarPanel.Location = new System.Drawing.Point(-9, -5);
            this.TitlebarPanel.Name = "TitlebarPanel";
            this.TitlebarPanel.Size = new System.Drawing.Size(362, 40);
            this.TitlebarPanel.TabIndex = 0;
            this.TitlebarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlebarPanel_MouseDown);
            // 
            // BannerPicture
            // 
            this.BannerPicture.BackColor = System.Drawing.Color.Transparent;
            this.BannerPicture.Image = ((System.Drawing.Image)(resources.GetObject("BannerPicture.Image")));
            this.BannerPicture.Location = new System.Drawing.Point(11, 5);
            this.BannerPicture.Name = "BannerPicture";
            this.BannerPicture.Size = new System.Drawing.Size(158, 33);
            this.BannerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BannerPicture.TabIndex = 0;
            this.BannerPicture.TabStop = false;
            this.BannerPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BannerPicture_MouseDown);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.VersionLabel.Location = new System.Drawing.Point(261, 25);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(38, 12);
            this.VersionLabel.TabIndex = 0;
            this.VersionLabel.Text = "v0.0.0";
            this.VersionLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VersionLabel_MouseDown);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MinimizeButton.Location = new System.Drawing.Point(299, 10);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(25, 25);
            this.MinimizeButton.TabIndex = 0;
            this.MinimizeButton.Text = "_";
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExitButton.Location = new System.Drawing.Point(326, 10);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(25, 25);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "❌";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // FormatCombobox
            // 
            this.FormatCombobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormatCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormatCombobox.ForeColor = System.Drawing.Color.Silver;
            this.FormatCombobox.FormattingEnabled = true;
            this.FormatCombobox.ItemHeight = 13;
            this.FormatCombobox.Items.AddRange(new object[] {
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
            this.FormatCombobox.Location = new System.Drawing.Point(7, 93);
            this.FormatCombobox.Name = "FormatCombobox";
            this.FormatCombobox.Size = new System.Drawing.Size(99, 21);
            this.FormatCombobox.TabIndex = 4;
            this.FormatCombobox.SelectedIndexChanged += new System.EventHandler(this.FormatCombobox_SelectedIndexChanged);
            // 
            // FormatLabel
            // 
            this.FormatLabel.AutoSize = true;
            this.FormatLabel.BackColor = System.Drawing.Color.Transparent;
            this.FormatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.FormatLabel.Location = new System.Drawing.Point(3, 79);
            this.FormatLabel.Name = "FormatLabel";
            this.FormatLabel.Size = new System.Drawing.Size(39, 13);
            this.FormatLabel.TabIndex = 0;
            this.FormatLabel.Text = "Format";
            // 
            // DownloadButton
            // 
            this.DownloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.DownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.DownloadButton.Image = ((System.Drawing.Image)(resources.GetObject("DownloadButton.Image")));
            this.DownloadButton.Location = new System.Drawing.Point(7, 145);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(120, 34);
            this.DownloadButton.TabIndex = 9;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = false;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // ViewAvailableFormatsButton
            // 
            this.ViewAvailableFormatsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ViewAvailableFormatsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewAvailableFormatsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewAvailableFormatsButton.ForeColor = System.Drawing.Color.Silver;
            this.ViewAvailableFormatsButton.Location = new System.Drawing.Point(106, 93);
            this.ViewAvailableFormatsButton.Name = "ViewAvailableFormatsButton";
            this.ViewAvailableFormatsButton.Size = new System.Drawing.Size(21, 21);
            this.ViewAvailableFormatsButton.TabIndex = 5;
            this.ViewAvailableFormatsButton.Text = "?";
            this.ViewAvailableFormatsButton.UseVisualStyleBackColor = false;
            this.ViewAvailableFormatsButton.Click += new System.EventHandler(this.ViewAvailableFormatsButton_Click);
            // 
            // ChangeLocationButton
            // 
            this.ChangeLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ChangeLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeLocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeLocationButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.ChangeLocationButton.Location = new System.Drawing.Point(7, 179);
            this.ChangeLocationButton.Name = "ChangeLocationButton";
            this.ChangeLocationButton.Size = new System.Drawing.Size(76, 23);
            this.ChangeLocationButton.TabIndex = 10;
            this.ChangeLocationButton.Text = "Change Folder";
            this.ChangeLocationButton.UseVisualStyleBackColor = false;
            this.ChangeLocationButton.Click += new System.EventHandler(this.ChangeLocationButton_Click);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.BackColor = System.Drawing.Color.Transparent;
            this.DirectoryLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DirectoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.DirectoryLabel.Location = new System.Drawing.Point(4, 202);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(114, 12);
            this.DirectoryLabel.TabIndex = 0;
            this.DirectoryLabel.Text = "DOWNLOAD_LOCATION";
            // 
            // ClearLocationButton
            // 
            this.ClearLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClearLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearLocationButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.ClearLocationButton.Location = new System.Drawing.Point(104, 179);
            this.ClearLocationButton.Name = "ClearLocationButton";
            this.ClearLocationButton.Size = new System.Drawing.Size(23, 23);
            this.ClearLocationButton.TabIndex = 12;
            this.ClearLocationButton.Text = "❌";
            this.ClearLocationButton.UseVisualStyleBackColor = false;
            this.ClearLocationButton.Click += new System.EventHandler(this.ClearLocationButton_Click);
            // 
            // UseCpuCheckbox
            // 
            this.UseCpuCheckbox.AutoSize = true;
            this.UseCpuCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.UseCpuCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UseCpuCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseCpuCheckbox.ForeColor = System.Drawing.Color.MediumPurple;
            this.UseCpuCheckbox.Location = new System.Drawing.Point(131, 172);
            this.UseCpuCheckbox.Name = "UseCpuCheckbox";
            this.UseCpuCheckbox.Size = new System.Drawing.Size(106, 16);
            this.UseCpuCheckbox.TabIndex = 19;
            this.UseCpuCheckbox.Text = "Encode Video (CPU)";
            this.UseCpuCheckbox.UseVisualStyleBackColor = false;
            this.UseCpuCheckbox.CheckedChanged += new System.EventHandler(this.UseCpuCheckbox_CheckedChanged);
            // 
            // UseConfigCheckbox
            // 
            this.UseConfigCheckbox.AutoSize = true;
            this.UseConfigCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.UseConfigCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UseConfigCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseConfigCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.UseConfigCheckbox.Location = new System.Drawing.Point(238, 77);
            this.UseConfigCheckbox.Name = "UseConfigCheckbox";
            this.UseConfigCheckbox.Size = new System.Drawing.Size(77, 16);
            this.UseConfigCheckbox.TabIndex = 23;
            this.UseConfigCheckbox.Text = "Save Options";
            this.UseConfigCheckbox.UseVisualStyleBackColor = false;
            this.UseConfigCheckbox.CheckedChanged += new System.EventHandler(this.UseConfigCheckbox_CheckedChanged);
            // 
            // ClearConfigButton
            // 
            this.ClearConfigButton.BackColor = System.Drawing.Color.Transparent;
            this.ClearConfigButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearConfigButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearConfigButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClearConfigButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearConfigButton.Image")));
            this.ClearConfigButton.Location = new System.Drawing.Point(313, 79);
            this.ClearConfigButton.Name = "ClearConfigButton";
            this.ClearConfigButton.Size = new System.Drawing.Size(11, 11);
            this.ClearConfigButton.TabIndex = 24;
            this.ClearConfigButton.UseVisualStyleBackColor = false;
            this.ClearConfigButton.Click += new System.EventHandler(this.ClearConfigButton_Click);
            // 
            // GifQualityLabel
            // 
            this.GifQualityLabel.AutoSize = true;
            this.GifQualityLabel.BackColor = System.Drawing.Color.Transparent;
            this.GifQualityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GifQualityLabel.ForeColor = System.Drawing.Color.Gold;
            this.GifQualityLabel.Location = new System.Drawing.Point(129, 118);
            this.GifQualityLabel.Name = "GifQualityLabel";
            this.GifQualityLabel.Size = new System.Drawing.Size(46, 12);
            this.GifQualityLabel.TabIndex = 0;
            this.GifQualityLabel.Text = "gif Quality";
            // 
            // GifResolutionTextbox
            // 
            this.GifResolutionTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GifResolutionTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GifResolutionTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GifResolutionTextbox.ForeColor = System.Drawing.Color.Khaki;
            this.GifResolutionTextbox.Location = new System.Drawing.Point(145, 130);
            this.GifResolutionTextbox.Name = "GifResolutionTextbox";
            this.GifResolutionTextbox.Size = new System.Drawing.Size(35, 13);
            this.GifResolutionTextbox.TabIndex = 15;
            this.GifResolutionTextbox.TextChanged += new System.EventHandler(this.GifResolutionTextbox_TextChanged);
            // 
            // GifFramerateTextbox
            // 
            this.GifFramerateTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GifFramerateTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GifFramerateTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GifFramerateTextbox.ForeColor = System.Drawing.Color.Khaki;
            this.GifFramerateTextbox.Location = new System.Drawing.Point(199, 130);
            this.GifFramerateTextbox.Name = "GifFramerateTextbox";
            this.GifFramerateTextbox.Size = new System.Drawing.Size(35, 13);
            this.GifFramerateTextbox.TabIndex = 16;
            this.GifFramerateTextbox.TextChanged += new System.EventHandler(this.GifFramerateTextbox_TextChanged);
            // 
            // GifResolutionLabel
            // 
            this.GifResolutionLabel.AutoSize = true;
            this.GifResolutionLabel.BackColor = System.Drawing.Color.Transparent;
            this.GifResolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GifResolutionLabel.ForeColor = System.Drawing.Color.Khaki;
            this.GifResolutionLabel.Location = new System.Drawing.Point(128, 130);
            this.GifResolutionLabel.Name = "GifResolutionLabel";
            this.GifResolutionLabel.Size = new System.Drawing.Size(15, 12);
            this.GifResolutionLabel.TabIndex = 0;
            this.GifResolutionLabel.Text = "R:";
            // 
            // GifFramerateLabel
            // 
            this.GifFramerateLabel.AutoSize = true;
            this.GifFramerateLabel.BackColor = System.Drawing.Color.Transparent;
            this.GifFramerateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GifFramerateLabel.ForeColor = System.Drawing.Color.Khaki;
            this.GifFramerateLabel.Location = new System.Drawing.Point(183, 130);
            this.GifFramerateLabel.Name = "GifFramerateLabel";
            this.GifFramerateLabel.Size = new System.Drawing.Size(14, 12);
            this.GifFramerateLabel.TabIndex = 0;
            this.GifFramerateLabel.Text = "F:";
            // 
            // OpenLocationButton
            // 
            this.OpenLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.OpenLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenLocationButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.OpenLocationButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenLocationButton.Image")));
            this.OpenLocationButton.Location = new System.Drawing.Point(82, 179);
            this.OpenLocationButton.Name = "OpenLocationButton";
            this.OpenLocationButton.Size = new System.Drawing.Size(23, 23);
            this.OpenLocationButton.TabIndex = 11;
            this.OpenLocationButton.UseVisualStyleBackColor = false;
            this.OpenLocationButton.Click += new System.EventHandler(this.OpenLocationButton_Click);
            // 
            // UseGpuCheckbox
            // 
            this.UseGpuCheckbox.AutoSize = true;
            this.UseGpuCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.UseGpuCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UseGpuCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseGpuCheckbox.ForeColor = System.Drawing.Color.YellowGreen;
            this.UseGpuCheckbox.Location = new System.Drawing.Point(131, 143);
            this.UseGpuCheckbox.Name = "UseGpuCheckbox";
            this.UseGpuCheckbox.Size = new System.Drawing.Size(106, 16);
            this.UseGpuCheckbox.TabIndex = 17;
            this.UseGpuCheckbox.Text = "Encode Video (GPU)";
            this.UseGpuCheckbox.UseVisualStyleBackColor = false;
            this.UseGpuCheckbox.CheckedChanged += new System.EventHandler(this.UseGpuCheckbox_CheckedChanged);
            // 
            // CodecLabel
            // 
            this.CodecLabel.AutoSize = true;
            this.CodecLabel.BackColor = System.Drawing.Color.Transparent;
            this.CodecLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodecLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.CodecLabel.Location = new System.Drawing.Point(128, 158);
            this.CodecLabel.Name = "CodecLabel";
            this.CodecLabel.Size = new System.Drawing.Size(42, 12);
            this.CodecLabel.TabIndex = 0;
            this.CodecLabel.Text = "Encoder:";
            // 
            // GpuEncoderTextbox
            // 
            this.GpuEncoderTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GpuEncoderTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GpuEncoderTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GpuEncoderTextbox.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.GpuEncoderTextbox.Location = new System.Drawing.Point(171, 158);
            this.GpuEncoderTextbox.Name = "GpuEncoderTextbox";
            this.GpuEncoderTextbox.Size = new System.Drawing.Size(64, 13);
            this.GpuEncoderTextbox.TabIndex = 18;
            this.GpuEncoderTextbox.TextChanged += new System.EventHandler(this.GpuEncoderTextbox_TextChanged);
            // 
            // UseTimeframeCheckbox
            // 
            this.UseTimeframeCheckbox.AutoSize = true;
            this.UseTimeframeCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.UseTimeframeCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UseTimeframeCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseTimeframeCheckbox.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.UseTimeframeCheckbox.Location = new System.Drawing.Point(7, 114);
            this.UseTimeframeCheckbox.Name = "UseTimeframeCheckbox";
            this.UseTimeframeCheckbox.Size = new System.Drawing.Size(111, 16);
            this.UseTimeframeCheckbox.TabIndex = 6;
            this.UseTimeframeCheckbox.Text = "Trim Length Between:";
            this.UseTimeframeCheckbox.UseVisualStyleBackColor = false;
            this.UseTimeframeCheckbox.CheckedChanged += new System.EventHandler(this.UseTimeframeCheckbox_CheckedChanged);
            // 
            // TimeframeStartLabel
            // 
            this.TimeframeStartLabel.AutoSize = true;
            this.TimeframeStartLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimeframeStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeframeStartLabel.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.TimeframeStartLabel.Location = new System.Drawing.Point(4, 130);
            this.TimeframeStartLabel.Name = "TimeframeStartLabel";
            this.TimeframeStartLabel.Size = new System.Drawing.Size(14, 12);
            this.TimeframeStartLabel.TabIndex = 0;
            this.TimeframeStartLabel.Text = "S:";
            // 
            // TimeframeEndLabel
            // 
            this.TimeframeEndLabel.AutoSize = true;
            this.TimeframeEndLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimeframeEndLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeframeEndLabel.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.TimeframeEndLabel.Location = new System.Drawing.Point(67, 130);
            this.TimeframeEndLabel.Name = "TimeframeEndLabel";
            this.TimeframeEndLabel.Size = new System.Drawing.Size(14, 12);
            this.TimeframeEndLabel.TabIndex = 0;
            this.TimeframeEndLabel.Text = "E:";
            // 
            // YtdlpArgumentsTextbox
            // 
            this.YtdlpArgumentsTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.YtdlpArgumentsTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.YtdlpArgumentsTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YtdlpArgumentsTextbox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.YtdlpArgumentsTextbox.Location = new System.Drawing.Point(240, 104);
            this.YtdlpArgumentsTextbox.Name = "YtdlpArgumentsTextbox";
            this.YtdlpArgumentsTextbox.Size = new System.Drawing.Size(100, 56);
            this.YtdlpArgumentsTextbox.TabIndex = 20;
            this.YtdlpArgumentsTextbox.Text = "";
            this.YtdlpArgumentsTextbox.TextChanged += new System.EventHandler(this.YtdlpArgumentsTextbox_TextChanged);
            this.YtdlpArgumentsTextbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.YtdlpArgumentsTextbox_MouseDoubleClick);
            // 
            // FilenameTextbox
            // 
            this.FilenameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FilenameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilenameTextbox.ForeColor = System.Drawing.Color.Silver;
            this.FilenameTextbox.Location = new System.Drawing.Point(238, 55);
            this.FilenameTextbox.Name = "FilenameTextbox";
            this.FilenameTextbox.Size = new System.Drawing.Size(103, 20);
            this.FilenameTextbox.TabIndex = 3;
            this.FilenameTextbox.TextChanged += new System.EventHandler(this.FilenameTextbox_TextChanged);
            // 
            // YtdlpArgumentsLabel
            // 
            this.YtdlpArgumentsLabel.AutoSize = true;
            this.YtdlpArgumentsLabel.BackColor = System.Drawing.Color.Transparent;
            this.YtdlpArgumentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YtdlpArgumentsLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.YtdlpArgumentsLabel.Location = new System.Drawing.Point(238, 90);
            this.YtdlpArgumentsLabel.Name = "YtdlpArgumentsLabel";
            this.YtdlpArgumentsLabel.Size = new System.Drawing.Size(76, 12);
            this.YtdlpArgumentsLabel.TabIndex = 0;
            this.YtdlpArgumentsLabel.Text = "yt-dlp Arguments";
            this.YtdlpArgumentsLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.YtdlpArgumentsLabel_MouseDoubleClick);
            // 
            // FilenameLabel
            // 
            this.FilenameLabel.AutoSize = true;
            this.FilenameLabel.BackColor = System.Drawing.Color.Transparent;
            this.FilenameLabel.ForeColor = System.Drawing.Color.SeaGreen;
            this.FilenameLabel.Location = new System.Drawing.Point(234, 41);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(49, 13);
            this.FilenameLabel.TabIndex = 0;
            this.FilenameLabel.Text = "Filename";
            // 
            // DisplayOutputCheckbox
            // 
            this.DisplayOutputCheckbox.AutoSize = true;
            this.DisplayOutputCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.DisplayOutputCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisplayOutputCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayOutputCheckbox.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.DisplayOutputCheckbox.Location = new System.Drawing.Point(239, 172);
            this.DisplayOutputCheckbox.Name = "DisplayOutputCheckbox";
            this.DisplayOutputCheckbox.Size = new System.Drawing.Size(52, 16);
            this.DisplayOutputCheckbox.TabIndex = 21;
            this.DisplayOutputCheckbox.Text = "Display";
            this.DisplayOutputCheckbox.UseVisualStyleBackColor = false;
            this.DisplayOutputCheckbox.CheckedChanged += new System.EventHandler(this.DisplayOutputCheckbox_CheckedChanged);
            // 
            // MoreOptionsLabel
            // 
            this.MoreOptionsLabel.AutoSize = true;
            this.MoreOptionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.MoreOptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoreOptionsLabel.ForeColor = System.Drawing.Color.Brown;
            this.MoreOptionsLabel.Location = new System.Drawing.Point(127, 79);
            this.MoreOptionsLabel.Name = "MoreOptionsLabel";
            this.MoreOptionsLabel.Size = new System.Drawing.Size(70, 13);
            this.MoreOptionsLabel.TabIndex = 0;
            this.MoreOptionsLabel.Text = "More Options";
            // 
            // KeepOutputCheckbox
            // 
            this.KeepOutputCheckbox.AutoSize = true;
            this.KeepOutputCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.KeepOutputCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KeepOutputCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeepOutputCheckbox.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.KeepOutputCheckbox.Location = new System.Drawing.Point(293, 172);
            this.KeepOutputCheckbox.Name = "KeepOutputCheckbox";
            this.KeepOutputCheckbox.Size = new System.Drawing.Size(42, 16);
            this.KeepOutputCheckbox.TabIndex = 22;
            this.KeepOutputCheckbox.Text = "Keep";
            this.KeepOutputCheckbox.UseVisualStyleBackColor = false;
            this.KeepOutputCheckbox.CheckedChanged += new System.EventHandler(this.KeepOutputCheckbox_CheckedChanged);
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.BackColor = System.Drawing.Color.Transparent;
            this.OutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputLabel.ForeColor = System.Drawing.Color.DarkCyan;
            this.OutputLabel.Location = new System.Drawing.Point(236, 161);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(84, 12);
            this.OutputLabel.TabIndex = 0;
            this.OutputLabel.Text = "Output Log Options";
            // 
            // VideoBitrateTextbox
            // 
            this.VideoBitrateTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.VideoBitrateTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VideoBitrateTextbox.ForeColor = System.Drawing.Color.Goldenrod;
            this.VideoBitrateTextbox.Location = new System.Drawing.Point(145, 104);
            this.VideoBitrateTextbox.Name = "VideoBitrateTextbox";
            this.VideoBitrateTextbox.Size = new System.Drawing.Size(35, 13);
            this.VideoBitrateTextbox.TabIndex = 13;
            this.VideoBitrateTextbox.TextChanged += new System.EventHandler(this.VideoBitrateTextbox_TextChanged);
            // 
            // BitrateLabel
            // 
            this.BitrateLabel.AutoSize = true;
            this.BitrateLabel.BackColor = System.Drawing.Color.Transparent;
            this.BitrateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BitrateLabel.ForeColor = System.Drawing.Color.Orange;
            this.BitrateLabel.Location = new System.Drawing.Point(128, 92);
            this.BitrateLabel.Name = "BitrateLabel";
            this.BitrateLabel.Size = new System.Drawing.Size(81, 12);
            this.BitrateLabel.TabIndex = 0;
            this.BitrateLabel.Text = "Bitrate for Encoder";
            // 
            // AudioBitrateTextbox
            // 
            this.AudioBitrateTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AudioBitrateTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AudioBitrateTextbox.ForeColor = System.Drawing.Color.Goldenrod;
            this.AudioBitrateTextbox.Location = new System.Drawing.Point(199, 104);
            this.AudioBitrateTextbox.Name = "AudioBitrateTextbox";
            this.AudioBitrateTextbox.Size = new System.Drawing.Size(35, 13);
            this.AudioBitrateTextbox.TabIndex = 14;
            this.AudioBitrateTextbox.TextChanged += new System.EventHandler(this.AudioBitrateTextbox_TextChanged);
            // 
            // VideoBitrateLabel
            // 
            this.VideoBitrateLabel.AutoSize = true;
            this.VideoBitrateLabel.BackColor = System.Drawing.Color.Transparent;
            this.VideoBitrateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoBitrateLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.VideoBitrateLabel.Location = new System.Drawing.Point(129, 104);
            this.VideoBitrateLabel.Name = "VideoBitrateLabel";
            this.VideoBitrateLabel.Size = new System.Drawing.Size(15, 12);
            this.VideoBitrateLabel.TabIndex = 0;
            this.VideoBitrateLabel.Text = "V:";
            // 
            // AudioBitrateLabel
            // 
            this.AudioBitrateLabel.AutoSize = true;
            this.AudioBitrateLabel.BackColor = System.Drawing.Color.Transparent;
            this.AudioBitrateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioBitrateLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.AudioBitrateLabel.Location = new System.Drawing.Point(183, 104);
            this.AudioBitrateLabel.Name = "AudioBitrateLabel";
            this.AudioBitrateLabel.Size = new System.Drawing.Size(15, 12);
            this.AudioBitrateLabel.TabIndex = 0;
            this.AudioBitrateLabel.Text = "A:";
            // 
            // TimeframeEndTextbox
            // 
            this.TimeframeEndTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TimeframeEndTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeframeEndTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeframeEndTextbox.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.TimeframeEndTextbox.Location = new System.Drawing.Point(81, 130);
            this.TimeframeEndTextbox.Name = "TimeframeEndTextbox";
            this.TimeframeEndTextbox.Size = new System.Drawing.Size(45, 13);
            this.TimeframeEndTextbox.TabIndex = 8;
            this.TimeframeEndTextbox.TextChanged += new System.EventHandler(this.TimeframeEndTextbox_TextChanged);
            // 
            // TimeframeStartTextbox
            // 
            this.TimeframeStartTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TimeframeStartTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeframeStartTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeframeStartTextbox.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.TimeframeStartTextbox.Location = new System.Drawing.Point(18, 130);
            this.TimeframeStartTextbox.Name = "TimeframeStartTextbox";
            this.TimeframeStartTextbox.Size = new System.Drawing.Size(46, 13);
            this.TimeframeStartTextbox.TabIndex = 7;
            this.TimeframeStartTextbox.TextChanged += new System.EventHandler(this.TimeframeStartTextbox_TextChanged);
            // 
            // Program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BackgroundImage = global::MediaDownloader.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(347, 214);
            this.Controls.Add(this.AudioBitrateLabel);
            this.Controls.Add(this.VideoBitrateLabel);
            this.Controls.Add(this.AudioBitrateTextbox);
            this.Controls.Add(this.BitrateLabel);
            this.Controls.Add(this.VideoBitrateTextbox);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.KeepOutputCheckbox);
            this.Controls.Add(this.DisplayOutputCheckbox);
            this.Controls.Add(this.FilenameLabel);
            this.Controls.Add(this.YtdlpArgumentsLabel);
            this.Controls.Add(this.FilenameTextbox);
            this.Controls.Add(this.ClearConfigButton);
            this.Controls.Add(this.UseConfigCheckbox);
            this.Controls.Add(this.YtdlpArgumentsTextbox);
            this.Controls.Add(this.TimeframeEndLabel);
            this.Controls.Add(this.TimeframeStartLabel);
            this.Controls.Add(this.UseTimeframeCheckbox);
            this.Controls.Add(this.TimeframeEndTextbox);
            this.Controls.Add(this.TimeframeStartTextbox);
            this.Controls.Add(this.GpuEncoderTextbox);
            this.Controls.Add(this.CodecLabel);
            this.Controls.Add(this.UseGpuCheckbox);
            this.Controls.Add(this.OpenLocationButton);
            this.Controls.Add(this.GifFramerateLabel);
            this.Controls.Add(this.GifResolutionLabel);
            this.Controls.Add(this.GifFramerateTextbox);
            this.Controls.Add(this.GifResolutionTextbox);
            this.Controls.Add(this.GifQualityLabel);
            this.Controls.Add(this.UseCpuCheckbox);
            this.Controls.Add(this.ClearLocationButton);
            this.Controls.Add(this.DirectoryLabel);
            this.Controls.Add(this.ChangeLocationButton);
            this.Controls.Add(this.ViewAvailableFormatsButton);
            this.Controls.Add(this.MoreOptionsLabel);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.FormatLabel);
            this.Controls.Add(this.FormatCombobox);
            this.Controls.Add(this.TitlebarPanel);
            this.Controls.Add(this.UrlLabel);
            this.Controls.Add(this.UrlTextbox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Program";
            this.Text = "MediaDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Program_FormClosing);
            this.Load += new System.EventHandler(this.Program_Load);
            this.TitlebarPanel.ResumeLayout(false);
            this.TitlebarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UrlTextbox;
        private System.Windows.Forms.Label UrlLabel;
        private System.Windows.Forms.Panel TitlebarPanel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.ComboBox FormatCombobox;
        private System.Windows.Forms.Label FormatLabel;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button ViewAvailableFormatsButton;
        private System.Windows.Forms.Button ChangeLocationButton;
        private System.Windows.Forms.Label DirectoryLabel;
        private System.Windows.Forms.Button ClearLocationButton;
        private System.Windows.Forms.CheckBox UseCpuCheckbox;
        private System.Windows.Forms.CheckBox UseConfigCheckbox;
        private System.Windows.Forms.Button ClearConfigButton;
        private System.Windows.Forms.Label GifQualityLabel;
        private System.Windows.Forms.TextBox GifResolutionTextbox;
        private System.Windows.Forms.TextBox GifFramerateTextbox;
        private System.Windows.Forms.Label GifResolutionLabel;
        private System.Windows.Forms.Label GifFramerateLabel;
        private System.Windows.Forms.PictureBox BannerPicture;
        private System.Windows.Forms.ToolTip ProgramToolTip;
        private System.Windows.Forms.Button OpenLocationButton;
        private System.Windows.Forms.CheckBox UseGpuCheckbox;
        private System.Windows.Forms.Label CodecLabel;
        private System.Windows.Forms.TextBox GpuEncoderTextbox;
        private System.Windows.Forms.CheckBox UseTimeframeCheckbox;
        private System.Windows.Forms.Label TimeframeStartLabel;
        private System.Windows.Forms.Label TimeframeEndLabel;
        private System.Windows.Forms.RichTextBox YtdlpArgumentsTextbox;
        private System.Windows.Forms.TextBox FilenameTextbox;
        private System.Windows.Forms.Label YtdlpArgumentsLabel;
        private System.Windows.Forms.Label FilenameLabel;
        private System.Windows.Forms.CheckBox DisplayOutputCheckbox;
        private System.Windows.Forms.Label MoreOptionsLabel;
        private System.Windows.Forms.CheckBox KeepOutputCheckbox;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.TextBox VideoBitrateTextbox;
        private System.Windows.Forms.Label BitrateLabel;
        private System.Windows.Forms.TextBox AudioBitrateTextbox;
        private System.Windows.Forms.Label VideoBitrateLabel;
        private System.Windows.Forms.Label AudioBitrateLabel;
        private System.Windows.Forms.TextBox TimeframeEndTextbox;
        private System.Windows.Forms.TextBox TimeframeStartTextbox;
    }
}