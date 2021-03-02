using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Practice.Login;

namespace Practice
{
    public partial class ProductInformationP : Form
    {
        public ProductInformationP()
        {
            InitializeComponent();
        }

        private void ProductInformationP_Load(object sender, EventArgs e)
        {
            SqlCommand q2 = new SqlCommand("Select Type from Product where ProdName = '" + Important.ProdName + '\'', Important.conex);
            SqlCommand q3 = new SqlCommand("Select Origin from Product where ProdName = '" + Important.ProdName + '\'', Important.conex);
            SqlCommand q4 = new SqlCommand("Select Mass from Product where ProdName = '" + Important.ProdName + '\'', Important.conex);
            SqlCommand q5 = new SqlCommand("Select Length from Product where ProdName = '" + Important.ProdName + '\'', Important.conex);
            SqlCommand q6 = new SqlCommand("Select Caliber from Product where ProdName = '" + Important.ProdName + '\'', Important.conex);
            SqlCommand q7 = new SqlCommand("Select Diameter from Product where ProdName = '" + Important.ProdName + '\'', Important.conex);
            SqlCommand q8 = new SqlCommand("Select Filling from Product where ProdName = '" + Important.ProdName + '\'', Important.conex);
            SqlCommand q9 = new SqlCommand("Select Quantity from Product where ProdName = '" + Important.ProdName + '\'', Important.conex);
            SqlCommand q10 = new SqlCommand("Select Price from Product where ProdName = '" + Important.ProdName + '\'', Important.conex);

            this.label10.Text = Important.ProdName;
            this.label20.Text = q2.ExecuteScalar().ToString();
            this.label30.Text = q3.ExecuteScalar().ToString();
            this.label40.Text = q4.ExecuteScalar().ToString();
            this.label50.Text = q5.ExecuteScalar().ToString();
            this.label60.Text = q6.ExecuteScalar().ToString();
            this.label70.Text = q7.ExecuteScalar().ToString();
            this.label80.Text = q8.ExecuteScalar().ToString();
            this.label90.Text = q9.ExecuteScalar().ToString();
            this.label100.Text = q10.ExecuteScalar().ToString() + '$';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.BringToFront();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\alex\Desktop\Practice\Practice\prodImg\" + Important.ProdName + ".jpg");
        }
    }
}
