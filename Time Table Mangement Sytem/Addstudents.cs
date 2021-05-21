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
    public partial class Addstudents : Form
    {
        public Addstudents()
        {
            InitializeComponent();
            //display when the page is open
            populate();
        }

        //Connection String 
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");
       

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tags manageStudent = new Tags();
            manageStudent.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Session_ManagementDashboard sd = new Session_ManagementDashboard();
            sd.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Addstudents_Load(object sender, EventArgs e)
        {

        }

        //Update Query
        private void button4_Click(object sender, EventArgs e)
        {
            if (year.SelectedIndex == -1 || programme.SelectedIndex == -1 || mainGroup.SelectedIndex == -1 || subGroup.SelectedIndex == -1 || groupId.Text == "" || subGroup.Text == "")
            {
                MessageBox.Show("Please Select a Student Group Detail do be Updated !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Update Student set Year ='"+year.SelectedItem.ToString()+"', Programme ='"+programme.SelectedItem.ToString()+"', GroupNo ='"+mainGroup.SelectedItem.ToString()+"', SubNo = '"+ subGroup.SelectedItem.ToString()+ "', GroupID ='"+groupId.Text+ "',SubID ='"+subId.Text+ "'  where StudentID =" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Group Details Updated Successfully .");
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //Genereate IDs
        private void button1_Click(object sender, EventArgs e)
        {
            string years = year.SelectedItem.ToString();
            string programmes = programme.SelectedItem.ToString();
            string mainG = mainGroup.SelectedItem.ToString();
            string subG = subGroup.SelectedItem.ToString();

              groupId.Text = years + "." +programmes + "."+ mainG;
              subId.Text = years + "." + programmes + "." + mainG + "." + subG;


        }

        //Save Student group 
        private void button13_Click(object sender, EventArgs e)
        {
            if (year.SelectedIndex == -1 || programme.SelectedIndex == -1 || mainGroup.SelectedIndex == -1 || subGroup.SelectedIndex == -1 || groupId.Text == "" || subId.Text == "" )
            {
                MessageBox.Show("Please Fill All Fields !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into Student values ('" +year.SelectedItem.ToString() + "','" + programme.SelectedItem.ToString() + "','" +mainGroup.SelectedItem.ToString() + "','" +subGroup.SelectedItem.ToString()+ "','" +groupId.Text+"','"+subId.Text+"')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Details Saved Successfully .");
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

        

        //to display data to the gridview when page is loaded
        private void populate()
        {
            Con.Open();
            string query = "Select * From Student";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
           StudentDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        //clear method
        private void Clear()
        {
            year.Text = "";
            programme.Text = "";
            mainGroup.Text = "";
            subGroup.Text = "";
            groupId.Text = "";
            subId.Text = "";

        }
        //Clear
        private void button11_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Data Grid View Onclick
        int key = 0;
        private void StudentDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //TagID = Convert.ToInt32(TagDGV.Rows[0].Cells[0].Value);
            year.SelectedItem  = StudentDGV.SelectedRows[0].Cells[1].Value.ToString();
            programme.SelectedItem = StudentDGV.SelectedRows[0].Cells[2].Value.ToString();
            mainGroup.SelectedItem = StudentDGV.SelectedRows[0].Cells[3].Value.ToString();
            subGroup.SelectedItem = StudentDGV.SelectedRows[0].Cells[4].Value.ToString();
            groupId.Text = StudentDGV.SelectedRows[0].Cells[5].Value.ToString();
            subId.Text = StudentDGV.SelectedRows[0].Cells[6].Value.ToString();


            if (year.SelectedItem == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(StudentDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        //Delete Query
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Student Detail to be Deleted !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Delete from Student where StudentID=" + key + ";";
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

        private void label16_Click(object sender, EventArgs e)
        {
            Addstudents addstudents = new Addstudents();
            addstudents.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
           Tags tags = new Tags();
            tags.Show();
            this.Hide();
        }

        private void StudentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            Lecturer ad = new Lecturer();
            ad.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Subjects ad = new Subjects();
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

        private void label12_Click(object sender, EventArgs e)
        {
            TimeTable_Lec ad = new TimeTable_Lec();
            ad.Show();
            this.Hide();
        }
    }
}
