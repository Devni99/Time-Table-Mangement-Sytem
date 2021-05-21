using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Mangement_Sytem
{
    class LocationNotAvail
    {
        public int lid { get; set; }
        public string lecid { get; set; }
        public string day { get; set; }
        public string room { get; set; }
        public string dur { get; set; }
        public string stime { get; set; }
        public string etime { get; set; }


        //Connection String
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");


        public DataTable select()
        {

            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Location_not_Avaible";
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


        public bool Insert(LocationNotAvail c)
        {
            bool isSuccess = false;

            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

            try
            {
                string sql = "INSERT INTO Location_not_Avaible(lecid,day,room,dur,stime,etime)VALUES(@lecid,@day,@room,@dur,@stime,@etime)";
                SqlCommand cmd = new SqlCommand(sql, Con);




                cmd.Parameters.AddWithValue("@lecid", c.lecid);
                cmd.Parameters.AddWithValue("@day", c.day);
                cmd.Parameters.AddWithValue("@room", c.room);
                cmd.Parameters.AddWithValue("@dur", c.dur);
                cmd.Parameters.AddWithValue("@stime", c.stime);
                cmd.Parameters.AddWithValue("@etime", c.etime);


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

        public bool Update(LocationNotAvail c)
        {
            bool isSuccess = false;

            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

            try
            {
                string sql = "UPDATE  Location_not_Avaible SET lecid=@lecid,day=@day,room=@room,dur=@dur,stime=@stime,etime=@etime WHERE lid=@lid";
                SqlCommand cmd = new SqlCommand(sql, Con);

                cmd.Parameters.AddWithValue("@lid ", c.lid);
                cmd.Parameters.AddWithValue("@lecid", c.lecid);
                cmd.Parameters.AddWithValue("@day", c.day);
                cmd.Parameters.AddWithValue("@room", c.room);
                cmd.Parameters.AddWithValue("@dur", c.dur);
                cmd.Parameters.AddWithValue("@stime", c.stime);
                cmd.Parameters.AddWithValue("@etime", c.etime);


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

        public bool Delete(LocationNotAvail c)
        {
            bool isSuccess = false;
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");




            try
            {
                string sql = "DELETE FROM Location_not_Avaible WHERE lid=@lid";
                SqlCommand cmd = new SqlCommand(sql, Con);
                cmd.Parameters.AddWithValue("@lid", c.lid);



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
