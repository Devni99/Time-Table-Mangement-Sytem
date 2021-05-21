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
    public partial class ConsecutiveSession : Form
    {
        public ConsecutiveSession()
        {
            InitializeComponent();
            populate();
        }

        //Connection String 
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");


        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

            foreach (DataGridViewRow dr in SessionDGV.Rows)
            {
                bool chkboxSelected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                if (chkboxSelected)
                {
                    string sqlquery = "Insert into ConsectiveSession values (@Lec01,@Lec02,@Code,@Subject,@GroupID,@Tag,@NumOfStu,@Duration)";
                    SqlCommand sqlComm = new SqlCommand(sqlquery, Con);
                    sqlComm.Parameters.AddWithValue("@Lec01", dr.Cells[2].Value);
                    sqlComm.Parameters.AddWithValue("@Lec02", dr.Cells[3].Value);
                    sqlComm.Parameters.AddWithValue("@Code", dr.Cells[4].Value);
                    sqlComm.Parameters.AddWithValue("@Subject", dr.Cells[5].Value);
                    sqlComm.Parameters.AddWithValue("@GroupID", dr.Cells[6].Value);
                    sqlComm.Parameters.AddWithValue("@Tag", dr.Cells[7].Value);
                    sqlComm.Parameters.AddWithValue("@NumOfStu", dr.Cells[8].Value);
                    sqlComm.Parameters.AddWithValue("@Duration", dr.Cells[9].Value);
                    Con.Open();
                    sqlComm.ExecuteNonQuery();
                    Con.Close();
                }
                label2.Text = "Selected Recordes Inserted Successfully";
            }
        }

        private void populate()
        {
            Con.Open();
            string query = "Select * From Session";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Con.Close();
        }

        private void ConsecutiveSession_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timeTableDatabaseDataSet2.Session' table. You can move, or remove it, as needed.
            this.sessionTableAdapter.Fill(this.timeTableDatabaseDataSet2.Session);
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "";
            chkbox.Width = 30;
            chkbox.Name = "checkBoxColumn";
            SessionDGV.Columns.Insert(0, chkbox);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManageConsecutive mc = new ManageConsecutive();
            mc.Show();
            this.Hide();
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
            Session_ManagementDashboard sd = new Session_ManagementDashboard();
            sd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ParallelSession ad = new ParallelSession();
            ad.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NotOverlappingSession ad = new NotOverlappingSession();
            ad.Show();
            this.Hide();
        }
    }
}
