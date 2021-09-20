using System;
using Aliquota.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Commands
{
    public class RescueProductApplicationCommand : Notifiable, ICommand
    {
        public RescueProductApplicationCommand()
        {

        }

        public RescueProductApplicationCommand(string title, double price, DateTime initialApplicationDate, DateTime endApplicationDate)
        {
            Id = Guid.NewGuid();
            Price = price;
            Title = title;
            InitialApplicationDate = initialApplicationDate;
            EndApplicationDate = endApplicationDate;
        }
        public Guid Id { get; private set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public DateTime InitialApplicationDate { get; set; }
        public DateTime EndApplicationDate { get; set; }
        public void Validate()
        {
            //Adicionar contract Price não pode ser zero ! 
            AddNotifications(new Contract().Requires()
            .IsGreaterOrEqualsThan(EndApplicationDate, InitialApplicationDate, "EndApplicationDate", "O Resgate não pode ser feito no passado !")
            .IsGreaterThan(Price, 0, "Price", "O valor de resgate não pode ser zero !")
            .IsNotNullOrEmpty(Title, "Title", "O Título de resgate não pode ser vazio !")
           .HasMinLen(Title, 5, "Title", "O Ativo deve conter ao mínimo 5 caracteres !")
           .HasMaxLen(Title, 5, "Title", "O Ativo deve conter ao máximo 5 caracteres !"));
        }

    }
}
