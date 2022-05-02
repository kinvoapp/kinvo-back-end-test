using Kinvo.Aliquota.Domain.Database.Interfaces.BaseRepository;
using Kinvo.Aliquota.Domain.Entities.IncomeApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Database.Interfaces.IncomeApplications
{
    public interface IIncomeApplicationRepository : IBaseRepository<IncomeApplication>
    {
    }
}
