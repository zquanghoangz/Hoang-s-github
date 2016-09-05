using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResizeRectangle
{
    public partial class FormView : Form
    {
        private Point _mouseDownPos;
        private Point _mouseCurrPos;
        private bool _holdingDown;

        public FormView()
        {
            InitializeComponent();
        }

        private void FormView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Coral,
                Min(_mouseDownPos.X , _mouseCurrPos.X),
                Min(_mouseDownPos.Y , _mouseCurrPos.Y),
                Math.Abs(_mouseDownPos.X- _mouseCurrPos.X),
                Math.Abs(_mouseDownPos.Y - _mouseCurrPos.Y));
        }

        private int Min(int x1, int x2)
        {
            return x1 > x2 ? x2 : x1;
        }

        private void FormView_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDownPos = new Point(e.X,e.Y);
            _holdingDown = true;
        }

        private void FormView_MouseUp(object sender, MouseEventArgs e)
        {
            _holdingDown = false;
        }

        private void FormView_MouseMove(object sender, MouseEventArgs e)
        {
            if (_holdingDown)
            {
                _mouseCurrPos = new Point(e.X,e.Y);
                Invalidate();
            }
        }
    }
}
