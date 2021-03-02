using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using static Practice.Login;

namespace Practice
{
    public partial class Aboutus : Form
    {
        public Aboutus()
        {
            InitializeComponent();
        }
        private void Aboutuscs_Load(object sender, EventArgs e)
        {
            Image img;
            img = Image.FromFile(Important.sysimgadr + "1.png");
            this.pictureBox1.Image = img;

            img = Image.FromFile(Important.sysimgadr + "2.jpg");
            this.pictureBox2.Image = img;

            img = Image.FromFile(Important.sysimgadr + "3.jpg");
            this.pictureBox3.Image = img;

            string text = File.ReadAllText(Important.sysimgadr + "1.txt");
            this.richTextBox1.Text = text;

            text = File.ReadAllText(Important.sysimgadr + "2.txt");
            this.richTextBox2.Text = text;

            text = File.ReadAllText(Important.sysimgadr + "3.txt");
            this.richTextBox3.Text = text;

            text = File.ReadAllText(Important.sysimgadr + "4.txt");
            this.richTextBox4.Text = text;

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\alex\Desktop\Practice\Practice\sysImg\1.png");
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\alex\Desktop\Practice\Practice\sysImg\2.jpg");
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\alex\Desktop\Practice\Practice\sysImg\3.jpg");
        }
    }
}
