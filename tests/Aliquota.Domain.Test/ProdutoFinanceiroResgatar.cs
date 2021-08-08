using Xunit;
using System;
using Aliquota.Domain.Models;
using Aliquota.Domain.Servicos.CalculoIR.Calculos;
using System.Collections.Generic;
using Aliquota.Domain.Servicos.CalculoIR;

namespace Aliquota.Domain.Test
{
    public class ProdutoFinanceiroResgatar
    {
        [Theory]
        [InlineData(170.0,"2021-08-05","2021-10-12",3.82,5)]
        public void ObtemValorIRAoResgatar(double valorAplicado,DateTime dataAplicacao,
                                                 DateTime dataResgate, double valorEsperadoIR,
                                                 double porcentagem)
        {
            var produtoFinanceiro = new ProdutoFinanceiro
            {
                DataAplicacao=dataAplicacao,
                ValorAplicado=valorAplicado,
                TipoProdutoFinanceiro= new TipoProdutoFinanceiro
                {
                    PorcentagemLucro=porcentagem
                }
            };
            var calculador = new CalculadorIR(GetCalculos());

            produtoFinanceiro.Resgatar(calculador, dataResgate);

            Assert.Equal(valorEsperadoIR, produtoFinanceiro.ValorIR);
        }

        private List<ICalculoIR> GetCalculos()
        => new List<ICalculoIR>
        {
            new CalculoAcimaDeDoisAnos(),
            new CalculoAteUmAno(),
            new CalculoAcimaDeDoisAnos()
        };
    }
}
