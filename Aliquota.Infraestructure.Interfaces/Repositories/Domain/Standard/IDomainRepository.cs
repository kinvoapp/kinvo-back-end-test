using Aliquota.Domain.Entities;
using Aliquota.Infraestructure.Interfaces.Repositories.Standard;

namespace Aliquota.Infraestructure.Interfaces.Repositories.Domain.Standard
{
    public interface IDomainRepository<TEntity> : IRepository<TEntity> where TEntity : class { }
}
