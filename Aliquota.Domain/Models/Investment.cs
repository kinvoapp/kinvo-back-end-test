using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain.Models
{
    public class Investment
    {
        public int Id { get; set; }

        [Display(Name = "Data do investimento")]
        public DateTime InvestmentDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Valor do investimento")]
        public decimal Value { get; set; }

        [Display(Name = "Data do Resgate")]
        public DateTime? RescueDate { get; set; }
    }
}
