using Aliquota.Domain.Domain.AgregadoProduto;
using Aliquota.Domain.Domain.AgregadoResgate;
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
        Resgate resgate;
        ICalcularImposto calcularImpostoRenda;
        public ImpostoRendaTest()
        {
            produto = Produto.Create("Teste", new DateTime(2019, 01, 05), 200.00M, 7.00M, 1500.00M);
            calcularImpostoRenda = new CalcularImpostoRenda();
        }

        [Fact]
        public void CalcularImpostoRendaInvestimentoAte1Ano()
        {
            resgate = produto.ResgatarRendimentos(produto.SaldoAtual, new DateTime(2019, 12, 05));
            calcularImpostoRenda.Calcular(resgate);
            Assert.Equal(22.5M, resgate.PercentualIR);
            Assert.Equal(resgate.Lucro() * (resgate.PercentualIR / 100), resgate.ValorIR);

        }

        [Fact]
        public void CalcularImpostoRendaInvestimentoDe1a2Anos()
        {
            resgate = produto.ResgatarRendimentos(produto.SaldoAtual, new DateTime(2020, 01, 07));
            calcularImpostoRenda.Calcular(resgate);
            Assert.Equal(18.5M, resgate.PercentualIR);
            Assert.Equal(resgate.Lucro() * (resgate.PercentualIR / 100), resgate.ValorIR);

        }

        [Fact]
        public void CalcularImpostoRendaInvestimentoAcima2Anos()
        {
            resgate = produto.ResgatarRendimentos(produto.SaldoAtual, new DateTime(2021, 01, 07));
            calcularImpostoRenda.Calcular(resgate);
            Assert.Equal(15.00M, resgate.PercentualIR);
            Assert.Equal(resgate.Lucro() * (resgate.PercentualIR / 100), resgate.ValorIR);

        }
    }
}
