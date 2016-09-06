using System;
using System.Windows.Forms;

namespace ConvertInfixToPostfixExpression
{
    public partial class KeyboardCtrl : UserControl
    {
        public KeyboardCtrl()
        {
            InitializeComponent();
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            txtFunctions.Text += btn.Text;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string text = txtFunctions.Text;
            if (text.Length > 0)
            {
                txtFunctions.Text = text.Substring(0, text.Length - 1);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFunctions.Text = string.Empty;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtFunctions.Text);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            txtFunctions.Text += Environment.NewLine;
        }
    }
}