using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Entities
{
    public class User : EntityBase
    {
        [MaxLength(50)]
        public string FullName { get; set; }

        public string PasswordHash { get; set; }

        public Guid PortfolioId { get; set; }

        public Portfolio Portfolio { get; set; }
    }
}