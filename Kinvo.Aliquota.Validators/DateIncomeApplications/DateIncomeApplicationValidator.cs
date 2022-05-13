using FluentValidation;
using Kinvo.Aliquota.Domain.Entities.DateIncomeApplications;
using Kinvo.Aliquota.Models.DateIncomeApplications;
using Kinvo.Aliquota.Validators.Interfaces.DateIncomeApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Validators.DateIncomeApplications
{
    public class DateIncomeApplicationValidator : AbstractValidator<DateIncomeApplicationRequest>, IDateIncomeApplicationValidator
    {
        public DateIncomeApplicationValidator()
        {
        }

        private void GeneralValidator()
        {
            RuleFor(x => x.AppliedValue)
                .NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Name is required");
        }

        public async Task ValidateCreation(DateIncomeApplicationRequest request)
        {
            GeneralValidator();
        }

        public async Task<DateIncomeApplication> ValidateEdit(Guid? uuid, DateIncomeApplicationRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DateIncomeApplication> ValidateRemove(Guid? uuid)
        {
            throw new NotImplementedException();
        }
    }
}
