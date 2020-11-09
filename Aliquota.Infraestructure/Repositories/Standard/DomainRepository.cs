using Aliquota.Infraestructure.Interfaces.Repositories.Domain.Standard;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Infraestructure.Repositories.Standard
{
    public class DomainRepository<TEntity> : Repository<TEntity>, IDomainRepository<TEntity> where TEntity : class
    {
        protected DomainRepository(DbContext dbContext) : base(dbContext) { }
    }
}
