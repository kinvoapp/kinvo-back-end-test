using Aliquota.Domain.DTOs;
using Aliquota.Domain.Entidades;
using Aliquota.Domain.Mediadores.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces.Servicos
{
    public interface IAplicacaoFinanceiraServico
    {
        Task<AplicacaoFinanceira> ObterPorIdAsync(Guid id);

        Task<IList<AplicacaoFinanceira>> ObterTodosAsync();

        Task<AplicacaoFinanceiraResgatada> ResgatarPorIdAsync(Guid id);

        Task<AplicacaoFinanceira> Inserir(InserirAplicacaoFinanceiraCommand command);
    }
}