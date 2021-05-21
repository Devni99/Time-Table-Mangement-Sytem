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
    public partial class TimeTable_Student : Form
    {
        public TimeTable_Student()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            TimeTable_Lec tm = new TimeTable_Lec();
            tm.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TimeTable_Lec tm = new TimeTable_Lec();
            tm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeTable_Student tm = new TimeTable_Student();
            tm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            TimeTable_Location tm = new TimeTable_Location();
            tm.Show();
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
    }
}
