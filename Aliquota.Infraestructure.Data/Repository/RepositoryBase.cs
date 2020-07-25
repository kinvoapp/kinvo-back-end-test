using Aliquota.Domain.Entity;
using Aliquota.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aliquota.Infrastructure.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected Contexto Contexto;

        public RepositoryBase()
        {
            var builder = new DbContextOptionsBuilder<Contexto>()
                .UseSqlServer("Server=localhost;Database=Aliquota;User Id=sa;Password=root;");

            Contexto = new Contexto(builder.Options);
        }

        public virtual async Task<bool> Any(Expression<Func<TEntity, bool>> expression) =>
           await Contexto.Set<TEntity>()
            .AsNoTracking()
            .AnyAsync(expression);

        public virtual async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression) =>
            await Contexto.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(expression);

        public virtual async Task<TEntity> FirstOrDefault() =>
            await Contexto.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync();

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await Contexto.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> expression) =>
            await Contexto.Set<TEntity>()
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();

        public virtual async Task<TEntity> GetById(Guid id) =>
            await Contexto.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<int> Count(Expression<Func<TEntity, bool>> expression) =>
            await Contexto.Set<TEntity>()
            .AsNoTracking()
            .CountAsync(expression);

        public virtual async Task<TEntity> Create(TEntity obj)
        {
            var entity = (await Contexto.AddAsync(obj)).Entity;
            await Contexto.SaveChangesAsync();
            return entity;
        }

        public virtual async Task Update(TEntity obj)
        {
            Contexto.Update(obj);
            await Contexto.SaveChangesAsync();
        }

        public virtual async Task Remove(Guid id)
        {
            var entity = await GetById(id);
            Contexto.Remove(entity);
            await Contexto.SaveChangesAsync();
        }
    }
}
