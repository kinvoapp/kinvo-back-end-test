using Microsoft.EntityFrameworkCore;
using Aliquota.Data.Context;
using Aliquota.Domain.Models;
using Aliquota.Domain.Interfaces;

namespace Aliquota.Data.Repository
{
    public class PosicaoRepository : Repository<Posicao>, IPosicaoRepository
    {
        public PosicaoRepository(AliquotaDbContext context) : base(context) { }

        public async Task<IEnumerable<Posicao>> ObterPosicoesPorProduto(Guid produtoId)
        {
            return await Buscar(p => p.ProdutoId == produtoId);
        }

        public async Task<Posicao> ObterProdutoPosicao(Guid id)
        {
            return await Db.Posicoes.AsNoTracking()
                //.Include(p => p.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
