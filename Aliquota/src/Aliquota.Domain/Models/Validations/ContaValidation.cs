using FluentValidation;

namespace Aliquota.Domain.Models.Validations
{
    public class ContaValidation : AbstractValidator<Conta>
    {
        public ContaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.ValorAplicacao)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .GreaterThan(0).WithMessage("O valor da aplicação precisa ser maior que {ComparisonValue}");

            RuleFor(p => p.DtResgate)
                .GreaterThan(p => p.DtAplicacao).WithMessage("A data de retirada não pode ser menor que a data de criação");
        }
    }
}
