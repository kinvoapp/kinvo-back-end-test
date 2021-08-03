using Aliquota.Domain.Entidades;
using Aliquota.Domain.Excecao;
using Aliquota.Domain.Interfaces.Repositorios;
using Aliquota.Domain.Interfaces.Servicos;
using Aliquota.Domain.Mediadores.Commands;
using Aliquota.Domain.Mediadores.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Aliquota.Domain.Mediadores.Handlers
{
    public class InserirAplicacaoFinanceiraHandler : IRequestHandler<InserirAplicacaoFinanceiraCommand, AplicacaoFinanceiraInserida>
    {
        private readonly ILogger<InserirAplicacaoFinanceiraHandler> logger;
        private readonly IRepositorioBase repositorio;
        private readonly IProdutoFinanceiroServico produtoFinanceiro;

        public InserirAplicacaoFinanceiraHandler(
            ILogger<InserirAplicacaoFinanceiraHandler> logger,
            IRepositorioBase repositorio,
            IProdutoFinanceiroServico produtoFinanceiro)
        {
            this.logger = logger;
            this.repositorio = repositorio;
            this.produtoFinanceiro = produtoFinanceiro;
        }

        public async Task<AplicacaoFinanceiraInserida> Handle(InserirAplicacaoFinanceiraCommand request, CancellationToken cancellationToken)
        {
            var produto = await produtoFinanceiro.ObterPorIdAsync(request.ProdutoFinanceiroId);
            if (produto == null)
                throw new AliquotaException($"Produto Financeiro {request.ProdutoFinanceiroId} não localizado");

            var entidade = await Adicionar(request, produto);

            logger.LogTrace($"Aplicação Financeira {entidade.Id} inserida");
            return new AplicacaoFinanceiraInserida { Entidade = entidade };
        }

        private async Task<AplicacaoFinanceira> Adicionar(InserirAplicacaoFinanceiraCommand request, ProdutoFinanceiro produto)
        {
            var quantidade = request.ValorAplicacao / produto.ValorCotacao;
            var entidade = new AplicacaoFinanceira(request.DataAplicacao, request.ValorAplicacao, quantidade, request.ProdutoFinanceiroId);

            await repositorio.AdicionarAsync(entidade);
            return entidade;
        }
    }
}