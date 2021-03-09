using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Infrastructure.DBContext;
using Aliquota.Domain.Entities;
using System.Threading.Tasks;

namespace Aliquota.Infrastructure
{
    public class ProdutoFinanceiroRepository : IProdutoFinanceiroRepo
    {
        private AliquotaDBContext _dbContext = null;
        public ProdutoFinanceiroRepository(AliquotaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Adicionar(ProdutoFinanceiro entity)
        {
            _dbContext.ProdutoFinanceiro.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Excluir(ProdutoFinanceiro entity)
        {
            _dbContext.ProdutoFinanceiro.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProdutoFinanceiro> ObterPorId(int Id)
        {
            return (ProdutoFinanceiro) await _dbContext.ProdutoFinanceiro.FindAsync(Id);
        }

        public async Task<IList<ProdutoFinanceiro>> Listar(Predicate<ProdutoFinanceiro> queryPredicate = null)
        {
            if (queryPredicate == null)
                return _dbContext.ProdutoFinanceiro.ToList();

            return _dbContext.ProdutoFinanceiro.Where(x => queryPredicate(x)).ToList();
        }

        public async Task Atualizar(ProdutoFinanceiro entity)
        {
            _dbContext.ProdutoFinanceiro.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
