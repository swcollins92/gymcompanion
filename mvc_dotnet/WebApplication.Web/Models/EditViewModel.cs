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
    }
}
