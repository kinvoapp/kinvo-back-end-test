using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidator>(TEntity obj);

        void Delete(int id);

        IList<TEntity> Get();

        TEntity GetById(int id);

        TEntity Update(TEntity obj);
    }
}
