using Aliquota.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interface
{
    public interface IServiceBase<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Create(TEntity obj);
        Task Update(TEntity obj);
        Task Remove(Guid id);
        Task<IEnumerable<TEntity>> GetById(Guid[] id);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> FirstOrDefault();
    }
}
