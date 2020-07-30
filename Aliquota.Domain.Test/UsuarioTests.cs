using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Aliquota.Domain.Test
{
    public class UsuarioTests
    {
        #region RegistrarAplicacao
        [Fact]
        public void RegistrarAplicacao_QuandoInformadoDadosValidos_DeveRegistrar()
        {
            Usuario usuario = new Usuario();

            usuario.RegistrarAplicacao(0.1, 1000);

            usuario.Aplicacoes.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData(0, 1000)]
        [InlineData(0.1, 0)]
        [InlineData(-0.1, 1000)]
        [InlineData(0.15, -500)]
        public void RegistrarAplicacao_QuandoInformadoDadosInvalidos_DeveRetornarExcecao(double rent, double valor)
        {
            Usuario usuario = new Usuario();

            usuario
                .Invoking(x => x.RegistrarAplicacao(rent, valor))
                .Should().Throw<ApplicationException>();

        }

        #endregion

        #region ResgatarAplicacao
        [Fact]
        public void ResgatarAplicacao_QuandoInformadoDadosValidos_DeveRegistrarDataResgate()
        {
            Usuario usuario = new Usuario() { Id = 0 };
            Aplicacao ap = new Aplicacao(0.1, 1000, usuario.Id) { Id = 1 };
            usuario.Aplicacoes.Add(ap);

            usuario.ResgatarAplicacao(ap.Id);

            usuario.Aplicacoes.Should().NotBeNullOrEmpty();
            ap.DataResgate.Value.Date.Should().Be(DateTime.Now.Date);
        }

        [Fact]
        public void ResgatarAplicacao_QuandoInformadoAplicacaoInexistente_DeveRetornarExcecao()
        {
            Usuario usuario = new Usuario() { Id = 0 };
            Aplicacao ap = new Aplicacao(0.1, 1000, usuario.Id) { Id = 1 };
            usuario.Aplicacoes.Add(ap);

            usuario
                .Invoking(x => x.ResgatarAplicacao(2))
                .Should().Throw<ApplicationException>();

        }

        #endregion

        #region SimularResgate

        [Fact]
        public void SimularResgateAplicacao_QuandoInformadoDadosValidos_DeveRegistrarDataResgate()
        {
            var dataResgate = DateTime.Now.AddDays(10);
            Usuario usuario = new Usuario() { Id = 0 };
            Aplicacao ap = new Aplicacao(0.1, 1000, usuario.Id) { Id = 1 };
            usuario.Aplicacoes.Add(ap);

            usuario.SimularResgateAplicacao(ap.Id, dataResgate);

            usuario.Aplicacoes.Should().NotBeNullOrEmpty();
            ap.DataResgate.Value.Should().Be(dataResgate);
        }

        [Theory]
        [InlineData(2, 5)]
        [InlineData(1, -2)]
        public void SimularResgateAplicacao_QuandoInformadoDadosInvalidos_DeveRetornarExcecao(int idAplicacao, int dias)
        {
            var dataResgate = DateTime.Now.AddDays(dias);
            Usuario usuario = new Usuario() { Id = 0 };
            Aplicacao ap = new Aplicacao(0.1, 1000, usuario.Id) { Id = 1 };
            usuario.Aplicacoes.Add(ap);

            usuario
                .Invoking(x => x.SimularResgateAplicacao(idAplicacao, dataResgate))
                .Should().Throw<ApplicationException>();

        }

        #endregion
    }
}
