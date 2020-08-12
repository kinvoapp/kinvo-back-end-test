using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class ResultadoFinanceiro
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Data da Aplicação")]
        public DateTime DataAplicacao { get; set; }

        [Display(Name = "Data do Resgate")]
        public DateTime DataResgate { get; set; }

        [Display(Name = "Valor da Aplicação")]
        public string ValorAplicado { get; set; }

        [Display(Name = "Valor do Lucro")]
        public string ValorRendimento { get; set; }

        [Display(Name = "Imposto Devido Sobre o Lucro")]
        public string ImpostoDevido { get; set; }

        [Display(Name = "Taxa de Juros do IR Aplicada no Resgate")]
        public string TaxaIRAplicada { get; set; }

        [Display(Name = "Valor a Receber")]
        public string LucroReal { get; set; }
    }
}
