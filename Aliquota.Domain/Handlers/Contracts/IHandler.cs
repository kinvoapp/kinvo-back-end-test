using System;
using Aliquota.Domain.Commands.Contracts;

namespace Aliquota.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
