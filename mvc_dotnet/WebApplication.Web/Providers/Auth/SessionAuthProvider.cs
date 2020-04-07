using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;
using Microsoft.AspNetCore.Http;
using WebApplication.Web.DAL;

namespace WebApplication.Web.Providers.Auth
{
    public class SessionAuthProvider : IAuthProvider
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IUserDAL userDAL;
        private static string SessionKey = "Auth_User";

        public SessionAuthProvider (IHttpContextAccessor contextAccessor, IUserDAL userDAL)
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

        //public GymMember GetGymMember()
        //{
        //    var email = Session.GetString(SessionKey);

        //    if (!String.IsNullOrEmpty(email))
        //    {

        //    }
        //}

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

        public void Register(string username, string password, string role)
        {
            var hashProvider = new HashProvider();
            var passwordHash = hashProvider.HashPassword(password);

            var user = new User
            {
                Username = username,
                Password = passwordHash.Password,
                Salt = passwordHash.Salt,
                Role = role
            };
            
            userDAL.CreateUser(user);
            
            Session.SetString(SessionKey, user.Username);
        }

        

        public void LogOff()
        {
            Session.Clear();
        }
    }
}
