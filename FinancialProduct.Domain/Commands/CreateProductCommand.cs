using FinancialProduct.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace FinancialProduct.Domain.Commands;

public class CreateProductCommand : Notifiable, ICommand
{
   public CreateProductCommand(){ }

    public CreateProductCommand(string title, int value, string user)
    {
        Title = title;
        Value = value;
        User = user;
    }

    public string Title { get; set; }
    public int Value { get;  set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
                  new Contract()
                      .Requires()
                      .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                      .HasMinLen(User, 6, "User", "Usuário inválido!")
              );
    }
}