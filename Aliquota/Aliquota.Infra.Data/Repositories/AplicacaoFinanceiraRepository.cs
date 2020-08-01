using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces;
using Aliquota.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Infra.Data.Repositories
{
    public class AplicacaoFinanceiraRepository : IDisposable, IAplicacaoFinanceiraRepository
    {
        protected AliquotaContext _context;

        public AplicacaoFinanceiraRepository(IServiceProvider serviceProvider)
        {
            _context = new AliquotaContext(serviceProvider.GetRequiredService<DbContextOptions<AliquotaContext>>());
        }

        public void Add(AplicacaoFinanceira obj)
        {
            _context.Set<AplicacaoFinanceira>().Add(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AplicacaoFinanceira> GetAll()
        {
            return _context.Set<AplicacaoFinanceira>().ToList();
        }

        public AplicacaoFinanceira GetById(int id)
        {
            return _context.Set<AplicacaoFinanceira>().Find(id);
        }

        public void Remove(AplicacaoFinanceira obj)
        {
            _context.Set<AplicacaoFinanceira>().Remove(obj);
            _context.SaveChanges();
        }

        public void Update(AplicacaoFinanceira obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
