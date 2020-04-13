using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Web.Models.GymDetails
{
    public class GymEquipment
    {
        [Required]
        public string Name  { get; set; }

        [Required]
        public string ProperUsage { get; set; }

        //TODO: Link photopath to actual photos of equipment
        public string PhotoPath { get; set; }

        //TODO: Link video to actual videos of equipment
        public string Video { get; set; }
    }
}
