using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class CadastroInvestidor : ValidationAttribute
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Tipo de Aplicação")]
        public string TipoAplicacao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Range(0, 999999.99)]
        [Display(Name = "Valor da Aplicação")]
        public double ValorAplicacao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [DataType(DataType.Date)]

        [Display(Name = "Data da Aplicação")]
        public DateTime DataAplicacao { get; set; }


        [ValidaData]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        [Display(Name = "Data do Resgate")]
        public DateTime DataResgate { get; set; }
    }
}
