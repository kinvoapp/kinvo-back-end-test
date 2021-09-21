using Aliquota.Domain.Commands.Contracts;
using Aliquota.Domain.Handlers.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Commands
{
    public class CreateClientCommand : Notifiable, ICommand
    {
        public string Document { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract().Requires()
            .HasMinLen(User, 3, "Name", "O nome deve conter ao mínimo 3 caracteres !")
            .HasMaxLen(User, 25, "Name", "O nome deve conter ao máximo 25 caracteres !")
            .IsNotNullOrEmpty(User, "Name", "O Nome do cliente não pode ser vazio !")
            .HasLen(Document, 11, "Document", "CPF inválido !"));
        }
    }
}