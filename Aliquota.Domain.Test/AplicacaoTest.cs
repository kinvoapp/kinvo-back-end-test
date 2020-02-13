using System;
using System.Collections.Generic;
using Aliquota.Domain.Models;
using System.Linq;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AplicaoTest
    {
        public AplicaoTest(){

            cliente = new Cliente
            {
                ClienteId = new Random().Next(0, 13),
                Nome = "Yuri Brandão",
                Aplicacoes = new List<Aplicacao>(),
                Resgates = new List<Resgate>(),
            };
        }

        readonly Cliente cliente;

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Aplicacao_Valor_Zero(decimal value)
        {
            Assert.Throws<ArgumentException>(() => Aplicacao.EfetuarAplicacao(cliente, value));
        }

        [Theory]
        [InlineData(2000.22)]
        [InlineData(1550.00)]
        public void Aplicacao_Valor_Correto(decimal value)
        {
           Aplicacao.EfetuarAplicacao(cliente, value);

            Assert.Equal(value, cliente.Aplicacoes.FirstOrDefault().Valor);
        }
        
    }
}
