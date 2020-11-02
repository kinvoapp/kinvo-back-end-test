using Income.Tax.Willian.Santos.Kinvo.Shared.Commands;
using Income.Tax.Willian.Santos.Kinvo.Shared.Commands.Interfaces;
using System.Threading.Tasks;

namespace Income.Tax.Willian.Santos.Kinvo.Shared.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        Task<GenericCommandResult> Handle(T command);
    }
}
