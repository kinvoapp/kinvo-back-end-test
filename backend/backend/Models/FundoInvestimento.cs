using System;
using System.Collections.Generic;

namespace src.Models
{
    public class FundoInvestimento : Ativo
    {
        // Deve ser um model de com todas as cotas do fundo por dia 
        public decimal CotaFundo { get; set; }

        //Deve ser um model de Pessoa Juridica
        public string Administrador { get; set; }

        public string IndicadorDesempenho { get; set; }

        //Deve ser um model de dominio 
        public string TipoFundo  { get; set; }

        public bool isFundoCotas { get; set; }

        public bool isFundoExclusivo { get; set; }

        public bool isTratamentoTributarioLongoPrazo { get; set; }

        public bool isDestinadoInvestidoresQualificados { get; set; }

        public virtual ICollection<AplicacaoFundo> AplicacoesFundo { get; set; }

        public virtual ICollection<ResgateFundo> ResgatesFundo { get; set; }

        public virtual ICollection<SaldoFundo> SaldoFundos { get; set; }

    }
}
