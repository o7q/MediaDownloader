using System.Drawing;
using System.Windows.Forms;
using static MediaDownloader.Tools.Forms;

namespace MediaDownloader.Tools.CustomMessageBox
{
    public partial class CustomMessageBox : Form
    {
        string messageText;
        string buttonText;
        bool enableUserControl;

        public DialogResult Result { get; private set; }

        public CustomMessageBox(string messageText_, string buttonText_, bool enableUserControl_)
        {
            InitializeComponent();

            messageText = messageText_;
            buttonText = buttonText_;
            enableUserControl = enableUserControl_;
        }

        private void CustomMessageBox_Load(object sender, System.EventArgs e)
        {
            MessageLabel.Text = messageText;
            OkButton.Text = buttonText;

            if (!enableUserControl)
            {
                CloseButton.Enabled = false;
                OkButton.Enabled = false;
            }

            Width = MessageLabel.Width + 10;
            Height = MessageLabel.Height + 105;

            TitlebarPanel.Width = Width;
            BottomBarPanel.Width = Width;
            BottomBarPanel.Location = new Point(BottomBarPanel.Location.X, MessageLabel.Height + 105 - BottomBarPanel.Height);

            CloseButton.Location = new Point(Width - CloseButton.Width, CloseButton.Location.Y);
            OkButton.Location = new Point(Width - OkButton.Width - 7, OkButton.Location.Y);
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            Result = DialogResult.OK;
            Close();
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            Result = DialogResult.Cancel;
            DialogResult = DialogResult.Cancel;
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