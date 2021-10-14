using Aliquota.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Serviços
{
    class CalculoImpostoServico
    {
        public double ValorInvestido { get; set; }
        public double SaldoBruto { get; set; }
        public DateTime DataInvestimento { get; set; }
        public DateTime DataResgate { get; set; }
        


        public double CalcularImposto(Carteira carteira)
        {
            
            double ValorImposto = 0.0;
            double lucro = SaldoBruto - ValorInvestido;

            //if () //Comparar tempo para descobrir intervalo
            //{

            //}

            return 0;
            
        }

    }
}
