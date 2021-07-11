using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Aliquota.Domain.Entities
{
    public class User : EntityBase
    {
        public User(string email, string fullName)
        {
            Email = email;
            FullName = fullName;
        }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        public byte[] PasswordHash { get; private set; }

        public double Balance { get; set; }

        public void SetPassword(string password) {
            var sha256 = SHA256.Create();
            PasswordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyPassword(string password) {
            var sha256 = SHA256.Create();
            return PasswordHash.SequenceEqual(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}