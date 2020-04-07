using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebApplication.Web.Providers.Auth
{
    public class HashProvider
    {
        private const int WorkFactor = 10000;

        public class HashedPassword
        {

            public HashedPassword(string password, string salt)
            {
                this.Password = password;
                this.Salt = salt;
            }

            public string Password { get; }

            public string Salt { get; }
        }

        public HashedPassword HashPassword(string plainTextPassword)
        {
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(plainTextPassword, 8, WorkFactor);

            byte[] hash = rfc.GetBytes(20);

            string salt = Convert.ToBase64String(rfc.Salt);

            return new HashedPassword(Convert.ToBase64String(hash), salt);
        }

        public bool VerifyPasswordMatch(string existingHashedPassword, string plainTextPassword, string salt)
        {
            byte[] saltArray = Convert.FromBase64String(salt); 

            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(plainTextPassword, saltArray, WorkFactor);

            byte[] hash = rfc.GetBytes(20);

            string newHashedPassword = Convert.ToBase64String(hash);

            return (existingHashedPassword == newHashedPassword);
        }
    }
}
