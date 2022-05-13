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
using Kinvo.Aliquota.Domain.Database.Interfaces.IncomeApplications;

namespace Kinvo.Aliquota.Validators.IncomeApplications
{
    public class IncomeApplicationValidator : AbstractValidator<IncomeApplicationRequest>, IIncomeApplicationValidator
    {
        private readonly IIncomeApplicationRepository _incomeApplicationRepository;
        public IncomeApplicationValidator(IIncomeApplicationRepository incomeApplicationRepository)
        {
            _incomeApplicationRepository = incomeApplicationRepository;
        }

        private void GeneralValidator()
        {
            RuleFor(x => x.AppliedValue)
                .NotEmpty().WithMessage("Applied Value is required").NotNull().WithMessage("Applied Value is required").LessThan(1)
                .WithMessage("Applied value must be greater than 0");

            RuleFor(x => x.Product)
                .NotEmpty().WithMessage("Product is required").NotNull().WithMessage("Product is required");

            RuleFor(x => x.Client)
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

        public async Task<IncomeApplication> ValidateUuid(Guid? uuid)
        {
            if (!uuid.HasValue)
            {
                throw new ArgumentException("Uuid is required");
                return null;
            }

            var obj = await _incomeApplicationRepository.FindAsync(uuid.Value);

            return obj;

        }
    }
}
