using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Providers.Auth;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;
using WebApplication.Web.Models.GymDetails;
using WebApplication.Web.Models.Account;

namespace WebApplication.Web.DAL
{
    public interface IGymDAL
    {
        bool AddSchedule(EditSchedule schedule);
        List<EditSchedule> GetSchedules();
        bool AddGymEquipment(GymEquipment equip);
        List<GymEquipment> GetEquipments();
        bool EditGymEquipment(EditGymEquipment equipment);
        GymEquipment GetEquipment(int id);
        bool AddGymUsage(GymUsageModel model);
        EditSchedule GetScheduleById(int id);
        bool EditSchedule(EditSchedule schedule);
        List<MachineMetrics> GetAllMachineMetrics();
    }
}
