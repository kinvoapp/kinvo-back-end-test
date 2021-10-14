using Aliquota.Domain.Entities.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Website.Blazor.Data
{

    public class FakeProductMove: FinanceProductMove
    {

        public User User { get; set; }

        public FinanceProduct FinanceProduct { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public decimal CurrentAmount { get; set; }

        [Required]
        public decimal Price { get; set; }
        public decimal TaxOver { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
    }
}
