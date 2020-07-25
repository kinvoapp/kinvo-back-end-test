using Aliquota.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interface.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Create(TEntity obj);
        Task Update(TEntity obj);
        Task Remove(Guid id);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FirstOrDefault();
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression);
    }
}