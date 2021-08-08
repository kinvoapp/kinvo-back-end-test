using Aliquota.Domain.Servicos.CalculoIR.Calculos;
using System;
using System.Collections.Generic;

namespace Aliquota.Domain.Servicos.CalculoIR
{
    public class CalculadorIR : ICalculadorIR
    {
        private readonly IEnumerable<ICalculoIR> _calculos;

        public CalculadorIR(IEnumerable<ICalculoIR> calculos)
        {
            _calculos = calculos;
        }

        public double CalculaIR(double lucro, DateTime dataAplicacao, DateTime dataResgate)
        {
            var valorIR = 0.0;
            foreach (var c in _calculos)
            {
                c.FazCalculo(ref valorIR, lucro, dataAplicacao, dataResgate);
            }
            return valorIR;
        }
    }
}
