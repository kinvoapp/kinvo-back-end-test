using Aliquota.Domain.Helper;
using System;

namespace Aliquota.Domain.Service
{
    public class AliquotaService
    {
        //regras de percentual de aliquota
        private const double ALIQUOTA1 = 0.225; //Até 1 ano de aplicação: 22,5% sobre o lucro
        private const double ALIQUOTA2 = 0.185; //De 1 a 2 anos de aplicação: 18,5% sobre o lucro
        private const double ALIQUOTA3 = 0.15; //Acima de 2 anos de aplicação: 15% sobre o lucro

        //regras de tempo de aplicação de aliquota
        private const int REGRAANO1 = 1;
        private const int REGRAANO2 = 2;

        public double Calcular(DateTime dataAplicacao, DateTime dataResgate)
        {
            var c = new CamparaDatasHelper(dataAplicacao, dataResgate);
            if (c.CalculaAnos(REGRAANO1))
                return ALIQUOTA1;
            else if (c.CalculaAnos(REGRAANO2))
                return ALIQUOTA2;
            else
                return ALIQUOTA3;

        }
    }
}
