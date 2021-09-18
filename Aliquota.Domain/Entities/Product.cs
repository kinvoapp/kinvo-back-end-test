using System;
using Flunt.Notifications;
using Flunt.Validations;
namespace Aliquota.Domain.Entities
{
    public class Product : Notifiable
    {
        public Product(string title, double price, DateTime applicationDate, DateTime endApplicationDate)
        {
            Id = Guid.NewGuid();
            Price = price;
            Title = title;
            ApplicationDate = applicationDate;
            EndApplicationDate = endApplicationDate;
            AddNotifications(new Contract().Requires()
            .IsGreaterOrEqualsThan(EndApplicationDate, ApplicationDate, "EndApplicationDate", "A data final da aplicação não pode ser no passado !")
            .IsGreaterOrEqualsThan(Price, 0, "Price", "O valor de resgate não pode ser zero !")
            .IsNotNullOrEmpty(Title, "Title", "O Título de resgate não pode ser nulo !"));
        }

        public Guid Id { get; private set; }
        public double Price { get; private set; }
        public string Title { get; private set; }
        public DateTime ApplicationDate { get; private set; }
        public DateTime EndApplicationDate { get; private set; }
        public bool Exists { get { return true; } }
        public bool Equals(Product other)
        {
            return Id == other.Id;
        }

        public bool ImAlive()
        {
            return Exists;
        }
    }
}
