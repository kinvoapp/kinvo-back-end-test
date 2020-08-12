using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models.BD
{
    public class BDResultadoFinanceiro
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string DataAplicacao { get; set; }
        public string DataResgate { get; set; }
        public string ValorAplicado { get; set; }
        public string ValorRendimento { get; set; }
        public string ImpostoDevido { get; set; }
        public string TaxaIRAplicada { get; set; }
        public string LucroReal { get; set; }
    }
}
