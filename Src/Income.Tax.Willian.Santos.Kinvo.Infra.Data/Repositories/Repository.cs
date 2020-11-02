using Income.Tax.Willian.Santos.Kinvo.Infra.Data.DataContext;
using Income.Tax.Willian.Santos.Kinvo.Shared.Entities;
using Income.Tax.Willian.Santos.Kinvo.Shared.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Income.Tax.Willian.Santos.Kinvo.Infra.Data.Repositories
{
    public abstract class ApplicationITRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ApplicationITDataContext Db;
        protected readonly DbSet<TEntity> dbSet;

        public async Task Include(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChages();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChages();
        }

        public virtual async Task Remove(Guid id)
        {
            dbSet.Remove(new TEntity { Id = id });
            await SaveChages();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChages()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

    }
}
