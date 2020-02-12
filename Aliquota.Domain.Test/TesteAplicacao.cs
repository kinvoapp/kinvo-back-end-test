using System;
using System.Collections.Generic;
using Aliquota.Domain.Models;
using System.Linq;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class TesteAplicacao
    {
        public TesteAplicacao(){

            cliente = new Cliente
            {
                ClienteId = new Random().Next(0, 13),
                Nome = "Yuri Brandão",
                Transacoes = new List<Transacao>()
            };

            transacao = new Transacao ();
        }

        readonly Cliente cliente;
        readonly Transacao transacao;

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Aplicacao_Valor_Zero(double value)
        {
            Assert.Throws<ArgumentException>(() => transacao.Aplicar(cliente, value));
        }

        [Theory]
        [InlineData(2000.22)]
        [InlineData(1550.00)]
        public void Aplicacao_Valor_Correto(double value)
        {
            transacao.Aplicar(cliente, value);

            Assert.Equal(value, cliente.Transacoes.FirstOrDefault().Valor);
        }
    }
}
