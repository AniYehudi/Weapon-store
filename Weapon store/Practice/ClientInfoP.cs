using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Practice.Login;

namespace Practice
{
    public partial class ClientInfoP : Form
    {
        public static string FullNameDisplay;
        public static string UserNameDisplay;
        public static string EmailDisplay;
        public static string PasswordDisplay;
        public static string ChargeDisplay;
        public ClientInfoP()
        {
            InitializeComponent();
            FullName();
            this.labelNc.Text = FullNameDisplay;
            UserName();
            this.labelNu.Text = UserNameDisplay;
            Email();
            this.labelE.Text = EmailDisplay;
            Password();
            this.labelP.Text = PasswordDisplay;
            Charge();
            this.labelSuma.Text = ChargeDisplay.ToString() + '$';
        }

        private void FullName()
        {
            string Query = "select FullName from _User where Username = '" + Important.uName + "'";
            SqlCommand dnc = new SqlCommand(Query, Important.conex);
            FullNameDisplay = dnc.ExecuteScalar().ToString();
        }

        private void UserName()
        {
            string Query = "select Username from _User where Username = '" + Important.uName + "'";
            SqlCommand dnu = new SqlCommand(Query, Important.conex);
            UserNameDisplay = dnu.ExecuteScalar().ToString();
        }

        private void Email()
        {
            string Query = "select Email from _User where Username = '" + Important.uName + "'";
            SqlCommand de = new SqlCommand(Query, Important.conex);
            EmailDisplay = de.ExecuteScalar().ToString();
        }

        private void Password()
        {
            string Query = "select Password from _User where Username = '" + Important.uName + "'";
            SqlCommand dp = new SqlCommand(Query, Important.conex);
            PasswordDisplay = dp.ExecuteScalar().ToString();
        }

        private void Charge()
        {
            string Query = "select Charge from _User where Username = '" + Important.uName + "'";
            SqlCommand dp = new SqlCommand(Query, Important.conex);
            ChargeDisplay = dp.ExecuteScalar().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ClientInfoP_Load(object sender, EventArgs e)
        {

        }
    }
}
