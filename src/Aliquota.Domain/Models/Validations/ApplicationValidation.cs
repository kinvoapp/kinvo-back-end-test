using FluentValidation;

namespace Aliquota.Domain.Models.Validations
{
    public class ApplicationValidation : AbstractValidator<Application>
    {
        public ApplicationValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .GreaterThan(0).WithMessage("O valor da aplicação precisa ser maior que {ComparisonValue}");

            RuleFor(p => p.WithdrawnAt)
                .GreaterThan(p => p.CreatedAt).WithMessage("A data de retirada não pode ser menor que a data de criação");
        }
    }
}
