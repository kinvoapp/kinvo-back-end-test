using System.Collections.Generic;

namespace Aliquota.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
         void Add(TEntity pObj);
         TEntity GetById(int pId);
         IEnumerable<TEntity> GetAll();
         void Update(TEntity pObj);
         void Remove(TEntity pObj);
         void Dispose();
         
    }
}