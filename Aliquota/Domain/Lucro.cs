using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Lucro : Aliquota
    {
        private double taxaAnual;
        private double lucro_;
        private double valor;

        public Lucro(String dataResgate, String dataAplicacao, double taxaAnual, double valor) : base(dataResgate, dataAplicacao)
        {
            this.taxaAnual = taxaAnual;
            this.valor = valor;

            setLucro();
        }
        public void setLucro()
        {
            TimeSpan t = (getDataResgate() - getDataAplicacao());

            double taxaDia = taxaAnual / 365.0;

            if (valor > 0)
            {
                 lucro_ =  valor * taxaDia * t.Days;
            }
        }
        public double getLucro()
        {
            return lucro_;
        }
    }
}
