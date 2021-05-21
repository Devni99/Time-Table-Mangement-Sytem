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
    public partial class ManageConsecutive : Form
    {
        public ManageConsecutive()
        {
            InitializeComponent();
            populate();
        }

        //Connection String 
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");


        private void label3_Click(object sender, EventArgs e)
        {

        }

        //to display data to the gridview when page is loaded
        private void populate()
        {
            Con.Open();
            string query = "Select * From ConsectiveSession";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ConsDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void ConsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        //update
        private void button15_Click(object sender, EventArgs e)
        {
            if (lec01.Text == "" || lec02.Text == "" || code.Text == ""|| subject.Text == "" || groupID.Text == "" || tag.Text == "" || duration.Text == "")
            {
                MessageBox.Show("Please Select a Session Detail do be Updated !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Update ConsectiveSession set Lec01 ='" + lec01.Text + "', Lec02='" + lec02.Text + "', Code ='" + code.Text + "', Subject = '" + subject.Text + "', GroupID ='" + groupID.Text + "', Tag ='" + tag.Text + "' , NumOfStu ='" + NoStudents.Text + "' , Duration ='" + duration.Text + "' where SessionID =" + key + ";";
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
        private void ConsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //TagID = Convert.ToInt32(TagDGV.Rows[0].Cells[0].Value);
            lec01.Text = ConsDGV.SelectedRows[0].Cells[1].Value.ToString();
            lec02.Text = ConsDGV.SelectedRows[0].Cells[2].Value.ToString();
            code.Text = ConsDGV.SelectedRows[0].Cells[3].Value.ToString();
            subject.Text = ConsDGV.SelectedRows[0].Cells[4].Value.ToString();
            groupID.Text = ConsDGV.SelectedRows[0].Cells[5].Value.ToString();
            tag.Text = ConsDGV.SelectedRows[0].Cells[6].Value.ToString();
            NoStudents.Text = ConsDGV.SelectedRows[0].Cells[7].Value.ToString();
            duration.Text = ConsDGV.SelectedRows[0].Cells[8].Value.ToString();

            if (lec01.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ConsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        //delete
        private void button1_Click(object sender, EventArgs e)
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
                    string Query = "Delete from ConsectiveSession where SessionID=" + key + ";";
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

        private void button2_Click(object sender, EventArgs e)
        {
            ConsecutiveSession cs = new ConsecutiveSession();
            cs.Show();
            this.Hide();
       
        }

        private void ManageConsecutive_Load(object sender, EventArgs e)
        {

        }

        private void lec01_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lec02_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void code_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void subject_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tag_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void duration_TextChanged(object sender, EventArgs e)
        {

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
