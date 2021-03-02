using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Practice.Login;

namespace Practice
{
    public partial class SaleListP : Form
    {
        public static double Buget;
        public static int SoldProducts;
        public static int AmountofSales;
        public SaleListP()
        {
            InitializeComponent();
        }

        private void SaleListP_Load(object sender, EventArgs e)
        {
            BugetCalculation();
            this.label1.Text = Buget.ToString() + '$';
            SoldProductsCalculation();
            this.label2.Text = SoldProducts.ToString();
            AmountofSalesCalculation();
            this.label3.Text = AmountofSales.ToString();
        }

        private void BugetCalculation()
        {
            string Querry1 = "if not exists (select * from sysobjects where name='temp' and xtype='U')" +
                    "create table temp" +
                    "(s float(2)) insert into temp select sum(Quantity) * sum(SoldPrice) from Sale group by SaleID; ";
            string Querry2 = "select sum(s) from temp";
            string Querry3 = "drop table temp;";

            SqlCommand crt = new SqlCommand(Querry1, Important.conex);
            crt.ExecuteNonQuery();

            SqlCommand prt = new SqlCommand(Querry2, Important.conex);
            try
            {
                Buget = Convert.ToDouble(prt.ExecuteScalar().ToString());
                Buget = Math.Round(Buget, 2);
            }

            catch
            {
                Buget = 0;
            }

            SqlCommand drp = new SqlCommand(Querry3, Important.conex);
            drp.ExecuteNonQuery();

        }

        void SoldProductsCalculation()
        {
            string Querry = "select sum(Quantity) from Sale";

            SqlCommand prt = new SqlCommand(Querry, Important.conex);

            try
            {
                SoldProducts = Convert.ToInt32(prt.ExecuteScalar().ToString());
            }

            catch
            {
                SoldProducts = 0;
            }
        }

        void AmountofSalesCalculation()
        {
            string Querry = "select count(Quantity) from Sale";

            SqlCommand prt = new SqlCommand(Querry, Important.conex);

            try
            {
                AmountofSales = Convert.ToInt32(prt.ExecuteScalar().ToString());
            }

            catch
            {
                AmountofSales = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeAdminP admin = new HomeAdminP();
            this.Hide();
            admin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {

            String Querry;

            if (this.richTextBoxSQLCondition.Text == "")
            {
                Querry = "select * from Sale";

                try
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        SqlCommand prt = new SqlCommand(Querry, Important.conex);
                        SqlDataAdapter da = new SqlDataAdapter(prt);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.Refresh();
                    }
                }

                catch (Exception ex)
                {
                    Important.message = ex.GetType().ToString();
                    DialogMessageP dial = new DialogMessageP();
                    dial.ShowDialog();
                }
            }


            else
            {
                Querry = "select * from Sale where " + this.richTextBoxSQLCondition.Text;

                try
                {
                    SqlCommand prt = new SqlCommand(Querry, Important.conex);
                    SqlDataAdapter da = new SqlDataAdapter(prt);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }

                catch (Exception ex)
                {
                    Important.message = ex.GetType().ToString();
                    DialogMessageP dial = new DialogMessageP();
                    dial.ShowDialog();
                }
            }
        }

        private void SaleListP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
