using Aliquota.Domain.Extensoes;
using System;

namespace Aliquota.Domain.Servicos.CalculoIR.Calculos
{
    public class CalculoDeUmADoisAnos : ICalculoIR
    {
        private readonly double _porcentagem = 18.5;

        public void FazCalculo(ref double valorIR, double lucro, DateTime dataAplicacao, DateTime dataResgate)
        {
            var meses = dataAplicacao.DiferencaDataAplicacaoEmMeses(dataResgate);
            if (meses > 12 && meses <= 24) valorIR = Math.Round((lucro / 100) * _porcentagem, 2);
        }
    }
}
