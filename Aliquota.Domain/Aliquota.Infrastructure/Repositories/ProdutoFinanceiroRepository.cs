using Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate;
using System.Linq;

namespace Aliquota.Infrastructure.Repositories
{
    public class ProdutoFinanceiroRepository : IProdutoFinanceiroRepository
    {
        private readonly AliquotaContext context;

        public ProdutoFinanceiroRepository(AliquotaContext context)
        {
            this.context = context;
        }

        public ProdutoFinanceiro Add(ProdutoFinanceiro produtoFinanceiro)
        {
            return context.produtoFinanceiros.Add(produtoFinanceiro).Entity;
        }

        public void Update(ProdutoFinanceiro produtoFinanceiro)
        {
            context.Entry(produtoFinanceiro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public ProdutoFinanceiro GetProdutoFinanceiroById(int id)
        {
            ProdutoFinanceiro produtoFinanceiro = context.produtoFinanceiros
                                                            .Where(x => x.Id == id)
                                                            .FirstOrDefault();
            return produtoFinanceiro;
        }

        public void Remove(ProdutoFinanceiro produtoFinanceiro)
        {
            context.Remove(produtoFinanceiro);
        }
    }
}
