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
    public partial class AddSessions : Form
    {
        SqlConnection Con;
        private int listBoxRowCount = 0;
        private int x = 0;
        private int id = 0;
        List<String> LecturerName = new List<String>();

        public AddSessions()
        {
            InitializeComponent();

            SelectTag.Text = "< - - - - Select - - - - >";

            //Connection String 
            Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");
        }

        

        private void loadAllData()
        {
            populate();
            loadLecturers();
            loadSubjects();
            loadSubCodes();
            loadGroups();
        }

        private void populate()
        {
            Con.Open();
            string query = "Select * From Session";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SessionDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        public void loadLecturers()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Name FROM dbo.[Lecturer]", Con);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                SelectLecturer.DataSource = dataTable;
                SelectLecturer.DisplayMember = "Name";
                SelectLecturer.ValueMember = "Name";

                SelectLecturer.Text = "< - - - - Select - - - - >";
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadSubjects()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT SubName FROM dbo.[Subject]", Con);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                SelectSubject.DataSource = dataTable;
                SelectSubject.DisplayMember = "SubName";
                SelectSubject.ValueMember = "SubName";

                SelectSubject.Text = "< - - - - Select - - - - >";
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadSubCodes()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT SubCode FROM dbo.[Subject]", Con);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                SelectSubCode.DataSource = dataTable;
                SelectSubCode.DisplayMember = "SubCode";
                SelectSubCode.ValueMember = "SubCode";

                SelectSubCode.Text = "< - - - - Select - - - - >";
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void loadGroups()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT GroupID FROM dbo.[Student]", Con);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                SelectGroup.DataSource = dataTable;
                SelectGroup.DisplayMember = "GroupID";
                SelectGroup.ValueMember = "GroupID";//

                SelectGroup.Text = "< - - - - Select - - - - >";//
                Con.Close();//
            }
            catch (Exception ex)//
            {
                MessageBox.Show(ex.Message);//
            }//
        }

        //save
        private void Save_Click(object sender, EventArgs e)
        {
            if (SelectLecturer.SelectedIndex == -1 || SelectedLecList.Items.Count == 0 || SelectTag.SelectedIndex == -1 || SelectGroup.SelectedIndex == -1 || SelectSubject.SelectedIndex == -1 || SelectSubCode.SelectedIndex == -1 || NumOfStudents.Text == "" || Duration.Text == "")
            {
                MessageBox.Show("Please Fill All Fields !");
            }
            else
            {
                try
                {
                    string lec_1, lec_2;

                    if (LecturerName.Count < 3)
                    {

                        lec_1 = LecturerName[1].ToString();
                        lec_2 = "N/A";

                    }
                    else
                    {
                        lec_1 = LecturerName[1].ToString();
                        lec_2 = LecturerName[2].ToString();
                    }


                    Con.Open();
                    string Query = "insert into Session values ('" + lec_1 + "','" + lec_2 + "','" + SelectSubCode.Text + "','" + SelectSubject.Text + "','" + SelectGroup.Text + "','" + SelectTag.Text + "','" + NumOfStudents.Text + "','" + Duration.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Session Details Saved Successfully .");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        public void clear()
        {
            loadAllData();
            SelectedLecList.Items.Clear();
            Duration.ResetText();
            NumOfStudents.ResetText();
            //Date.ResetText();
            SelectTag.Text = "< - - - - Select - - - - >";
            listBoxRowCount = 1;
            x = 1;
            LecturerName.Clear();
            LecturerName.Add("1");
            id = 0;
            Save.Enabled = true;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (SelectLecturer.SelectedIndex == -1 || SelectedLecList.Items.Count == 0 || SelectTag.SelectedIndex == -1 || SelectGroup.SelectedIndex == -1 || SelectSubject.SelectedIndex == -1 || SelectSubCode.SelectedIndex == -1 || NumOfStudents.Text == "" || Duration.Text == "")
            {
                MessageBox.Show("Please Fill All Fields !");
            }
            else
            {
                try
                {
                    string lec_1, lec_2;

                    if (LecturerName.Count < 3)
                    {

                        lec_1 = LecturerName[1].ToString();
                        lec_2 = "N/A";

                    }
                    else
                    {
                        lec_1 = LecturerName[1].ToString();
                        lec_2 = LecturerName[2].ToString();
                    }

                    Con.Open();
                    string Query = "Update Session set  Lecturer1 ='" + lec_1 + "', Lecturer2 ='" + lec_2 + "', SubjectCode ='" + SelectSubCode.Text + "', SubjectName ='" + SelectSubject.Text + "', GroupID  = '" + SelectGroup.Text + "',  Tag = '" + SelectTag.Text + "',  NumOfStu  = '" + NumOfStudents.Text + "',  Duration  = '" + Duration.Text + "' where Id =" + id + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Session Details Updated Successfully .");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            {
                if (id == 0)
                {
                    MessageBox.Show("Select a Session to be Deleted !");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        string Query = "Delete from Session where Id=" + id + ";";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Session Deleted Successfully ");
                        Con.Close();
                        populate();
                        clear();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }

        private void SessionDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void AddSessions_Load(object sender, EventArgs e)
        {
            loadAllData();
        }

        

        private void SelectedLecList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void SessionDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Save.Enabled = false;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = SessionDGV.Rows[e.RowIndex];
                    id = Int32.Parse(row.Cells[0].Value.ToString());
                    SelectSubCode.Text = row.Cells[3].Value.ToString();
                    SelectSubject.Text = row.Cells[4].Value.ToString();
                    SelectGroup.Text = row.Cells[5].Value.ToString();
                    SelectTag.Text = row.Cells[6].Value.ToString();
                    NumOfStudents.Text = row.Cells[7].Value.ToString();
                    Duration.Text = row.Cells[8].Value.ToString();
                    //Date.Text = row.Cells[9].Value.ToString();

                    if (row.Cells[2].Value.ToString() == "N/A")
                    {
                        SelectLecturer.Text = "1. " + row.Cells[1].Value.ToString();
                    }
                    else
                    {
                        SelectLecturer.Text = "1. " + row.Cells[1].Value.ToString() + ", 2. " + row.Cells[2].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectLecturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxRowCount == 0)
                {
                    SelectedLecList.Items.Clear();
                    listBoxRowCount++;
                }
                else if (LecturerName.Count < 3)
                {

                    LecturerName.Add(SelectLecturer.Text);

                    if (x != 0)
                    {


                        SelectedLecList.Items.Add(x + ". " + LecturerName[x]);

                        x++;
                    }
                    else
                    {
                        x++;
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SessionDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void SelectTag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
