using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.MemberInfo
{
    public class ViewWorkoutMetrics
    {
        public List<WorkoutMetrics> AllMetrics { get; set; }
        public double TimeSpent { get; set; }
    }
}
