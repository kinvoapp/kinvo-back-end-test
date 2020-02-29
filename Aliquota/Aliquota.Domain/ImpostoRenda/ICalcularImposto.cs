using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.ImpostoRenda
{
    public interface ICalcularImposto
    {
        void Calcular(IImpostoRenda impostoRenda);
    }
}
