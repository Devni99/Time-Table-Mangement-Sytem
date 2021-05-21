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
    public partial class ManageNotOverlappingSessions : Form
    {
        public ManageNotOverlappingSessions()
        {
            InitializeComponent();
            populate();
        }

        //Connection String 
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void populate()
        {
            Con.Open();
            string query = "Select * From NotOverlapping";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            NotDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        //Update
        private void button3_Click(object sender, EventArgs e)
        {

            if (lec01.Text == "" || lec02.Text == "" || code.Text == "" || subject.Text == "" || groupID.Text == "" || tag.Text == "" || duration.Text == "")
            {
                MessageBox.Show("Please Select a Session Detail do be Updated !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Update NotOverlapping set Lec01 ='" + lec01.Text + "', Lec02='" + lec02.Text + "', Code ='" + code.Text + "', Subject = '" + subject.Text + "', GroupID ='" + groupID.Text + "', Tag ='" + tag.Text + "'  , NumOfStu ='" + NoStudents.Text + "', Duration ='" + duration.Text + "' where SessionID =" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Session Details Updated Successfully .");
                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        //clear method
        private void Clear()
        {
            lec01.Text = "";
            lec02.Text = "";
            code.Text = "";
            subject.Text = "";
            groupID.Text = "";
            tag.Text = "";
            NoStudents.Text = "";
            duration.Text = "";

        }

        //Data Grid View Onclick
        int key = 0;

        private void NotDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //TagID = Convert.ToInt32(TagDGV.Rows[0].Cells[0].Value);
            lec01.Text = NotDGV.SelectedRows[0].Cells[1].Value.ToString();
            lec02.Text = NotDGV.SelectedRows[0].Cells[2].Value.ToString();
            code.Text = NotDGV.SelectedRows[0].Cells[3].Value.ToString();
            subject.Text = NotDGV.SelectedRows[0].Cells[4].Value.ToString();
            groupID.Text = NotDGV.SelectedRows[0].Cells[5].Value.ToString();
            tag.Text = NotDGV.SelectedRows[0].Cells[6].Value.ToString();
            NoStudents.Text = NotDGV.SelectedRows[0].Cells[7].Value.ToString();
            duration.Text = NotDGV.SelectedRows[0].Cells[8].Value.ToString();

            if (lec01.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(NotDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        //Delete
        private void button4_Click(object sender, EventArgs e)
        {

            if (key == 0)
            {
                MessageBox.Show("Select a Session to be Deleted !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Delete from NotOverlapping where SessionID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Deleted Successfully ");
                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            NotOverlappingSession mc = new NotOverlappingSession();
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
            TimeTable_Lec ad = new TimeTable_Lec();
            ad.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ParallelSession ad = new ParallelSession();
            ad.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NotOverlappingSession ad = new NotOverlappingSession();
            ad.Show();
            this.Hide();
        }

        private void ManageNotOverlappingSessions_Load(object sender, EventArgs e)
        {

        }
    }
}
