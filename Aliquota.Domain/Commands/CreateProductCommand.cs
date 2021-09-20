using System;
using Aliquota.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Commands
{
    public class CreateProductCommand : Notifiable, ICommand
    {
        public CreateProductCommand()
        {

        }

        public CreateProductCommand(double price, string title, DateTime initialApplicationDate, DateTime endApplicationDate)
        {
            Price = price;
            Title = title;
            InitialApplicationDate = initialApplicationDate;
            EndApplicationDate = endApplicationDate;
        }

        public double Price { get; set; }
        public string Title { get; set; }
        public DateTime InitialApplicationDate { get; set; }
        public DateTime EndApplicationDate { get; set; }
        public void Validate()
        {
            //Ajeitar os contracts
            AddNotifications(new Contract().Requires().HasMinLen(Title, 3, "Title", "Por favor, no mínimo 3 caracteres para o nome do produto")
            .HasMaxLen(Title, 12, "Title", "Titulo com no máximo até 12 caracteres !")
            .IsLowerThan(EndApplicationDate, InitialApplicationDate, "EndApplicationDate", "O produto não pode ter uma data final anterior a data inicial ! "));
        }
    }
}
