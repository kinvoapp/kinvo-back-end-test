using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Negocio.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<T> Find(Guid id);
        Task<IEnumerable<T>> List();
        void Add(T item);
        void Remove(T item);
        void Edit(T item);
    }
}
