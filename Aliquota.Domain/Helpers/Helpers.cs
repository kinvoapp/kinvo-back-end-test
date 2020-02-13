using System;
using System.Linq;

namespace Aliquota.Domain.Helpres
{
    public class Helpres
    {
        public static class ImpostoDeRenda
        {
            public const decimal ATE_UM_ANO = 0.225m;
            public const decimal DE_UM_A_DOIS_ANOS = 0.185m;
            public const decimal ACIMA_DE_DOIS_ANOS = 0.15m;
        }

        public static decimal CalcularImpostoDeRenda(decimal lucro, int anosDeAplicacao){

            decimal impostDeRenda = 0.00m;

            if(anosDeAplicacao <= 1){
                impostDeRenda = lucro * ImpostoDeRenda.ATE_UM_ANO;
            }
            else if(anosDeAplicacao > 1 && anosDeAplicacao <=2){
                impostDeRenda = lucro * ImpostoDeRenda.DE_UM_A_DOIS_ANOS;

            }else{
                impostDeRenda = lucro * ImpostoDeRenda.ACIMA_DE_DOIS_ANOS;
            }

            return impostDeRenda;
        }

        public static int GetAnosDeAplicacao(DateTime dataDaAplicacao, DateTime dataDoResgate){

            return dataDoResgate.Year - dataDaAplicacao.Year;
        }

        public static decimal CalcularLucro(decimal valorAplicdo, DateTime dataDaAplicacao, DateTime dataDoResgate){

            decimal lucro = 0.00m;

            var data = dataDoResgate - dataDaAplicacao;

            lucro = valorAplicdo * data.Days;
          
            return lucro;
        }
    }
}
