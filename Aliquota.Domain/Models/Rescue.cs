using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class Rescue
    {
        public int RescueId { get; set; }

        [Display(Name = "Data da Aplicação")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }

        [Display(Name = "Data do Resgate")]
        [DataType(DataType.Date)]
        public DateTime ApplicationRescue { get; set; }

        [Display(Name = "Valor da Aplicação")]
        public double ApplicationValue { get; set; }

        [Display(Name = "Valor Bruto")]
        public double GrossValue { get; set; }

        [Display(Name = "Rendimento ao Ano")]
        public string Income { get; set; }

        [Display(Name = "Imposto de Renda")]
        public double Ir { get; set; }

        [Display(Name = "Lucro")]
        public double Profit { get; set; }

        [Display(Name = "Valor Líquido")]
        public double LiquidValue { get; set; }


       
    }


}
