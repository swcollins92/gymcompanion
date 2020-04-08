using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.Account
{
    public class RegisterViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string WorkoutGoals { get; set; }

        public string WorkoutProfile { get; set; }

        [Display(Name = "PhotoPath")]
        public byte[] PhotoPath { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}
