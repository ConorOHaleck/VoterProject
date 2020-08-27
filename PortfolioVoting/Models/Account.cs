using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace PortfolioVoting.Models
{
    public class Account
    {
        public const int Salt = 128;

        public int AccountID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string StoredSalt { get; set; }
        public bool IsAdmin { get; set; }
        public int MyProperty { get; set; }

        public virtual ICollection<PollAccount> PollEnrollment { get; set; }


        public void setPassword(string RawPassword)
        {
            byte[] salt = new byte[Salt / 8];

            using ( var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: RawPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: (2 * Salt) / 8));

            this.Password = hashed;
            this.StoredSalt = Convert.ToBase64String(salt);

        }

        public bool checkPassword(string attempt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: attempt,
                salt: Convert.FromBase64String(StoredSalt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: (2 * Salt) / 8));

            if(hashed == Password)
            {
                return true;
            }

            return false;
        }
    }
}
