using Aliquota.Domain.Infraestrutura.DBConfig;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorios.ProdutoFinanceiroRp
{
    public class ProdutoFinanceiroRepositorio : RepositorioGenericoEF<ProdutoFinanceiro>,IProdutoFinanceiroRepositorio
    {
        public ProdutoFinanceiroRepositorio(AliquotaContexto contexto) : base(contexto){}

        public async Task<ProdutoFinanceiro> BuscaProdutoFinanceiroPor(Guid id)
        => await BuscaPorId(id);

        public async Task<IEnumerable<ProdutoFinanceiro>> BuscarTodos()
        => await Todos();

        public async Task DeletaProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro)
        => await Excluir(produtoFinanceiro);

        public async Task SalvaProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro)
        => await Incluir(produtoFinanceiro);

        public async Task AtualizaProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro)
        => await Alterar(produtoFinanceiro);

        protected override async Task<IEnumerable<ProdutoFinanceiro>> Todos()
        => await _contexto
                        .ProdutosFinanceiros
                            .Include(p=>p.TipoProdutoFinanceiro)
                                .ToListAsync();

        protected override async Task<ProdutoFinanceiro> BuscaPorId(Guid id)
        => await _contexto
                        .ProdutosFinanceiros
                            .Include(p => p.TipoProdutoFinanceiro)
                                .FirstOrDefaultAsync(p=>p.Id.Equals(id));
    }
}
