using Aliquota.Domain.Extensoes;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class DateTimeDiferencaDataAplicacaoEmMeses
    {
        [Theory]
        [InlineData(1,"2021-08-04","2021-08-05")]
        [InlineData(4, "2021-08-04", "2022-01-01")]
        public void ObtemDiferencaDasDatasDeAplicacaoEResgateEmMeses(int valorEsperado,DateTime dataAplicacao,DateTime dataResgate)
        {
            var diferenca = dataAplicacao.DiferencaDataAplicacaoEmMeses(dataResgate);
            Assert.Equal(valorEsperado,diferenca);
        }

        [Theory]
        [InlineData(4, "2021-04-04")]
        public void ObtemQuantidadeDeMesesDesdeADataDeAplicacaoMesmoSemPassarDataDeResgate(int valorEsperado,DateTime dataAplicacao)
        {
            var diferenca = dataAplicacao.DiferencaDataAplicacaoEmMeses(null);
            Assert.Equal(valorEsperado, diferenca);
        }
    }
}
