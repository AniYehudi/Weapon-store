using System;
using System.Drawing;
using System.Windows.Forms;
using static Practice.Login;

namespace Practice
{
    public partial class HomeClientP : Form
    {
        public HomeClientP()
        {
            InitializeComponent();
        }

        private void HomeClientP_Load(object sender, EventArgs e)
        {
            label2.Text = "Salut " + Important.uName;
            Image img;
            img = Image.FromFile(Important.sysimgadr + "Logo.png");
            this.pictureBox1.Image = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientInfoP clientinfo = new ClientInfoP();
            clientinfo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BrowsePanelP browse = new BrowsePanelP();
            this.Hide();
            browse.Show();
        }

        private void HomeClientP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Aboutus abus = new Aboutus();
            abus.ShowDialog();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\alex\Desktop\Practice\Practice\sysImg\Logo.png");
        }
    }
}
