using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using static MediaDownloader.Data.QueueItem.QueueItemStructure;

namespace MediaDownloader.Tools
{
    public static class Forms
    {
        // constants for mouse window events
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;

        // import the SendMessage and ReleaseCapture functions from user32.dll
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // method to move the form when the mouse is clicked and dragged
        public static void MoveForm(IntPtr handle, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public static void ChangeDownloadButtonColors(bool isDownloading, Button downloadButton, Button downloadAllButton)
        {
            if (isDownloading)
            {
                try
                {
                    downloadButton.Invoke((MethodInvoker)delegate
                    {
                        downloadButton.ForeColor = Color.FromArgb(255, 143, 188, 139);
                        downloadButton.BackColor = Color.FromArgb(255, 47, 62, 46);
                        downloadAllButton.FlatAppearance.BorderColor = Color.FromArgb(255, 95, 125, 92);

                        downloadButton.Text = "Downloading...";
                        downloadButton.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    });
                }
                catch { }

                try
                {
                    downloadAllButton.Invoke((MethodInvoker)delegate
                    {
                        downloadAllButton.ForeColor = Color.FromArgb(255, 216, 191, 216);
                        downloadAllButton.BackColor = Color.FromArgb(255, 72, 63, 72);
                        downloadAllButton.FlatAppearance.BorderColor = Color.FromArgb(255, 144, 127, 144);
                    });
                }
                catch { }
            }
            else
            {
                try
                {
                    downloadButton.Invoke((MethodInvoker)delegate
                    {
                        downloadButton.ForeColor = Color.FromArgb(255, 50, 205, 50);
                        downloadButton.BackColor = Color.FromArgb(255, 16, 68, 16);
                        downloadAllButton.FlatAppearance.BorderColor = Color.FromArgb(255, 33, 136, 33);

                        downloadButton.Text = "Download finished!";
                        downloadButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    });
                }
                catch { }

                try
                {
                    downloadAllButton.Invoke((MethodInvoker)delegate
                    {
                        downloadAllButton.ForeColor = Color.FromArgb(255, 147, 112, 219);
                        downloadAllButton.BackColor = Color.FromArgb(255, 49, 37, 73);
                        downloadAllButton.FlatAppearance.BorderColor = Color.FromArgb(255, 98, 74, 146);
                    });
                }
                catch { }
            }
        }

        public static void ReadQueueItemPackToListBox(ListBox listBox, List<QueueItemBase> queueItemsList, bool reverseOrder)
        {
            listBox.Invoke((MethodInvoker)delegate
            {
                listBox.Items.Clear();

                if (queueItemsList.Count == 0)
                    return;

                for (int i = 0; i < queueItemsList.Count; i++)
                {
                    if (queueItemsList[i].OUTPUT_NAME == null)
                        continue;

                    int indexNum = reverseOrder ? queueItemsList.Count - i : i + 1;

                    listBox.Items.Add("[" + indexNum.ToString() + "] " + queueItemsList[i].OUTPUT_NAME);
                }
            });
        }

        public static void DrawListBox(ListBox listbox, DrawItemEventArgs e, Color selectionColor, Color backgroundColor)
        {
            // code forked from: https://stackoverflow.com/a/3709452
            // custom drawing for queue list box items
            e.DrawBackground();
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            int index = e.Index;
            if (index >= 0 && index < listbox.Items.Count)
            {
                Graphics g = e.Graphics;

                SolidBrush backgroundBrush;
                if (selected)
                    backgroundBrush = new SolidBrush(selectionColor);
                else if ((index % 2) == 0)
                    backgroundBrush = new SolidBrush(Color.FromArgb(255, backgroundColor.R / 2, backgroundColor.G / 2, backgroundColor.B / 2));
                else
                    backgroundBrush = new SolidBrush(Color.FromArgb(255, backgroundColor.R, backgroundColor.G, backgroundColor.B));
                g.FillRectangle(backgroundBrush, e.Bounds);

                string text = listbox.Items[index].ToString();
                g.DrawString(text, e.Font, new SolidBrush(Color.FromArgb(255, 255, 255, 255)), listbox.GetItemRectangle(index).Location);
            }
            //
        }
    }
}