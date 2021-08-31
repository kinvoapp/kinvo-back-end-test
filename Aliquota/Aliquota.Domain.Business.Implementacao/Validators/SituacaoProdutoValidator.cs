using Aliquota.Domain.Business.Validation;
using Aliquota.Domain.Entities.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Business.Implementacao.Validators
{
    public class SituacaoProdutoValidator : Validator<SituacaoProduto>
    {
        public SituacaoProdutoValidator()
        {
            RuleSet(ValidationEnum.Insercao, () =>
            {
                RuleFor(obj => obj.IdSituacaoProduto).NotEmpty();
            });

            RuleSet(ValidationEnum.Atualizacao, () =>
            {
                RuleFor(obj => obj.IdSituacaoProduto).NotEmpty();
                RuleFor(obj => obj.Situacao).NotEmpty();
            });

            RuleSet(ValidationEnum.Delecao, () =>
            {
                RuleFor(obj => obj.Id).NotEmpty();
            });
        }
    }
}
