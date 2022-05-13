using Kinvo.Aliquota.Domain.Entities.DateWithdrawals;
using Kinvo.Aliquota.Models.DateWithdrawals;
using Kinvo.Aliquota.Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Service.Interfaces.DateWithdrawals
{
    public interface IDateWithdrawalService : IBaseService<DateWithdrawal>
    {
        Task<DateWithdrawalResponse> Create(DateWithdrawalRequest dateWithdrawalRequest);

        Task<DateWithdrawalResponse> Edit(Guid? Uuid, DateWithdrawalRequest request);

        Task Remove(Guid? Uuid);

        Task<List<DateWithdrawalResponse>> List();
    }
}
