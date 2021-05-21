using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Time_Table_Mangement_Sytem
{
    class WorkTimeHour
    {

        public int lectureid { get; set; }
        public string noworkd { get; set; }
        public string day1 { get; set; }
        public string day2 { get; set; }
        public string day3 { get; set; }
        public string day4 { get; set; }
        public string day5 { get; set; }
        public string day6 { get; set; }
        public string day7 { get; set; }
        public string stime { get; set; }
        public string dura { get; set; }
        public string etime { get; set; }
        public string hours { get; set; }

        //Connection String
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");


        public DataTable select()
        {

            //Connection String
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM WorkingDays";
                SqlCommand cmd = new SqlCommand(sql, Con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                Con.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {

            }

            finally
            {
                Con.Close();
            }
            return dt;


        }


        public bool Insert(WorkTimeHour c)
        {
            bool isSuccess = false;

            //Connection String
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");


            try
            {
                string sql = "INSERT INTO WorkingDays (noworkd,day1,day2,day3,day4,day5,day6,day7,stime,dura,etime,hours)VALUES(@noworkd,@day1,@day2,@day3,@day4,@day5,@day6,@day7,@stime,@dura,@etime,@hours)";
                SqlCommand cmd = new SqlCommand(sql, Con);



                cmd.Parameters.AddWithValue("@noworkd ", c.noworkd);
                cmd.Parameters.AddWithValue("@day1", c.day1);
                cmd.Parameters.AddWithValue("@day2", c.day2);
                cmd.Parameters.AddWithValue("@day3", c.day3);
                cmd.Parameters.AddWithValue("@day4", c.day4);
                cmd.Parameters.AddWithValue("@day5", c.day5);
                cmd.Parameters.AddWithValue("@day6", c.day6);
                cmd.Parameters.AddWithValue("@day7", c.day7);
                cmd.Parameters.AddWithValue("@stime", c.stime);
                cmd.Parameters.AddWithValue("@dura", c.dura);
                cmd.Parameters.AddWithValue("@etime", c.etime);
                cmd.Parameters.AddWithValue("@hours", c.hours);

                Con.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }

                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }

            finally
            {
                Con.Close();
            }
            return isSuccess;

        }


        public bool Update(WorkTimeHour c)
        {
            bool isSuccess = false;

            //Connection String
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");


            try
            {
                string sql = "UPDATE  WorkingDays SET noworkd=@noworkd,day1=@day1,day2=@day2,day3=@day3,day4=@day4,day5=@day5,day6=@day6,day7=@day7,stime=@stime,dura=@dura,etime=@etime,hours=@hours WHERE lectureid=@lectureid";
                SqlCommand cmd = new SqlCommand(sql, Con);

                cmd.Parameters.AddWithValue("@noworkd ", c.noworkd);
                cmd.Parameters.AddWithValue("@day1", c.day1);
                cmd.Parameters.AddWithValue("@day2", c.day2);
                cmd.Parameters.AddWithValue("@day3", c.day3);
                cmd.Parameters.AddWithValue("@day4", c.day4);
                cmd.Parameters.AddWithValue("@day5", c.day5);
                cmd.Parameters.AddWithValue("@day6", c.day6);
                cmd.Parameters.AddWithValue("@day7", c.day7);
                cmd.Parameters.AddWithValue("@stime", c.stime);
                cmd.Parameters.AddWithValue("@dura", c.dura);
                cmd.Parameters.AddWithValue("@etime", c.etime);
                cmd.Parameters.AddWithValue("@hours", c.hours);
                cmd.Parameters.AddWithValue("@lectureid", c.lectureid);


                Con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }

                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }

            finally
            {
                Con.Close();
            }
            return isSuccess;


        }



        public bool Delete(WorkTimeHour c)
        {
            bool isSuccess = false;


            //Connection String
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

            try
            {
                string sql = "DELETE FROM WorkingDays WHERE lectureid=@lectureid";
                SqlCommand cmd = new SqlCommand(sql, Con);
                cmd.Parameters.AddWithValue("@lectureid", c.lectureid);



                Con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }

                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }

            finally
            {
                Con.Close();
            }
            return isSuccess;

        }
    }
}
