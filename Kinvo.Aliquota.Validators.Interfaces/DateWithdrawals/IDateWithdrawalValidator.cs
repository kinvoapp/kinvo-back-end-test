using Kinvo.Aliquota.Domain.Entities.DateWithdrawals;
using Kinvo.Aliquota.Models.DateWithdrawals;
using Kinvo.Aliquota.Validators.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Validators.Interfaces.DateWithdrawals
{
    public interface IDateWithdrawalValidator : IBaseValidator<DateWithdrawal, DateWithdrawalRequest>
    {
    }
}
