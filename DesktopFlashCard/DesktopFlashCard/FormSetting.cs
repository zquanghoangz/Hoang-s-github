using System;
using System.Windows.Forms;

namespace DesktopFlashCard
{
    public partial class FormSetting : Form
    {
        public DlgResult Result;

        public FormSetting()
        {
            InitializeComponent();

            Result = new DlgResult();
            DialogResult = DialogResult.Cancel;
        }

        public FormSetting(string path, int timer)
        {
            InitializeComponent();

            Result = new DlgResult();
            DialogResult = DialogResult.Cancel;

            txtPath.Text = path;
            nudTimer.Value = timer;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                RootFolder = Environment.SpecialFolder.MyComputer
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dialog.SelectedPath;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Result.Path = txtPath.Text;
            Result.Timer = Convert.ToInt32(nudTimer.Value);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class DlgResult
    {
        public string Path { get; set; }
        public int Timer { get; set; }
    }
}