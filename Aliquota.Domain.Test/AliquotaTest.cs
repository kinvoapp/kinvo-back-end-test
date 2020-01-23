using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AliquotaTest
    {
        readonly GerenciadorInvestimento gerenciador = new GerenciadorInvestimento();
        readonly Investimento investimento = new Investimento();

        [Fact]
        public void ResgateAte1Ano()
        {
            investimento.DataAplicacao = DateTime.Parse("22/01/2020");
            investimento.DataResgate = DateTime.Parse("22/06/2020");
            investimento.ValorAplicacao = 1000;
            investimento.ValorBruto = 1220;
            gerenciador.Resgatar(investimento);

            Assert.Equal(49.5, investimento.ValorIR);
            Assert.Equal(1170.5, investimento.ValorLiquido);
        }

        [Fact]
        public void ResgateDe1a2Anos()
        {
            investimento.DataAplicacao = DateTime.Parse("22/01/2020");
            investimento.DataResgate = DateTime.Parse("22/06/2021");
            investimento.ValorAplicacao = 1000;
            investimento.ValorBruto = 1220;
            gerenciador.Resgatar(investimento);

            Assert.Equal(40.7, investimento.ValorIR);
            Assert.Equal(1179.3, investimento.ValorLiquido);
        }

        [Fact]
        public void ResgateAcima2Anos()
        {
            investimento.DataAplicacao = DateTime.Parse("22/01/2020");
            investimento.DataResgate = DateTime.Parse("22/06/2023");
            investimento.ValorAplicacao = 1000;
            investimento.ValorBruto = 1220;
            gerenciador.Resgatar(investimento);

            Assert.Equal(33, investimento.ValorIR);
            Assert.Equal(1187, investimento.ValorLiquido);
        }

        [Fact]
        public void ResgateValorAplicacaoZerado()
        {
            investimento.ValorAplicacao = 0;

            Exception ex = Assert.Throws<Exception>(() => gerenciador.Resgatar(investimento));
            Assert.Equal("Valor da aplicação do investimento deve ser maior que 0", ex.Message);
        }

        [Fact]
        public void ResgateDataAplicacaoMaiorQueDataResgate()
        {
            investimento.DataAplicacao = DateTime.Parse("22/01/2023");
            investimento.DataResgate = DateTime.Parse("22/06/2020");
            investimento.ValorAplicacao = 1000;

            Exception ex = Assert.Throws<Exception>(() => gerenciador.Resgatar(investimento));
            Assert.Equal("Data da aplicação está maior que a data de resgate", ex.Message);
        }
    }
}
