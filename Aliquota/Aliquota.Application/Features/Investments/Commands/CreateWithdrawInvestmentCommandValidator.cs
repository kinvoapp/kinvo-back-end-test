using Aliquota.Application.Interfaces.Repositories;
using FluentValidation;

namespace Aliquota.Application.Features.Investments.Commands
{
    public class CreateWithdrawInvestmentCommandValidator : AbstractValidator<CreateWithdrawInvestmentCommand>
    {
        private readonly IInvestmentRepository _investmentRepository;
        public CreateWithdrawInvestmentCommandValidator(IInvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;

            RuleFor(inv => inv.WithdrawDate)
                .MustAsync(async (command, withdrawDate, cancel) => 
                {
                    var investment = await _investmentRepository.GetByIdAsync(command.Id);
                    return withdrawDate > investment.Start;
                }).WithMessage("Withdraw date cannot be before Investment start date.");

            RuleFor(inv => inv.Id)
                .NotEmpty().WithMessage("Investment Id cannot be empty.");
        }

    }
}
