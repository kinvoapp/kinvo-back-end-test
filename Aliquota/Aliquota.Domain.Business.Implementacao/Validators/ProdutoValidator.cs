using Aliquota.Domain.Business.Validation;
using Aliquota.Domain.Entities.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Business.Implementacao.Validators
{
    public class ProdutoValidator : Validator<Produto>
    {
        public ProdutoValidator()
        {
            RuleSet(ValidationEnum.Insercao, () =>
            {
                RuleFor(obj => obj.IdProduto).NotEmpty();
                RuleFor(obj => obj.DataInvestimento).NotEmpty();
                RuleFor(obj => obj.ValorInvestido).NotEmpty().GreaterThan(0m);
            });

            RuleSet(ValidationEnum.Atualizacao, () =>
            {
                RuleFor(obj => obj.IdProduto).NotEmpty();
                RuleFor(obj => obj.ValorAtual).NotEmpty().GreaterThan(0m);
                RuleFor(obj => obj.DataResgate)
                    .GreaterThan(obj => obj.DataInvestimento)
                    .When(obj => obj.ValorResgatado.HasValue);

            });

            RuleSet(ValidationEnum.Delecao, () =>
            {
                RuleFor(obj => obj.Id).NotEmpty();
            });
        }
    }
}
