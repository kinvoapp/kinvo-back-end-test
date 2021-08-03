using Aliquota.Domain.Mediadores.Events;
using MediatR;
using System;

namespace Aliquota.Domain.Mediadores.Commands
{
    public class ResgatarAplicacaoFinanceiraCommand : IRequest<AplicacaoFinanceiraRemovida>
    {
        public Guid Id { get; private set; }

        public ResgatarAplicacaoFinanceiraCommand(Guid id)
        {
            Id = id;
        }
    }
}