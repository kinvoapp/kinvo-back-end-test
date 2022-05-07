using Aliquota.Data.Context;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

