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
                    SqlCommand cmd = new SqlCommand("INSERT INTO Member_Timelog (member_id, check_in, check_out) " +
                        "VALUES (@membr_id, @chech_in, @check_out )", conn);
                    cmd.Parameters.AddWithValue("@member_id", id);
                    cmd.Parameters.AddWithValue("@check_in", DateTime.Now);
                    cmd.Parameters.AddWithValue("@check_out", null);

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

        public void CheckOut()
        {
            throw new NotImplementedException();
        }
    }
}
