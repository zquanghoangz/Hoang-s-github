using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGameDemo
{
    public partial class FormView : Form
    {
        //Define some constants first
        #region Constants

        //The size of each square in game board
        private const int SQUARE_SIZE = 15;
        //The number of squares in board
        private const int NUMBER_OF_SQUARES = 20;//index 0->19

        #endregion

        #region Fields & Properties

        //The point we will start to draw everything
        private Point _start = new Point(30, 30);
        //To store location of all snake's parts
        private List<Point> _snake = new List<Point>();
        //We define the move direction
        enum MoveDirection
        {
            Up, Down, Left, Right
        }
        //Which direction this snake is moving
        private MoveDirection _moveDirection = MoveDirection.Down;//demo value
        //Make snake move timer
        private Timer _timer;

        #endregion

        public FormView()
        {
            InitializeComponent();

            //We create demo snake data
            CreateDemoSnake();

            //Create timer
            _timer=new Timer{Interval = 200}; //0.2 second
            _timer.Tick += (s, e) => MoveNext();
            _timer.Enabled = true;//get start
        }

        private void CreateDemoSnake()
        {
            //I will fill some random ^^ data
            _snake.Add(new Point(15, 4));//snake head
            _snake.Add(new Point(16, 4));
            _snake.Add(new Point(17, 4));
            _snake.Add(new Point(18, 4));
            _snake.Add(new Point(18, 5));
            _snake.Add(new Point(18, 6));
            _snake.Add(new Point(18, 7));
            _snake.Add(new Point(18, 8));//my mistake
            _snake.Add(new Point(19, 8));
            _snake.Add(new Point(19, 9));
            _snake.Add(new Point(19, 10));

        }

        //OK, let's start with writing board
        protected override void OnPaint(PaintEventArgs e)
        {
            //Create instance of graphic
            Graphics g = this.CreateGraphics();

            //Call function draw board
            DrawGameBoard(g);

            //Call function draw snake
            DrawSnake(g);

            base.OnPaint(e);
        }

        private void DrawSnake(Graphics g)
        {
            foreach (var p in _snake)
            {
                //just draw some rectange
                g.FillRectangle(Brushes.DarkGreen,//look better
                    _start.X + p.X * SQUARE_SIZE,
                    _start.Y + p.Y * SQUARE_SIZE,
                    SQUARE_SIZE, SQUARE_SIZE);
            }
        }

        private void DrawGameBoard(Graphics g)
        {
            //Draw board game
            for (int i = 0; i <= NUMBER_OF_SQUARES; i++)
            {
                //Draw hozontal lines
                g.DrawLine(new Pen(Brushes.Brown),
                    _start.X,
                    _start.Y + SQUARE_SIZE * i,
                    _start.X + SQUARE_SIZE * NUMBER_OF_SQUARES,
                    _start.Y + SQUARE_SIZE * i);

                //Draw vertical lines
                g.DrawLine(new Pen(Brushes.Brown),
                    _start.X + SQUARE_SIZE * i,
                    _start.Y,
                    _start.X + SQUARE_SIZE * i,
                    _start.Y + SQUARE_SIZE * NUMBER_OF_SQUARES);
            }
        }

        //Do moving change
        private void MoveNext()
        {
            //Backup sake's tail position
            var tail = new Point(_snake[_snake.Count - 1].X, _snake[_snake.Count - 1].Y);

            //Only head will have new location, all other parts will be copy next
            //Do copy next
            for (int i = _snake.Count - 1; i > 0; i--)//except the first item
            {
                _snake[i] = new Point(_snake[i - 1].X, _snake[i - 1].Y);
            }
            //Snake's head is moving
            switch (_moveDirection)
            {
                case MoveDirection.Up:
                    _snake[0] = new Point(_snake[0].X, _snake[0].Y - 1);
                    break;
                case MoveDirection.Down: 
                    _snake[0] = new Point(_snake[0].X, _snake[0].Y + 1);
                    break;
                case MoveDirection.Left:
                    _snake[0] = new Point(_snake[0].X - 1, _snake[0].Y);
                    break;
                case MoveDirection.Right:
                    _snake[0] = new Point(_snake[0].X + 1, _snake[0].Y);
                    break;
            }

            if (_snake[0].X<0||
                _snake[0].Y<0||
                _snake[0].X>NUMBER_OF_SQUARES-1||
                _snake[0].Y>NUMBER_OF_SQUARES-1)
            {
                //Stop it
                _timer.Enabled = false;
                //AAAA Snake go out of box
                MessageBox.Show("AAAA!!!! Snake go out of box");
            }
            else
            {
                //Re-draw form
                //this.Invalidate();//we will come back later
               //Only head n tail changing, so lets re-draw them only
                this.Invalidate(new Rectangle(_start.X + _snake[0].X * SQUARE_SIZE,
                    _start.Y + _snake[0].Y * SQUARE_SIZE,
                    SQUARE_SIZE, SQUARE_SIZE));
                //and tail???
                this.Invalidate(new Rectangle(_start.X + tail.X * SQUARE_SIZE,
                    _start.Y + tail.Y * SQUARE_SIZE,
                    SQUARE_SIZE, SQUARE_SIZE));
                //very good now
                //Thank you for watching
                //If you have any question
                //Contact:zquanghoangz@gmail.com
            }
        }
    }
}
