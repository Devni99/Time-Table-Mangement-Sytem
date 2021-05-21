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
    public partial class WorkingDays : Form
    {
        public WorkingDays()
        {
            InitializeComponent();
            populate();
        }
        WorkTimeHour c = new WorkTimeHour();

        private void WorkingDays_Load(object sender, EventArgs e)
        {

        }

        private void populate()
        {
            Con.Open();
            string query = "Select * From WorkingDays";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.noworkd = cmbNofwday.Text;
            c.day1 = cmb1.Text;
            c.day2 = cmb2.Text;
            c.day3 = cmb3.Text;
            c.day4 = cmb4.Text;
            c.day5 = cmb5.Text;
            c.day6 = cmb6.Text;
            c.day7 = cmb7.Text;
            c.stime = cmbst.Text;
            c.dura = cmbdura.Text;
            c.etime = cmbet.Text;
            c.hours = txthrs.Text;

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
            dataGridView1.DataSource = dt;
            populate();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            c.lectureid = int.Parse(txtid.Text);
            c.noworkd = cmbNofwday.Text;
            c.day1 = cmb1.Text;
            c.day2 = cmb2.Text;
            c.day3 = cmb3.Text;
            c.day4 = cmb4.Text;
            c.day5 = cmb5.Text;
            c.day6 = cmb6.Text;
            c.day7 = cmb7.Text;
            c.stime = cmbst.Text;
            c.dura = cmbdura.Text;
            c.etime = cmbet.Text;
            c.hours = txthrs.Text;
            bool success = c.Update(c);
            if (success == true)
            {
                MessageBox.Show(" Successfully updated");
                DataTable dt = c.select();
                dataGridView1.DataSource = dt;
                populate();
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Update .Try again");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            c.lectureid = Convert.ToInt32(txtid.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                MessageBox.Show("Successfully Deleted");
                DataTable dt = c.select();
                dataGridView1.DataSource = dt;
                populate();
                clear();


            }
            else
            {
                MessageBox.Show("Failed to Delete");
            }
        }

        //Connection String
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtsearch.Text;
            
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM WorkingDays WHERE lectureid LIKE '%" + keyword + "%'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void clear()
        {
            txtid.Text = "";
            cmbNofwday.Text = "";
            cmb1.Text = "";
            cmb2.Text = "";
            cmb3.Text = "";
            cmb4.Text = "";
            cmb5.Text = "";
            cmb6.Text = "";
            cmb7.Text = "";
            cmbst.Text = "";
            cmbdura.Text = "";
            cmbet.Text = "";
            txthrs.Text = "";

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtid.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            cmbNofwday.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            cmb1.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            cmb2.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            cmb3.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            cmb4.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            cmb5.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            cmb6.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            cmb7.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
            cmbst.Text = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
            cmbdura.Text = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
            cmbet.Text = dataGridView1.Rows[rowIndex].Cells[11].Value.ToString();
            txthrs.Text = dataGridView1.Rows[rowIndex].Cells[12].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
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
