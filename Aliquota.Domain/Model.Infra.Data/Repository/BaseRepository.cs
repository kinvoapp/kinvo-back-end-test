using Model.Domain.Entities;
using Model.Domain.Interfaces;
using Model.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Model.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AliquotaDomainContext _aliquotaDomainContext;

        public BaseRepository(AliquotaDomainContext aliquotaDomainContext)
        {
            _aliquotaDomainContext = aliquotaDomainContext;
        }

        public void Insert(TEntity obj)
        {
            _aliquotaDomainContext.Set<TEntity>().Add(obj);
            _aliquotaDomainContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _aliquotaDomainContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _aliquotaDomainContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _aliquotaDomainContext.Set<TEntity>().Remove(Select(id));
            _aliquotaDomainContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _aliquotaDomainContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _aliquotaDomainContext.Set<TEntity>().Find(id);

    }
}
