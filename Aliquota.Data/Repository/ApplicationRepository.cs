using System;
using System.Linq;
using Aliquota.Data.Context;
using Aliquota.Data.Entity;
using Aliquota.Data.Interface;

namespace Aliquota.Data.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AliquotaContext DbContext;
        public ApplicationRepository(AliquotaContext dbContext)
        {
            DbContext = dbContext;
        }

        public Application Apply(Application application)
        {
            Application app = DbContext.Applications.Add(application).Entity;
            DbContext.SaveChanges();
            return app;
        }

        public Application Withdraw(long id, decimal withdrawValue)
        {
            Application application = DbContext.Applications.FirstOrDefault(a => a.Id == id);
            application.WithdrawValue = withdrawValue;
            application.WithdrawDate = DateTime.Now;
            DbContext.SaveChanges();
            return application;
        }

        public Application GetByCode(string code) => DbContext.Applications.FirstOrDefault(a => a.ApplicationCode == code);
    }
}