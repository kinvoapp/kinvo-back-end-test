using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.WebApp.Models
{
    public class AplicacaoViewModel
    {
        public string Id { get; set; }

        public DateTime DataAplicacao { get; set; }

        public decimal ValorAplicado { get; set; }

        public Guid ProdutoFinanceiroId { get; set; }

        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }

        public Aplicacao ConvertToModel()
        {
            Aplicacao result = new Aplicacao()
            {
                Id = String.IsNullOrEmpty(this.Id)? Guid.Empty : Guid.Parse(this.Id),
                DataAplicacao = this.DataAplicacao,
                ValorAplicado = this.ValorAplicado,
                ProdutoFinanceiroId = this.ProdutoFinanceiroId
            };

            return result;
        }
    }
}
