using System;
using Aliquota.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Commands
{
    public class CreateProductCommand : Notifiable, ICommand
    {
        public double Price { get; set; }
        public string Title { get; set; }
        public DateTime InitialApplicationDate { get; set; }
        public DateTime EndApplicationDate { get; set; }

        // public void Validate()
        // {

        //     AddNotifications(new Contract().Requires()
        //     .IsGreaterOrEqualsThan(EndApplicationDate, InitialApplicationDate, "EndApplicationDate", "A data final da aplicação não pode ser no passado !")
        //     .IsGreaterThan(Price, 0, "Price", "O valor de resgate não pode ser zero !")
        //     .IsNotNullOrEmpty(Title, "Title", "O Título de resgate não pode ser vazio !")
        //     .HasMinLen(Title, 5, "Title", "O Ativo deve conter ao mínimo 5 caracteres !")
        //     .HasMaxLen(Title, 5, "Title", "O Ativo deve conter ao máximo 5 caracteres !"));
        // }

        bool ICommand.Valid()
        {
            AddNotifications(new Contract().Requires()
            .IsGreaterOrEqualsThan(EndApplicationDate, InitialApplicationDate, "EndApplicationDate", "A data final da aplicação não pode ser no passado !")
            .IsGreaterThan(Price, 0, "Price", "O valor de resgate não pode ser zero !")
            .IsNotNullOrEmpty(Title, "Title", "O Título de resgate não pode ser vazio !")
            .HasMinLen(Title, 5, "Title", "O Ativo deve conter ao mínimo 5 caracteres !")
            .HasMaxLen(Title, 5, "Title", "O Ativo deve conter ao máximo 5 caracteres !"));
            return Valid;
        }
    }
}
