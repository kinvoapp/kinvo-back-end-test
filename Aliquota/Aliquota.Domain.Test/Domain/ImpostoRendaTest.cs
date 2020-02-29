using Aliquota.Domain.Domain.AgregadoProduto;
using Aliquota.Domain.ImpostoRenda;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test.Domain
{
    public class ImpostoRendaTest
    {
        Produto produto;
        ICalcularImposto calcularImpostoRenda;
        public ImpostoRendaTest()
        {
            produto = Produto.Create("Teste", new DateTime(2019, 01, 05), 200.00M, 7.00M, 1500.00M);
            calcularImpostoRenda = new CalcularImpostoRenda();
        }

        [Fact]
        public void CalcularImpostoRendaInvestimentoAte1Ano()
        {
            var rendimento = produto.ResgatarRendimentos(produto.SaldoAtual, new DateTime(2019, 12, 05));
            calcularImpostoRenda.Calcular(rendimento);
            Assert.Equal(22.5M, rendimento.PercentualIR);

        }

        [Fact]
        public void CalcularImpostoRendaInvestimentoDe1a2Anos()
        {
            var rendimento = produto.ResgatarRendimentos(produto.SaldoAtual, new DateTime(2020, 01, 07));
            calcularImpostoRenda.Calcular(rendimento);
            Assert.Equal(18.5M, rendimento.PercentualIR);

        }

        [Fact]
        public void CalcularImpostoRendaInvestimentoAcima2Anos()
        {
            var rendimento = produto.ResgatarRendimentos(produto.SaldoAtual, new DateTime(2021, 01, 07));
            calcularImpostoRenda.Calcular(rendimento);
            Assert.Equal(15.00M, rendimento.PercentualIR);

        }
    }
}
