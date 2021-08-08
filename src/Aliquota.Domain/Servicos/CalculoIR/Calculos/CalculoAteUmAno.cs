using Aliquota.Domain.Extensoes;
using System;

namespace Aliquota.Domain.Servicos.CalculoIR.Calculos
{
    public class CalculoAteUmAno : ICalculoIR
    {
        private readonly double _porcentagem = 22.5;

        public void FazCalculo(ref double valorIR, double lucro, DateTime dataAplicacao, DateTime dataResgate)
        {
            var meses = dataAplicacao.DiferencaDataAplicacaoEmMeses(dataResgate);
            if (meses <= 12) valorIR = Math.Round((lucro / 100) * _porcentagem, 2);
        }
    }
}
