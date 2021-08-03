using Aliquota.Domain.DTOs;
using Aliquota.Domain.Entidades;
using Aliquota.Domain.Interfaces.Repositorios;
using Aliquota.Domain.Interfaces.Servicos;
using Aliquota.Domain.Mediadores.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Servicos
{
    internal class AplicacaoFinanceiraServico : IAplicacaoFinanceiraServico
    {
        private readonly ILogger<AplicacaoFinanceiraServico> logger;
        private readonly IRepositorioBase repositorio;
        private readonly IMediator mediador;

        public AplicacaoFinanceiraServico(
            ILogger<AplicacaoFinanceiraServico> logger,
            IRepositorioBase repositorio,
            IMediator mediador)
        {
            this.logger = logger;
            this.repositorio = repositorio;
            this.mediador = mediador;
        }

        public async Task<AplicacaoFinanceira> Inserir(InserirAplicacaoFinanceiraCommand command)
        {
            var inserido = await mediador.Send(command);
            await mediador.Publish(inserido);
            return inserido.Entidade;
        }

        public Task<AplicacaoFinanceira> ObterPorIdAsync(Guid id)
        {
            return repositorio.ObterPorIdAsync<AplicacaoFinanceira>(id);
        }

        public Task<IList<AplicacaoFinanceira>> ObterTodosAsync()
        {
            return repositorio.ObterTodosAsync<AplicacaoFinanceira>();
        }

        public async Task<AplicacaoFinanceiraResgatada> ResgatarPorIdAsync(Guid id)
        {
            var retorno = await mediador.Send(new ResgatarAplicacaoFinanceiraCommand(id));
            return retorno.Entidade;
        }
    }
}