using System.Windows.Forms;

namespace ConvertInfixToPostfixExpression
{
    public class DelegateBase : UserControl
    {
        #region Delegates

        public delegate void CloseFormDelegate();

        #endregion

        public CloseFormDelegate CloseForm;
    }
}