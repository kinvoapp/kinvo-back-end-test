using Microsoft.VisualBasic;
using System;

namespace Aliquota.Domain.Entities
{
    public class Aplicacao
    {
        public Produto Produto { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorAplicado { get; set; }
        public decimal ValorBruto { get => ValorAplicado + Rendimento; }
        public decimal ValorLiquido { get => ValorBruto - IR; }
        public decimal Rendimento { get; set; }
        public decimal IR { get; set; }
        public DateTime? DataResgate { get; set; }
        public bool IsResgado { get => DataResgate.HasValue; }

    }

}
