using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Applications
{
    public interface IAppAplicacao : IAppGeneric<Aplicacao>
    {
        decimal ImpostoRendaDevido(Aplicacao a_Aplicacao);
    }
}
