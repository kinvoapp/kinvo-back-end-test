using Aliquota.Domain.Mediadores.Events;
using MediatR;
using System;

namespace Aliquota.Domain.Mediadores.Commands
{
    public class RemoverProdutoFinanceiroCommand : IRequest<ProdutoFinanceiroRemovida>
    {
        public Guid Id { get; private set; }

        public RemoverProdutoFinanceiroCommand(Guid id)
        {
            Id = id;
        }
    }
}