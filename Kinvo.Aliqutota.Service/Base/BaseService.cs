using FluentValidation;
using Kinvo.Aliquota.Domain.Database.Interfaces.BaseRepository;
using Kinvo.Aliquota.Domain.Entities.DefaultEntities;
using Kinvo.Aliquota.Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliqutota.Service.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : DefaultEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<TEntity> Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public IList<TEntity> Get() => _baseRepository.Select();

        public TEntity GetById(int id) => _baseRepository.Select(id);

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não Econtrados");

            validator.ValidateAndThrow(obj);
        }
    }
}
