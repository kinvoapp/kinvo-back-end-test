using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }

        [Required(ErrorMessage = "Insira um valor válido.")]
        [Display(Name = "Valor da Aplicação")]
        public double ApplicationValue { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        [Display(Name = "Data da Aplicação")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        [Display(Name = "Data do Resgate")]
        [DataType(DataType.Date)]
        public DateTime ApplicationRescue { get; set; }
    }
}
