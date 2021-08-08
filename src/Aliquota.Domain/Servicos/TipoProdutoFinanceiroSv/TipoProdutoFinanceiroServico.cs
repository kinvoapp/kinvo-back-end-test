using Aliquota.Domain.Models;
using Aliquota.Domain.Repositorios.TipoProdutoFinanceiroRp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Servicos.TipoProdutoFinanceiroSv
{
    public class TipoProdutoFinanceiroServico : ITipoProdutoFinanceiroServico
    {
        private ITipoProdutoFinanceiroRepositorio _tipoProdutoFinanceiroRepositorio;

        public TipoProdutoFinanceiroServico(ITipoProdutoFinanceiroRepositorio tipoProdutoFinanceiroRepositorio)
        {
            _tipoProdutoFinanceiroRepositorio = tipoProdutoFinanceiroRepositorio;
        }

        public async Task<TipoProdutoFinanceiro> BuscaTipoProdutoFinanceiroPor(Guid id)
        => await _tipoProdutoFinanceiroRepositorio.BuscaTipoProdutoFinanceiroPor(id);

        public async Task<IEnumerable<TipoProdutoFinanceiro>> BuscarTodos()
        => await _tipoProdutoFinanceiroRepositorio.BuscarTodos();

        public async Task CadastraTipoProdutoFinanceiro(TipoProdutoFinanceiro tipoProdutoFinanceiro)
        => await _tipoProdutoFinanceiroRepositorio.SalvaTipoProdutoFinanceiro(tipoProdutoFinanceiro);

        public async Task DeletaTipoProdutoFinanceiro(TipoProdutoFinanceiro tipoProdutoFinanceiro)
        => await _tipoProdutoFinanceiroRepositorio.DeletaTipoProdutoFinanceiro(tipoProdutoFinanceiro);

        public async Task AlteraTipoProdutoServico(TipoProdutoFinanceiro tipoProdutoFinanceiro)
        => await _tipoProdutoFinanceiroRepositorio.AtualizaTipoProdutoFinanceiro(tipoProdutoFinanceiro);
    }
}
