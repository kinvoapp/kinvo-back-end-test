using Aliquota.Domain.CustomAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class AplicacaoModel
    {
        public int AplicacaoId { get; set; }

        [Required]
        [Display(Name = "Valor aplicado")]
        [DataType(DataType.Currency)]
        [Range(1, 9999999999999999.99, ErrorMessage = "Valor não pode ser menor que 1")]
        public decimal ValorInicial { get; set; }

        [Required]
        [Display(Name = "Data da aplicação")]
        [DataType(DataType.Date)]
        public DateTime DataAplicada { get; set; }

        
        [Display(Name = "Data da retirada")]
        [DataType(DataType.Date)]
        [DateTimeCompare("DataAplicada")]
        public DateTime? DataRetirada { get; set; }

        
        [Display(Name = "Valor final bruto")]
        [DataType(DataType.Currency)]
        public decimal? ValorFinalBruto { get; set; }

        
        [Display(Name = "Imposto de renda")]
        [DataType(DataType.Currency)]
        [Range(0, 9999999999999999.99)]
        public decimal? ValorImpostoRenda { get; set; }

        
        [Display(Name = "Lucro líquido")]
        [DataType(DataType.Currency)]
        public decimal? ValorLucroLiquido { get; set; }

        
        
    }
}
