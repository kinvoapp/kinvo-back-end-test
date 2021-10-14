using Aliquota.Data.Context;
using Aliquota.Data.Contratos;
using System;
using System.Threading.Tasks;

namespace Aliquota.Data.Implementações
{
    public class GeralImp : IGeralPersist
    {
        private readonly AliquotaContext context;
        public GeralImp(AliquotaContext _context)
        {
            context = _context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
