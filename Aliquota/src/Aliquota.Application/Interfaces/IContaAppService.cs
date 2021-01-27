using Aliquota.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Application.Interfaces
{
    public interface IContaAppService
    {
        Task<IEnumerable<ContaViewModel>> ListContasAsync();
        Task<ContaViewModel> GetContaByIdAsync(Guid id);
    }
}
