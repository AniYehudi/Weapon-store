using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Practice
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (Important.conex.State == ConnectionState.Closed)
                Important.conex.Open();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxPassword.Text == "")
                lblError.Text = "Toate câmpurile trebuie să fie complete!";

            else
            {
                if (radioButton1.Checked)
                    Important.uType = radioButton1.Text;

                else
                    Important.uType = radioButton2.Text;

                SqlCommand check = new SqlCommand("select COUNT(UserID) from _User where UserName = '" + textBoxUsername.Text + "' and Password = '" + textBoxPassword.Text + "' and UserType = '" + Important.uType + "'", Important.conex);
                int result = Convert.ToInt32(check.ExecuteScalar().ToString());

                if (result == 1)
                {
                    if (Important.uType == "Admin")
                    {
                        HomeAdminP admin = new HomeAdminP();
                        this.Hide();
                        Important.uName = textBoxUsername.Text;
                        admin.Show();
                    }

                    else
                    {
                        HomeClientP user = new HomeClientP();
                        this.Hide();
                        Important.uName = textBoxUsername.Text;
                        user.Show();
                    }

                }

                else
                {
                    lblError.Text = "Parolă, nume de utilizator sau tip de utilizator incorecte\nCompletați casetele cu date corecte!";
                }
            }
        }

        public class Important 
        {
            public static string uName;
            public static string uType;
            public static SqlConnection conex = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\alex\Desktop\Organiser\Training\C#\Visual C#\Weapon store\Practice\Database\practicey3db.mdf;Integrated Security=True;Connect Timeout=30");
            
            public static string prodimgadr = Environment.CurrentDirectory + @"\prodImg\";
            public static string[] pifiles = Directory.GetFiles(prodimgadr);
            public static string sysimgadr = Environment.CurrentDirectory + @"\sysImg\";
            public static string[] sifiles = Directory.GetFiles(sysimgadr);
            public static string proddescradr = Environment.CurrentDirectory + @"\prodDescr\";
            public static string[] pdfiles = Directory.GetFiles(proddescradr);

            public static string message;
            public static bool confirm;
            public static string ProdName;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
