using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Aliquota.Domain.Entities
{
    public class User : EntityBase
    {
        public User(string email, string fullName, Portfolio portfolio)
        {
            Email = email;
            FullName = fullName;
            Portfolio = portfolio;
        }

        [EmailAddress]
        public string Email { get; private set; }

        [MaxLength(50)]
        public string FullName { get; private set; }

        public byte[] PasswordHash { get; private set; }

        public Guid PortfolioId { get; private set; }

        public Portfolio Portfolio { get; private set; }

        public void SetPassword(string password) {
            var sha256 = SHA256.Create();
            PasswordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool ComparePassword(string password) {
            var sha256 = SHA256.Create();
            return PasswordHash == sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}