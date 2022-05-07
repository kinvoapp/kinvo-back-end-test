using Aliquota.Domain.Entities;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class MovimentacaoTestes
    {
        [Fact]
        public void CriarObjectoMovimentacaoValido()
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
    }
}