using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.GymDetails
{
    public class MachineMetrics
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public int NumberOfTimeUsed { get; set; }
    }
}
