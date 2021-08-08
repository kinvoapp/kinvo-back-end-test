using Aliquota.Domain.Infraestrutura.DBConfig;
using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorios.TipoProdutoFinanceiroRp
{
    public class TipoProdutoFinanceiroRepositorio : RepositorioGenericoEF<TipoProdutoFinanceiro>, ITipoProdutoFinanceiroRepositorio
    {
        public TipoProdutoFinanceiroRepositorio(AliquotaContexto contexto) : base(contexto) { }

        public async Task AtualizaTipoProdutoFinanceiro(TipoProdutoFinanceiro tipoProdutoFinanceiro)
        => await Alterar(tipoProdutoFinanceiro);

        public async Task<TipoProdutoFinanceiro> BuscaTipoProdutoFinanceiroPor(Guid id)
        => await BuscaPorId(id);

        public async Task<IEnumerable<TipoProdutoFinanceiro>> BuscarTodos()
        => await Todos();

        public async Task DeletaTipoProdutoFinanceiro(TipoProdutoFinanceiro tipoProdutoFinanceiro)
        => await Excluir(tipoProdutoFinanceiro);

        public async Task SalvaTipoProdutoFinanceiro(TipoProdutoFinanceiro tipoProdutoFinanceiro)
        => await Incluir(tipoProdutoFinanceiro);
    }
}
