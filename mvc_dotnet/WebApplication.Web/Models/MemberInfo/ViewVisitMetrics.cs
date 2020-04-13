using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.MemberInfo
{
    public class ViewVisitMetrics
    {
        public double AverageDuration { get; set; }
        public List<VisitMetrics> AllVisitMetrics { get; set; }
    }
}
