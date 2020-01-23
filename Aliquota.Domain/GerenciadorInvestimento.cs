using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class GerenciadorInvestimento
    {
        public GerenciadorInvestimento()
        {

        }

        public void Resgatar(Investimento investimento)
        {
            ValidaDados(investimento);

            var aliquota = CalculaRangeAliquota(investimento.DataAplicacao, investimento.DataResgate);
            investimento.ValorIR = ((investimento.ValorBruto - investimento.ValorAplicacao) * aliquota) / 100;
            investimento.ValorLiquido = investimento.ValorBruto - investimento.ValorIR;
        }

        private void ValidaDados(Investimento investimento)
        {
            if (investimento.ValorAplicacao <= 0) throw new Exception("Valor da aplicação do investimento deve ser maior que 0");

            if (investimento.DataAplicacao > investimento.DataResgate) throw new Exception("Data da aplicação está maior que a data de resgate");
        }

        private double CalculaRangeAliquota(DateTime dataAplicacao, DateTime dataResgate)
        {
            var totalAnos = (dataResgate - dataAplicacao).TotalDays / 365.2425;

            if (totalAnos < 1)
                return 22.5;
            else if (totalAnos >= 1 && totalAnos <= 2)
                return 18.5;
            else
                return 15;

        }
    }
}
