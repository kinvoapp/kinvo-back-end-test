using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces;
using Aliquota.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly PersistContext persistContext;

        public BaseRepository(PersistContext mySqlContext)
        {
            persistContext = mySqlContext;
        }

        public void Insert(TEntity obj)
        {
            persistContext.Set<TEntity>().Add(obj);
            persistContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            persistContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            persistContext.SaveChanges();
        }

        public void Delete(int id)
        {
            persistContext.Set<TEntity>().Remove(Select(id));
            persistContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            persistContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            persistContext.Set<TEntity>().Find(id);

    }
}
