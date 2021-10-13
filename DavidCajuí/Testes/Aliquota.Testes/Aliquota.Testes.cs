using Entities.Entities;
using NUnit.Framework;
using Xunit;

namespace Aliquota.Testes
{
    public class Tests
    {
        [SetUp]
        public void CalculoIr1Ano()
        {
            Product productAplicacao = new Product {
                Id = 1,
                DataInicioAplicacao = new System.DateTime(2021 / 10 / 13),
                DataResgateAplicacao = new System.DateTime(2021 / 11 / 23),
                RendimentoAplicacao = 2,
                ValorAplicado = "5000"


            };

            var valorEsperado = "1125";


            Assert.Equals(valorEsperado, productAplicacao.ValorDoImposto);
        }


    

    [Fact]
        public void CalculoIr2Anos()
        {
             Product productAplicacao = new Product {
                 Id = 1,
                DataInicioAplicacao = new System.DateTime(2021 / 10 / 13),
                DataResgateAplicacao = new System.DateTime(2023 / 10 / 14),
                RendimentoAplicacao = 2,
                ValorAplicado = "5000"


            };

    var valorEsperado = "925";


    Assert.Equals(valorEsperado, productAplicacao.ValorDoImposto);
        }



        [Fact]
        public void CalculoIr3Anos()
        {
            Product productAplicacao = new Product {
                Id = 1,
                DataInicioAplicacao = new System.DateTime(2021 / 10 / 13),
                DataResgateAplicacao = new System.DateTime(2024 / 10 / 14),
                RendimentoAplicacao = 2,
                ValorAplicado = "5000"


            };

            var valorEsperado = "750";


            Assert.Equals(valorEsperado, productAplicacao.ValorDoImposto);
        }

        [Fact]
        public void ValidacaoDatas()
        {
            Product productAplicacao = new Product {
                Id = 1,
                DataInicioAplicacao = new System.DateTime(2021 / 10 / 13),
                DataResgateAplicacao = new System.DateTime(2020 / 10 / 13),
                RendimentoAplicacao = 2,
                ValorAplicado = "5000"


            };

            var valorEsperado = "Página404";


            Assert.Equals(valorEsperado, productAplicacao.Notitycoes);
        }

        [Fact]
        public void ValidacaoValorAplicado()
        {
            Product productAplicacao = new Product {
                Id = 1,
                DataInicioAplicacao = new System.DateTime(2021 / 10 / 13),
                DataResgateAplicacao = new System.DateTime(2020 / 10 / 13),
                RendimentoAplicacao = 2,
                ValorAplicado = "0"


            };

            var valorEsperado = "Página404";


            Assert.Equals(valorEsperado, productAplicacao.Notitycoes);
        }


    }
}

    
    
    
    

