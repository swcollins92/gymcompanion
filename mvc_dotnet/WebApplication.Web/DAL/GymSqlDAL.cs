using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Providers.Auth;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;
using WebApplication.Web.Models.GymDetails;
using WebApplication.Web.Models.Account;
using System.Data.SqlClient;

namespace WebApplication.Web.DAL
{
    public class GymSqlDAL : IGymDAL
    {
        private readonly string connectionString;

        public GymSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool EditSchedule(EditSchedule schedule)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Schedule (name,description,date) " +
                        "VALUES (@name, @description, @date )",conn);
                    cmd.Parameters.AddWithValue("@name", schedule.Name);
                    cmd.Parameters.AddWithValue("@description", schedule.Description);
                    cmd.Parameters.AddWithValue("@date", schedule.Date);

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

        public List<EditSchedule> GetSchedules()
        {
            List<EditSchedule> list = new List<EditSchedule>();
            EditSchedule result = new EditSchedule();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * From Schedule ", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        result = MapRowToschedule(reader);
                        list.Add(result);
                    }

                    return list;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        private EditSchedule MapRowToschedule(SqlDataReader reader)
        {
            return new EditSchedule()
            {
                Name = Convert.ToString(reader["name"]),
                Description = Convert.ToString(reader["description"]),
                Date = Convert.ToDateTime(reader["date"]),
            };
        }
    }
}
