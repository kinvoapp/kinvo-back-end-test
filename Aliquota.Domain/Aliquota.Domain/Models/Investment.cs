using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class Investment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ooops, i think you forgot your name :D")]
        public string InvestorName { get; set; }
        public DateTime DayOfInvestment { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
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
