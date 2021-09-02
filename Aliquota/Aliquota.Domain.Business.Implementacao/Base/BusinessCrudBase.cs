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

        public Task Add(T Entidade)
        {
            Task r;
            
            r = _repository.Add(Entidade);
            
            return r;
        }

        public Task AddAll(IEnumerable<T> items)
        {
            Task r;
            r = _repository.AddAll(items);
            return r;
        }
        public async Task<List<T>> GetAll()
        {
            return await _repository.AllAssync();
        }

        public Task<T> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Task DeleteById(int id)
        {
            var Entidade = _repository.GetById(id).Result;
            return Delete(Entidade);
        }

        public Task Delete(T Entidade)
        {
            Task r;
            r = _repository.Delete(Entidade);
            return r;
        }

        public Task Update(T Entidade)
        {
            Task r;
            r = _repository.Update(Entidade);
            return r;
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
