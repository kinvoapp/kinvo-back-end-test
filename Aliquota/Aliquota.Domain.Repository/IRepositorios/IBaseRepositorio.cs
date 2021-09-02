using Aliquota.Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repository.IRepositorios
{
    public interface IBaseRepositorio<T> : IDisposable where T : class, IEntidade<int>
    {
        Task<Task> Add(T entity);
        Task<List<T>> AllAssync();
        Task AddAll(IEnumerable<T> entities);
        Task<Task> AddAllAsync(IEnumerable<T> entities);
        Task DeleteAll(IEnumerable<T> entities);
        Task<Task> DeleteAllAsync(IEnumerable<T> entities);
        Task<Task> UpdateAll(IEnumerable<T> entities);
        Task Delete(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        IQueryable<T> GetQueryable();
        Task Update(T entity);
    }
}
