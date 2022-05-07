﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
