using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time_Table_Mangement_Sytem
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].XValueMember = "Registerd_Lectures";
            chart1.Series[0].YValueMembers = "Registerd_Lectures";

            chart1.Series[0].XValueMember = "Registerd_Students";
            chart1.Series[0].YValueMembers = "Registerd_Students";

            chart1.Series[0].XValueMember = "Registerd_Subjects";
            chart1.Series[0].YValueMembers = "Registerd_Subjects";

            chart1.Series[0].XValueMember = "Registerd_Rooms";
            chart1.Series[0].YValueMembers = "Registerd_Rooms";

            chart1.DataSource = timeTableDatabaseDataSet1.Statistics;
            chart1.DataBind();

        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timeTableDatabaseDataSet1.Statistics' table. You can move, or remove it, as needed.
            this.statisticsTableAdapter1.Fill(this.timeTableDatabaseDataSet1.Statistics);
            //// TODO: This line of code loads data into the 'tImeTableDBDataSet.Statistics' table. You can move, or remove it, as needed.
            //this.statisticsTableAdapter.Fill(this.tImeTableDBDataSet.Statistics);

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
