
using Aliquota.Domain.Api.Services;
using Aliquota.Domain.Api.ViewModel;
using Aliquota.Domain.Context;
using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ProdutoResgatado
    {
        


        [Theory]
        [InlineData(2000, Tipo.Mensal, 5.5, "2015-12-25")]
        [InlineData(1000, Tipo.Semestral, 5.5, "2015-12-25")]
        [InlineData(1000, Tipo.Anual, 5.5, "2015-12-25")]
        public void RetornaResultResgate63Meses(decimal valorAplcado, Tipo tipo, decimal porcentagem, string dataCriacao)
        {
            ResultResgate resgateEsperado = new ResultResgate();
            switch (tipo)
            {
                case Tipo.Mensal:
                    resgateEsperado = new ResultResgate { IR = 1039.5m, LucroBruto = 6930.0m, LucroLiquido = 5890.5m, TotalReagate = 7890.5m };
                    break;
                case Tipo.Semestral:
                    resgateEsperado = new ResultResgate { IR = 1039.5m, LucroBruto = 6930.0m, LucroLiquido = 5890.5m, TotalReagate = 7890.5m };
                    break;
                case Tipo.Anual:
                    resgateEsperado = new ResultResgate { IR = 41.25m, LucroBruto = 275.0m, LucroLiquido = 233.75m, TotalReagate = 1233.75m };
                    break;
                default:
                    break;
            }
            var meses = Meses.Contar(DateTime.Parse(dataCriacao));

            ResultResgate resgate = Operacao.Resgate(tipo, meses, valorAplcado, porcentagem);

            Assert.Equal(resgateEsperado.LucroBruto, resgate.LucroBruto);
            Assert.Equal(resgateEsperado.LucroLiquido, resgate.LucroLiquido);
            Assert.Equal(resgateEsperado.TotalReagate, resgate.TotalReagate);
        }
    }
}
