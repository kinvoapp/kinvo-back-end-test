using Aliquota.Domain.Business.Validation;
using Aliquota.Domain.Entities.Entidades;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;

namespace Aliquota.Domain.Business.Implementacao.Validators
{
    public class TipoProdutoValidator : Validator<TipoProduto>
    {
        public TipoProdutoValidator()
        {
            RuleSet(ValidationEnum.Insercao, () =>
            {
                RuleFor(obj => obj.IdTipoProduto).NotEmpty();
            });

            RuleSet(ValidationEnum.Atualizacao, () =>
            {
                RuleFor(obj => obj.IdTipoProduto).NotEmpty();
                RuleFor(obj => obj.NomeTipoProduto).NotEmpty();
            });

            RuleSet(ValidationEnum.Delecao, () =>
            {
                RuleFor(obj => obj.Id).NotEmpty();
            });
        }
    }
}
