using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertInfixToPostfixExpression
{
    public partial class FormView : Form
    {
        private ConvertToPostFixCtrl _convertToPostFixCtrl;
        private KeyboardCtrl _keyboardCtrl;
        private GraphCtrl _graphCtrl;

        public FormView()
        {
            InitializeComponent();
            IntializeUserControl();

            AddMainUserControl(_convertToPostFixCtrl);
        }

        private void IntializeUserControl()
        {
            _convertToPostFixCtrl = new ConvertToPostFixCtrl { CloseForm = Close };
            _graphCtrl = new GraphCtrl();
            _keyboardCtrl = new KeyboardCtrl();

        }

        private void AddMainUserControl(UserControl control)
        {
            if (Controls.Count == 0 || Controls[0].GetType() != control.GetType())
            {
                Controls.Clear();

                control.Dock = DockStyle.Fill;
                Controls.Add(control);

                mainMenuStrip.Dock = DockStyle.Top;
                Controls.Add(mainMenuStrip);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void infixToPostfixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMainUserControl(_convertToPostFixCtrl);
        }

        private void graphFunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMainUserControl(_graphCtrl);
        }

        private void keyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMainUserControl(_keyboardCtrl);
        }
    }
}
