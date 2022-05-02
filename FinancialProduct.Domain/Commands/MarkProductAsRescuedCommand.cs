using FinancialProduct.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace FinancialProduct.Domain.Commands;

public class MarkProductAsRescuedCommand : Notifiable, ICommand
{
    public MarkProductAsRescuedCommand(){ }

    public MarkProductAsRescuedCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
                  new Contract()
                      .Requires()                 
                      .HasMinLen(User, 6, "User", "Usuário inválido!")
              );
    }
}