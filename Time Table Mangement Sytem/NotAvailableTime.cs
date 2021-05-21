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
    public partial class NotAvailableTime : Form
    {
        public NotAvailableTime()
        {
            InitializeComponent();
            populate();
            
        }

        LocationNotAvail c = new LocationNotAvail();
        notavailable ci = new notavailable();
        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //loaction
        private void btnadd_Click(object sender, EventArgs e)
        {
            c.lecid = cmblecid.Text;
            c.day = cmbday.Text;
            c.room = cmbroom.Text;
            c.dur = cmbdur.Text;
            c.stime = cmbstime.Text;
            c.etime = cmbetime.Text;

            bool success = c.Insert(c);
            if (success == true)
            {

                MessageBox.Show(" Successfully Inserted");
                clear();

            }
            else
            {
                MessageBox.Show("Failed to Add New.Try agin");

            }

            DataTable dt = c.select();
            dataGridView6.DataSource = dt;
        }

        public void clear()
        {
            txtlid.Text = "";
            cmblecid.Text = "";
            cmbroom.Text = "";
            cmbdur.Text = "";
            cmbstime.Text = "";
            cmbetime.Text = "";

        }

        //location
        private void btnupdate_Click(object sender, EventArgs e)
        {
            c.lid = int.Parse(txtlid.Text);
            c.lecid = cmblecid.Text;
            c.day = cmbday.Text;
            c.room = cmbroom.Text;
            c.dur = cmbdur.Text;
            c.stime = cmbstime.Text;
            c.etime = cmbetime.Text;
            bool success = c.Update(c);
            if (success == true)
            {
                MessageBox.Show(" Successfully updated");
                DataTable dt = c.select();
                dataGridView6.DataSource = dt;
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Update .Try again");
            }
        }

        //loaction
        private void btndelete_Click(object sender, EventArgs e)
        {
            c.lid = Convert.ToInt32(txtlid.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                MessageBox.Show("Successfully Deleted");
                DataTable dt = c.select();
                dataGridView6.DataSource = dt;


            }
            else
            {
                MessageBox.Show("Failed to Delete");
            }
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

        private void textsearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textsearch.Text;
      
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Location_not_Avaible WHERE lid LIKE '%" + keyword + "%'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView6.DataSource = dt;
        }

        private void dataGridView6_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtlid.Text = dataGridView6.Rows[rowIndex].Cells[0].Value.ToString();
            cmblecid.Text = dataGridView6.Rows[rowIndex].Cells[1].Value.ToString();
            cmbday.Text = dataGridView6.Rows[rowIndex].Cells[2].Value.ToString();
            cmbroom.Text = dataGridView6.Rows[rowIndex].Cells[3].Value.ToString();
            cmbdur.Text = dataGridView6.Rows[rowIndex].Cells[4].Value.ToString();
            cmbstime.Text = dataGridView6.Rows[rowIndex].Cells[5].Value.ToString();
            cmbetime.Text = dataGridView6.Rows[rowIndex].Cells[6].Value.ToString();
        }

        private void populate()
        {
            Con.Open();
            string query = "Select * From Location_not_Avaible";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView6.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void populate1()
        {
            Con.Open();
            string query = "Select * From Not_Avai_time";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnclear_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            cmbid.Text = dataGridView4.Rows[rowIndex].Cells[0].Value.ToString();
            cmblec.Text = dataGridView4.Rows[rowIndex].Cells[1].Value.ToString();
            cmbgrp.Text = dataGridView4.Rows[rowIndex].Cells[2].Value.ToString();
            cmbsid.Text = dataGridView4.Rows[rowIndex].Cells[3].Value.ToString();
            cmbdur1.Text = dataGridView4.Rows[rowIndex].Cells[4].Value.ToString();
            cmbstime1.Text = dataGridView4.Rows[rowIndex].Cells[5].Value.ToString();
            cmbetime1.Text = dataGridView4.Rows[rowIndex].Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ci.lec = cmblec.Text;
            ci.grp = cmbgrp.Text;
            ci.sid = cmbsid.Text;
            ci.dur = cmbdur1.Text;
            ci.stime = cmbstime1.Text;
            ci.etime = cmbetime1.Text;


            bool success = ci.Insert(ci);
            if (success == true)
            {

                MessageBox.Show(" Successfully Inserted");
                clear1();

            }
            else
            {
                MessageBox.Show("Failed to Add New.Try agin");

            }

            DataTable dt = ci.select();
            dataGridView4.DataSource = dt;
        }

        public void clear1()
        {
            cmbid.Text = "";
            cmblec.Text = "";
            cmbgrp.Text = "";
            cmbsid.Text = "";
            cmbdur1.Text = "";
            cmbstime1.Text = "";
            cmbetime1.Text = "";


        }

        private void NotAvailableTime_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ci.id = Convert.ToInt32(cmbid.Text);
            bool success = ci.Delete(ci);
            if (success == true)
            {
                MessageBox.Show("Successfully Deleted");
                DataTable dt = ci.select();
                dataGridView4.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Delete");
            }
        }

        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textsearch.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Not_Avai_time WHERE id LIKE '%" + keyword + "%'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView6.DataSource = dt;
        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate1();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            ci.id = int.Parse(cmbid.Text);

            ci.lec = cmblec.Text;
            ci.grp = cmbgrp.Text;
            ci.sid = cmbsid.Text;
            ci.dur = cmbdur1.Text;
            ci.stime = cmbstime1.Text;
            ci.etime = cmbetime1.Text;

            bool success = ci.Update(ci);
            if (success == true)
            {
                MessageBox.Show(" Successfully updated");
                DataTable dt = ci.select();
                dataGridView4.DataSource = dt;
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Update .Try again");
            }
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
