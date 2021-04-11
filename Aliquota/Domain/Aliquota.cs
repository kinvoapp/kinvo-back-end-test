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
            TimeSpan tempo = (getDataResgate() - getDataAplicacao()) / 365;

            if (tempo.Days < 0)
            {
                // MessageBox.Show("Data Inválida");
            }
            if (tempo.Days < 1)
            {
                aliquota = 0.225;
            }
            else if (tempo.Days <= 2)
            {
                aliquota = 0.185;
            }
            else if (tempo.Days > 2)
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
