using Aliquota.Domain.Entities;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class MovimentacaoTestes
    {
        [Fact]
        public void GerarAplicacaoValida()
        {
            double valor = 320.00;
            Tipo tipo = Tipo.Aplicacao;
            DateTime dataMovimentacao = new DateTime(2022,05,06,22,11,00);

            var movimentacao = new Movimentacao()
            {
                Valor = valor,
                DataMovimentacao = dataMovimentacao,
                Tipo = tipo
            };

            Assert.Equal(valor, movimentacao.Valor);
            Assert.Equal(dataMovimentacao, movimentacao.DataMovimentacao);
            Assert.Equal(tipo, movimentacao.Tipo);
        }

        [Fact]
        public void GerarResgateValido()
        {
            double valor = 320.00;
            Tipo tipo = Tipo.Resgate;
            DateTime dataMovimentacao = new DateTime(2023,05,07,22,11,00);

            var movimentacao = new Movimentacao()
            {
                Valor = valor,
                DataMovimentacao = dataMovimentacao,
                Tipo = tipo
            };

            Assert.Equal(valor, movimentacao.Valor);
            Assert.Equal(dataMovimentacao, movimentacao.DataMovimentacao);
            Assert.Equal(tipo, movimentacao.Tipo);
        }

        [Fact]
        public void TestaExcecaoComResgateInvalido()
        {
            //Arrange        
            int numeroInvalido = 1000;
            //Act
            //Assert
            Assert.Throws<FormatException>(
                () => new Movimentacao().Valor = numeroInvalido

             );
        }
    }
}