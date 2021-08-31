using Aliquota.Domain.Business.Validation;
using Aliquota.Domain.Entities.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Business.Implementacao.Validators
{
    public class ClienteValidator : Validator<Cliente>
    {
        public ClienteValidator()
        {
            RuleSet(ValidationEnum.Insercao, () =>
            {
                RuleFor(obj => obj.IdCliente).NotEmpty();
                RuleFor(obj => obj.NomeCliente).NotEmpty();
            });

            RuleSet(ValidationEnum.Atualizacao, () =>
            {
                RuleFor(obj => obj.IdCliente).NotEmpty();
                RuleFor(obj => obj.ProdutoLista).NotNull().NotEmpty();

            });

            RuleSet(ValidationEnum.Delecao, () =>
            {
                RuleFor(obj => obj.Id).NotEmpty();
            });
        }
    }
}
