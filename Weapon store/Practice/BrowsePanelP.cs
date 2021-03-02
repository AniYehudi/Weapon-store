using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using static Practice.Login;

namespace Practice
{
    public partial class BrowsePanelP : Form
    {
        public static double Cost;
        public static double AmountMoney;

        private void BuyProductTransaction()
        {
            SqlCommand UserId = new SqlCommand("select UserId from _User where Username = '" + Important.uName + "\'", Important.conex);
            SqlCommand ProdId = new SqlCommand("select ProdId from Product where ProdName = '" + this.labelProdName.Text + "\'", Important.conex);
            SqlCommand Money = new SqlCommand("select Charge from _User where Username = '" + Important.uName + "\'", Important.conex);
            SqlCommand Quantity = new SqlCommand("select Quantity from Product where ProdName = '" + this.labelProdName.Text + "\'", Important.conex);

            string Transaction =
                "BEGIN TRANSACTION\n" +
                "insert into Sale values(" + Convert.ToInt32(UserId.ExecuteScalar().ToString()) +
                ", " + Convert.ToInt32(ProdId.ExecuteScalar().ToString()) +
                ", " + Cost +
                ", " + Convert.ToInt32(this.textBoxQuan.Text) +
                ", getdate());\n" +
                " update Product set Quantity = " + (Convert.ToInt32(Quantity.ExecuteScalar().ToString()) - Convert.ToInt32(this.textBoxQuan.Text)) +
                " where ProdName = '" + Important.ProdName +
                "'; update _User set Charge = " + (Math.Round(Convert.ToDouble(Money.ExecuteScalar().ToString()), 2) - Math.Round(AmountMoney, 2)) +
                " where Username = '" + Important.uName + "'; " +
                "COMMIT";

            SqlCommand buy = new SqlCommand(Transaction, Important.conex);
            buy.ExecuteNonQuery();
        }

        public BrowsePanelP()
        {
            InitializeComponent();
        }

        private void BrowsePanelP_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Lista de produse");

            for (int i = 0; i < Important.pifiles.Length; i++)
            {
                FileInfo file = new FileInfo(Important.pifiles[i]);
                table.Rows.Add(file.Name.Substring(0, file.Name.LastIndexOf(".")));
            }

            dataGridView1.DataSource = table;
            Important.ProdName = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.labelProdName.Text = Important.ProdName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeClientP home = new HomeClientP();
            this.Hide();
            home.Show();
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            ProductInformationP prodinfo = new ProductInformationP();
            string prodName = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            Image img;
            img = Image.FromFile(Important.prodimgadr + prodName + ".jpg");
            prodinfo.pictureBox1.Image = img;

            string proddescr = File.ReadAllText(Important.proddescradr + prodName + ".txt");
            prodinfo.richTextBox1.Text = proddescr;
            prodinfo.ShowDialog();
        }

        private void textBoxQuan_TextChanged(object sender, EventArgs e)
        {

            string Query = "select Quantity from Product where ProdName = '" +
                    Important.ProdName + "'";

            SqlCommand SQLprodQuan = new SqlCommand(Query, Important.conex);

            try
            {
                int prodQuan = Convert.ToInt32(SQLprodQuan.ExecuteScalar().ToString());
                if (Convert.ToInt32(this.textBoxQuan.Text) <= prodQuan)
                {
                    Query = "select Price from Product where ProdName = '" +
                        Important.ProdName + "'";
                    string text;

                    try
                    {
                        SqlCommand sel = new SqlCommand(Query, Important.conex);
                        Cost = Convert.ToDouble(sel.ExecuteScalar().ToString());
                        text = this.textBoxQuan.Text;
                        if (text == "")
                            text = "0";
                        AmountMoney = Convert.ToInt32(text) * Math.Round(Cost, 2);
                    }
                    catch (Exception ex)
                    {
                        Important.message = ex.GetType().ToString();
                        DialogMessageP dial = new DialogMessageP();
                        dial.ShowDialog();
                        this.textBoxQuan.Text = "";
                    }
                    labelPrice.Text = AmountMoney.ToString() + '$';
                }

                else
                {
                    DialogMessageP dial = new DialogMessageP();
                    Important.message = "Cantitatea selectata depaseste \ncantitatea disponibila pe stock";
                    dial.ShowDialog();
                    this.textBoxQuan.Text = "0";
                }
            }

            catch
            {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Important.ProdName = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.labelProdName.Text = Important.ProdName;


            this.textBoxQuan.TabIndex = 0;
            this.textBoxQuan.Text = "0";

            string Query = "select Price from Product where ProdName = '" +
                Important.ProdName + "'";

            try
            {
                SqlCommand sel = new SqlCommand(Query, Important.conex);
                Cost = Convert.ToDouble(sel.ExecuteScalar().ToString());
                AmountMoney = Convert.ToInt32(textBoxQuan.Text) * Math.Round(Cost, 2);
            }
            catch (Exception ex)
            {
                Important.message = ex.GetType().ToString();
                DialogMessageP dial = new DialogMessageP();
                dial.ShowDialog();
                this.textBoxQuan.Text = "";
            }
            labelPrice.Text = AmountMoney.ToString() + '$';
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductInformationP prodinfo = new ProductInformationP();
            string prodName = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            Image img;
            img = Image.FromFile(Important.prodimgadr + prodName + ".jpg");
            prodinfo.pictureBox1.Image = img;

            string proddescr = File.ReadAllText(Important.proddescradr + prodName + ".txt");
            prodinfo.richTextBox1.Text = proddescr;
            prodinfo.ShowDialog();
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            DialogMessageP dial = new DialogMessageP();
            DialogConfirmationP conf = new DialogConfirmationP();
            string Query = "Select Charge from _User where Username = '" + Important.uName + "';";

            try
            {
                if (Convert.ToInt32(this.textBoxQuan.Text) < 1)
                {
                    Important.message = "Selecteaza cantitatea dorita de produse!";
                    dial.ShowDialog();
                }

                else
                {
                    SqlCommand money = new SqlCommand(Query, Important.conex);
                    double charge = Convert.ToDouble(money.ExecuteScalar().ToString());

                    if (charge < AmountMoney)
                    {
                        Important.message = "Nu aveti bani suficienti!";
                        dial.ShowDialog();
                    }

                    else
                    {
                        Important.message = "Sunteti siguri ca doriti sa cumparati acest produs?";
                        conf.ShowDialog();

                        if (Important.confirm == true)
                        {
                            BuyProductTransaction();
                            Important.message = "Va multumim pentru ca ati cumparat acest produs!";
                            dial.ShowDialog();
                        }
                    }
                }
            }
            catch { }
        }

        private void BrowsePanelP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
