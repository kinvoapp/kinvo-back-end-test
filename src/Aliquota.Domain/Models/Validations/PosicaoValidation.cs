using FluentValidation;

namespace Aliquota.Domain.Models.Validations
{
    public class PosicaoValidation : AbstractValidator<Posicao>
    {
        public PosicaoValidation()
        {
            RuleFor(c => c.ValorAportado)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        }
    }
}
