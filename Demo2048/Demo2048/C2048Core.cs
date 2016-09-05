using System;

namespace Demo2048
{
    public class C2048Core
    {
        #region Fields & Properties

        private readonly Random _rand;
        private readonly int[,] _tempMatrix;
        private bool _anyMove;
        private bool _moveDetected = true;
        public int[,] Matrix { get; set; }
        public decimal Score { get; set; }

        #endregion Fields & Properties

        public C2048Core()
        {
            _rand = new Random();
            Score = 0;
            _tempMatrix = new int[4, 4];
            InitCoreMatrix();
        }

        #region Public Methods

        public void AddNewElement()
        {
            if (NotAnyZeroValue())
            {
                return;
            }

            do
            {
                int nextIndex = _rand.Next(0, 16);
                int j = nextIndex%4;
                int i = nextIndex/4;

                if (Matrix[i, j] == 0)
                {
                    Matrix[i, j] = NewValue();
                    break;
                }
            } while (true);
        }

        public bool PullRight()
        {
            InitStep();

            while (_moveDetected)
            {
                _moveDetected = false;
           
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Compare2PointsAndUpdateValue(j, 3 - i, j, 2 - i);
                    }
                }
            }

            return _anyMove;
        }

        public bool PullLeft()
        {
            InitStep();

            while (_moveDetected)
            {
                _moveDetected = false;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Compare2PointsAndUpdateValue(j, i, j, i + 1);
                    }
                }
            }

            return _anyMove;
        }

        public bool PullBottom()
        {
            InitStep();

            while (_moveDetected)
            {
                _moveDetected = false;
              
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Compare2PointsAndUpdateValue(3 - i, j, 2 - i, j);
                    }
                }
            }

            return _anyMove;
        }

        public bool PullTop()
        {
            InitStep();

            while (_moveDetected)
            {
                _moveDetected = false;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Compare2PointsAndUpdateValue(i, j, i + 1, j);
                    }
                }
            }

            return _anyMove;
        }

        public bool HasANextMove()
        {
            if (!NotAnyZeroValue())
            {
                return true;
            }

            //Has any move
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Matrix[j, i] == Matrix[j, i + 1] || Matrix[i, j] == Matrix[i + 1, j] ||
                        Matrix[j, 3 - i] == Matrix[j, 2 - i] || Matrix[3 - i, j] == Matrix[2 - i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion Public Methods

        #region Private Helper Methods

        private void InitStep()
        {
            ResetMatrix(_tempMatrix);
            _moveDetected = true;
            _anyMove = false;
        }

        private bool NotAnyZeroValue()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void InitCoreMatrix()
        {
            Matrix = new int[4, 4];
            ResetMatrix(Matrix);

            AddNewElement();
            AddNewElement();
        }

        private int NewValue()
        {
            switch (_rand.Next(0, 10)) //10%
            {
                case 1:
                    return 4;
                default:
                    return 2;
            }
        }

        private void Compare2PointsAndUpdateValue(int x1, int y1, int x2, int y2)
        {
            if (_tempMatrix[x1, y1] == 1 || _tempMatrix[x2, y2] == 1)
            {
                return;
            }

            if (Matrix[x1, y1] == 0 && Matrix[x2, y2] != 0)
            {
                Matrix[x1, y1] = Matrix[x2, y2];
                Matrix[x2, y2] = 0;

                _moveDetected = _anyMove = true;
            }
            else if (Matrix[x1, y1] != 0 && Matrix[x2, y2] != 0 && Matrix[x1, y1] == Matrix[x2, y2])
            {
                Matrix[x1, y1] = Matrix[x1, y1]*2;
                Matrix[x2, y2] = 0;
                Score += Matrix[x1, y1];

                _moveDetected = _anyMove = true;
                _tempMatrix[x1, y1] = 1;
            }
        }

        private void ResetMatrix(int[,] matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        #endregion Private Helper Methods
    }
}