using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Aliquota.Application.Features.FinancialProducts.Commands
{
    public class CreateFinancialProductCommandValidator : AbstractValidator<CreateFinancialProductCommand>
    {
        public CreateFinancialProductCommandValidator()
        {
            RuleFor(fp => fp.MinimalInvestedAmount)
                .NotNull().WithMessage("Minimal Invested Amount cannot be empty.")
                .GreaterThan(0).WithMessage("Minimal Invested Amount cannot be negative or zero.");
            RuleFor(fp => fp.Name)
                .NotEmpty().WithMessage("Name cannot be  empty.");
            RuleFor(fp => fp.MonthlyIncome)
                .NotEmpty().WithMessage("Monthly Income cannot be  empty.");
            RuleFor(fp => fp.Profitability)
                .IsInEnum().WithMessage("Profitability is out of range.");
            RuleFor(fp => fp.Deadline)
                .IsInEnum().WithMessage("Deadline is out of range.");
        }
    }
}
