using Kinvo.Aliquota.Domain.Entities.DateIncomeApplications;
using Kinvo.Aliquota.Models.DateIncomeApplications;
using Kinvo.Aliquota.Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Service.Interfaces.DateIncomeApplications
{
    public interface IDateIncomeApplicationService : IBaseService<DateIncomeApplication>
    {
        Task<DateIncomeApplicationResponse> Create(DateIncomeApplicationRequest dateIncomeApplicationRequest);

        Task<DateIncomeApplicationResponse> Edit(Guid? Uuid, DateIncomeApplicationRequest request);

        Task Remove(Guid? Uuid);

        Task<List<DateIncomeApplicationResponse>> List();
    }
}
