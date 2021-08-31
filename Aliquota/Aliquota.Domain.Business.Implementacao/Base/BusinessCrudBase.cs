using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Business.Validation;
using Aliquota.Domain.Entities.Interface;
using Aliquota.Domain.Repository.Implementacao.Context;
using Aliquota.Domain.Repository.IRepositorios;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.Implementacao.Base
{
    public abstract class BusinessCrudBase<T> : IBusinessCrudBase<T>, IDisposable where T : class, IEntidade<int>
    {

        public virtual IValidation<T> Validator { get; set; }
        public virtual IBaseRepositorio<T> _repository { get; set; }
        private bool _disposed = false;

        protected BusinessCrudBase()
        {
        }

        public Task Add(T Entidade)
        {
            Task r;
            if (Validator.GetRules(ValidationEnum.Insercao).Count() > 0)
            {
                var testaEntidade = Validator.Validate(Entidade, ValidationEnum.Insercao);
                if (testaEntidade.IsValid)
                {
                    r = _repository.Add(Entidade);
                }
                else
                {
                    throw new Exception(testaEntidade.ToString());
                }
            }
            else
            {
                r = _repository.Add(Entidade);
            }
            return r;
        }

        public Task AddAll(IEnumerable<T> items)
        {
            Task r;
            if (Validator.GetRules(ValidationEnum.Insercao).Any())
            {
                var todosValidos = true;
                foreach (var e in items)
                {
                    var testaEntidade = Validator.Validate(e,ValidationEnum.Insercao);
                    if (!testaEntidade.IsValid)
                    {
                        todosValidos = false;
                        break;
                    }
                }
                if (todosValidos)
                {
                    r = _repository.AddAll(items);
                }
                else
                {
                    r = Task.CompletedTask;
                }
            }
            else
            {
                r = _repository.AddAll(items);
            }
            return r;
        }

        public Task DeleteById(object id)
        {
            var Entidade = _repository.GetById(id).Result;
            return Delete(Entidade);
        }

        public Task Delete(T Entidade)
        {
            Task r;
            if (Validator.GetRules(ValidationEnum.Delecao).Count() > 0)
            {
                var testaEntidade = Validator.Validate(Entidade, ValidationEnum.Delecao);
                if (testaEntidade.IsValid)
                {
                    r = _repository.Delete(Entidade);
                }
                else
                {

                    r = Task.CompletedTask;
                }
            }
            else
            {
                r = _repository.Delete(Entidade);
            }
            return r;
        }

        public Task Update(T Entidade)
        {
            Task r;
            if (Validator.GetRules(ValidationEnum.Atualizacao).Count() > 0)
            {
                var testaEntidade = Validator.Validate(Entidade, ValidationEnum.Atualizacao);
                if (testaEntidade.IsValid)
                {
                    r = _repository.Update(Entidade);
                }
                else
                {

                    r = Task.CompletedTask;
                }
            }
            else
            {
                r = _repository.Update(Entidade);
            }
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
