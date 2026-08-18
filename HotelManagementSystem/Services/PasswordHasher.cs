using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HotelManagementSystem.Services
{
    public static class PasswordHasher
    {
        public static string HashPassword (string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                100_000,
                HashAlgorithmName.SHA256, 32);

            string saltText = Convert.ToBase64String(salt);
            string hashText = Convert.ToBase64String(hash);

            return $"{saltText}:{hashText}";
        }

        public static bool VerifyPassword(string password, string storedPasswordHash)
        {
            try
            {
                string[] parts = storedPasswordHash.Split(':');

                if (parts.Length != 2)
                {
                    return false;
                }

                byte[] salt = Convert.FromBase64String(parts[0]);
                byte[] expectedHash = Convert.FromBase64String(parts[1]);

                byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    100_000,
                    HashAlgorithmName.SHA256,
                    32);

                return CryptographicOperations.FixedTimeEquals(expectedHash, actualHash);
            }

            catch
            {
                return false;
            }
        }

    }
}
