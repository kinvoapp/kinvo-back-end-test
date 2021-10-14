using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace JWT_Auth
{
    public static class TokenComponent
    {
        private static string secret = "isso deveria ser um arquivo com um RSA KEY de verdade";
        public static string GenerateToken(string name, string password)
        {
            string token = "{{\"Name\":\"{0}\", \"ExpiresAt\":\"{1}\"}}";
            string.Format(token, name, DateTime.Now.AddHours(3).ToString());
            token += "." + HashToken(token);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
        }
        public static bool ValidateToken(string token)
        {
            var bytes = Convert.FromBase64String(token); 
            var jwt = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            var parts = jwt.Split('.');
            if (parts.Length <= 1)
                return false;
            return HashToken(parts[0]) == parts[1];
        }
        private static string HashToken(string token)
        {
            string newtoken = token + secret;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] byteArr= sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(newtoken));
                return Convert.ToBase64String(byteArr);
            }
        }
    }
}
