using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.WebApp.Models
{
    public class ProdutoFinanceiroViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public decimal Cotacao { get; set; }

        public ProdutoFinanceiro ConvertToModel()
        {
            ProdutoFinanceiro result = new ProdutoFinanceiro()
            {
                Id = this.Id,
                Nome = this.Nome,
                Cotacao = this.Cotacao
            };

            return result;
        }
    }
}
