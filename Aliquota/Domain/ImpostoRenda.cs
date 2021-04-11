using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Aliquota.Domain
{
    public class ImpostoRenda
    {
        private DateTime dataResgate;
        private DateTime dataAplicacao;
        private double ir;

        public ImpostoRenda()
        {

        }
        public ImpostoRenda(String dataResgate, String dataAplicacao)
        {
            this.dataResgate = DateTime.ParseExact(dataResgate, "d/M/yyyy", CultureInfo.InvariantCulture);
            this.dataAplicacao = DateTime.ParseExact(dataAplicacao, "d/M/yyyy", CultureInfo.InvariantCulture);
        }
        public double getIR(Lucro lucro)
        {
            ir = lucro.getLucro() * lucro.getAliquota();
            return ir;
        }
        public DateTime getDataResgate()
        {
            return dataResgate;
        }

        public DateTime getDataAplicacao()
        {
            return dataAplicacao;
        }

    }
}
