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
    public partial class Tags : Form
    {
        public Tags()
        {
            InitializeComponent();
            populate();
        }
        //Connection String 
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");
        public int TagID;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ManageStudent_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Addstudents Ob = new Addstudents();
            Ob.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //delete Tag
        private void button10_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Tag to be Deleted !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Delete from Tag where TagID =" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tag Deleted Successfully.");
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

        //Update Query
        private void button13_Click(object sender, EventArgs e)
        {
            if (tagname.Text == "" || taglabel.Text == "")
            {
                MessageBox.Show("Please Select a Tag do be Updated !");
            }
            else 
            {
                try
                {
                    Con.Open();
                    string Query = "Update Tag set TagName ='" +tagname.Text+ "',TagLabel ='"+taglabel.Text+"' where TagID =" +key+";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tag Details Updated Successfully.");
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

        private void label2_Click_1(object sender, EventArgs e)
        {
            Session_ManagementDashboard sd = new Session_ManagementDashboard();
            sd.Show();
            this.Hide();
        }

        //to display data to the gridview when page is loaded
        private void populate()
        {
            Con.Open();
            string query = "Select * From Tag";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TagDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        //Save Tags
        private void button1_Click(object sender, EventArgs e)
        {
            if(tagname.Text == "" || taglabel.Text == "")
            {
                MessageBox.Show("Please Fill All Fields !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into Tag values ('" +tagname.Text+"','"+taglabel.Text+"')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tag Details Saved Successfully.");
                    Con.Close();
                    populate();
                    Clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Clear()
        {
            tagname.Text = "" ;
            taglabel.Text = "" ;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Data Grid View Onclick
        int key = 0;
        private void TagDGV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //TagID = Convert.ToInt32(TagDGV.Rows[0].Cells[0].Value);
            tagname.Text = TagDGV.SelectedRows[0].Cells[1].Value.ToString();
            taglabel.Text = TagDGV.SelectedRows[0].Cells[2].Value.ToString();

            if(tagname.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TagDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void TagDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tagname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Tags tags = new Tags();
            tags.Show();
            this.Hide();
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
