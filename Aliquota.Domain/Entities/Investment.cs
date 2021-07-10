using System;

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

        public FinancialProduct FinancialProduct { get; set; }

        public int Value { get; set; }
    }
}