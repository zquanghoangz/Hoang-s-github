using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertInfixToPostfixExpression
{
    public partial class AStepCtrl : UserControl
    {
        public AStepCtrl()
        {
            InitializeComponent();
        }

        public AStepCtrl(int number, string stack, string output)
        {
            InitializeComponent();

            grpStepNumber.Text = string.Format("Step: {0}", number);
            lblStack.Text = string.Format("Stack: {0}", stack);
            lblOutput.Text = string.Format("Output: {0}", output);
        }
    }
}
