using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Entities
{
    public class Investment : BaseEntity
    {
        public string Cpf { get; set; }
        public double Capital { get; set; } // Amount invested + Profits.
        public DateTime InvestmentDayZero { get; set; } // On this DateTime the Investment started.
    }
}
