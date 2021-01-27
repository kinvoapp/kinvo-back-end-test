using Aliquota.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Models
{
    public class Conta : Entity
    {
        public Conta()
        {
            Ativo = true;
        }
        public string Nome { get; set; }
        public decimal ValorAplicacao { get; set; }
        public decimal ValorCorrente { get; set; }
        public DateTime DtAplicacao { get; set; }
        public DateTime? DtResgate { get; set; }
        public bool Ativo { get; set; }
        private int YearDifference()
        {
            return Convert.ToDateTime(DtResgate).Year - DtAplicacao.Year;
        }

        private decimal _valorResgate;
        public decimal ValorResgate
        {
            get
            {
                if (YearDifference() < 1)
                {
                    return ValorCorrente - (ValorCorrente - ValorAplicacao) * Convert.ToDecimal(0.225);
                }
                else if(YearDifference() >= 1 && YearDifference() <= 2)
                {
                    return ValorCorrente - (ValorCorrente - ValorAplicacao) * Convert.ToDecimal(0.185);
                }
                else
                {
                    return ValorCorrente - (ValorCorrente - ValorAplicacao) * Convert.ToDecimal(0.15);
                }
            }

            set
            {
                if (YearDifference() < 1)
                {
                    _valorResgate =  ValorCorrente - (ValorCorrente - ValorAplicacao) * Convert.ToDecimal(0.225);
                }
                else if (YearDifference() >= 1 && YearDifference() <= 2)
                {
                    _valorResgate = ValorCorrente - (ValorCorrente - ValorAplicacao) * Convert.ToDecimal(0.185);
                }
                else
                {
                    _valorResgate = ValorCorrente - (ValorCorrente - ValorAplicacao) * Convert.ToDecimal(0.15);
                }
            }
        }
    }
}
