using Aliquota.Domain.Commands;
using Aliquota.Domain.Commands.Contracts;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers.Contracts;
using Aliquota.Domain.Repositories;
using Flunt.Notifications;

namespace Aliquota.Domain.Handlers
{
    public class CreateFlowCommandHandler : Notifiable, IHandler<CreateClientCommand>,
    IHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        public CreateFlowCommandHandler(IProductRepository repository) //injeta a dependencia do repositorio
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateClientCommand command)
        {
            //verificar se o usuario ja existe (document e name) //não aplicado
            if (_repository.ClientExist(command.Document))
                AddNotification("Document", "CPF Já cadastrado !");

            //Criar as entidade 
            var client = new Client(command.User, command.Document);

            //Validação
            AddNotifications(client.Notifications);

            command.Validate();
            if (command.Invalid)
            {
                //se não for valido já retorna o erro para tela junto com o que foi colocado errado
                return new GenericCommandResult(false, "Erro ao cadastrar cliente !", command.Notifications);
            }
            //Persistir no banco
            _repository.Save(client);

            //Retorna resultado para tela
            return new GenericCommandResult(true, "Cliente cadastrado com sucesso !", client.Id);
        }
        public ICommandResult Handle(CreateProductCommand command)
        {
            var product = new Product(command.Title, command.Price, command.CreateDate, command.RescueDate);
            var client = _repository.GetClient(command.Document);
            var order = new Order(client);


            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro ao criar produto !", command.Notifications);
            }

            _repository.SaveProduct(product); //Inicio do fluxo
            order.AddProducts(product);
            order.PlaceOrder();
            order.ReturnProductTax(product);
            return new GenericCommandResult(true, $"Produto cadastrado com sucesso. Seu resgate foi consultado e o valor é de {product.TaxValue} !", product.Id);
        }
    }
}