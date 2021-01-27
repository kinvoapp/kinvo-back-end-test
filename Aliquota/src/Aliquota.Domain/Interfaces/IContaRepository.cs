using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task<IEnumerable<Conta>> ListContasAsync();
        Task<Conta> GetContaByIdAsync(Guid id);
        Task<Conta> UpdateConta(Guid id);
    }
}
