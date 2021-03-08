using Aliquota.Domain.Entities;
using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;

namespace Aliquota.Applications
{
    public class AppProdutoFinanceiro : IAppProdutoFinanceiro
    {
        private IProdutoFinanceiroRepo _repo;

        public AppProdutoFinanceiro(IProdutoFinanceiroRepo produtoFinanceiroRepo)
        {
            _repo = produtoFinanceiroRepo;
        }

        public void Adicionar(ProdutoFinanceiro produtoFinanceiro)
        {            
            _repo.Adicionar(produtoFinanceiro);
        }
        public void Atualizar(ProdutoFinanceiro produtoFinanceiro)
        {          
            _repo.Atualizar(produtoFinanceiro);
        }
        public void Excluir(ProdutoFinanceiro produtoFinanceiro)
        {
            _repo.Excluir(produtoFinanceiro);
        }
        public ProdutoFinanceiro ObterPorId(int produtoFinanceiroID)
        {
            return _repo.ObterPorId(produtoFinanceiroID);
        }
        public IList<ProdutoFinanceiro> Listar(Predicate<ProdutoFinanceiro> queryPredicate = null)
        {
            return _repo.Listar(queryPredicate);
        }        
    }
}
