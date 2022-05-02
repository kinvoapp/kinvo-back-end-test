using Kinvo.Aliquota.Domain.Entities.IncomeApplications;
using Kinvo.Aliquota.Models.IncomeApplications;
using Kinvo.Aliquota.Validators.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Validators.Interfaces.IncomeApplications
{
    public interface IIncomeApplicationValidator : IBaseValidator<IncomeApplication, IncomeApplicationRequest>
    {
    }
}
