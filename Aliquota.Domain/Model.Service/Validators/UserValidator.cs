using FluentValidation;
using Model.Domain.Entities;

namespace Model.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Please enter the cpf.")
                .NotNull().WithMessage("Please enter the cpf.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Please enter the email.")
                .NotNull().WithMessage("Please enter the email.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Please enter the password.")
                .NotNull().WithMessage("Please enter the password.");

            RuleFor(c => c.Capital)
                .NotEmpty().WithMessage("Please enter the amount invested.")
                .NotNull().WithMessage("Please enter the amount invested.");
        }
    }
}
