using System;
using Aliquota.Domain.Commands.Contracts;

namespace Aliquota.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand //tipo genetico para o handler
    {
        ICommandResult Handle(T command);
    }
}
