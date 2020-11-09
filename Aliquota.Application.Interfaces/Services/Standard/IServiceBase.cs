using System.Collections.Generic;

namespace Aliquota.Application.Interfaces.Services.Standard
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);

        TEntity Add(TEntity obj);
        void Update(TEntity obj);

        bool Remove(object id);
        void Remove(TEntity obj);
    }
}
