using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Entities
{
    public class Client : Notifiable
    {
        private IList<Product> _products;
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<Product> Products { get; private set; }
        public Client(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            _products = new List<Product>();
            AddNotifications(new Contract().Requires()
            .HasMinLen(Name, 3, "Name", "O nome deve conter ao mínimo 3 caracteres !")
            .HasMaxLen(Name, 25, "Name", "O nome deve conter ao máximo 25 caracteres !")
            .IsNotNullOrEmpty(Name, "Name", "O Nome do cliente não pode ser vazio !"));
        }
        public void AddProduct(Product products)
        {
            _products.Add(products);
        }
        public double Rescue(Product product)
        {
            _products.Add(product);
            double result = product.CalculationOfIncomeTaxCollection();
            return result;
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
