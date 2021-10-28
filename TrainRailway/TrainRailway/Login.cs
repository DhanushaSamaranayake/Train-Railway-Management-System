using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainRailway
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            bool isValid = false;

            if (txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Enter UserName and Password....");
            }
            else 
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\TrainRailway.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();

                string sql = "SELECT User_Name, Password FROM AdminTBL";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader sReader;
                sReader = cmd.ExecuteReader();

                while (sReader.Read())
                {
                    if (sReader["User_Name"].ToString().Equals(txtusername.Text) && sReader["Password"].ToString().Equals(txtpassword.Text))
                    {
                        isValid = true;
                        Dasboard ds = new Dasboard();
                        this.Hide();
                        ds.Show();
                        break;
                    }
                }
                conn.Close();

                if (!isValid) 
                {
                    MessageBox.Show("Wrong UserName and Password...");
                }
            }
            /*
            else if (txtusername.Text == "Admin" && txtpassword.Text == "Admin123")
            {
                Dasboard ds = new Dasboard();
                ds.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong UserName and Password...");
            }*/
        }
    }
}
