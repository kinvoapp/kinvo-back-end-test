using System;
using Flunt.Notifications;
using Flunt.Validations;
namespace Aliquota.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string title, double price, DateTime createDate, DateTime rescueDate)
        {
            Title = title;
            Price = price;
            CreateDate = createDate.Date;
            RescueDate = rescueDate.Date;
            AddNotifications(new Contract().Requires()
            .IsGreaterOrEqualsThan(RescueDate.Date, CreateDate.Date, "EndApplicationDate", "A data final da aplicação não pode ser no passado !")
            .IsGreaterThan(Price, 0, "Price", "O valor de resgate não pode ser zero !")
            .IsNotNullOrEmpty(Title, "Title", "O Título de resgate não pode ser vazio !")
            .HasMinLen(Title, 5, "Title", "O Ativo deve conter ao mínimo 5 caracteres !")
            .HasMaxLen(Title, 5, "Title", "O Ativo deve conter ao máximo 5 caracteres !"));
        }

        public string Title { get; private set; }
        public double Price { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime RescueDate { get; private set; }
        public TimeSpan DateCompare { get; private set; }
        public double TaxValue { get; private set; }

        public bool Equals(Product other)
        {
            return Id == other.Id;
        }

        public double CalculationOfIncomeTaxCollection()
        {
            DateCompare = RescueDate.Date - CreateDate.Date;
            double time = DateCompare.Days / 365;
            TaxValue = 0;
            if (time <= 1)
            {
                var n = (22.5 / 100) * Price;
                TaxValue = n;
            }
            if (time == 2)
            {
                var n = (18.5 / 100) * Price;
                TaxValue = n;
            }
            if (time >= 3)
            {
                var n = (15.0 / 100) * Price;
                TaxValue = n;
            }
            AddNotification("Product", "Produto resgatado com sucesso !");
            return TaxValue;
        }

        public override string ToString()
        {
            return $"{Title}";
        }
    }

}
