using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.GymDetails
{
    public class ViewEquipmentsModel
    {
        public string Role { get; set; }
        public List<GymEquipment> AllEquipments { get; set; }

        public List<SelectListItem> GymEquipment = new List<SelectListItem>()
        {
             new SelectListItem() { Text = "Treadmill", Value = "treadmill" },
             new SelectListItem() { Text = "Benchpress", Value = "benchpress" },
             new SelectListItem() { Text = "Elliptical", Value = "elliptical" },
             new SelectListItem() { Text = "Squat Rack", Value = "squatrack" },
             new SelectListItem() { Text = "Bicep Curl Machine", Value = "bicep" }
        };
    }
}
