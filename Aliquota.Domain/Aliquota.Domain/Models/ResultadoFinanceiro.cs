using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class ResultadoFinanceiro
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Data da Aplicação")]
        public string DataAplicacao { get; set; }

        [Display(Name = "Data do Resgate")]
        public string DataResgate { get; set; }

        [Display(Name = "Valor da Aplicação")]
        public string ValorAplicado { get; set; }

        [Display(Name = "Valor do Lucro")]
        public string ValorRendimento { get; set; }

        [Display(Name = "Imposto Devido Sobre o Lucro")]
        public string ImpostoDevido { get; set; }

        [Display(Name = "Valor a Receber")]
        public string LucroReal { get; set; }
    }
}
