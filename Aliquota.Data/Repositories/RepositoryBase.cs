using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Data.Context;
using Aliquota.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aliquota.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected AliquotaContext _context;

        public RepositoryBase(IServiceProvider pServiceProvider)
        { 
            _context = new AliquotaContext(pServiceProvider.GetRequiredService<DbContextOptions<AliquotaContext>>());
        }

        public void Add(TEntity pObj)
        {
            _context.Set<TEntity>().Add(pObj);
            _context.SaveChanges();
        }


        public void Dispose()
        {
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
 
        public TEntity GetById(int pId)
        {
            return _context.Set<TEntity>().Find(pId);
        }

        public void Remove(TEntity pObj)
        {
            _context.Set<TEntity>().Remove(pObj);
            _context.SaveChanges();
        }

        public void Update(TEntity pObj)
        {
            _context.Entry(pObj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}