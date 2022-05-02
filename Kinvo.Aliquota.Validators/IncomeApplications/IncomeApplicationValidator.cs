using FluentValidation;
using Kinvo.Aliquota.Domain.Entities.IncomeApplications;
using Kinvo.Aliquota.Models.DateWithdrawals;
using Kinvo.Aliquota.Models.IncomeApplications;
using Kinvo.Aliquota.Validators.Interfaces.DateWithdrawals;
using Kinvo.Aliquota.Validators.Interfaces.IncomeApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Validators.IncomeApplications
{
    public class IncomeApplicationValidator : AbstractValidator<IncomeApplicationRequest>, IIncomeApplicationValidator
    {
        public IncomeApplicationValidator()
        {   
        }

        private void GeneralValidator()
        {
            RuleFor(x => x.AppliedValue)
                .NotEmpty().WithMessage("Applied Value is required").NotNull().WithMessage("Applied Value is required");

            RuleFor(x => x.DateWithdrawal)
                .NotEmpty().WithMessage("Date Withdrawal is required").NotNull().WithMessage("Date Withdrawal is required");

            RuleFor(x => x.DateIncomeApplication)
                .NotEmpty().WithMessage("Date Income Application is required").NotNull().WithMessage("Date Income Application is required");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product is required").NotNull().WithMessage("Product is required");

            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("Client is required").NotNull().WithMessage("Client is required");
        }

        public async Task ValidateCreation(IncomeApplicationRequest request)
        {
            GeneralValidator();
        }

        public async Task<IncomeApplication> ValidateEdit(Guid? uuid, IncomeApplicationRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IncomeApplication> ValidateRemove(Guid? uuid)
        {
            throw new NotImplementedException();
        }
    }
}
