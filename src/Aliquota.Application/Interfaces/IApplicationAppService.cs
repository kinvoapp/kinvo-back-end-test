using Aliquota.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Application.Interfaces
{
    public interface IApplicationAppService
    {
        Task<List<ApplicationViewModel>> ListApplicationsAsync();
        Task<ApplicationViewModel> GetApplicationByIdAsync(Guid id);
    }
}
