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

namespace Time_Table_Mangement_Sytem
{
    public partial class Location : Form
    {
        public Location()
        {
            InitializeComponent();
        }

        //Connection String 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Location values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            disp_data();
            MessageBox.Show("Insert Data Successfully");
        }

        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Location";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Location where ID='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Delete Data Successfully");
        }

        private void Location_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Location set Building='" + textBox2.Text + "',Room_Name='" + textBox3.Text + "',Room_Type='" + textBox4.Text + "',Quantity='" + textBox5.Text + "'where ID='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Update Data Successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Location where ID='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Lecturer ad = new Lecturer();
            ad.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Addstudents Ob = new Addstudents();
            Ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Subjects ad = new Subjects();
            ad.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Tags ad = new Tags();
            ad.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Location ad = new Location();
            ad.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Statistics ad = new Statistics();
            ad.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            WorkingDays ad = new WorkingDays();
            ad.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Session_ManagementDashboard sd = new Session_ManagementDashboard();
            sd.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            TimeTable_Lec ad = new TimeTable_Lec();
            ad.Show();
            this.Hide();
        }
    }
}
