using System;
using System.Drawing;
using System.Windows.Forms;
using static Practice.Login;

namespace Practice
{
    public partial class HomeAdminP : Form
    {
        public HomeAdminP()
        {
            InitializeComponent();
        }

        private void HomeAdminP_Load(object sender, EventArgs e)
        {
            label2.Text = "Salut " + Important.uName;
            Image img;
            img = Image.FromFile(Important.sysimgadr + "Logo.png");
            this.pictureBox1.Image = img;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductListP pl = new ProductListP();
            this.Hide();
            pl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserListP ul = new UserListP();
            this.Hide();
            ul.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaleListP sl = new SaleListP();
            this.Hide();
            sl.Show();
        }

        private void HomeAdminP_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\alex\Desktop\Practice\Practice\sysImg\Logo.png");
        }
    }
}
