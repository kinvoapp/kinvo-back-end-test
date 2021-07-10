using System;

namespace Aliquota.Domain.Entities
{
    public class Investment : EntityBase
    {
        public Investment() : base() { }

        public DateTimeOffset ApplicationDate { get; private set; }

        public DateTimeOffset? RedemptionDate { get; private set; }

        public Guid PortfolioId { get; private set; }

        public Portfolio Portfolio { get; private set; }

        public Guid FinancialProductId { get; private set; }

        public FinancialProduct FinancialProduct { get; private set; }

        public int Value { get; private set; }
    }
}