using Microsoft.EntityFrameworkCore;
using Aliquota.Data.Context;
using Aliquota.Domain.Models;
using Aliquota.Domain.Interfaces;

namespace Aliquota.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AliquotaDbContext context) : base(context) { }

        public async Task<Produto> ObterPosicoesProduto(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                .Include(c => c.Posicoes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Produto> ObterPosicoesAtivasProduto(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                .Include(c => c.Posicoes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
