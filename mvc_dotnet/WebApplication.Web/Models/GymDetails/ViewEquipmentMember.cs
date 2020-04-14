using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.GymDetails
{
    public class ViewEquipmentMember
    {
        public string Role { get; set; }
        public List<GymEquipment> AllEquipments { get; set; }
    }
}
