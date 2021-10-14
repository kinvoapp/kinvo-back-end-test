using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain.Entidades
{
    public class Carteira
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public double ValorInvestido { get; set; }
        public double ValorBruto { get; set; }
        public IEnumerable<ProdutoFinanceiro> ProdutoFinanceiro { get; set; }
        public IEnumerable<ComprovanteResgate> ListaComprovanteResgate { get; set; }


    }
}
