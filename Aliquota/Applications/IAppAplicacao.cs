using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Applications
{
    public interface IAppAplicacao : IAppGeneric<Aplicacao>
    {
        void ValidarAplicacao(Aplicacao aplicacao);
        decimal ObterPercentualIR(int periodoAplicacao);
        decimal ImpostoRendaDevido(Aplicacao a_Aplicacao);
    }
}
