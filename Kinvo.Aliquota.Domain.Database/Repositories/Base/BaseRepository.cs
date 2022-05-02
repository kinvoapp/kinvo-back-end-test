using Kinvo.Aliquota.Domain.Database.Interfaces.BaseRepository;
using Kinvo.Aliquota.Domain.Entities.DefaultEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : DefaultEntity
    {
        protected readonly AppDbContext _appDbContext;
        private readonly DbContext _dbContext;

        protected virtual IQueryable<TEntity> DbSet => (IQueryable<TEntity>)this._appDbContext.Set<TEntity>();

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Insert(TEntity obj)
        {
            _appDbContext.Set<TEntity>().Add(obj);
            _appDbContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _appDbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            _appDbContext.Set<TEntity>().Remove(Select(id));
            _appDbContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _appDbContext.Set<TEntity>().ToList();

        public TEntity Select(long id) =>
            _appDbContext.Set<TEntity>().Find(id);

        public async Task<TEntity> FindAsync(Guid uuid, params Expression<Func<TEntity, object>>[] includes)
        {
            return await((IEnumerable<Expression<Func<TEntity, object>>>)includes).Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(this.DbSet, (Func<IQueryable<TEntity>, Expression<Func<TEntity, object>>, IQueryable<TEntity>>)((current, inc) => (IQueryable<TEntity>)current.Include<TEntity, object>(inc))).FirstOrDefaultAsync<TEntity>((Expression<Func<TEntity, bool>>)(x => x.Uuid == uuid));
        }

        public async Task<List<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return await ((IEnumerable<Expression<Func<TEntity, object>>>)includes).Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(this.DbSet, (Func<IQueryable<TEntity>, Expression<Func<TEntity, object>>, IQueryable<TEntity>>)((current, inc) => (IQueryable<TEntity>)current.Include<TEntity, object>(inc))).ToListAsync();
        }
    }
}
