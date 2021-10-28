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
    public partial class Availability : Form
    {
        public Availability()
        {
            InitializeComponent();
            DataPop();
            FillCMBtraincode();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\TrainRailway.mdf;Integrated Security=True;Connect Timeout=30");
        private void DataPop()
        {
            conn.Open();
            string Query = "SELECT * FROM TRAVELTBL";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            var ds = new DataSet();
            sda.Fill(ds);
            traveldatagrid.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void FillCMBtraincode()
        {
            string TrStatus = "Available";
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Train_ID FROM TRAINTBL WHERE Train_Status = '" + TrStatus + "'", conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Train_ID", typeof(int));
            dt.Load(rdr);
            combotraincode.ValueMember = "Train_ID";
            combotraincode.DataSource = dt;
            conn.Close();
        }

        private void ChangeStatus()
        {
            string TrStatus = "Available";
            try
            {
                conn.Open();
                string Query = "UPDATE TRAINTBL SET Train_Status='" + TrStatus + "' WHERE Train_ID = " + combotraincode.SelectedValue.ToString() + ";";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                DataPop();
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }
        }

        private void travel_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void BTNadd_Click(object sender, EventArgs e)
        {
            if (txttravelcost.Text == "" || combotraincode.SelectedIndex == -1 || combosource.SelectedIndex == -1 || combodestination.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Info...!");
            }
            else
            {

                try
                {
                    conn.Open();
                    string Query = "INSERT INTO TRAVELTBL values('" + txtdateandtime.Value + "','" + combotraincode.SelectedValue.ToString() + "','" + combosource.SelectedItem.ToString() + "','" + combodestination.SelectedItem.ToString() + "'," + txttravelcost.Text + ")";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Travel Add Successful...!");
                    conn.Close();
                    DataPop();
                    ChangeStatus();
                    //reset();
                }
                catch (Exception ea)
                {
                    MessageBox.Show(ea.Message);
                }
            }
        }

        private void BTNreset_Click(object sender, EventArgs e)
        {
            combosource.SelectedIndex = -1;
            combodestination.SelectedIndex = -1;
            txttravelcost.Text = "";
        }

        private void BTNedit_Click(object sender, EventArgs e)
        {

            if (combotraincode.SelectedIndex == -1 || combodestination.SelectedIndex == -1 || txttravelcost.Text == "")
            {
                MessageBox.Show("Missing Info...!");
            }
            else
            {

                try
                {
                    conn.Open();
                    //string Query = "INSERT INTO PASSENGERTBL values('" + txtPassengerName.Text + "','" + txtPassengerAddress.Text + "','" + Gender + "','" + CMBnationality.SelectedItem.ToString() + "','" + txtPassengerPhone.Text + "')";
                    string Query = "UPDATE TRAVELTBL  SET Travel_Date='" + txtdateandtime.Value + "',Train=" + combotraincode.SelectedValue.ToString() + ",Source='" + combosource.SelectedItem.ToString() + "',Destination='" + combodestination.SelectedItem.ToString() + "',Cost=" + txttravelcost.Text + " WHERE Travel_Code = " + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Travel Update Successfully...!");
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

        int key = 0;
   
        private void traveldatagrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtdateandtime.Text = traveldatagrid.SelectedRows[0].Cells[1].Value.ToString();
            combotraincode.SelectedValue = traveldatagrid.SelectedRows[0].Cells[2].Value.ToString();
            combosource.SelectedItem = traveldatagrid.SelectedRows[0].Cells[3].Value.ToString();
            combodestination.SelectedItem = traveldatagrid.SelectedRows[0].Cells[4].Value.ToString();
            txttravelcost.Text = traveldatagrid.SelectedRows[0].Cells[5].Value.ToString();
            if (combotraincode.SelectedIndex == -1)
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(traveldatagrid.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void combotraincode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
           Dasboard ds = new Dasboard();
            ds.Show();
            this.Hide();
        }
    }
}
