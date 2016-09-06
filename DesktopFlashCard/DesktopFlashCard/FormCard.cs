using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DesktopFlashCard
{
    public partial class FormCard : Form
    {
        private readonly Random _rand;
        private readonly List<int> _usedCards;
        private string _currentAudioPath;
        private List<string> _fileAudios;
        private List<string> _fileCards;
        private string _folder = "Hiragana";

        public FormCard()
        {
            InitializeComponent();
            _rand = new Random();
            _usedCards = new List<int>();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCard_Load(object sender, EventArgs e)
        {
            InitializeCards();
        }

        private void InitializeCards()
        {
            if (Directory.Exists(_folder))
            {
                _fileCards =
                    Directory.GetFiles(_folder, "*.*", SearchOption.AllDirectories).Where(file => file.ToLower().
                        EndsWith(".gif") || file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".jpg") ||
                                                                                                  file.ToLower()
                                                                                                      .EndsWith(".bmp"))
                        .ToList();
                _fileAudios =
                    Directory.GetFiles(_folder, "*.*", SearchOption.AllDirectories).Where(file => file.ToLower().
                        EndsWith(".mp3")).ToList();
            }

            SetCard();
        }

        private void SetCard()
        {
            if (_fileCards.Count < 1) return;

            int idx = RandomNext();
            picText.Image = new Bitmap(_fileCards[idx]);
            lblName.Text = Path.GetFileNameWithoutExtension(_fileCards[idx]);
            _currentAudioPath = _fileAudios.First(x => Path.GetFileNameWithoutExtension(x) == lblName.Text);

            AudioPlayHelper.Stop();
            AudioPlayHelper.Play(_currentAudioPath, true);
        }

        private int RandomNext()
        {
            if (_usedCards.Count >= _fileCards.Count)
            {
                _usedCards.Clear();
            }

            int x;
            do
            {
                x = _rand.Next(0, _fileCards.Count);
            } while (_usedCards.Contains(x));
            _usedCards.Add(x);
            return x;
        }

        private void tmrChangeCard_Tick(object sender, EventArgs e)
        {
            SetCard();
        }

        private void FormCard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var dlg = new FormSetting(_folder, tmrChangeCard.Interval);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tmrChangeCard.Interval = dlg.Result.Timer;
                _folder = dlg.Result.Path;
                InitializeCards();
            }
        }

        #region Form Move

        private bool _isMoving;
        private Point _startMouse;


        private void FormCard_MouseUp(object sender, MouseEventArgs e)
        {
            _isMoving = false;
        }

        private void FormCard_MouseDown(object sender, MouseEventArgs e)
        {
            _isMoving = true;
            _startMouse = new Point(e.X, e.Y);
        }

        private void FormCard_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMoving)
            {
                Location = new Point(Location.X - _startMouse.X + e.X,
                    Location.Y - _startMouse.Y + e.Y);
            }
        }

        #endregion
    }
}