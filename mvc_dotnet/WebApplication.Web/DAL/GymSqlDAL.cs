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

        public bool AddSchedule(EditSchedule schedule)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Schedule (name,description,date) " +
                        "VALUES (@name, @description, @date )", conn);
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

        public bool EditGymEquipment(EditGymEquipment equipment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE gym_equipment " +
                        "SET name = @name, usage = @usage, photo_path = @photo_path " +
                        "WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@name", equipment.Name);
                    cmd.Parameters.AddWithValue("@usage", equipment.ProperUsage);
                    cmd.Parameters.AddWithValue("@photo_path", equipment.PhotoPath);
                    
                    cmd.Parameters.AddWithValue("@id", equipment.Id);

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
                        result = MapRowToSchedule(reader);
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

        public EditSchedule GetScheduleById(int id)
        {
            EditSchedule result = new EditSchedule();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * From Schedule WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = MapRowToSchedule(reader);
                    }

                    return result;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public bool EditSchedule(EditSchedule schedule)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Schedule " +
                        "SET name = @name, description = @description, date = @date " +
                        "WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@name", schedule.Name);
                    cmd.Parameters.AddWithValue("@description", schedule.Description);
                    cmd.Parameters.AddWithValue("@date", schedule.Date);
                    cmd.Parameters.AddWithValue("@id", schedule.Id);

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

        public bool AddGymEquipment(GymEquipment equip)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO gym_equipment (name, usage, photo_path) " +
                        "VALUES (@name, @usage, @photo_path)", conn);
                    cmd.Parameters.AddWithValue("@name", equip.Name);
                    cmd.Parameters.AddWithValue("@usage", equip.ProperUsage);
                    cmd.Parameters.AddWithValue("@photo_path", equip.PhotoPath);
                    
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

        public List<GymEquipment> GetEquipments()
        {
            List<GymEquipment> list = new List<GymEquipment>();
            GymEquipment equip = new GymEquipment();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * From gym_equipment ", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        equip = MapRowToEquipment(reader);
                        list.Add(equip);
                    }

                    return list;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public GymEquipment GetEquipment(int id)
        {
            GymEquipment equip = new GymEquipment();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * From gym_equipment WHERE id = @id ", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        equip = MapRowToEquipment(reader);
                    }

                    return equip;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        //public ViewEquipmentMember GetEquipmentPhotoPath(int id)
        //{
        //    ViewEquipmentMember equip = new ViewEquipmentMember();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand("Select photo_path From gym_equipment WHERE id = @id ", conn);
        //            cmd.Parameters.AddWithValue("@id", id);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                equip = MapRowToEquipment(reader);
        //            }

        //            return equip;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //}

        public bool AddGymUsage(GymUsageModel model)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO gym_equipment_usage (equipment_id, member_id, date_time, reps, weight) " +
                        "VALUES (@equipment_id, @member_id, @date_time, @reps, @weight)", conn);
                    cmd.Parameters.AddWithValue("@equipment_id", model.Equipment_id);
                    cmd.Parameters.AddWithValue("@member_id", model.Member_id);
                    cmd.Parameters.AddWithValue("@date_time", model.Date_time);
                    cmd.Parameters.AddWithValue("@reps", model.Reps);
                    cmd.Parameters.AddWithValue("@weight", model.Weight);
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

        public List<MachineMetrics> GetAllMachineMetrics()
        {
            List<MachineMetrics> list = new List<MachineMetrics>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MONTH(date_time) as month, YEAR(date_time) as year, " +
                       "equipment_id, count(*) as times_used, gym_equipment.name " +
                       "From gym_equipment_usage " +
                       "INNER JOIN gym_equipment on gym_equipment.id = gym_equipment_usage.equipment_id " +
                       "GROUP BY MONTH(date_time), YEAR(date_time), equipment_id, gym_equipment.name " +
                       "ORDER BY times_used DESC", conn);
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        MachineMetrics metric = new MachineMetrics();
                        metric = MapRowToMachineMetrics(reader);
                        list.Add(metric);
                    }

                    return list;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        private MachineMetrics MapRowToMachineMetrics(SqlDataReader reader)
        {
            return new MachineMetrics()
            {
                EquipmentId= Convert.ToInt32(reader["equipment_id"]),
                EquipmentName = Convert.ToString(reader["name"]),
                NumberOfTimeUsed = Convert.ToInt32(reader["times_used"]),
                Month = Convert.ToInt32(reader["month"]),
                Year = Convert.ToInt32(reader["year"])
            };
        }

        private GymEquipment MapRowToEquipment(SqlDataReader reader)
        {
            return new GymEquipment()
            {
                Id = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["name"]),
                ProperUsage = Convert.ToString(reader["usage"]),
                PhotoPath = Convert.ToString(reader["photo_path"]),
                
            };
        }

        private EditSchedule MapRowToSchedule(SqlDataReader reader)
        {
            return new EditSchedule()
            {
                Id = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["name"]),
                Description = Convert.ToString(reader["description"]),
                Date = Convert.ToDateTime(reader["date"]),
            };
        }



    }
}
