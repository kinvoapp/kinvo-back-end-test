using System;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Commands.Contracts;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers.Contracts;
using Aliquota.Domain.Repositories;
using Flunt.Notifications;

namespace Aliquota.Domain.Handlers
{
    public class CreateOrderCommandHandler : Notifiable, IHandler<CreateClientCommand>,
    IHandler<AddOrderCommand>,
    IHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        public CreateOrderCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateClientCommand command)
        {
            //verificar se o usuario ja existe (document e name)
            if (_repository.ClientExist(command.Document))
                AddNotification("Document", "CPF Já cadastrado !");

            //Criar as entidade 
            var client = new Client(command.User, command.Document);
            //validação
            AddNotifications(client.Notifications);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro ao cadastrar cliente !", command.Notifications);
            }
            //Persistir no banco
            _repository.Save(client);

            //Retorna resultado para tela
            return new CreateClientCommandResult(client.Id, client.Document, client.User.ToString());
        }
        public ICommandResult Handle(CreateProductCommand command)
        {
            var product = new Product(command.Title, command.Price, command.CreateDate, command.RescueDate);
            var client = _repository.GetById(command.CustomerId);
            var order = new Order(client);

            AddNotifications(client.Notifications);
            AddNotifications(order.Notifications);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro ao criar produto !", command.Notifications);
            }

            _repository.SaveProduct(product);
            return new CreateClientCommandResult(product.Id, product.Title, product.Price.ToString());
        }

        public ICommandResult Handle(AddOrderCommand command)
        {
            var product = _repository.GetByProductId(command.ProductId);
            var client = _repository.GetById(command.CustomerId);
            var order = new Order(client);

            AddNotifications(client.Notifications);
            AddNotifications(order.Notifications);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro ao criar pedido !", command.Notifications);
            }

            _repository.SaveOrder(order);
            return new CreateClientCommandResult(order.Id, client.Document, client.User.ToString());
        }


    }
}