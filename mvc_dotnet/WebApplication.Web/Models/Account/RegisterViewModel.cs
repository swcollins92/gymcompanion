using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string WorkoutGoals { get; set; }

        public string WorkoutProfile { get; set; }

        [Display(Name = "PhotoPath")]
        public string PhotoPath { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

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
             new SelectListItem() { Text = "smiley face", Value = "smiley_face" },
             new SelectListItem() {Text = "Mike", Value = "Mike"},
             new SelectListItem() {Text = "Deadpool", Value ="Deadpool"},
             new SelectListItem() {Text = "JoeExotic", Value ="JoeExotic"},
             new SelectListItem() {Text = "John Fulton", Value ="ripped_john"}
        };
        public List<SelectListItem> BodyProfile = new List<SelectListItem>()
        {
             new SelectListItem() { Text = "Fit", Value = "Fit" },
             new SelectListItem() { Text = "Slim", Value = "Slim" },
             new SelectListItem() { Text = "Big", Value = "Big" },
             new SelectListItem() { Text = "Husky", Value = "Husky" },
             new SelectListItem() { Text = "Tall", Value = "Tall" },
             new SelectListItem() { Text = "Short", Value = "Short" }
        };
        public List<SelectListItem> WorkoutGoalsSelection = new List<SelectListItem>()
        {
             new SelectListItem() { Text = "Lose Weight", Value = "Lose Weight" },
             new SelectListItem() { Text = "Be Healthier", Value = "Be Healthier" },
             new SelectListItem() { Text = "Relieve Stress", Value = "Relieve Stress" },
             new SelectListItem() { Text = "Gain Muscle", Value = "Gain Muscle" },
             new SelectListItem() { Text = "Be More Athletic", Value = "Be More Athletic" }
        };
    }
}
