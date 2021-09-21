using System;
using System.Collections.Generic;
using Aliquota.Domain.Commands.Contracts;
using Aliquota.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aliquota.Domain.Commands
{
    public class ReturnTaxRescueValueCommand : Notifiable, ICommand
    {
        public ReturnTaxRescueValueCommand()
        {
            Products = new List<Product>();
        }
        public double TaxValue { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime RescueDate { get; set; }
        public TimeSpan DateCompare { get; set; }
        public string Document { get; set; }
        public string User { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public IList<Product> Products { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract().Requires()
            .HasMinLen(User, 3, "Name", "O nome deve conter ao mínimo 3 caracteres !")
            .IsGreaterOrEqualsThan(RescueDate.Date, CreateDate.Date, "EndApplicationDate", "A data final da aplicação não pode ser no passado !")
            .HasMaxLen(User, 25, "Name", "O nome deve conter ao máximo 25 caracteres !")
            .IsNotNullOrEmpty(User, "Name", "O Nome do cliente não pode ser vazio !")
            .HasLen(Document, 11, "Document", "CPF inválido !")
            .IsNotNullOrEmpty(Title, "Title", "O Título de resgate não pode ser vazio !")
            .HasMinLen(Title, 5, "Title", "O Ativo deve conter ao mínimo 5 caracteres !")
            .HasMaxLen(Title, 5, "Title", "O Ativo deve conter ao máximo 5 caracteres !")
            .HasLen(CustomerId.ToString(), 36, "CustomerId", "Identificador do Cliente Inválido !!!")
            .HasLen(ProductId.ToString(), 36, "ProductId", "Identificador do Produto Inválido !!!")
            .IsGreaterThan(Products.Count, 0, "Products", "Nenhum ativo foi encontrado !")); ;
        }
    }
}
