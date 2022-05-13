using Kinvo.Aliquota.Domain.Entities.DateIncomeApplications;
using Kinvo.Aliquota.Models.DateIncomeApplications;
using Kinvo.Aliquota.Validators.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Validators.Interfaces.DateIncomeApplications
{
    public interface IDateIncomeApplicationValidator : IBaseValidator<DateIncomeApplication, DateIncomeApplicationRequest>
    {
    }
}
