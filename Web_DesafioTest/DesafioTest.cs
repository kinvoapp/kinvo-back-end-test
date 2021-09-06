using Entities.Entities;
using System;
using Xunit;

namespace Web_DesafioTest
{
    public class DesafioTest
    {
        //VALIDAR O CAMPO DA RENDA INFORMADA
        [Fact]
        public void TestCampoRenda()
        {
            Consulta consulta = new();
            Assert.True(consulta.ValidarRendaAplicada(1000, "Renda"));
            Assert.False(consulta.ValidarRendaAplicada(0, "Renda"));
        }

        //VALIDAR O CAMPO DO LUCRO INFORMADO
        [Fact]
        public void TestCampoLucro()
        {
            Consulta consulta = new();
            Assert.True(consulta.ValidarLucro(1000, "Lucro"));
            Assert.False(consulta.ValidarLucro(0, "Lucro"));
        }

        //VALIDAR A DATA DE APLICACAO
        [Fact]
        public void TestCampoDataAplicacao()
        {
            Consulta consulta = new();
            var dataAplicacao = new DateTime(2020,6,5);
            Assert.True(consulta.ValidarDataAplicacao(dataAplicacao, "DataAplicacao"));
            dataAplicacao = new DateTime();
            Assert.False(consulta.ValidarDataAplicacao(dataAplicacao, "DataAplicacao"));
        }

        //VALIDAR A DATA DE RESGATE
        [Fact]
        public void TestCampoDataResgate()
        {
            Consulta consulta = new();
            var dataResgate = new DateTime(2020, 6, 8);
            Assert.True(consulta.ValidarDataResgate(dataResgate, "DataResgate"));
            dataResgate = new DateTime();
            Assert.False(consulta.ValidarDataResgate(dataResgate, "DataResgate"));
        }

        //VALIDAR A DATA DE RESGATE SOBRE A DATA DE APLICAÇÃO
        [Fact]
        public void TestCampoDataResgateSobreAplicacao()
        {
            Consulta consulta = new();
            var dataAplicacao = new DateTime(2020, 6, 5);
            var dataResgate = new DateTime(2020, 6, 8);
            Assert.True(consulta.ValidarDataResgateSobreAplicacao(dataResgate, dataAplicacao, "DataResgate"));
            dataAplicacao = new DateTime(2020, 6, 5);
            dataResgate = new DateTime(2020, 6, 2);
            Assert.False(consulta.ValidarDataResgateSobreAplicacao(dataResgate, dataAplicacao, "DataResgate"));
        }
    }
}
