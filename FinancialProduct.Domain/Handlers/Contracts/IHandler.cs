using FinancialProduct.Domain.Commands.Contracts;

namespace FinancialProduct.Domain.Handlers.Contracts;

    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
