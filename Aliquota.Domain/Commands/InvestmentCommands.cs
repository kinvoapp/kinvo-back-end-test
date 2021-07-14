using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Commands {
    public class CreateInvestmentCommand {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}