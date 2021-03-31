using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Models
{
    public class Aplicacao
    {
        public Guid Id { get; set; }

        public DateTime DataAplicacao { get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorAplicado { get; set; }

        public Guid ProdutoFinanceiroId { get; set; }

        public virtual ProdutoFinanceiro ProdutoFinanceiro { get; set; }
    }
}
