using System;
using System.Collections.Generic;

namespace Aliquota.Infraestructure.Interfaces.Repositories.Standard
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);

        TEntity Add(TEntity obj);
        int Update(TEntity obj);

        bool Remove(object id);
        int Remove(TEntity obj);
    }
}
