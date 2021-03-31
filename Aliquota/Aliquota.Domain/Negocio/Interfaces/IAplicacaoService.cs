using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Negocio.Interfaces
{
    public interface IAplicacaoService : IBaseService<Aplicacao>
    {
        bool ValidarAplicacao(Aplicacao aplicacao);

        bool ValidarResgate(Aplicacao aplicacao, DateTime dataResgate);

        decimal ObterAlicotaImposto(Aplicacao aplicacao, DateTime dataResgate);

        decimal ObterImpostoARecolher(Aplicacao aplicacao, DateTime dataResgate);

        void Resgatar(Aplicacao aplicacao, DateTime dataResgate);
    }
}
