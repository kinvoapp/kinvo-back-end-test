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

        public Application Apply(ApplicationDTO application)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Document == application.Document);
            var newApplication = new Application()
            {
                ApplicationValue = application.Value,
                Client = client,
                ClientId = client.Id,
                ApplicationDate = application.ApplicationDate,
                IsActive = true
            };
            _context.Applications.Add(newApplication);
            _context.SaveChanges();

            return newApplication;
        }

        public Application Withdraw(Application application)
        {
            var updateApplication = GetApplication(application.Id);

            _context.Applications.Attach(updateApplication);

            updateApplication = application;

            _context.SaveChanges();

            return updateApplication;
        }

    }
}