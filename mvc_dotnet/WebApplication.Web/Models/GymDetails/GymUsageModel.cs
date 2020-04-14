using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.GymDetails
{
    public class GymUsageModel
    {
        public int Equipment_id { get; set; }
        public int Member_id { get; set; }
        public DateTime Date_time { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }

    }
}
