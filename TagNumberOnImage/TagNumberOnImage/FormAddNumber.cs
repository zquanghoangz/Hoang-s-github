using System.Windows.Forms;

namespace TagNumberOnImage
{
    public partial class FormAddNumber : Form
    {
        public FormAddNumber()
        {
            InitializeComponent();
            Hide();
        }

        public int ShowDialog(int number)
        {
            
            nudAddNumber.Minimum = number;
            nudAddNumber.Value = number;
            ShowDialog();
            return (int)nudAddNumber.Value;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        
    }
}
