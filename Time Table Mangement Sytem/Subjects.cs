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
    public partial class Subjects : Form
    {
        public Subjects()
        {
            InitializeComponent();
            populate();
        }

        //Connection String 
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");
        private void SubDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Update
        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (OfferedYear.SelectedIndex == -1 || OfferSem.SelectedIndex == -1 || NOOfLecHour.Value == 0 || NoOFTuteHour.Value == -0 || NoOfLabHour.Value == -0 || NoOfEvaluHour.Value == -0 || SubName.Text == "" || SubCode.Text == "")
                {
                    MessageBox.Show("Please Select a Subjects Detail do be Updated !");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        string Query = "Update Subject set  SubName ='" + SubName.Text + "', OfferedYear ='" + OfferedYear.SelectedItem.ToString() + "', OfferSem ='" + OfferSem.SelectedItem.ToString() + "', NoLecHour ='" + NOOfLecHour.Text.ToString() + "', NoTuteHour  = '" + NoOFTuteHour.Text.ToString() + "',  NoLabHour = '" + NoOfLabHour.Text.ToString() + "',  NoEvaluHour  = '" + NoOfEvaluHour.Text.ToString() + "'  where SubCode=" + key + ";";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Subjects Details Updated Successfully .");
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
        }

        //Save
        private void button13_Click(object sender, EventArgs e)
        {
            {
                if (OfferedYear.SelectedIndex == -1 || OfferSem.SelectedIndex == -1 || NOOfLecHour.Value == 0 || NoOFTuteHour.Value == -0 || NoOfLabHour.Value == -0 || NoOfEvaluHour.Value == -0 || SubName.Text == "" || SubCode.Text == "")
                {
                    MessageBox.Show("Please Fill All Fields !");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        string Query = "insert into Subject values ('" + OfferedYear.SelectedItem.ToString() + "','" + OfferSem.SelectedItem.ToString() + "','" + SubName.Text + "','" + SubCode.Text + "','" + NOOfLecHour.Value.ToString() + "','" + NoOFTuteHour.Value.ToString() + "','" + NoOfLabHour.Value.ToString() + "','" + NoOfEvaluHour.Value.ToString() + "')";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Subjects Details Saved Successfully .");
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
        }

        private void populate()
        {
            Con.Open();
            string query = "Select * From Subject";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SubDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        //Delete
        private void button2_Click(object sender, EventArgs e)
        {
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a Subjects Details to be Deleted !");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        string Query = "Delete from Subject where SubCode=" + key + ";";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Lecturer Deleted Successfully ");
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
        }

        //Clear method
        private void Clear()
        {
            OfferedYear.Text = "";
            OfferSem.Text = "";
            SubName.Text = "";
            SubCode.Text = "";
            NOOfLecHour.Text = "";
            NoOFTuteHour.Text = "";
            NoOfLabHour.Text = "";
            NoOfEvaluHour.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Data Grid View Onclick
        int key = 0;
        private void SubDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OfferedYear.SelectedItem = SubDGV.SelectedRows[0].Cells[0].Value.ToString();
            OfferSem.SelectedItem = SubDGV.SelectedRows[0].Cells[1].Value.ToString();
            SubName.Text = SubDGV.SelectedRows[0].Cells[2].Value.ToString();
            SubCode.Text = SubDGV.SelectedRows[0].Cells[3].Value.ToString();
            NOOfLecHour.Text = SubDGV.SelectedRows[0].Cells[4].Value.ToString();
            NoOFTuteHour.Text = SubDGV.SelectedRows[0].Cells[5].Value.ToString();
            NoOfLabHour.Text = SubDGV.SelectedRows[0].Cells[6].Value.ToString();
            NoOfEvaluHour.Text = SubDGV.SelectedRows[0].Cells[7].Value.ToString();

            if (OfferedYear.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(SubDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Subjects sub = new Subjects();
            sub.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Lecturer lec = new Lecturer();
            lec.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Addstudents Ob = new Addstudents();
            Ob.Show();
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

        private void label12_Click(object sender, EventArgs e)
        {
            TimeTable_Lec ad = new TimeTable_Lec();
            ad.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Session_ManagementDashboard sd = new Session_ManagementDashboard();
            sd.Show();
            this.Hide();
        }

        private void Subjects_Load(object sender, EventArgs e)
        {

        }
    }
}
