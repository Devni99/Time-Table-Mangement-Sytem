using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Mangement_Sytem
{
    class notavailable
    {
        public int id { get; set; }
        public string lec { get; set; }
        public string grp { get; set; }
        public string sid { get; set; }
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
                string sql = "SELECT * FROM Not_Avai_time";
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

        public bool Insert(notavailable ci)
        {
            bool isSuccess = false;

            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

            try
            {
                string sql = "INSERT INTO Not_Avai_time(lec,grp,sid,dur,stime,etime)VALUES(@lec,@grp,@sid,@dur,@stime,@etime)";
                SqlCommand cmd = new SqlCommand(sql, Con);



                cmd.Parameters.AddWithValue("@lec ", ci.lec);
                cmd.Parameters.AddWithValue("@grp", ci.grp);
                cmd.Parameters.AddWithValue("@sid", ci.sid);
                cmd.Parameters.AddWithValue("@dur", ci.dur);
                cmd.Parameters.AddWithValue("@stime", ci.stime);
                cmd.Parameters.AddWithValue("@etime", ci.etime);

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


        public bool Update(notavailable ci)
        {
            bool isSuccess = false;

            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");


            try
            {
                string sql = "UPDATE  Not_Avai_time SET lec=@lec,grp=@grp,sid=@sid,dur=@dur,stime=@stime,etime=@etime WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, Con);

                cmd.Parameters.AddWithValue("@id ", ci.id);
                cmd.Parameters.AddWithValue("@lec ", ci.lec);
                cmd.Parameters.AddWithValue("@grp", ci.grp);
                cmd.Parameters.AddWithValue("@sid", ci.sid);
                cmd.Parameters.AddWithValue("@dur", ci.dur);
                cmd.Parameters.AddWithValue("@stime", ci.stime);
                cmd.Parameters.AddWithValue("@etime", ci.etime);


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



        public bool Delete(notavailable ci)
        {
            bool isSuccess = false;
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TimeTableDatabase.mdf;Integrated Security=True");

            try
            {
                string sql = "DELETE FROM Not_Avai_time WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, Con);
                cmd.Parameters.AddWithValue("@id", ci.id);



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
