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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
            DataPop();
            FillCMBpassengerID();
            FillCMBtravelcode();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\TrainRailway.mdf;Integrated Security=True;Connect Timeout=30");
        private void DataPop()
        {
            conn.Open();
            string Query = "SELECT * FROM RESERVATIONTBL";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            var ds = new DataSet();
            sda.Fill(ds);
            datagridreservation.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void FillCMBpassengerID()
        {
            //string TrStatus = "Busy";
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Passenger_ID FROM PASSENGERTBL", conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Passenger_ID", typeof(int));
            dt.Load(rdr);
            combopassengerID.ValueMember = "Passenger_ID";
            combopassengerID.DataSource = dt;
            conn.Close();
        }

        private void FillCMBtravelcode()
        {
            //string TrStatus = "Busy";
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Travel_Code FROM TRAVELTBL", conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Travel_Code", typeof(int));
            dt.Load(rdr);
            combotravelcode.ValueMember = "Travel_Code";
            combotravelcode.DataSource = dt;
            conn.Close();
        }
        string pname;
        private void GetPName()
        {
            conn.Open();
            string mysql = "SELECT * FROM PASSENGERTBL WHERE Passenger_ID =" + combopassengerID.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(mysql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                pname = dr["Passenger_Name"].ToString();

            }
            conn.Close();
            MessageBox.Show(pname);
        }
        string Date, Src, Dest;
        int Cost;
        private void GetTravel()
        {
            conn.Open();
            string mysql = "SELECT* FROM TRAVELTBL WHERE Travel_Code =" + combotravelcode.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(mysql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Date = dr["Travel_Date"].ToString();
                Src = dr["Source"].ToString();
                Dest = dr["Destination"].ToString();
                Cost = Convert.ToInt32(dr["Cost"].ToString());

            }
            conn.Close();
            MessageBox.Show(Date+Src+Dest+Cost);
        }


        private void gunaLabel4_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }

        private void combopassengerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void combotravelcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void combotravelcode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTravel();
        }

        private void combopassengerID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPName();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            Dasboard ds = new Dasboard();
            ds.Show();
            this.Hide();
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void BTNaddreservation_Click(object sender, EventArgs e)
        {

            if (combopassengerID.SelectedIndex == -1 || combotravelcode.SelectedIndex == -1)
            {
                MessageBox.Show("MISSING INFORMATION");
            }
            else
            {
                try
                {
                    conn.Open();
                    string Query = "INSERT INTO RESERVATIONTBL values(" + combopassengerID.SelectedValue.ToString() + ",'" + pname + "','" + combotravelcode.SelectedValue.ToString() + "','" + Date + "','" + Src + "','" + Dest + "'," + Cost + ")";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("RESERVATION ACCEPTED");
                    conn.Close();
                    DataPop();
                    //reset();
                }
                catch (Exception ea)
                {
                    MessageBox.Show(ea.Message);
                }
            }
       }
    }

}
