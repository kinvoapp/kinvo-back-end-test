using System;

namespace Aliquota.Domain.Entidades
{
    public class ComprovanteResgate
    {
        public int Id { get; set; }
        public double ValorResgate { get; set; } 
        public double ValorDoImposto { get; set; }
        public DateTime DataResgate { get; set; } = DateTime.Now;
        public DateTime PeriodoInvestimento { get; set; }
        public int CarteiraId { get; set; }
        public Carteira Carteira { get; set; }
    }
}
