using FluentValidation;
using System;

namespace Aliquota.Domain.Models.ViewModelsValidators
{
    public class InvestmentViewModelValidator : AbstractValidator<Investment>
    {
        public InvestmentViewModelValidator()
        {
            RuleFor(x => x.InvestmentDate).NotEmpty().WithMessage("Digite a data de investimento")
                .Must(ValidDate).WithMessage("A data de investimento não pode ser maior que hoje");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Digite o valor de investimento")
                .GreaterThan(0).WithMessage("Valor de investimento não pode ser menor ou igual a zero");
        }

        public bool ValidDate(DateTime date)
        {
            if(date.Date <= DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }
    }
}
