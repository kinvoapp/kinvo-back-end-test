using AliquotaImpostoRenda.Dominio.Comum;
using AliquotaImpostoRenda.Dominio.Enum;
using System;

namespace AliquotaImpostoRenda.Dominio.Entidades
{
    public class ExtratoAplicacao : Entidade
    {
        public DateTime DataAplicacao { get; set; }
        public DateTime DataResgate { get; set; }
        public double ValorResgatado { get; set; }
        public double ValorParaPagarImposto { get; set; }
        public eTipoEntradaLucro TipoEntradaLucro { get; set; }
        public double PorcentagemLucro { get; set; }
        public double PorcentagemPagamento { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
