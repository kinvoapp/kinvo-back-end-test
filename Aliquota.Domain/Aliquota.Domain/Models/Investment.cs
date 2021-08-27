using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public string InvestorName { get; set; }
        public DateTime DayOfInvestment { get; set; }
        public double InitialAmount { get; set; }

        public Investment()
        {
        }

        public Investment(int id, string investorName, DateTime dayOfInvestment, double initialAmount)
        {
            Id = id;
            InvestorName = investorName;
            DayOfInvestment = dayOfInvestment;
            InitialAmount = initialAmount;
        }
    }
}
