using FluentValidation;
using Model.Domain.Entities;

namespace Model.Service.Validators
{
    public class InvestmentValidator : AbstractValidator<Investment>
    {
        public InvestmentValidator()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Please enter the cpf.")
                .NotNull().WithMessage("Please enter the cpf.");

            RuleFor(c => c.Capital)
                .NotEmpty().WithMessage("Please enter the amount that is going to be invested.")
                .NotNull().WithMessage("Please enter the amount that is going to be invested.")
                .LessThan(0).WithMessage("Please enter a valid (positive) value.");
        }
    }
}
