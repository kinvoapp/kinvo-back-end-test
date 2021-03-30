using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Models
{
    public class ProdutoFinanceiro
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public decimal Cotacao { get; set; }
    }
}
