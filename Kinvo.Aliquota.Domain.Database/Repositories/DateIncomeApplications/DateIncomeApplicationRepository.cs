using Kinvo.Aliquota.Domain.Database.Interfaces.DateIncomeApplications;
using Kinvo.Aliquota.Domain.Entities.DateIncomeApplications;
using Kinvo.Aliquota.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Repositories.DateIncomeApplications
{
    public class DateIncomeApplicationRepository : BaseRepository<DateIncomeApplication>, IDateIncomeApplicationRepository
    {
        private readonly AppDbContext _appDbContext;

        public DateIncomeApplicationRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
