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

        public RescueProductApplicationCommand(Guid id, double price, string title, DateTime initialApplicationDate, DateTime endApplicationDate)
        {
            Id = id;
            Price = price;
            Title = title;
            InitialApplicationDate = initialApplicationDate;
            EndApplicationDate = endApplicationDate;
        }
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public DateTime InitialApplicationDate { get; set; }
        public DateTime EndApplicationDate { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract().Requires().HasMinLen(Title, 3, "Title", "Por favor, no mínimo 3 caracteres para o nome do produto")
            .HasMaxLen(Title, 12, "Title", "Titulo com no máximo até 12 caracteres !")
            .IsLowerThan(EndApplicationDate, InitialApplicationDate, "EndApplicationDate", "O Resgate não pode ser feito se a data for menor que a data de aplicação !")
            .IsLowerOrEqualsThan(InitialApplicationDate, DateTime.Now.AddYears(1), "InitialApplicationDate", "O Resgate só pode ser feito com no mínimo um ano de aplicação !"));
        }
    }
}
