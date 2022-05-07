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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AliquotaDbContext context) : base(context) { } 

        public async Task<Produto> ObterPosicoesProduto(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                .Include(c => c.Posicoes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        //Todo
        public async Task<Produto> ObterPosicoesAtivasProduto(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                .Include(c => c.Posicoes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
