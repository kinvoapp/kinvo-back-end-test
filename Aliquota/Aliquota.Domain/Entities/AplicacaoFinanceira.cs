
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain.Entities
{
    public class AplicacaoFinanceira
    {

        private const int ANO365 = 365;
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataAplicacao { get; set; }

        public DateTime DataResgate { get; set; }

        public Decimal ValorAplicacao { get; set; }

        public Decimal RentabilidadeAnual { get; set; }

        [NotMapped]
        public Decimal Rendimento
        {
            get
            {
                return ValorAplicacao * (RentabilidadeAnual * DiasAplicacaoAtiva / ANO365) / 100;
            }
        }

        [NotMapped]
        public Decimal IRRecolhido
        {
            get
            {
                return Rendimento * AliquotaIR / 100;
            }
        }

        [NotMapped]
        public Decimal AliquotaIR
        {
            get
            {
                if (DiasAplicacaoAtiva <= ANO365)
                    return 22.5M;
                else if (DiasAplicacaoAtiva <= ANO365 * 2)
                    return 18.5M;
                else
                    return 15;
            }
        }

        [NotMapped]
        public int DiasAplicacaoAtiva
        {
            get
            {
                return (int)((TimeSpan)(DataResgate - DataAplicacao)).TotalDays;
            }
        } 
    }
}
