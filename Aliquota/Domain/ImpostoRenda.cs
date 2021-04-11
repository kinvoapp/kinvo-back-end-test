﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class ImpostoRenda
    {
        private double valor;
        private DateTime dataResgate;
        private DateTime dataAplicacao;
        private double ir;

        public Lucro lucro;

        public ImpostoRenda()
        {

        }
        public ImpostoRenda(DateTime dataResgate, DateTime dataAplicacao)
        {
            this.dataResgate = dataResgate;
            this.dataAplicacao = dataAplicacao;
        }
        public double getIR()
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

        public double getValor()
        {
            return valor;
        }
    }
}
