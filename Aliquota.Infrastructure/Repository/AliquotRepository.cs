using System.Linq;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces;
using Aliquota.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Infrastructure.Repository
{
    public class AliquotRepository : IAliquotRepository
    {
        public readonly PostgresContext _context;

        public AliquotRepository(PostgresContext context)
        {
            _context = context;
        }

        public Application GetApplication(int id)
        {
            return _context.Applications
                .Include(c => c.Client)
                .FirstOrDefault(a => a.Id == id);
        }

        public Application Apply(Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();

            return application;
        }

        public Application Withdraw(Application application)
        {
            var updateApplication = GetApplication(application.Id);
            
            _context.Applications.Attach(updateApplication);

            updateApplication.IsActive = application.IsActive;
            updateApplication.WithdrawDate = application.WithdrawDate;
            updateApplication.WithdrawValue = application.WithdrawValue;

            _context.SaveChanges();

            return updateApplication;
        }

    }
}