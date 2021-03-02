using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Practice.Login;

namespace Practice
{
    public partial class ProductListP : Form
    {
        public ProductListP()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HomeAdminP admin = new HomeAdminP();
            this.Hide();
            admin.Show();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string Insert;
            string Select;

            Insert = "insert into Product values('" 
                + this.textBox1.Text + "', '" + this.textBox2.Text + "', '"
                + this.textBox3.Text + "', '" + this.textBox4.Text + "', '"
                + this.textBox5.Text + "', '" + this.textBox6.Text + "', '"
                + this.textBox7.Text + "', '" + this.textBox8.Text + "', '"
                + this.textBox9.Text + "', '" + this.textBox10.Text + "'); ";

            try
            {
                SqlCommand ins = new SqlCommand(Insert, Important.conex);
                ins.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Important.message = ex.GetType().ToString();
                DialogMessageP dial = new DialogMessageP();
                dial.ShowDialog();
            }

            Select = "select * from Product";
            SqlCommand sel = new SqlCommand(Select, Important.conex);
            SqlDataAdapter da = new SqlDataAdapter(sel);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            this.richTextBoxSQLCondition.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string Delete;
            string Select;
            if (this.richTextBoxSQLCondition.Text == "")
            {
                Delete = "delete from Product";
                DialogConfirmationP conf = new DialogConfirmationP();
                Important.message = "Doriti sa stergeti toate datele din tabel?";
                conf.label1.Text = Important.message;
                conf.ShowDialog();
            }

            else
            {
                Delete = "delete from Product where " + this.richTextBoxSQLCondition.Text;
                DialogConfirmationP conf = new DialogConfirmationP();
                Important.message = "Doriti sa stergeti aceste date din tabel?";
                conf.label1.Text = Important.message;
                conf.ShowDialog();
            }

            if (Important.confirm == true)
                try
                {
                    SqlCommand del = new SqlCommand(Delete, Important.conex);
                    del.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    Important.message = ex.GetType().ToString();
                    DialogMessageP dial = new DialogMessageP();
                    dial.ShowDialog();
                }

            Select = "select * from Product";
            SqlCommand sel = new SqlCommand(Select, Important.conex);
            SqlDataAdapter da = new SqlDataAdapter(sel);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            this.richTextBoxSQLCondition.Text = "";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string Update;
            string Select;
            string Check;

            try
            {
                Check = "select ProdName from Product where " + this.richTextBoxSQLCondition.Text + ";";
                SqlCommand comCheck1 = new SqlCommand(Check, Important.conex);
                if (this.textBox1.Text == "")
                    this.textBox1.Text = comCheck1.ExecuteScalar().ToString();

                Check = "select Type from Product where " + this.richTextBoxSQLCondition.Text + ";";
                SqlCommand comCheck2 = new SqlCommand(Check, Important.conex);
                if (this.textBox2.Text == "")
                    this.textBox2.Text = comCheck2.ExecuteScalar().ToString();

                Check = "select Origin from Product where " + this.richTextBoxSQLCondition.Text + ";";
                SqlCommand comCheck3 = new SqlCommand(Check, Important.conex);
                if (this.textBox3.Text == "")
                    this.textBox3.Text = comCheck3.ExecuteScalar().ToString();

                Check = "select Mass from Product where " + this.richTextBoxSQLCondition.Text + ";";
                SqlCommand comCheck4 = new SqlCommand(Check, Important.conex);
                if (this.textBox4.Text == "")
                    this.textBox4.Text = comCheck4.ExecuteScalar().ToString();

                Check = "select Length from Product where " + this.richTextBoxSQLCondition.Text + ";";
                SqlCommand comCheck5 = new SqlCommand(Check, Important.conex);
                if (this.textBox5.Text == "")
                    this.textBox5.Text = comCheck5.ExecuteScalar().ToString();

                Check = "select Caliber from Product where " + this.richTextBoxSQLCondition.Text + ";";
                SqlCommand comCheck6 = new SqlCommand(Check, Important.conex);
                if (this.textBox6.Text == "")
                    this.textBox6.Text = comCheck6.ExecuteScalar().ToString();

                Check = "select Diameter from Product where " + this.richTextBoxSQLCondition.Text + ";";
                SqlCommand comCheck7 = new SqlCommand(Check, Important.conex);
                if (this.textBox7.Text == "")
                    this.textBox7.Text = comCheck7.ExecuteScalar().ToString();

                Check = "select Filling from Product where " + this.richTextBoxSQLCondition.Text + ";";
                SqlCommand comCheck8 = new SqlCommand(Check, Important.conex);
                if (this.textBox8.Text == "")
                    this.textBox8.Text = comCheck8.ExecuteScalar().ToString();

                Check = "select Quantity from Product where " + this.richTextBoxSQLCondition.Text + ";";
                SqlCommand comCheck9 = new SqlCommand(Check, Important.conex);
                if (this.textBox9.Text == "")
                    this.textBox9.Text = comCheck9.ExecuteScalar().ToString();

                Check = "select Price from Product where " + this.richTextBoxSQLCondition.Text + ";";
                SqlCommand comCheck10 = new SqlCommand(Check, Important.conex);
                if (this.textBox10.Text == "")
                    this.textBox10.Text = comCheck10.ExecuteScalar().ToString();

                Update = "update Product set ProdName = '" + this.textBox1.Text + "', Type = '"
                    + this.textBox2.Text + "', Origin = '" + this.textBox3.Text + "', Mass = '"
                    + this.textBox4.Text + "', Length = '" + this.textBox5.Text + "', Caliber = '"
                    + this.textBox6.Text + "', Diameter = '" + this.textBox7.Text + "', Filling = '"
                    + this.textBox8.Text + "', Quantity = '" + this.textBox9.Text + "', Price = '"
                    + this.textBox10.Text + "' where " + this.richTextBoxSQLCondition.Text + ";";

                SqlCommand upd = new SqlCommand(Update, Important.conex);
                upd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Important.message = ex.GetType().ToString();
                DialogMessageP dial = new DialogMessageP();
                dial.ShowDialog();
            }

            Select = "select * from Product";
            SqlCommand sel = new SqlCommand(Select, Important.conex);
            SqlDataAdapter da = new SqlDataAdapter(sel);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            this.richTextBoxSQLCondition.Text = "";
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            String Querry;

            if (this.richTextBoxSQLCondition.Text == "")
            {
                Querry = "select * from Product";

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
                Querry = "select * from Product where " + this.richTextBoxSQLCondition.Text;

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

            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            this.richTextBoxSQLCondition.Text = "";
        }

        private void ProductListP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ProductListP_Load(object sender, EventArgs e)
        {

        }
    }
}
