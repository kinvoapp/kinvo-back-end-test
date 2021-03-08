using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Infrastructure.DBContext;
using Aliquota.Domain.Entities;

namespace Aliquota.Infrastructure
{
    public class ProdutoFinanceiroRepository : IProdutoFinanceiroRepo
    {
        private AliquotaDBContext _dbContext = null;
        public ProdutoFinanceiroRepository(AliquotaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Adicionar(ProdutoFinanceiro entity)
        {
            _dbContext.ProdutoFinanceiro.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Excluir(ProdutoFinanceiro entity)
        {
            _dbContext.ProdutoFinanceiro.Remove(entity);
            _dbContext.SaveChanges();
        }

        public ProdutoFinanceiro ObterPorId(int Id)
        {
            return (ProdutoFinanceiro)_dbContext.ProdutoFinanceiro.Find(Id);
        }

        public IList<ProdutoFinanceiro> Listar(Predicate<ProdutoFinanceiro> queryPredicate = null)
        {
            return _dbContext.ProdutoFinanceiro.Where(x => queryPredicate(x)).ToList();
        }

        public void Atualizar(ProdutoFinanceiro entity)
        {
            _dbContext.ProdutoFinanceiro.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
