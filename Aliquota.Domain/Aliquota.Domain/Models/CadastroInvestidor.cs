using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class CadastroInvestidor : ValidationAttribute
    {
        public int ID { get; set; }

        [Display(Name = "Tipo de Aplicação")]
        public string TipoAplicacao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Range(1, 999999.99, ErrorMessage = "O valor da aplicação deve ser superior a 0")]
        [Display(Name = "Valor da Aplicação")]
        public double ValorAplicacao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Data da Aplicação")]
        public DateTime DataAplicacao { get; set; }


        [ValidaDataCadastro]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        [Display(Name = "Data do Resgate")]
        public DateTime DataResgate { get; set; }
    }
}
