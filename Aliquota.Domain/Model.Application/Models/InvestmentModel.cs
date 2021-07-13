using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Application.Models
{
    public class InvestmentModel
    {
        public int Id { get; set; }

        public string Cpf { get; set; }
        
        public double Capital { get; set; } // Amount invested + Profits.
        
        public DateTime InvestmentDayZero { get; set; } // On this DateTime the Investment started.
    }
}
