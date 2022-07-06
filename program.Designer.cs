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
            this.inputbox = new System.Windows.Forms.TextBox();
            this.titlelabel = new System.Windows.Forms.Label();
            this.byo7qlabel = new System.Windows.Forms.Label();
            this.urllabel = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.titlebarpanel = new System.Windows.Forms.Panel();
            this.versionlabel = new System.Windows.Forms.Label();
            this.minimizebutton = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.formatbox = new System.Windows.Forms.ComboBox();
            this.formatlabel = new System.Windows.Forms.Label();
            this.downloadbutton = new System.Windows.Forms.Button();
            this.advancedlabel = new System.Windows.Forms.Label();
            this.viewavailableformatsbutton = new System.Windows.Forms.Button();
            this.customargsbox = new System.Windows.Forms.RichTextBox();
            this.customargslabel = new System.Windows.Forms.Label();
            this.githubbutton = new System.Windows.Forms.Button();
            this.infobutton = new System.Windows.Forms.Button();
            this.locationButton = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.clearLocationButton = new System.Windows.Forms.Button();
            this.applycodecs = new System.Windows.Forms.CheckBox();
            this.ytdlpgithubbutton = new System.Windows.Forms.Button();
            this.slowwarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.titlebarpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputbox
            // 
            this.inputbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.inputbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputbox.ForeColor = System.Drawing.Color.Silver;
            this.inputbox.Location = new System.Drawing.Point(7, 55);
            this.inputbox.Name = "inputbox";
            this.inputbox.Size = new System.Drawing.Size(334, 20);
            this.inputbox.TabIndex = 0;
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.BackColor = System.Drawing.Color.Transparent;
            this.titlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.titlelabel.Location = new System.Drawing.Point(36, 11);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(185, 25);
            this.titlelabel.TabIndex = 3;
            this.titlelabel.Text = "MediaDownloader";
            this.titlelabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlelabel_MouseMove);
            // 
            // byo7qlabel
            // 
            this.byo7qlabel.AutoSize = true;
            this.byo7qlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byo7qlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.byo7qlabel.Location = new System.Drawing.Point(238, 20);
            this.byo7qlabel.Name = "byo7qlabel";
            this.byo7qlabel.Size = new System.Drawing.Size(39, 13);
            this.byo7qlabel.TabIndex = 4;
            this.byo7qlabel.Text = "by o7q";
            this.byo7qlabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.byo7qlabel_MouseMove);
            // 
            // urllabel
            // 
            this.urllabel.AutoSize = true;
            this.urllabel.BackColor = System.Drawing.Color.Transparent;
            this.urllabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urllabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(128)))), ((int)(((byte)(75)))));
            this.urllabel.Location = new System.Drawing.Point(5, 42);
            this.urllabel.Name = "urllabel";
            this.urllabel.Size = new System.Drawing.Size(24, 12);
            this.urllabel.TabIndex = 5;
            this.urllabel.Text = "URL";
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(12, 11);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(28, 25);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 7;
            this.logo.TabStop = false;
            this.logo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.logo_MouseMove);
            // 
            // titlebarpanel
            // 
            this.titlebarpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.titlebarpanel.Controls.Add(this.versionlabel);
            this.titlebarpanel.Controls.Add(this.minimizebutton);
            this.titlebarpanel.Controls.Add(this.exitbutton);
            this.titlebarpanel.Controls.Add(this.logo);
            this.titlebarpanel.Controls.Add(this.titlelabel);
            this.titlebarpanel.Controls.Add(this.byo7qlabel);
            this.titlebarpanel.Location = new System.Drawing.Point(-9, -5);
            this.titlebarpanel.Name = "titlebarpanel";
            this.titlebarpanel.Size = new System.Drawing.Size(362, 40);
            this.titlebarpanel.TabIndex = 9;
            this.titlebarpanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebarpanel_MouseMove);
            // 
            // versionlabel
            // 
            this.versionlabel.AutoSize = true;
            this.versionlabel.BackColor = System.Drawing.Color.Transparent;
            this.versionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.versionlabel.Location = new System.Drawing.Point(213, 21);
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(28, 12);
            this.versionlabel.TabIndex = 10;
            this.versionlabel.Text = "v2.5";
            this.versionlabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.versionlabel_MouseMove);
            // 
            // minimizebutton
            // 
            this.minimizebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizebutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.minimizebutton.Location = new System.Drawing.Point(301, 10);
            this.minimizebutton.Name = "minimizebutton";
            this.minimizebutton.Size = new System.Drawing.Size(25, 25);
            this.minimizebutton.TabIndex = 11;
            this.minimizebutton.Text = "_";
            this.minimizebutton.UseVisualStyleBackColor = true;
            this.minimizebutton.Click += new System.EventHandler(this.minimizebutton_Click);
            // 
            // exitbutton
            // 
            this.exitbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exitbutton.Location = new System.Drawing.Point(328, 10);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(25, 25);
            this.exitbutton.TabIndex = 10;
            this.exitbutton.Text = "❌";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // formatbox
            // 
            this.formatbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.formatbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formatbox.ForeColor = System.Drawing.Color.Silver;
            this.formatbox.FormattingEnabled = true;
            this.formatbox.Items.AddRange(new object[] {
            "[Video]",
            "(raw video)",
            "mp4",
            "webm",
            "",
            "[Audio]",
            "(raw audio)",
            "mp3",
            "wav",
            "m4a",
            "",
            "[Custom]",
            "(Custom Arguments)"});
            this.formatbox.Location = new System.Drawing.Point(7, 93);
            this.formatbox.Name = "formatbox";
            this.formatbox.Size = new System.Drawing.Size(121, 21);
            this.formatbox.TabIndex = 10;
            // 
            // formatlabel
            // 
            this.formatlabel.AutoSize = true;
            this.formatlabel.BackColor = System.Drawing.Color.Transparent;
            this.formatlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(128)))));
            this.formatlabel.Location = new System.Drawing.Point(4, 80);
            this.formatlabel.Name = "formatlabel";
            this.formatlabel.Size = new System.Drawing.Size(35, 12);
            this.formatlabel.TabIndex = 11;
            this.formatlabel.Text = "Format";
            // 
            // downloadbutton
            // 
            this.downloadbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.downloadbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadbutton.ForeColor = System.Drawing.Color.LimeGreen;
            this.downloadbutton.Location = new System.Drawing.Point(7, 124);
            this.downloadbutton.Name = "downloadbutton";
            this.downloadbutton.Size = new System.Drawing.Size(121, 34);
            this.downloadbutton.TabIndex = 12;
            this.downloadbutton.Text = "Download";
            this.downloadbutton.UseVisualStyleBackColor = false;
            this.downloadbutton.Click += new System.EventHandler(this.downloadbutton_Click);
            // 
            // advancedlabel
            // 
            this.advancedlabel.AutoSize = true;
            this.advancedlabel.BackColor = System.Drawing.Color.Transparent;
            this.advancedlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advancedlabel.ForeColor = System.Drawing.Color.Brown;
            this.advancedlabel.Location = new System.Drawing.Point(128, 79);
            this.advancedlabel.Name = "advancedlabel";
            this.advancedlabel.Size = new System.Drawing.Size(56, 13);
            this.advancedlabel.TabIndex = 13;
            this.advancedlabel.Text = "Advanced";
            // 
            // viewavailableformatsbutton
            // 
            this.viewavailableformatsbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.viewavailableformatsbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewavailableformatsbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewavailableformatsbutton.ForeColor = System.Drawing.Color.IndianRed;
            this.viewavailableformatsbutton.Location = new System.Drawing.Point(130, 93);
            this.viewavailableformatsbutton.Name = "viewavailableformatsbutton";
            this.viewavailableformatsbutton.Size = new System.Drawing.Size(51, 28);
            this.viewavailableformatsbutton.TabIndex = 14;
            this.viewavailableformatsbutton.Text = "View Raw Formats";
            this.viewavailableformatsbutton.UseVisualStyleBackColor = false;
            this.viewavailableformatsbutton.Click += new System.EventHandler(this.viewavailableformatsbutton_Click);
            // 
            // customargsbox
            // 
            this.customargsbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customargsbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customargsbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customargsbox.ForeColor = System.Drawing.Color.LightCoral;
            this.customargsbox.Location = new System.Drawing.Point(236, 93);
            this.customargsbox.Name = "customargsbox";
            this.customargsbox.Size = new System.Drawing.Size(105, 87);
            this.customargsbox.TabIndex = 15;
            this.customargsbox.Text = "";
            // 
            // customargslabel
            // 
            this.customargslabel.AutoSize = true;
            this.customargslabel.BackColor = System.Drawing.Color.Transparent;
            this.customargslabel.ForeColor = System.Drawing.Color.IndianRed;
            this.customargslabel.Location = new System.Drawing.Point(240, 78);
            this.customargslabel.Name = "customargslabel";
            this.customargslabel.Size = new System.Drawing.Size(95, 13);
            this.customargslabel.TabIndex = 16;
            this.customargslabel.Text = "Custom Arguments";
            // 
            // githubbutton
            // 
            this.githubbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.githubbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.githubbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.githubbutton.ForeColor = System.Drawing.Color.IndianRed;
            this.githubbutton.Location = new System.Drawing.Point(183, 93);
            this.githubbutton.Name = "githubbutton";
            this.githubbutton.Size = new System.Drawing.Size(51, 28);
            this.githubbutton.TabIndex = 17;
            this.githubbutton.Text = "MediaD GitHub";
            this.githubbutton.UseVisualStyleBackColor = false;
            this.githubbutton.Click += new System.EventHandler(this.githubbutton_Click);
            // 
            // infobutton
            // 
            this.infobutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.infobutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infobutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infobutton.ForeColor = System.Drawing.Color.Coral;
            this.infobutton.Location = new System.Drawing.Point(130, 124);
            this.infobutton.Name = "infobutton";
            this.infobutton.Size = new System.Drawing.Size(51, 28);
            this.infobutton.TabIndex = 18;
            this.infobutton.Text = "Info";
            this.infobutton.UseVisualStyleBackColor = false;
            this.infobutton.Click += new System.EventHandler(this.infobutton_Click);
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
            this.locationButton.TabIndex = 19;
            this.locationButton.Text = "Change Location";
            this.locationButton.UseVisualStyleBackColor = false;
            this.locationButton.Click += new System.EventHandler(this.locationButton_Click);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.BackColor = System.Drawing.Color.Transparent;
            this.directoryLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.directoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.directoryLabel.Location = new System.Drawing.Point(5, 181);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(0, 9);
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
            this.clearLocationButton.TabIndex = 21;
            this.clearLocationButton.Text = "X";
            this.clearLocationButton.UseVisualStyleBackColor = false;
            this.clearLocationButton.Click += new System.EventHandler(this.clearLocationButton_Click);
            // 
            // applycodecs
            // 
            this.applycodecs.AutoSize = true;
            this.applycodecs.BackColor = System.Drawing.Color.Transparent;
            this.applycodecs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applycodecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applycodecs.ForeColor = System.Drawing.Color.IndianRed;
            this.applycodecs.Location = new System.Drawing.Point(130, 152);
            this.applycodecs.Name = "applycodecs";
            this.applycodecs.Size = new System.Drawing.Size(105, 16);
            this.applycodecs.TabIndex = 22;
            this.applycodecs.Text = "Apply Video Codecs";
            this.applycodecs.UseVisualStyleBackColor = false;
            // 
            // ytdlpgithubbutton
            // 
            this.ytdlpgithubbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ytdlpgithubbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ytdlpgithubbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytdlpgithubbutton.ForeColor = System.Drawing.Color.IndianRed;
            this.ytdlpgithubbutton.Location = new System.Drawing.Point(183, 124);
            this.ytdlpgithubbutton.Name = "ytdlpgithubbutton";
            this.ytdlpgithubbutton.Size = new System.Drawing.Size(51, 28);
            this.ytdlpgithubbutton.TabIndex = 23;
            this.ytdlpgithubbutton.Text = "yt-dlp GitHub";
            this.ytdlpgithubbutton.UseVisualStyleBackColor = false;
            this.ytdlpgithubbutton.Click += new System.EventHandler(this.ytdlpgithubbutton_Click);
            // 
            // slowwarning
            // 
            this.slowwarning.AutoSize = true;
            this.slowwarning.BackColor = System.Drawing.Color.Transparent;
            this.slowwarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slowwarning.ForeColor = System.Drawing.Color.IndianRed;
            this.slowwarning.Location = new System.Drawing.Point(143, 167);
            this.slowwarning.Name = "slowwarning";
            this.slowwarning.Size = new System.Drawing.Size(27, 9);
            this.slowwarning.TabIndex = 24;
            this.slowwarning.Text = "(slow)";
            // 
            // program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(350, 190);
            this.Controls.Add(this.slowwarning);
            this.Controls.Add(this.ytdlpgithubbutton);
            this.Controls.Add(this.applycodecs);
            this.Controls.Add(this.clearLocationButton);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.locationButton);
            this.Controls.Add(this.infobutton);
            this.Controls.Add(this.githubbutton);
            this.Controls.Add(this.customargslabel);
            this.Controls.Add(this.customargsbox);
            this.Controls.Add(this.viewavailableformatsbutton);
            this.Controls.Add(this.advancedlabel);
            this.Controls.Add(this.downloadbutton);
            this.Controls.Add(this.formatlabel);
            this.Controls.Add(this.formatbox);
            this.Controls.Add(this.titlebarpanel);
            this.Controls.Add(this.urllabel);
            this.Controls.Add(this.inputbox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "program";
            this.Text = "MediaDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.program_FormClosing);
            this.Load += new System.EventHandler(this.program_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.titlebarpanel.ResumeLayout(false);
            this.titlebarpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputbox;
        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label byo7qlabel;
        private System.Windows.Forms.Label urllabel;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Panel titlebarpanel;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Button minimizebutton;
        private System.Windows.Forms.Label versionlabel;
        private System.Windows.Forms.ComboBox formatbox;
        private System.Windows.Forms.Label formatlabel;
        private System.Windows.Forms.Button downloadbutton;
        private System.Windows.Forms.Label advancedlabel;
        private System.Windows.Forms.Button viewavailableformatsbutton;
        private System.Windows.Forms.RichTextBox customargsbox;
        private System.Windows.Forms.Label customargslabel;
        private System.Windows.Forms.Button githubbutton;
        private System.Windows.Forms.Button infobutton;
        private System.Windows.Forms.Button locationButton;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Button clearLocationButton;
        private System.Windows.Forms.CheckBox applycodecs;
        private System.Windows.Forms.Button ytdlpgithubbutton;
        private System.Windows.Forms.Label slowwarning;
    }
}