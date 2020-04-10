using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.MemberInfo
{
    public class Timelog
    {
        public int MemberId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool IsCheckedIn { get; set; }

        public IList<SelectListItem> AllMembers { get; set; }
    }
}
