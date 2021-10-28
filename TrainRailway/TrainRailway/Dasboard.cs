using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainRailway
{
    public partial class Dasboard : Form
    {
        public Dasboard()
        {
            InitializeComponent();
        }

        private void gunaElipsePanel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void gunaElipsePanel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void gunaCirclePictureBox2_Click(object sender, EventArgs e)
        {
            Train_Management train = new Train_Management();
            train.Show();
            this.Hide();
        }

        private void gunaCirclePictureBox3_Click(object sender, EventArgs e)
        {
            Passenger ps = new Passenger();
            ps.Show();
            this.Hide();
        }

        private void gunaCirclePictureBox4_Click(object sender, EventArgs e)
        {
            Availability tr = new Availability();
            tr.Show();
            this.Hide();
        }

        private void gunaCirclePictureBox5_Click(object sender, EventArgs e)
        {
            Booking rs = new Booking();
            rs.Show();
            this.Hide();
        }

        private void gunaCirclePictureBox6_Click(object sender, EventArgs e)
        {
            Cancellation cl = new Cancellation ();
            cl.Show();
            this.Hide();
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {
            Train_Management train = new Train_Management();
            train.Show();
            this.Hide();
        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {
            Passenger ps = new Passenger();
            ps.Show();
            this.Hide();
        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {
            Availability tr = new Availability();
            tr.Show();
            this.Hide();
        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {
            Booking rs = new Booking();
            rs.Show();
            this.Hide();
        }

        private void gunaLabel6_Click(object sender, EventArgs e)
        {
            Cancellation cl = new Cancellation();
            cl.Show();
            this.Hide();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            Login Lg = new Login();
            Lg.Show();
            this.Hide();
        }

        private void Dasboard_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
