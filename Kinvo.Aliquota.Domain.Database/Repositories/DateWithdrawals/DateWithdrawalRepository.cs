using Kinvo.Aliquota.Domain.Database.Interfaces.DateWithdrawals;
using Kinvo.Aliquota.Domain.Entities.DateWithdrawals;
using Kinvo.Aliquota.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Repositories.DateWithdrawals
{
    public class DateWithdrawalRepository : BaseRepository<DateWithdrawal>, IDateWithdrawalRepository
    {
        private readonly AppDbContext _appDbContext;

        public DateWithdrawalRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
