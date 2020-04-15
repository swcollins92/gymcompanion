using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class EditViewModel
    {
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string WorkoutGoals { get; set; }

        public string WorkoutProfile { get; set; }

        public string PhotoPath { get; set; }

        public List<SelectListItem> Avatars = new List<SelectListItem>()
        {
             new SelectListItem() { Text = "batman", Value = "batman" },
             new SelectListItem() { Text = "cool emoji", Value = "cool_emoji" },
             new SelectListItem() { Text = "daredevil", Value = "daredevil" },
             new SelectListItem() { Text = "female", Value = "female" },
             new SelectListItem() { Text = "male", Value = "male" },
             new SelectListItem() { Text = "joker", Value = "joker" },
             new SelectListItem() { Text = "ninja", Value = "ninja" },
             new SelectListItem() { Text = "pikachu", Value = "pikachu" },
             new SelectListItem() { Text = "smiley face", Value = "smiley_face" }
        };
    }
}
