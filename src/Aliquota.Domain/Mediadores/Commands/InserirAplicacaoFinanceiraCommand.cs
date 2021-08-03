using Aliquota.Domain.Mediadores.Events;
using MediatR;
using System;

namespace Aliquota.Domain.Mediadores.Commands
{
    public class InserirAplicacaoFinanceiraCommand : IRequest<AplicacaoFinanceiraInserida>
    {
        public DateTime DataAplicacao { get; set; }
        public decimal ValorAplicacao { get; set; }
        public decimal Quantidade { get; set; }
        public Guid ProdutoFinanceiroId { get; set; }
    }
}