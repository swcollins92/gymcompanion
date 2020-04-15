using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Web.Models.GymDetails
{
    public class GymEquipment
    {
        public int Id { get; set; }

        [Required]
        public string Name  { get; set; }

        [Required]
        public string ProperUsage { get; set; }

        //TODO: Link photopath to actual photos of equipment
        public string PhotoPath { get; set; }

        //TODO: Link video to actual videos of equipment
        public string Video { get; set; }

        public List<SelectListItem> GymEquipments = new List<SelectListItem>()
        {
             new SelectListItem() { Text = "Treadmill", Value = "treadmill" },
             new SelectListItem() { Text = "Benchpress", Value = "benchpress" },
             new SelectListItem() { Text = "Elliptical", Value = "elliptical" },
             new SelectListItem() { Text = "Squat Rack", Value = "squatrack" },
             new SelectListItem() { Text = "Bicep Curl Machine", Value = "bicep" },
             new SelectListItem() { Text = "Chest Press Machine", Value = "armpress" },
             new SelectListItem() { Text = "Free Weight Workout", Value = "dunbells" },
             new SelectListItem() { Text = "Leg Press", Value = "legpress" },
             new SelectListItem() { Text = "Universal Workout", Value = "Resistence" },
             new SelectListItem() { Text = "defaultimage", Value = "defaultequipment" }
        };
    }
}
