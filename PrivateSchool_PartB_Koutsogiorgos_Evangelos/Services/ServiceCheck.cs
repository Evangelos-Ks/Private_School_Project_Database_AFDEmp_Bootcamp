using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace Services
{
    public class ServiceCheck
    {
        public static string conString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public bool ExistStudentsPerCourse(int sid, int cid)
        {
            List<int> sids = new List<int>();
            List<int> cids = new List<int>();
            bool existTheStudentAtCourse = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select * from StudentCourse";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        sids.Add(Convert.ToInt32(reader["Sid"].ToString()));
                        cids.Add(Convert.ToInt32(reader["Cid"].ToString()));
                    }
                }
                for (int i = 0; i < sids.Count; i++)
                {
                    if (sids[i] == sid && cids[i] == cid) return true;
                    else existTheStudentAtCourse = false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_SC_ESPC");
                existTheStudentAtCourse = true;
            }
            return existTheStudentAtCourse;
        }

        public bool ExistTrainerPerCourse(int tid, int cid)
        {
            List<int> tids = new List<int>();
            List<int> cids = new List<int>();
            bool existTheTrainerAtCourse = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string queryString = "select * from TrainerCourse";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tids.Add(Convert.ToInt32(reader["Tid"].ToString()));
                        cids.Add(Convert.ToInt32(reader["Cid"].ToString()));
                    }
                }
                for (int i = 0; i < tids.Count; i++)
                {
                    if (tids[i] == tid && cids[i] == cid) return true;
                    else existTheTrainerAtCourse = false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong Code: S_SC_ETPC");
                existTheTrainerAtCourse = true;
            }
            return existTheTrainerAtCourse;
        }
    }
}
