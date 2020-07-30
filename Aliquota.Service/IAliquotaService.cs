using System;
using System.Collections.Generic;
using Aliquota.Domain;

namespace Aliquota.Service
{
    public interface IAliquotaService
    {
        IEnumerable<Aplicacao> ListarAplicacoes(int userId);

        void CriarAplicacao(double valor, double rentabilidade, int userId);

        void CriarUsuarioSeNaoExiste(int userId);

        Aplicacao ResgatarAplicacao(int aplicacaoId, int userId);

        Aplicacao SimularResgateAplicacao(int aplicacaoId, int userId, DateTime dataResgate);
    }
}