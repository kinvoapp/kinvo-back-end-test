using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Entities
{
    public class Investment : EntityBase
    {
        public Investment() : base() { }

        public DateTimeOffset ApplicationDate { get; set; }

        public DateTimeOffset? RedemptionDate { get; set; }

        public Guid PortfolioId { get; set; }

        public Portfolio Portfolio { get; set; }

        public Guid FinancialProductId { get; set; }

        [Required]
        public FinancialProduct FinancialProduct { get; set; }

        public double InitialValue { get; set; }
    }
}