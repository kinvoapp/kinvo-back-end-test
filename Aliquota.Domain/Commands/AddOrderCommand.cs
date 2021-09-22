using System;
using System.Collections.Generic;
using Aliquota.Domain.Commands.Contracts;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Commands
{
    public class AddOrderCommand : Notifiable, ICommand
    {
        public AddOrderCommand()
        {

            ProductsList = new List<Product>();
            ProductsList.Add(Product);
        }

        public Guid CustomerId { get; set; } //reidratar
        //public Guid ProductId { get; set; }
        public string Title { get; set; }
        public IList<Product> ProductsList { get; set; }
        public Product Product { get; set; }
        public string User { get; set; }
        public string Document { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
            .HasLen(CustomerId.ToString(), 36, "CustomerId", "Identificador do Cliente Inválido !!!")
            //.HasLen(ProductId.ToString(), 36, "ProductId", "Identificador do Produto Inválido !!!")
            .IsGreaterThan(ProductsList.Count, 0, "Products", "Nenhum ativo foi encontrado !"));

        }
    }
}