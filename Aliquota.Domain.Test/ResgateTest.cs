using System;
using System.Collections.Generic;
using Aliquota.Domain.Models;
using System.Linq;
using Xunit;
using static Aliquota.Domain.Helpres.Helpres;

namespace Aliquota.Domain.Test
{
    public class ResgateTest
    {
        public ResgateTest(){

            cliente = new Cliente
            {
                ClienteId = new Random().Next(0, 13),
                Nome = "Yuri Brandão",
                Aplicacoes = new List<Aplicacao>(),
                Resgates = new List<Resgate>(),
            };
        }

        readonly Cliente cliente;

        [Fact]
        public void Resgate_Cliente_Sem_Aplicacao()
        {
            Assert.Throws<ArgumentException>(() => Resgate.EfetuarResgate(cliente, DateTime.Now));
        }

        [Fact]
        public void Resgate_Data_Menor()
        {
            Aplicacao.EfetuarAplicacao(cliente, 50000); // Aplicaçaõ feita na data de Hoje
            var dataDeResgate = DateTime.Now.AddYears(-1); // Aplicaçaõ feito a um ano atrás

            Assert.Throws<ArgumentException>(() => Resgate.EfetuarResgate(cliente, dataDeResgate));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Resgate_Data_Correta(int value)
        {
            Aplicacao.EfetuarAplicacao(cliente, 50000);
            var dataDeResgate = DateTime.Now.AddYears(value);
           Resgate.EfetuarResgate(cliente, DateTime.Now.AddYears(value));

            Assert.Equal(dataDeResgate, Resgate.EfetuarResgate(cliente, dataDeResgate).Data);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Resgate_Calculo_IR(int value)
        {
            Aplicacao.EfetuarAplicacao(cliente, 50000);
            var dataDeResgate = DateTime.Now.AddYears(value);
            var aplicacao = cliente.Aplicacoes.Where(q => !q.FoiResgatada).FirstOrDefault();

            decimal lucro = CalcularLucro(aplicacao.Valor, aplicacao.Data, dataDeResgate);
            decimal valorIr = CalcularImpostoDeRenda(lucro, dataDeResgate.Year - aplicacao.Data.Year);

            Assert.Equal(valorIr, Resgate.EfetuarResgate(cliente, dataDeResgate).IR);
        }
    }
}
