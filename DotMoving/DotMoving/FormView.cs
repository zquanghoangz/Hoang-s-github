using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DotMoving
{
    public sealed partial class FormView : Form
    {
        #region Constants

        private const int OBJECT_SIZE = 5;
        private const int GRID_COUNT = 80;
        private const int START_POINT_X = 50;
        private const int START_POINT_Y = 50;

        #endregion

        #region Fields

        private readonly Timer _timer;
        private int _current;
        private List<Point> _movingPattern = new List<Point>();

        #endregion

        #region Events

        public FormView()
        {
            InitializeComponent();
            DoubleBuffered = true;
            CreateDemoPattern();
            _timer = new Timer
            {
                Interval = 100 //1s
            };
            _timer.Tick += Timer_Tick;
            _current = 0;

            SmoothMovingPattern();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Draw grid - hozontal lines
            for (int i = 0; i <= GRID_COUNT; i++)
            {
                g.DrawLine(new Pen(Brushes.Black), START_POINT_X, START_POINT_Y + OBJECT_SIZE * i,
                    START_POINT_X + GRID_COUNT * OBJECT_SIZE, START_POINT_Y + OBJECT_SIZE * i);
            }

            //Draw grid - vertical lines
            for (int j = 0; j <= GRID_COUNT; j++)
            {
                g.DrawLine(new Pen(Brushes.Black), START_POINT_X + OBJECT_SIZE * j, START_POINT_Y,
                    START_POINT_X + OBJECT_SIZE * j, START_POINT_Y + GRID_COUNT * OBJECT_SIZE);
            }

            //Draw object
            g.FillEllipse(Brushes.DarkRed, CreateRectangle(_current));

            //draw object
            base.OnPaint(e);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _current++;
            if (_current == _movingPattern.Count)
            {
                _current = 0;
            }

            //I will lag if invalidate all form
            //Invalidate();
            //Just do in a rectangle
            Invalidate(CreateRectangle(_current));
            Invalidate(_current > 0 ?
                CreateRectangle(_current - 1) : CreateRectangle(_movingPattern.Count - 1));
        }

        #endregion

        #region Business

        private Rectangle CreateRectangle(int idx)
        {
            int x = _movingPattern[idx].X;
            int y = _movingPattern[idx].Y;
            var rect = new Rectangle(x * OBJECT_SIZE + START_POINT_X, y * OBJECT_SIZE + START_POINT_Y,
                OBJECT_SIZE, OBJECT_SIZE);
            return rect;
        }

        private void CreateDemoPattern()
        {
            //Will create by an algorithm
            _movingPattern.Add(new Point(0, 1));
            _movingPattern.Add(new Point(3, 1));
            _movingPattern.Add(new Point(5, 15));
            _movingPattern.Add(new Point(10, 20));
            _movingPattern.Add(new Point(20, 40));
            _movingPattern.Add(new Point(40, 49));
            _movingPattern.Add(new Point(78, 79));
            _movingPattern.Add(new Point(63, 59));
            _movingPattern.Add(new Point(20, 13));
            _movingPattern.Add(new Point(25, 1));
            _movingPattern.Add(new Point(0, 1));
        }

        /// <summary>
        ///     Make the pattern be more smooth
        /// </summary>
        private void SmoothMovingPattern()
        {
            var newPattern = new List<Point>();
            for (int i = 0; i < _movingPattern.Count - 1; i++)
            {
                newPattern.Add(_movingPattern[i]);

                int tempX = _movingPattern[i].X;
                while (tempX != _movingPattern[i + 1].X)
                {
                    tempX += tempX < _movingPattern[i + 1].X ? 1 : -1;
                    newPattern.Add(new Point(tempX, _movingPattern[i].Y));
                }

                int tempY = _movingPattern[i].Y;
                while (tempY != _movingPattern[i + 1].Y)
                {
                    tempY += tempY < _movingPattern[i + 1].Y ? 1 : -1;
                    newPattern.Add(new Point(_movingPattern[i + 1].X, tempY));
                }
            }
            //last
            newPattern.Add(_movingPattern[_movingPattern.Count - 1]);

            //Set back
            _movingPattern = newPattern;
        }

        #endregion
    }
}