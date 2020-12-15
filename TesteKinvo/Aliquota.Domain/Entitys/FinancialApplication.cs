using System;

namespace Aliquota.Domain.Entitys
{
    public class FinancialApplication : BaseClass
    {
        // public virtual Client Client { get; set; }
        // public virtual Product Product { get; set; }

        public decimal YieldRate { get; set; }
        public DateTime DateApplication { get; set; }
        public DateTime DateRescue { get; set; }
        public decimal Investiment { get; set; }

    }
}
