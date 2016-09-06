using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TagNumberOnImage
{
    public partial class FormView : Form
    {
        private string _allText;
        private Bitmap _drawedImage;
        private int _number = 1;

        public FormView()
        {
            InitializeComponent();
            _drawedImage = new Bitmap(Width, Height);
            _allText = string.Empty;
        }

        private void GetImageFromClipBoard()
        {
            try
            {
                _drawedImage = new Bitmap(Width, Height);
                IDataObject dataObject = Clipboard.GetDataObject();
                object o = null;
                if (dataObject != null)
                {
                    o = dataObject.GetData("PNG");
                }

                Graphics g = Graphics.FromImage(_drawedImage); //.CreateGraphics();

                if (o == null)
                    return;

                var stream = o as MemoryStream;
                if (stream != null)
                {
                    g.DrawImage(new Bitmap(stream), new Point(0, 0));
                }

                BackgroundImage = _drawedImage;
                Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("Please copy image first!");
            }
        }

        private void GetImageFromFile(string fileName)
        {
            try
            {
                _drawedImage = new Bitmap(Width, Height);
                Graphics g = Graphics.FromImage(_drawedImage);
                g.DrawImage(new Bitmap(fileName), new Point(0, 0));

                BackgroundImage = _drawedImage;
                Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("Please copy image first!");
            }
        }

        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(_drawedImage); //.CreateGraphics();

            DrawRectangeNumber(g, e.Location);

            Invalidate();
            SetNumber();
        }

        private void SetNumber()
        {
            _allText += string.Format("{0:000}{1}", _number, Environment.NewLine);
            _number++;
        }

        private void ResetNumber()
        {
            _allText = string.Empty;
            _number = 1;
        }

        private void DrawRectangeNumber(Graphics g, Point p)
        {
            p = new Point(p.X - 9, p.Y - 6);

            g.FillRectangle(Brushes.Yellow, p.X, p.Y, 18, 12);
            g.DrawRectangle(new Pen(Brushes.Red), p.X, p.Y, 18, 12);

            g.DrawString(string.Format("{0:000}", _number),
                new Font("Times New Roman", 7), Brushes.Red, p);
        }


        private void FormView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                ResetNumber();
                GetImageFromClipBoard();
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O)
            {
                ResetNumber();
                var dialog = new OpenFileDialog {Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg"};
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    GetImageFromFile(dialog.FileName);
                }
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                SetImageFromClipBoard();
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N)
            {
                _number = new FormAddNumber().ShowDialog(_number);
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.X)
            {
                ResetNumber();
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.T)
            {
                Clipboard.SetText(_allText);
            }

            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show(@"Ctrl + V to paste image into the window.
Ctrl + O to open image from file.
Ctrl + C to copy image from the window.
Ctrl + N to change the number for next adding.
Ctrl + X to reset number to 1.
Ctrl + T to copy the number list.");
            }
        }

        private void SetImageFromClipBoard()
        {
            var bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(BackgroundImage, 0, 0);

            Clipboard.SetDataObject(bmp);
        }
    }
}