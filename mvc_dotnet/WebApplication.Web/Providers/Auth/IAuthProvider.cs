using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.Providers.Auth
{
    public interface IAuthProvider
    {
        bool IsLoggedIn { get; }

        User GetCurrentUser();

        bool SignIn(string username, string password);

        bool ChangePassword(string existingPassword, string newPassword);

        void Register(string username, string password, string role);

        bool UserHasRole(string[] roles);

        void LogOff();
    }
}
