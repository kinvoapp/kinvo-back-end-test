using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceGenericApp<T> where T : class
    {
        Task Add(T Objeto);

        Task Delete(T Objeto);

        Task<T> GetEntityById(int Id);

        Task<List<T>> List();
    }
}
