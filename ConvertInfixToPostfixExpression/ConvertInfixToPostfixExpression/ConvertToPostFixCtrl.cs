using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ConvertInfixToPostfixExpression
{
    public partial class ConvertToPostFixCtrl : DelegateBase
    {
        private readonly List<string> _outputs;
        private readonly List<string> _stacks;
        private int _curIndex;

        public ConvertToPostFixCtrl()
        {
            InitializeComponent();
            _stacks = new List<string>();
            _outputs = new List<string>();
            _curIndex = 0;
        }

        private void AddStepIndex(int stepIndex)
        {
            if (stepIndex < 0 || stepIndex >= _outputs.Count())
                return;

            AddControl(new AStepCtrl(stepIndex + 1, _stacks[stepIndex], _outputs[stepIndex]));
            _curIndex++;
        }

        private void AddFromIndex(int stepIndex)
        {
            if (stepIndex < 0 || stepIndex >= _outputs.Count)
                return;

            for (int i = stepIndex; i < _outputs.Count; i++)
            {
                AddControl(new AStepCtrl(i + 1, _stacks[i], _outputs[i]));
            }
            _curIndex = 0;
        }

        private void AddControl(Control ctrl)
        {
            ctrl.Anchor = AnchorStyles.None;
            ctrl.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            ctrl.Dock = DockStyle.Top;

            pnlShowStep.Controls.Add(ctrl);
            pnlShowStep.Controls.SetChildIndex(ctrl, 0);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            pnlShowStep.Controls.Clear();
            _curIndex = 0;

            //Validate expression
            ErrorItem item = CExpValidation.ExpValidate(txtInputExp.Text);
            if (item.Code != 0)
            {
                MessageBox.Show(string.Format("Possition: {0}.\nMessage: {1}", item.Code, item.Msg));
                return;
            }

            //process to create all lists
            _stacks.Clear();
            _outputs.Clear();
            List<string> expSplited = CExpPostfix.ExpSplit(txtInputExp.Text);
            lblSplitedExp.Text = string.Format("Result: {0} = {1}",
                                               CExpPostfix.ListToString(expSplited),
                                               CExpCalculation.CalculativeExpPostfix(
                                                   CExpPostfix.CreateExpPostfix(expSplited)));

            CExpPostfix.CreateStackOutput(expSplited, _stacks, _outputs);
            lblOutput.Text = "Postfix:";

            ButtonsEnable(false);
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            AddStepIndex(_curIndex);

            if (_curIndex == _outputs.Count)
            {
                lblOutput.Text = string.Format("Postfix: {0}", _outputs[_outputs.Count - 1]);
                ButtonsEnable(true);
            }
        }

        private void btnStepOver_Click(object sender, EventArgs e)
        {
            AddFromIndex(_curIndex);
            lblOutput.Text = string.Format("Postfix: {0}", _outputs[_outputs.Count - 1]);
            ButtonsEnable(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CloseForm!=null)
            {
                CloseForm();
            }
        }

        private void ButtonsEnable(bool isShowStart)
        {
            btnStart.Enabled = isShowStart;
            btnNextStep.Enabled = !isShowStart;
            btnStepOver.Enabled = !isShowStart;
        }

        private void lblOutput_DoubleClick(object sender, EventArgs e)
        {
            string msg = @"Infix to Postfix Conversion
• We use a stack
• When an operand is read, output it
• When an operator is read
    – Pop until the top of the stack has an element of lower precedence
    – Then push it
• When ) is found, pop until we find the matching (
• ( has the lowest precedence when in the stack but has the highest precedence when in the input
• When we reach the end of input, pop until the stack is empty";
            MessageBox.Show(msg);
        }

        private void lblSplitedExp_DoubleClick(object sender, EventArgs e)
        {
            string msg = @"From Postfix to Answer
• The reason to convert infix to postfix expression is that we can compute the answer of postfix expression easier by using a stack.";
            MessageBox.Show(msg);
        }
    }
}