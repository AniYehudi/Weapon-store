using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Practice.Login;

namespace Practice
{
    public partial class UserListP : Form
    {
        public UserListP()
        {
            InitializeComponent();
        }

        private void UserListP_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HomeAdminP admin = new HomeAdminP();
            this.Hide();
            admin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Insert;
            string Select;

            Insert = "insert into _User values('" + this.textBox1.Text + "', '" + this.textBox2.Text +
                    "', '" + this.textBox3.Text + "', '" + this.textBox4.Text + "', '" + this.textBox5.Text
                    + "', " + Convert.ToDouble(this.textBox6.Text) + "); ";

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

            Select = "select * from _User";
            SqlCommand sel = new SqlCommand(Select, Important.conex);
            SqlDataAdapter da = new SqlDataAdapter(sel);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            this.textBox1.Text = "";
            this.textBox6.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Querry;
            if (this.richTextBox1.Text == "")
            {
                Querry = "select * from _User";

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
                Querry = "select * from _User where " + this.richTextBox1.Text;

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
            this.textBox6.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.richTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Delete;
            string Select;
            if (this.richTextBox1.Text == "")
            {
                Delete = "delete from _User";
                DialogConfirmationP conf = new DialogConfirmationP();
                Important.message = "Doriti sa stergeti toate datele din tabel?";
                conf.label1.Text = Important.message;
                conf.ShowDialog();
            }


            else
            {
                Delete = "delete from _User where " + this.richTextBox1.Text;
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

            Select = "select * from _User";
            SqlCommand sel = new SqlCommand(Select, Important.conex);
            SqlDataAdapter da = new SqlDataAdapter(sel);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            this.textBox1.Text = "";
            this.textBox6.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.richTextBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Update;
            string Select;
            string Check;

            try
            {
                Check = "select FullName from _User where " + this.richTextBox1.Text + ";";
                SqlCommand comCheck1 = new SqlCommand(Check, Important.conex);
                if (this.textBox1.Text == "")
                    this.textBox1.Text = comCheck1.ExecuteScalar().ToString();

                Check = "select Username from _User where " + this.richTextBox1.Text + ";";
                SqlCommand comCheck2 = new SqlCommand(Check, Important.conex);
                if (this.textBox2.Text == "")
                    this.textBox2.Text = comCheck2.ExecuteScalar().ToString();

                Check = "select Email from _User where " + this.richTextBox1.Text + ";";
                SqlCommand comCheck3 = new SqlCommand(Check, Important.conex);
                if (this.textBox3.Text == "")
                    this.textBox3.Text = comCheck3.ExecuteScalar().ToString();

                Check = "select Password from _User where " + this.richTextBox1.Text + ";";
                SqlCommand comCheck4 = new SqlCommand(Check, Important.conex);
                if (this.textBox4.Text == "")
                    this.textBox4.Text = comCheck4.ExecuteScalar().ToString();

                Check = "select UserType from _User where " + this.richTextBox1.Text + ";";
                SqlCommand comCheck5 = new SqlCommand(Check, Important.conex);
                if (this.textBox5.Text == "")
                    this.textBox5.Text = comCheck5.ExecuteScalar().ToString();

                Check = "select Charge from _User where " + this.richTextBox1.Text + ";";
                SqlCommand comCheck6 = new SqlCommand(Check, Important.conex);
                if (this.textBox6.Text == "")
                    this.textBox6.Text = comCheck6.ExecuteScalar().ToString();

                Update = "update _User set FullName = '" + this.textBox1.Text + "', Username = '"
                    + this.textBox2.Text + "', Email = '" + this.textBox3.Text + "', Password = '"
                    + this.textBox4.Text + "', UserType = '" + this.textBox5.Text + "', Charge = " + Convert.ToDouble(this.textBox6.Text)
                    + " where " + this.richTextBox1.Text + ";";

                SqlCommand upd = new SqlCommand(Update, Important.conex);
                upd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Important.message = ex.GetType().ToString();
                DialogMessageP dial = new DialogMessageP();
                dial.ShowDialog();
            }

            Select = "select * from _User";
            SqlCommand sel = new SqlCommand(Select, Important.conex);
            SqlDataAdapter da = new SqlDataAdapter(sel);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            this.textBox1.Text = "";
            this.textBox6.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.richTextBox1.Text = "";
        }

        private void UserListP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
