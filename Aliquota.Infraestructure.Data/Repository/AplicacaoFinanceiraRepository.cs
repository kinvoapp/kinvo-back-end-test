using Aliquota.Domain.Entity;
using Aliquota.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Infrastructure.Data.Repository
{
    public class AplicacaoFinanceiraRepository : RepositoryBase<AplicacaoFinanceira>, IAplicacaoFinanceiraRepository
    {
        public override async Task<AplicacaoFinanceira> GetById(Guid id) =>
            await Contexto.Set<AplicacaoFinanceira>()
            .Include(x => x.Cliente)
            .Include(x => x.Produto)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}
