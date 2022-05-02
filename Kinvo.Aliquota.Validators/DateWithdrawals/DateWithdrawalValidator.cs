using FluentValidation;
using Kinvo.Aliquota.Domain.Entities.DateWithdrawals;
using Kinvo.Aliquota.Models.DateWithdrawals;
using Kinvo.Aliquota.Validators.Interfaces.DateWithdrawals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Validators.DateWithdrawals
{
    public class DateWithdrawalValidator : AbstractValidator<DateWithdrawalRequest>, IDateWithdrawalValidator
    {
        public DateWithdrawalValidator()
        {
        }

        private void GeneralValidator()
        {
            RuleFor(x => x.WithdrawalValue)
                .NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Name is required");
        }

        public async Task ValidateCreation(DateWithdrawalRequest request)
        {
            GeneralValidator();
        }

        public async Task<DateWithdrawal> ValidateEdit(Guid? uuid, DateWithdrawalRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DateWithdrawal> ValidateRemove(Guid? uuid)
        {
            throw new NotImplementedException();
        }
    }
}
