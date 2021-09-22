using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Commands.Contracts;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Commands
{
    public class AddOrderCommand : Notifiable, ICommand
    {
        private readonly IList<OrderProduct> _products;

        public AddOrderCommand()
        {
            _products = new List<OrderProduct>();
            OrderItems = new List<OrderItemCommand>();
        }

        public string ClientDocument { get; set; }
        public string ProductTitle { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public IReadOnlyCollection<OrderProduct> Products => _products.ToArray();
        public void Validate()
        {
            AddNotifications(new Contract().Requires()
            .IsNotNullOrEmpty(ClientDocument, "ClientDocument", "O documento do cliente não pode ser vazio !")
            .HasLen(ClientDocument, 11, "ClientDocument", "CPF do cliente inválido !")
            .HasMinLen(ProductTitle, 5, "ProductTitle", "O produto deve conter ao mínimo 3 caracteres !")
            .HasMaxLen(ProductTitle, 5, "ProductTitle", "O produto deve conter ao máximo 25 caracteres !"));

        }
    }
    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public double Price { get; set; }
    }
}