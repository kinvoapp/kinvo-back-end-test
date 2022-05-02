using Kinvo.Aliquota.Domain.Entities.DefaultEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Database.Interfaces.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : DefaultEntity
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(long id);

        IList<TEntity> Select();

        TEntity Select(long id);

        Task<TEntity> FindAsync(Guid uuid,
            params Expression<Func<TEntity, object>>[] includes);

        Task<List<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] includes);
    }
}
