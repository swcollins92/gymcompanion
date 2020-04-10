using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.DAL
{
    public class MemberSqlDAL : IMemberDAL
    {
        private readonly string connectionString;

        public MemberSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool CheckIn(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Member_Timelog (member_id, check_in) " +
                        "VALUES (@member_id, @check_in)", conn);
                    cmd.Parameters.AddWithValue("@member_id", id);
                    cmd.Parameters.AddWithValue("@check_in", DateTime.Now);

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (SqlException ex)
            {
                return false;
                throw;
            }
        }

        public bool CheckOut(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Member_Timelog SET check_out = @check_out " +
                        "WHERE member_id = @member_id ", conn);
                    cmd.Parameters.AddWithValue("@member_id", id);
                    cmd.Parameters.AddWithValue("@check_out", DateTime.Now);

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (SqlException ex)
            {
                return false;
                throw;
            }
        }

        public bool CheckedInStatus (int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Check_In FROM Member_Timelog " +
                        "WHERE member_id = @member_id ", conn);
                    cmd.Parameters.AddWithValue("@member_id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                return false;
                throw;
            }
        }
    }
}
