using Aliquota.Domain.Service;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AliquotaTest
    {
        private const double ALIQUOTA1 = 0.225; //Até 1 ano de aplicação: 22,5% sobre o lucro
        private const double ALIQUOTA2 = 0.185; //De 1 a 2 anos de aplicação: 18,5% sobre o lucro
        private const double ALIQUOTA3 = 0.15; //Acima de 2 anos de aplicação: 15% sobre o lucro

        //regras de tempo de aplicação de aliquota
        private const int REGRAANO1 = 1;
        private const int REGRAANO2 = 2;

        [Theory]
        [InlineData("2021-09-05", "2022-05-05", 1)] //menos de um ano
        [InlineData("2021-09-05", "2022-09-05", 1)] //um ano
        [InlineData("2021-09-05", "2023-05-05", 2)] //entre um ano e dois anos
        [InlineData("2021-09-05", "2023-09-05", 2)] //dois anos
        [InlineData("2021-09-05", "2024-09-06", 3)] //mais de dois anos
        public void Calcular(string dataAplicao, string dataResgate, int teste)
        {
            var service = new AliquotaService();
            var c = service.Calcular(DateTime.Parse(dataAplicao), DateTime.Parse(dataResgate));

            var assert = 0.0;
            if (teste == REGRAANO1)
                assert = ALIQUOTA1;
            else if (teste == REGRAANO2)
                assert = ALIQUOTA2;
            else
                assert = ALIQUOTA3;

            Assert.True(c == assert);
        }
    }
}
