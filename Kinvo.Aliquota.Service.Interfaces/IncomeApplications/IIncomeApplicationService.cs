using Kinvo.Aliquota.Domain.Entities.IncomeApplications;
using Kinvo.Aliquota.Models.IncomeApplications;
using Kinvo.Aliquota.Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Service.Interfaces.IncomeApplications
{
    public interface IIncomeApplicationService : IBaseService<IncomeApplication>
    {
        Task<IncomeApplicationResponse> Create(IncomeApplicationRequest incomeApplicationRequest);

        Task<IncomeApplicationResponse> Edit(Guid? Uuid, IncomeApplicationRequest request);

        Task Remove(Guid? Uuid);

        Task<List<IncomeApplicationResponse>> List();
    }
}
