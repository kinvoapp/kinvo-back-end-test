using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Aliquota.Domain
{
    public class Aliquota : IR
    {
        private double aliquota;
        public Aliquota(DateTime dataResgate, DateTime dataAplicacao): base(dataResgate, dataAplicacao)
        {
            setAliquota();
        }
        public void setAliquota()
        {
            TimeSpan tempo = (getDataResgate() - getDataAplicacao()) / 365;

            if (tempo.Days < 0)
            {
                MessageBox.Show("Data Inválida");
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
