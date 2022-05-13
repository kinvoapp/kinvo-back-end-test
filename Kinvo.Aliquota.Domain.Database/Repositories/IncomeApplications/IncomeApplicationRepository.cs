using Kinvo.Aliquota.Domain.Database.Interfaces.IncomeApplications;
using Kinvo.Aliquota.Domain.Entities.IncomeApplications;
using Kinvo.Aliquota.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Repositories.IncomeApplications
{
    public class IncomeApplicationRepository : BaseRepository<IncomeApplication>, IIncomeApplicationRepository
    {
        private readonly AppDbContext _appDbContext;

        public IncomeApplicationRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
