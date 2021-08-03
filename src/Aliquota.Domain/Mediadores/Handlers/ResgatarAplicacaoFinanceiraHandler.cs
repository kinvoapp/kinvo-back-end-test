using Aliquota.Domain.DTOs;
using Aliquota.Domain.Entidades;
using Aliquota.Domain.Interfaces.Repositorios;
using Aliquota.Domain.Mediadores.Commands;
using Aliquota.Domain.Mediadores.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aliquota.Domain.Mediadores.Handlers
{
    public class ResgatarAplicacaoFinanceiraHandler
        : IRequestHandler<ResgatarAplicacaoFinanceiraCommand, AplicacaoFinanceiraRemovida>
    {
        private ILogger<ResgatarAplicacaoFinanceiraHandler> logger;
        private IRepositorioBase repositorio;

        public ResgatarAplicacaoFinanceiraHandler(
            ILogger<ResgatarAplicacaoFinanceiraHandler> logger,
            IRepositorioBase repositorio)
        {
            this.logger = logger;
            this.repositorio = repositorio;
        }

        public async Task<AplicacaoFinanceiraRemovida> Handle(
            ResgatarAplicacaoFinanceiraCommand request, CancellationToken cancellationToken)
        {
            var entidade = await repositorio.ObterPorIdAsync<AplicacaoFinanceira>(request.Id);
            if (entidade == null)
                return new AplicacaoFinanceiraRemovida();

            var resgate = AplicacaoFinanceira(entidade);
            await repositorio.RemoverAsync(entidade).ConfigureAwait(false);

            logger.LogTrace($"Aplicação financeiro {entidade.Id} resgatada");
            return new AplicacaoFinanceiraRemovida { Entidade = resgate };
        }

        private AplicacaoFinanceiraResgatada AplicacaoFinanceira(AplicacaoFinanceira entidade)
        {
            var valorLucro = entidade.Lucro;
            var percentualImposto = ObterPercentualImpostoRenda(entidade.DataAplicacao);
            var valorDesconto = valorLucro * percentualImposto;
            var lucroLiquido = (entidade.ValorAplicacao + valorLucro) - valorDesconto;

            return new AplicacaoFinanceiraResgatada
            {
                DataAplicacao = entidade.DataAplicacao,
                ValorAplicado = entidade.ValorAplicacao,
                LucroLiquido = lucroLiquido,
                PercentualImpostoRenda = percentualImposto
            };
        }

        private decimal ObterPercentualImpostoRenda(DateTime dataAplicacao)
        {
            var totalDias = (int)DateTime.Now.Date.Subtract(dataAplicacao).TotalDays;
            if (totalDias <= 365)
                return 0.225M;
            else if (totalDias > 365 && totalDias <= 730)
                return 0.185M;
            else
                return 0.15M;
        }
    }
}