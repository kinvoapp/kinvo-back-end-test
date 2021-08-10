using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Aliquota.Application.Features.FinancialProducts.Commands
{
    public class DeleteFinancialProductCommandValidator : AbstractValidator<DeleteFinancialProductCommand>
    {
        public DeleteFinancialProductCommandValidator()
        {
            RuleFor(fp => fp.Id)
                .NotEmpty().WithMessage("Id cannot be empty.");
        }
    }
}