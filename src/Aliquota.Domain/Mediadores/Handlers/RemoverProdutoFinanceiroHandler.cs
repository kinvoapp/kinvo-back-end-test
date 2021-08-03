using Aliquota.Domain.Entidades;
using Aliquota.Domain.Interfaces.Repositorios;
using Aliquota.Domain.Mediadores.Commands;
using Aliquota.Domain.Mediadores.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Aliquota.Domain.Mediadores.Handlers
{
    public class RemoverProdutoFinanceiroHandler
        : IRequestHandler<RemoverProdutoFinanceiroCommand, ProdutoFinanceiroRemovida>
    {
        private readonly ILogger<RemoverProdutoFinanceiroHandler> logger;
        private readonly IRepositorioBase repositorio;

        public RemoverProdutoFinanceiroHandler(
            ILogger<RemoverProdutoFinanceiroHandler> logger,
            IRepositorioBase repositorio)
        {
            this.logger = logger;
            this.repositorio = repositorio;
        }

        public async Task<ProdutoFinanceiroRemovida> Handle(RemoverProdutoFinanceiroCommand request, CancellationToken cancellationToken)
        {
            var entidade = await repositorio.ObterPorIdAsync<ProdutoFinanceiro>(request.Id);

            if (entidade == null)
                return new ProdutoFinanceiroRemovida();

            await repositorio.RemoverAsync(entidade).ConfigureAwait(false);

            logger.LogTrace($"Produto Financeiro {entidade.Id} excluído");
            return new ProdutoFinanceiroRemovida { Entidade = entidade };
        }
    }
}