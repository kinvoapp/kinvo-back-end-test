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

        [Fact]
        public void Aplicacao_Valor_Zero()
        {
            Assert.Throws<ArgumentException>(() => transacao.Aplicar(cliente, 0));
        }

         [Fact]
        public void Aplicacao_Valor_Correto()
        {
            transacao.Aplicar(cliente, 1000);

            Assert.Equal(1000.00, cliente.Transacoes.FirstOrDefault().Valor);
        }
    }
}
