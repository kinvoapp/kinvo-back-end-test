using Aliquota.Application.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Application.ViewModels
{
    public class ProdutoFinanceiroViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "A aplicação não pode ser igual ou menor que zero")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Aplicacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataAplicacao { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Lucro { get; set; }

        [IsDateAfter("DataAplicacao", "A data de resgate não pode ser menor que a data de aplicação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataResgate { get; set; }
    }
}