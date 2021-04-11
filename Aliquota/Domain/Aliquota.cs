using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Aliquota : ImpostoRenda
    {
        private double aliquota;

        public Aliquota(String dataResgate, String dataAplicacao): base(dataResgate, dataAplicacao)
        {
            setAliquota();
        }
        public void setAliquota()
        {
            TimeSpan t = (getDataResgate() - getDataAplicacao());

            double tempo = t.Days / 365.0;

            if (tempo < 0)
            {

            }
            if (tempo < 1)
            {
                aliquota = 0.225;
            }
            else if (tempo <= 2)
            {
                aliquota = 0.185;
            }
            else if (tempo > 2)
            {
                aliquota = 0.15;
            }

        }
        public double getAliquota()
        {
            return aliquota;
        }

    }
}
