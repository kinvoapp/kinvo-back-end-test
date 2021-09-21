using System;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Commands.Contracts;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers.Contracts;
using Aliquota.Domain.Repositories;
using Flunt.Notifications;

namespace Aliquota.Domain.Handlers
{
    public class CreateFlowCommandHandler : Notifiable, IHandler<CreateClientCommand>,
    IHandler<AddOrderCommand>,
    IHandler<CreateProductCommand>,
    IHandler<ReturnTaxRescueValueCommand>
    {
        private readonly IProductRepository _repository;
        public CreateFlowCommandHandler(IProductRepository repository)
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
            return new GenericCommandResult(true, "Cliente cadastrado com sucesso !", client);
        }
        public ICommandResult Handle(CreateProductCommand command)
        {
            var product = new Product(command.Title, command.Price, command.CreateDate, command.RescueDate);
            var client = _repository.GetById(command.CustomerId);
            //var order = new Order(client.User, client.Document);

            //AddNotifications(client.Notifications);
            AddNotifications(product.Notifications);
            //validar se cliente existe
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro ao criar produto !", command.Notifications);
            }

            _repository.SaveProduct(product);
            return new GenericCommandResult(true, "Produto cadastrado com sucesso !", product);
        }

        public ICommandResult Handle(AddOrderCommand command)
        {
            var product = _repository.GetByProductId(command.ProductId);
            var client = _repository.GetById(command.CustomerId);
            var order = new Order(command.User, command.Document);

            AddNotifications(order.Notifications);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro ao criar pedido !", command.Notifications);
            }
            _repository.SaveOrder(order);
            order.AddProducts(command.Product);
            return new GenericCommandResult(true, "Pedido criado com sucesso !", order);
        }
        public ICommandResult Handle(ReturnTaxRescueValueCommand command)
        {
            //Pega produto, cliente e ordem do banco
            var product = _repository.GetByProductId(command.ProductId);
            var client = _repository.GetById(command.CustomerId);
            var order = _repository.GetOrderById(command.OrderId);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro ao resgatar ativo !", command.Notifications);
            }
            _repository.ReturnIncomeTax(command.TaxValue);
            return new GenericCommandResult(true, "Ativo resgatado com sucesso ! O valor da taxa é: ", command.TaxValue);
        }
        //Resolver erro NULL EXCEPTION que esta dando do postman

    }
}