using Aliquota.Domain.Entities;
using Aliquota.Domain.IRepos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Applications
{
    public class AppProdutoFinanceiro : IAppProdutoFinanceiro
    {
        private IProdutoFinanceiroRepo _repo;

        public AppProdutoFinanceiro(IProdutoFinanceiroRepo produtoFinanceiroRepo)
        {
            _repo = produtoFinanceiroRepo;
        }

        public async Task Adicionar(ProdutoFinanceiro produtoFinanceiro)
        {
            await _repo.Adicionar(produtoFinanceiro);
        }
        public async Task Atualizar(ProdutoFinanceiro produtoFinanceiro)
        {
            await _repo.Atualizar(produtoFinanceiro);
        }
        public async Task Excluir(ProdutoFinanceiro produtoFinanceiro)
        {
            await _repo.Excluir(produtoFinanceiro);
        }
        public async Task<ProdutoFinanceiro> ObterPorId(int produtoFinanceiroID)
        {
            return await _repo.ObterPorId(produtoFinanceiroID);
        }
        public async Task<IList<ProdutoFinanceiro>> Listar(Predicate<ProdutoFinanceiro> queryPredicate = null)
        {
            return await _repo.Listar(queryPredicate);
        }        
    }
}
