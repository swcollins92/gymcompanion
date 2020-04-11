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

        public string PhotoPath { get; set; }
    }
}
