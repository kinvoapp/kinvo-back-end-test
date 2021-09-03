using Aliquota.Domain.Entities.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.IBusiness
{
    public interface IBusinessCrudBase<T> : IDisposable where T : class, IEntidade<int>
    {
        Task<T> Add(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task<Task> AddAll(IEnumerable<T> items);
        Task DeleteById(int id);
        Task Delete(T entity);
        Task Update(T entity);
        void Dispose();
        void Dispose(bool disposing);
        
    }
}
