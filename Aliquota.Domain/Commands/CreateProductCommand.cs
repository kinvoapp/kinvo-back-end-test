using System;
using Aliquota.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Commands
{
    //POST
    //Commands não tem regras de negócio, apenas validação 
    public class CreateProductCommand : Notifiable, ICommand
    {
        public CreateProductCommand()
        {

        }
        public CreateProductCommand(Guid id, string title, double price, DateTime initialApplicationDate, DateTime endApplicationDate)
        {
            Id = id;
            Price = price;
            Title = title;
            InitialApplicationDate = initialApplicationDate;
            EndApplicationDate = endApplicationDate;
        }
        public Guid Id { get; set; }
        public double Price { get; set; } //não necessita ser private, pois a API utiliza ele 
        public string Title { get; set; }
        public DateTime InitialApplicationDate { get; set; }
        public DateTime EndApplicationDate { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract().Requires()
            .IsGreaterOrEqualsThan(EndApplicationDate, InitialApplicationDate, "EndApplicationDate", "A data final da aplicação não pode ser no passado !")
             .IsGreaterThan(Price, 0, "Price", "O valor de resgate não pode ser zero !")
             .IsNotNullOrEmpty(Title, "Title", "O Título de resgate não pode ser vazio !")
             .HasMinLen(Title, 5, "Title", "O Ativo deve conter ao mínimo 5 caracteres !")
             .HasMaxLen(Title, 5, "Title", "O Ativo deve conter ao máximo 5 caracteres !"));
        }

    }
}
