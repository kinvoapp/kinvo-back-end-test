using FluentValidation;
using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Service.Validators
{
    public class RescueValidator : AbstractValidator<Investment>
    {
        public RescueValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("There is no active investment for this user account.")
                .NotNull().WithMessage("There is no active investment for this user account.");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("There is no active investment for this user account.")
                .NotNull().WithMessage("There is no active investment for this user account.")
                .Equal(c => c.Cpf).WithMessage("This investment does not belongs to this user account.");

            RuleFor(c => c.Capital)
                .NotEmpty().WithMessage("Please enter the amount that is going to be rescued.")
                .NotNull().WithMessage("Please enter the amount that is going to be rescued.")
                .GreaterThan(Investment => Investment.Capital).WithMessage("Please enter a value less than or equals to the amount invested.");

            RuleFor(i => i.InvestmentDayZero)
                .LessThan(i => DateTime.Now).WithMessage("The rescue date has to be newer than today's date.");
        }
    }
}
