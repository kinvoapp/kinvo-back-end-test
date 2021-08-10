using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aliquota.Application.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Validators;

namespace Aliquota.Application.Features.Investments.Commands
{
    public class CreateInvestmentCommandValidator : AbstractValidator<CreateInvestmentCommand>
    {
        private readonly IFinancialProductRepository _financialProductRepository;

        public CreateInvestmentCommandValidator(IFinancialProductRepository financialProductRepository)
        {
            _financialProductRepository = financialProductRepository;

            RuleFor(inv => inv.FinancialProductId)
                .NotEmpty().WithMessage("FinancialProductId cannot be empty.");

            RuleFor(inv => inv.Amount)
                .MustAsync(async (command, amount, cancel) =>
                {
                    var fp = await _financialProductRepository.GetByIdAsync(command.FinancialProductId);
                    return fp?.MinimalInvestedAmount <= amount;
                }).WithMessage(
                    "Amount should be Equal or greater than Minimal Invested Amount from Financial Product.");

            RuleFor(inv => inv.Start)
                .NotEmpty().WithMessage("Invalid start date.");
        }
    }
}