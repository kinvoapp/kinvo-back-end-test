using Aliquota.Application.Interfaces.Services.Standard;
using Aliquota.Infraestructure.Interfaces.Repositories.Standard;
using System.Collections.Generic;

namespace Aliquota.Application.Services.Standard
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual TEntity Add(TEntity obj)
        {
            return repository.Add(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public virtual TEntity GetById(object id)
        {
            return repository.GetById(id);
        }

        public virtual bool Remove(object id)
        {
            return repository.Remove(id);
        }

        public virtual void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            repository.Update(obj);
        }
    }
}
