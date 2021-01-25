using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;
using Aliquota.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Infra.Data.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AliquotaContext _context;
        public ApplicationRepository(AliquotaContext context)
        {
            _context = context;
        }
        public async Task<List<Application>> ListApplicationsAsync()
        {
            return await _context.Applications.AsNoTracking().ToListAsync();
        }

        public async Task<Application> GetApplicationByIdAsync(Guid id)
        {
            return await _context.Applications.AsNoTracking().FirstAsync(e => e.Id == id);
        }

        public void AddApplication(Application application)
        {
            _context.Applications.Add(application);
        }
    }
}
