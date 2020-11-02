using Income.Tax.Willian.Santos.Kinvo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Income.Tax.Willian.Santos.Kinvo.Shared.Interfaces.Repositories
{
    public interface IRepository<TEntity>: IDisposable where TEntity: Entity
    {
        Task Include(TEntity entity);

        Task<TEntity> GetById(Guid id);

        Task<List<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task Remove(Guid id);

        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChages();
    }
}
