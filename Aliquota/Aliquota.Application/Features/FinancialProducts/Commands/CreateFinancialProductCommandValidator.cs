using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Aliquota.Application.Interfaces.Repositories;
using FluentValidation;

namespace Aliquota.Application.Features.FinancialProducts.Commands
{
    public class CreateFinancialProductCommandValidator : AbstractValidator<CreateFinancialProductCommand>
    {
        public CreateFinancialProductCommandValidator(IFinancialProductRepository financialProductRepository)
        {
            RuleFor(fp => fp.MinimalInvestedAmount)
                .NotNull()
                .WithMessage("Minimal Invested Amount cannot be empty.")
                .GreaterThan(0)
                .WithMessage("Minimal Invested Amount cannot be negative or zero.");
            RuleFor(fp => fp.Name)
                .NotEmpty()
                .WithMessage("Name cannot be  empty.")
                .MustAsync((command, name, cancellationToken) => financialProductRepository.IsNameUnique(name))
                .WithMessage("Name should be unique, name already registered.");
            RuleFor(fp => fp.MonthlyIncome)
                .NotEmpty()
                .WithMessage("Monthly Income cannot be  empty.");
            RuleFor(fp => fp.Profitability)
                .IsInEnum()
                .WithMessage("Profitability is out of range.");
            RuleFor(fp => fp.Deadline)
                .IsInEnum()
                .WithMessage("Deadline is out of range.");
        }
    }
}