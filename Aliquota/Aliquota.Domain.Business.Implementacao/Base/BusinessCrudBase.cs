using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Entities.Interface;
using Aliquota.Domain.Repository.IRepositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.Implementacao.Base
{
    public abstract class BusinessCrudBase<T> : IBusinessCrudBase<T>, IDisposable where T : class, IEntidade<int>
    {

        public virtual IBaseRepositorio<T> _repository { get; set; }
        private bool _disposed = false;

        protected BusinessCrudBase()
        {
        }

        public async Task<T> Add(T Entidade)
        {
            return await _repository.Add(Entidade);
        }

        public async Task<Task> AddAll(IEnumerable<T> items)
        {
            Task r;
            r = await _repository.AddAll(items);
            return r;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.AllAssync();
        }
        public List<T> GetAll()
        {
            return  _repository.All();
        }

        public Task<T> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task DeleteById(int id)
        {
            var Entidade = await _repository.GetById(id);
            await Delete(Entidade);
        }

        public async Task Delete(T Entidade)
        {
            await _repository.Delete(Entidade);
        }

        public async Task Update(T Entidade)
        {
            await _repository.Update(Entidade);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _repository = null;
            }
            _disposed = true;
        }

    }
}
