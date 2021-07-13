using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Commands {
    public class CreateInvestmentCommand {
        [Required]
        public Guid FinancialProductId { get; set; }

        [Required]
        public double Value { get; set; }
    }
}