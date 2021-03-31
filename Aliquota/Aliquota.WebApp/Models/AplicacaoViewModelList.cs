using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.WebApp.Models
{
    public class AplicacaoViewModelList
    {
        public Guid Id { get; set; }

        public DateTime DataAplicacao { get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorAplicado { get; set; }

        public string Produto { get; set; }

        public Guid ProdutoId { get; set; }

        public decimal ValorAtual { get; set; }

        public decimal Variacao { get; set; }

        public int DiasAplicado { get; set; }

        public static AplicacaoViewModelList ConvertToModelView(Aplicacao aplicacao)
        {
            AplicacaoViewModelList result = new AplicacaoViewModelList()
            {
                Id = aplicacao.Id,
                DataAplicacao = aplicacao.DataAplicacao,
                Quantidade = aplicacao.Quantidade,
                Produto = aplicacao.ProdutoFinanceiro.Nome,
                ProdutoId = aplicacao.ProdutoFinanceiroId,
                ValorAplicado = aplicacao.ValorAplicado,
                ValorAtual = aplicacao.ProdutoFinanceiro.Cotacao * aplicacao.Quantidade,
                Variacao = (aplicacao.ProdutoFinanceiro.Cotacao * aplicacao.Quantidade) - aplicacao.ValorAplicado,
                DiasAplicado = (DateTime.Now - aplicacao.DataAplicacao).Days
            };

            return result;
        }
    }

}
