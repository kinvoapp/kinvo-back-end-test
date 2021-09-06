using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    [Table("Usuario")]
    public class Consulta : Notify
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Renda Obrigatória")]
        [Display(Name = "Renda Fixa")]
        public double Renda { get; set; }

        [Required(ErrorMessage = "Lucro Obtido Obrigatório")]
        [Display(Name = "Lucro Obtido")]
        public double Lucro { get; set; }

        [Required(ErrorMessage = "Data de Aplicação Obrigatória")]
        [Display(Name = "Data da Aplicação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAplicacao { get; set; }

        [Required(ErrorMessage = "Data de Resgate Obrigatória")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Resgate")]
        public DateTime DataResgate { get; set; }

        [Display(Name = "IOF Cobrado em %")]
        public double? IOF { get; set; }

        [Display(Name = "IR sobre a IOF em %")]
        public double? IR { get; set; } 

        [Display(Name = "IR Total")]
        public double? ValorIR { get; set; }

        [Display(Name = "Valor do Resgate")]
        public double? Resgate { get; set; }
    }
}
