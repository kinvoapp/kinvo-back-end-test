using Aliquota.Domain.ProdutoModule;
using Aliquota.Domain.Shared;
using Aliquota.Infrastructure.Shared;

namespace Aliquota.Infrastructure.Modules
{
    public class ProdutoORM : RepositoryBase<Produto>, IRepository<Produto>
    {
        public ProdutoORM(AliquotaDBContext db) : base(db)
        {
        }
    }
}
