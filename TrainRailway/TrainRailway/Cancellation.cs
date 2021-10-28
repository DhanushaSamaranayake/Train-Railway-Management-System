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
    public partial class Cancellation : Form
    {
        public Cancellation()
        {
            InitializeComponent();
            DataPop();
            FillTicketId();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\TrainRailway.mdf;Integrated Security=True;Connect Timeout=30");
        private void DataPop()
        {
            conn.Open();
            string Query = "SELECT * FROM CANCELLATIONTBL";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            var ds = new DataSet();
            sda.Fill(ds);
            datagridcancel.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void FillTicketId()
        {
            //string TrStatus = "Busy";
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Ticket_ID FROM RESERVATIONTBL", conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Ticket_ID", typeof(int));
            dt.Load(rdr);
            CMBticketID.ValueMember = "Ticket_ID";
            CMBticketID.DataSource = dt;
            conn.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void remove()
        {
            try
            {
                conn.Open();
                string Query = "DELETE FROM RESERVATIONTBL WHERE Ticket_ID=" + CMBticketID.SelectedValue.ToString() + "";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }

        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            
            if (CMBticketID.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Info...!");
            }
            else
            {
                try
                {
                    conn.Open();
                    string Query = "INSERT INTO CANCELLATIONTBL values(" + CMBticketID.SelectedValue.ToString() + ",'" + DateTime.Today.Date+ "')";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ticket Cancelled...!");
                    conn.Close();
                    DataPop();
                    remove();
                    FillTicketId();
                    CMBticketID.SelectedIndex = -1;
                    //reset();
                }
                catch (Exception ea)
                {
                    MessageBox.Show(ea.Message);
                }
            }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            Dasboard ds = new Dasboard();
            ds.Show();
            this.Hide();
        }

        private void Cancel_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
