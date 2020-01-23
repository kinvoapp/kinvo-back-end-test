using System;

namespace Aliquota.Domain
{
    public class Investimento
    {
        public Investimento()
        {

        }

        public DateTime DataAplicacao { get; set; }
        public DateTime DataResgate { get; set; }

        public double ValorAplicacao { get; set; }
        public double ValorBruto { get; set; }
        public double ValorIR { get; set; }
        public double ValorLiquido { get; set; }


    }
}
