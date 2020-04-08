using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;
using Microsoft.AspNetCore.Http;
using WebApplication.Web.DAL;
using WebApplication.Web.Models.Account;

namespace WebApplication.Web.Providers.Auth
{
    public class SessionAuthProvider : IAuthProvider
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IUserDAL userDAL;
        private static string SessionKey = "Auth_User";

        public SessionAuthProvider(IHttpContextAccessor contextAccessor, IUserDAL userDAL)
        {
            this.contextAccessor = contextAccessor;
            this.userDAL = userDAL;
        }

        ISession Session => contextAccessor.HttpContext.Session;

        public bool IsLoggedIn => !String.IsNullOrEmpty(Session.GetString(SessionKey));

        public bool ChangePassword(string existingPassword, string newPassword)
        {
            var hashProvider = new HashProvider();
            var user = GetCurrentUser();

            if (user != null && hashProvider.VerifyPasswordMatch(user.Password, existingPassword, user.Salt))
            {
                var newHash = hashProvider.HashPassword(newPassword);
                user.Password = newHash.Password;
                user.Salt = newHash.Salt;

                userDAL.UpdateUser(user);

                return true;
            }

            return false;
        }

        public User GetCurrentUser()
        {
            var username = Session.GetString(SessionKey);

            if (!String.IsNullOrEmpty(username))
            {
                return userDAL.GetUser(username);
            }

            return null;
        }

        public EditViewModel GetEditMember()
        {
            var username = Session.GetString(SessionKey);
            EditViewModel model = new EditViewModel();

            if (!String.IsNullOrEmpty(username))
            {
                User currentUser = GetCurrentUser();
                GymMember member = userDAL.GetMember(currentUser.Id);
                model.Email = member.Email;
                model.WorkoutGoals = member.WorkoutGoals;
                model.WorkoutProfile = member.WorkoutProfile;
                model.PhotoPath = member.PhotoPath;
                model.Password = currentUser.Password;
            }

            return model;
        }

        public bool SignIn(string username, string password)
        {
            var user = userDAL.GetUser(username);
            var hashProvider = new HashProvider();

            if (user != null && hashProvider.VerifyPasswordMatch(user.Password, password, user.Salt))
            {
                Session.SetString(SessionKey, user.Username);
                return true;
            }

            return false;
        }

        public bool UserHasRole(string[] roles)
        {
            var user = GetCurrentUser();
            return (user != null) &&
                roles.Any(r => r.ToLower() == user.Role.ToLower());
        }

        public void Register(RegisterViewModel model)
        {
            var hashProvider = new HashProvider();
            var passwordHash = hashProvider.HashPassword(model.Password);

            var user = new User
            {
                Username = model.Username,
                Password = passwordHash.Password,
                Salt = passwordHash.Salt,
                Role = model.Role
            };

            int userId = userDAL.CreateUser(user);

            var gymMember = new GymMember
            {
                Name = model.Name,

                Email = model.Email,

                WorkoutGoals = model.WorkoutGoals,
                WorkoutProfile = model.WorkoutProfile,

                PhotoPath = model.PhotoPath
            };

            userDAL.AddGymMember(gymMember, userId);
            
           Session.SetString(SessionKey, model.Username);
        }
        
        public void LogOff()
        {
            Session.Clear();
        }
    }
}
