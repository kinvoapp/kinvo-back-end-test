using Aliquota.Domain.Servicos.ProdutoFinanceiroSv.ValidacaoResgate;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ValidacaoDataResgateValidaDataResgate
    {
        [Fact]
        public void LancaArgumentExceptionCasoDataResgateSejaMenorQueDataAplicacao()
        {
            var executorValidacao = new ValidacaoDataResgate();
            var dataAplicacao = DateTime.Now;
            var dataResgate = "2021-08-05";

            Assert.Throws<ArgumentException>(
                () => executorValidacao.ValidaDataResgate(dataResgate,dataAplicacao)
            );
        }

        [Fact]
        public void LancaFormatExceptionCasoDataResgateSejaUmaStringInvalida()
        {
            var executorValidacao = new ValidacaoDataResgate();
            var dataAplicacao = DateTime.Now;
            var dataResgate = "adasdasd";

            Assert.Throws<FormatException>(
                () => executorValidacao.ValidaDataResgate(dataResgate, dataAplicacao)
            );
        }
    }
}
