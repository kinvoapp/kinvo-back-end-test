using Aliquota.Domain.Entity;
using Aliquota.Domain.Interface;
using Aliquota.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        protected readonly IRepositoryBase<TEntity> Repository;

        public ServiceBase(IRepositoryBase<TEntity> repositorio) => Repository = repositorio;

        public virtual async Task<TEntity> FirstOrDefault() =>
            await Repository.FirstOrDefault();

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await Repository.GetAll();

        public virtual async Task<TEntity> GetById(Guid id) =>
            await Repository.GetById(id);

        public virtual async Task<TEntity> Create(TEntity obj) =>
            await Repository.Create(obj);

        public virtual async Task Remove(Guid id) =>
            await Repository.Remove(id);

        public virtual async Task Update(TEntity obj) =>
            await Repository.Update(obj);

        public async Task<IEnumerable<TEntity>> GetById(Guid[] id) =>
            await Repository.Get(e => id.Contains(e.Id));
    }
}
