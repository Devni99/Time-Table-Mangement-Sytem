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
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
            populate();
        }

        //Connection String 
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");
        public int SessionRoomID ;

        private void button2_Click(object sender, EventArgs e)
        {

            if (lec01.Text == "" || room.Text == "")
            {
                MessageBox.Show("Please Fill All Fields !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into SessionRoom values ('" + lec01.Text + "','" + lec02.Text + "','" + code.Text + "','" + subject.Text + "','" + groupID.Text + "','" + tag.Text + "','" + duration.Text + "','" + room.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Details Saved Successfully.");
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (lec02.Text == "" || room.Text == "")
            {
                MessageBox.Show("Please Select a Session room to be Updated !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Update SessionRoom set Lec01 ='" + lec01.Text + "', Lec02 ='" + lec02.Text + "', Code ='" + code.Text + "', Subject ='" + subject.Text + "', GroupID ='" + groupID.Text + "', Tag ='" + tag.Text + "', Duration='" + duration.Text + "', Room ='" + room.Text + "' where SessionRoomID =" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Session Room  Details Updated Successfully.");
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

        private void populate()
        {
            Con.Open();
            string query = "Select * From SessionRoom";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            RoomDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        //Data Grid View Onclick
        int key = 0;
        private void RoomDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // TagID = Convert.ToInt32(TagDGV.Rows[0].Cells[0].Value);
            lec01.Text = RoomDGV.SelectedRows[0].Cells[1].Value.ToString();
            lec02.Text = RoomDGV.SelectedRows[0].Cells[2].Value.ToString();
            code.Text = RoomDGV.SelectedRows[0].Cells[3].Value.ToString();
            subject.Text = RoomDGV.SelectedRows[0].Cells[4].Value.ToString();
            groupID.Text = RoomDGV.SelectedRows[0].Cells[5].Value.ToString();
            tag.Text = RoomDGV.SelectedRows[0].Cells[6].Value.ToString();
            duration.Text = RoomDGV.SelectedRows[0].Cells[7].Value.ToString();
            room.Text = RoomDGV.SelectedRows[0].Cells[8].Value.ToString();

            if (lec01.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(RoomDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Session Room to be Deleted !");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Delete from SessionRoom where SessionRoomID =" + key + ";";
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

        private void Clear()
        {
            lec01.Text = "";
            lec02.Text = "";
            code.Text = "";
            subject.Text = "";
            groupID.Text = "";
            tag.Text = "";
            duration.Text = "";
            room.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
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

        private void AddRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
