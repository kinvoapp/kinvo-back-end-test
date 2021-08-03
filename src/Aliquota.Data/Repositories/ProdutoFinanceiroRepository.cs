
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Data.Repositories
{
    public class ProdutoFinanceiroRepository : IProdutoFinanceiroRepository
    {
        private readonly AliquotaContext _context;

        public ProdutoFinanceiroRepository(AliquotaContext context)
        {
            _context = context;
        }
        public Task<List<ProdutoFinanceiro>> ObterTodos()
        {
            return _context.ProdutosFinanceiros.AsNoTracking().ToListAsync();
        }
        public async Task Adicionar(ProdutoFinanceiro produtoFinanceiro)
        {
            await _context.ProdutosFinanceiros.AddAsync(produtoFinanceiro);
        }

        public Task<ProdutoFinanceiro> ObterPeloId(Guid id)
        {
            return _context.ProdutosFinanceiros.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}