using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Demo2048
{
    public partial class FormView : Form
    {
        private const int StartX = 50;
        private const int StartY = 50;
        private const int SquareSize = 80;
        private const int LineSize = 8;
        private readonly C2048Core _c2048Core = new C2048Core();
        private Dictionary<int, Brush> _brushes;

        public FormView()
        {
            InitializeComponent();
            DefineColorBrushes();
        }

        private void DefineColorBrushes()
        {
            _brushes = new Dictionary<int, Brush>
            {
                {2, Brushes.LightYellow},
                {4, Brushes.LemonChiffon},
                {8, Brushes.NavajoWhite},
                {16, Brushes.SandyBrown},
                {32, Brushes.Orange},
                {64, Brushes.DarkOrange},
                {128, Brushes.Peru},
                {256, Brushes.Brown},
                {512, Brushes.Brown},
                {1024, Brushes.Brown},
                {2048, Brushes.Brown},
                {4096, Brushes.Brown},
                {8192, Brushes.Red},
                {16384, Brushes.DarkRed},
            };
        }


        private void FormView_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(new Pen(Brushes.Tan, LineSize), StartX, StartY + i * SquareSize, StartX + 4 * SquareSize,
                    StartY + i * SquareSize);
            }


            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(new Pen(Brushes.Tan, LineSize), StartX + i * SquareSize, StartY, StartX + i * SquareSize,
                    StartY + 4 * SquareSize);
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_c2048Core.Matrix[i, j] != 0)
                    {
                        FillElement(g, _c2048Core.Matrix[i, j], StartX + j * SquareSize + LineSize / 2,
                            StartY + i * SquareSize + LineSize / 2,
                            SquareSize - LineSize, SquareSize - LineSize);
                    }
                }
            }

            g.DrawString(_c2048Core.Score.ToString(), new Font("Tahoma", 14), Brushes.Gray, 10, 10);
        }

        private void FillElement(Graphics g, int number, int x, int y, int w, int h)
        {
            g.FillRectangle(_brushes[number], x, y, w, h);
            g.DrawString(number.ToString(), new Font("Tahoma", 14), Brushes.Gray, x, y);
        }

        private void FormView_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_c2048Core.HasANextMove())
            {
                MessageBox.Show("Lose");
                return;
            }

            bool anyMove = false;
            if (e.KeyCode == Keys.Up)
            {
                //Move all to up
                anyMove = anyMove || _c2048Core.PullTop();
            }
            else if (e.KeyCode == Keys.Down)
            {
                //Move all to down
                anyMove = anyMove || _c2048Core.PullBottom();
            }
            else if (e.KeyCode == Keys.Left)
            {
                //Move all to left
                anyMove = anyMove || _c2048Core.PullLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                //Move all to right
                anyMove = anyMove || _c2048Core.PullRight();
            }

            if (anyMove)
            {
                Invalidate();
                //Add new number
                _c2048Core.AddNewElement();

            }
        }
    }
}