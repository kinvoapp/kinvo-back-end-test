using System;
using Aliquota.Domain;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AliquotaTest
    {
        private readonly Produto _produto;
        private readonly Calculadora _calculadora;
        
        public AliquotaTest()
        {
            _calculadora = new Calculadora();
            _produto = new Produto();
        }

        [Theory]
        //Testes positivos
        [InlineData(545.60, "22/10/2019", "22/11/2019")]
        [InlineData(3698.65, "22/10/2017", "22/11/2020")]
        [InlineData(1.05, "15/08/2009", "01/01/2017")]
        //Testes negativos
        [InlineData(100, "22/01/2020", "05/12/2019")]//Data Incorreta
        [InlineData(-159, "30/07/2018", "31/08/2018")]//Valor da Aplicação negativo
        public void TestedeRegras(double valoraplicado, string inicial, string final)
        {
            var produto1 = new Produto
            {
                
                ValorAplicado = _calculadora.ValorAplicado(valoraplicado),
                DataInicial = DateTime.Parse(inicial),
                DataResgate = DateTime.Parse(final),
                TempoDeAplicacao = _calculadora.DuracaoAplicado(inicial, final),
                Lucro = _calculadora.CalculaLucro(10),
                Imposto = _calculadora.AliquotaCalculada()
            };
            
        }
        [Fact]
        public void TesteAliquota1Ano()
        {
            var produto1 = new Produto
            {
                
                ValorAplicado = _calculadora.ValorAplicado(100), //para verificar se vai calcular a porcentagem correta
                TempoDeAplicacao = _calculadora.DuracaoAplicado("22/10/2018", "22/09/2019"), //Data com menos de 1 ano
                Lucro = _calculadora.CalculaLucro(100),//para verificar se vai calcular a porcentagem correta
                Imposto = _calculadora.AliquotaCalculada()
            };
            Assert.Equal(22.5, produto1.Imposto);
        }
        
        [Fact]
        public void TesteAliquota2Ano()
        {
            var produto1 = new Produto
            {
                
                ValorAplicado = _calculadora.ValorAplicado(100), //para verificar se vai calcular a porcentagem correta
                TempoDeAplicacao = _calculadora.DuracaoAplicado("22/5/2018", "22/10/2019"), //Data com mais de 1 ano, porém menos de 2 anos
                Lucro = _calculadora.CalculaLucro(100),//para verificar se vai calcular a porcentagem correta
                Imposto = _calculadora.AliquotaCalculada()
            };
            Assert.Equal(18.5, produto1.Imposto);
        }

        [Fact]
        public void TesteAliquotaMaisde3Anos()
        {
            var produto1 = new Produto
            {
               
                ValorAplicado = _calculadora.ValorAplicado(100), //para verificar se vai calcular a porcentagem correta
                TempoDeAplicacao = _calculadora.DuracaoAplicado("22/10/2015", "22/10/2019"), //Data maior que 2 anos
                Lucro = _calculadora.CalculaLucro(100),//para verificar se vai calcular a porcentagem correta
                Imposto = _calculadora.AliquotaCalculada()
            };
            Assert.Equal(15, produto1.Imposto);
        }

    }
}
