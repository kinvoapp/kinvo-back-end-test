using FluentValidation;

namespace Aliquota.Domain.Models.Validations
{
    public class AplicacaoValidation : AbstractValidator<Aplicacao>
    {
        public AplicacaoValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(4, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.ValorAplicado)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .GreaterThan(0).WithMessage("O valor da aplicado precisa ser maior que {ComparisonValue}");

            RuleFor(p => p.DataRetirada)
                .GreaterThan(p => p.DataAplicacao).WithMessage("A data de retirada não pode ser menor que a data da aplicação");
        }
    }
}
