using System;
using System.Threading.Tasks;
using Aliquota.Core.DomainObjects;

namespace Aliquota.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        Task<bool> SaveChangesAsync();
    }
}