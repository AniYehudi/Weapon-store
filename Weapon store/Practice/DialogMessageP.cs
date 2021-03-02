using System;
using System.Windows.Forms;
using static Practice.Login;

namespace Practice
{
    public partial class DialogMessageP : Form
    {
        public DialogMessageP()
        {
            InitializeComponent();
        }

        private void DialogMessageP_Load(object sender, EventArgs e)
        {
            if (Important.message[0] == 'V')
                this.label1.Text = Important.message;

            else
                this.label1.Text = "Eroare : " + Important.message;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
