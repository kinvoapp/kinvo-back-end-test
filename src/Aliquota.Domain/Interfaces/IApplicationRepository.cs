using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces
{
    public interface IApplicationRepository
    {
        Task<List<Application>> ListApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(Guid id);
        void AddApplication(Application application);
    }
}
