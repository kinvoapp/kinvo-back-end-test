using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class ResultadoFinanceiro
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string DataAplicacao { get; set; }
        public string DataResgate { get; set; }
        public string ValorAplicado { get; set; }
        public string TotalRendimento { get; set; }
        public string ValorRendimento { get; set; }
        public string ValorJuros { get; set; }

        public string LucroTotal { get; set; }
    }
}
