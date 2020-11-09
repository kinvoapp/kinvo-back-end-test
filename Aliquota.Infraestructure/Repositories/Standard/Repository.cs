using Aliquota.Infraestructure.Interfaces.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Aliquota.Infraestructure.Repositories.Standard
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        protected Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual TEntity Add(TEntity obj)
        {
            var r = dbSet.Add(obj);
            Commit();
            return r.Entity;
        }

        public virtual int Update(TEntity obj)
        {
            dbContext.Entry(obj).State = EntityState.Modified;
            return Commit();
        }

        public virtual bool Remove(object id)
        {
            TEntity entity = GetById(id);

            if (entity == null) return false;

            return Remove(entity) > 0;
        }

        public virtual int Remove(TEntity obj)
        {
            dbSet.Remove(obj);
            return Commit();
        }

        private int Commit()
        {
            return dbContext.SaveChanges();
        }
    }
}
