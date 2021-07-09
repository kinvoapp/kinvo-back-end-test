using System.Collections;
using System.Linq;

using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces;
using Aliquota.Infrastructure.Context;

namespace Aliquota.Infrastructure.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        public readonly PostgresContext _context;

        public ApplicationRepository(PostgresContext context)
        {
            _context = context;
        }

        public Application GetApplication(int id)
        {
            return _context.Applications.FirstOrDefault(a => a.Id == id);
        }
        
        public Application Apply(Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();

            return application;
        }

        public Application Withdraw(Application application)
        {
            _context.Applications.Attach(application);
            _context.SaveChanges();

            return application;
        }
    }
}