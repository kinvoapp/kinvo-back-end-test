using System;
using System.Collections.Generic;

namespace Aliquota.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {    
        void Add(TEntity pObj);
         TEntity GetById(int pId);
         IEnumerable<TEntity> GetAll();
         void Update(TEntity pObj);
         void Remove(TEntity pObj);
         void Dispose();

    }
}