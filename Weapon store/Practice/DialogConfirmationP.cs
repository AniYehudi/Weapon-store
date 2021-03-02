using System;
using System.Windows.Forms;
using static Practice.Login;

namespace Practice
{
    public partial class DialogConfirmationP : Form
    {
        public DialogConfirmationP()
        {
            InitializeComponent();
        }

        private void DialogConfirmationP_Load(object sender, EventArgs e)
        {
            this.label1.Text = Important.message;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Important.confirm = true;
            this.Close();
        }

        private void buttonNu_Click(object sender, EventArgs e)
        {
            Important.confirm = false;
            this.Close();
        }
    }
}
