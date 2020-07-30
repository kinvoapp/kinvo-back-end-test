using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Interfaces.IRepositories;
using src.Models;

namespace src.Repositories
{
    /// <summary>
    /// Classe de base para os repositories usados na aplicação
    /// </summary>
    /// <typeparam name="TEntity">Tipo de Entidade que herdará os métodos</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public virtual async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstAsync(predicate);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual List<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<TEntity> FindAsync(params object[] keys)
        {
            return await _dbSet.FindAsync(keys);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(params object[] keys)
        {
            var entity = _dbSet.Find(keys);
            _dbSet.Remove(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var existing = await _dbSet.FindAsync(entity);
            if (existing != null)
            { 
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.Entry(existing).Property("AddedDate").IsModified = false;
            }
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
