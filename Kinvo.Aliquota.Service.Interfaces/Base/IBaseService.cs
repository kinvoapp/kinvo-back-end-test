using FluentValidation;
using Kinvo.Aliquota.Domain.Entities.DefaultEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Service.Interfaces.Base
{
    public interface IBaseService<TEntity> where TEntity : DefaultEntity
    {
        Task<TEntity> Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Delete(int id);

        IList<TEntity> Get();

        TEntity GetById(int id);

        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
