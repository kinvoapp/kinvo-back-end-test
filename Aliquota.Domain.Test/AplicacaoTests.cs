using System;
using Xunit;
using FluentAssertions;

namespace Aliquota.Domain.Test
{
    public class AplicacaoTests
    {
        //Foi testado em Usuario
        #region CriarAplicacao
        [Fact]
        public void CriarAplicacao_QuandoInformadoDadosValidos_DeveRegistrar()
        {
            Aplicacao ap = new Aplicacao(0.01, 10000, 1);

            ap.Should().NotBeNull();
            ap.DataResgate.Should().BeNull();
            ap.ValorAplicado.Should().Be(10000);
            ap.ValorBruto.Should().Be(ap.ValorAplicado);
        }

        //[Theory]
        //[InlineData(-1, 1000)]
        //[InlineData(0, 1000)]
        //[InlineData(0.1, 0)]
        //[InlineData(0.15, -500)]
        //public void CriarAplicacao_QuandoInformadoDadosInvalidos_DeveRetornarExcecao(double rent, double valor)
        //{
        //    Aplicacao ap = new Aplicacao();

        //    ap.Cr

        //    ap.Invoking(x => x.Aplcacao(rent, valor))
        //        .Should().Throw<ApplicationException>();

        //}

        #endregion

        #region Resgatar
        [Fact]
        public void Resgatar_QuandoNaoPassarData_DeveRegistrarDataAtualResgate()
        {
            Aplicacao ap = new Aplicacao(0.1, 1000, 0) { Id = 1 };

            ap.Resgatar();

            ap.DataResgate.Value.Date.Should().Be(DateTime.Now.Date);
        }

        [Fact]
        public void Resgatar_QuandoPassarData_DeveRegistrarDataResgate()
        {
            Aplicacao ap = new Aplicacao(0.1, 1000, 0) { Id = 1 };

            var data = DateTime.Now.AddDays(20);

            ap.Resgatar(data);

            ap.DataResgate.Value.Should().Be(data);
        }

        [Fact]
        public void Resgatar_QuandoAplicacaoJaTiverResgatada_DeveRetornarExcecao()
        {
            Aplicacao ap = new Aplicacao(0.1, 1000, 0) { Id = 1 };
            ap.Resgatar();

            ap.Invoking(x => x.Resgatar(DateTime.Now.AddDays(3)))
                .Should().Throw<ApplicationException>().WithMessage("Esta aplicação já foi resgatada");

        }

        [Fact]
        public void Resgatar_PassandoDataResgateAnteriorDataRegistro_DeveRetornarExcecao()
        {
            Aplicacao ap = new Aplicacao(0.1, 1000, 0) { Id = 1 };

            ap.Invoking(x => x.Resgatar(DateTime.Now.AddDays(-3)))
                .Should().Throw<ApplicationException>().WithMessage($"A data de resgaste deve ser maior ou igual a {ap.DataRegistro}");

        }

        #endregion

        [Fact]
        public void Resgatar_NoMesmoDiaQueRegistrou_ValorBrutoDeveSerIgualValorAplicado()
        {
            Aplicacao ap = new Aplicacao(0.1, 1000, 0) { Id = 1 };

            ap.Resgatar();

            ap.ValorBruto.Should().Be(ap.ValorAplicado);
        }


        [Fact]
        public void Resgatar_DiasAposQueRegistrou_ValorBrutoDeveSerCalculado()
        {
            Aplicacao ap = new Aplicacao(0.1, 1000, 0) { Id = 1 };
           
            ap.Resgatar(DateTime.Now.AddDays(30));

            Math.Round(ap.ValorBruto, 2).Should().Be(17449.40);
        }

        [Fact]
        public void Resgatar_NoMesmoDiaQuandoRegistrou_ValorLiquidoDeveSerCalculadoComImpostoRenda22porcento()
        {
            Aplicacao ap = new Aplicacao(0.1, 1000, 0) { Id = 1 };

            ap.Resgatar();

            Math.Round(ap.ValorLiquido, 2).Should().Be(1000);
        }

        [Fact]
        public void Resgatar_UmAnoAposQuandoRegistrou_ValorLiquidoDeveSerCalculadoComImpostoRenda22porcento()
        {
            Aplicacao ap = new Aplicacao(0.01, 1000, 0) { Id = 1 };

            ap.Resgatar(DateTime.Now.AddDays(365));

            Math.Round(ap.ValorLiquido, 2).Should().Be(29507.16);
        }

        [Fact]
        public void Resgatar_PoucoMaisDeUmAnoAposQuandoRegistrou_ValorLiquidoDeveSerCalculadoComImpostoRenda18porcento()
        {
            Aplicacao ap = new Aplicacao(0.01, 1000, 0) { Id = 1 };

            ap.Resgatar(DateTime.Now.AddDays(366));

            Math.Round(ap.ValorLiquido, 2).Should().Be(31286.43);
        }

        [Fact]
        public void Resgatar_DoisAnosAposQuandoRegistrou_ValorLiquidoDeveSerCalculadoComImpostoRenda18porcento()
        {
            Aplicacao ap = new Aplicacao(0.01, 1000, 0) { Id = 1 };

            ap.Resgatar(DateTime.Now.AddDays(730));

            Math.Round(ap.ValorLiquido, 2).Should().Be(1163669.15);
        }

        [Fact]
        public void Resgatar_PoucoMaisDeDoisAnosAposQuandoRegistrou_ValorLiquidoDeveSerCalculadoComImpostoRenda18porcento()
        {
            Aplicacao ap = new Aplicacao(0.01, 1000, 0) { Id = 1 };

            ap.Resgatar(DateTime.Now.AddDays(731));

            Math.Round(ap.ValorLiquido, 2).Should().Be(1225734.22);
        }
    }
}
