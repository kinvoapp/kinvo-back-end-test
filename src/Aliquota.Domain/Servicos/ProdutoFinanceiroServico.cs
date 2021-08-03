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
    internal class ProdutoFinanceiroServico : IProdutoFinanceiroServico
    {
        private readonly ILogger<ProdutoFinanceiroServico> logger;
        private readonly IRepositorioBase repositorio;
        private readonly IMediator mediador;

        public ProdutoFinanceiroServico(
            ILogger<ProdutoFinanceiroServico> logger,
            IRepositorioBase repositorio,
            IMediator mediador)
        {
            this.logger = logger;
            this.repositorio = repositorio;
            this.mediador = mediador;
        }

        public async Task<ProdutoFinanceiro> ObterPorIdAsync(Guid id)
        {
            return await repositorio.ObterPorIdAsync<ProdutoFinanceiro>(id);
        }

        public async Task<IList<ProdutoFinanceiro>> ObterTodosAsync()
        {
            return await repositorio.ObterTodosAsync<ProdutoFinanceiro>();
        }

        public async Task<ProdutoFinanceiro> RemoverPorIdAsync(Guid id)
        {
            var removido = await mediador.Send(new RemoverProdutoFinanceiroCommand(id));
            return removido.Entidade;
        }
    }
}