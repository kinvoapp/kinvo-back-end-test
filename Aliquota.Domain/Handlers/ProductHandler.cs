using System;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Commands.Contracts;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers.Contracts;
using Aliquota.Domain.Repositories;
using Flunt.Notifications;

namespace Aliquota.Domain
{
    public class ProductHandler : Notifiable, IHandler<CreateProductCommand>, IHandler<RescueProductApplicationCommand>
    {
        private readonly IProductRepository _repository; //injeção de dependencia 
        public ProductHandler(IProductRepository repo)
        {
            _repository = repo;
        }
        public ICommandResult Handle(CreateProductCommand command)
        {
            if (Invalid)
            {
                return new GenericCommandResult(false, "Opa, tem algo errado aí !", command.Notifications);
            }
            var product = new Product(command.Title, command.Price, command.InitialApplicationDate, command.EndApplicationDate);
            _repository.Create(product);
            return new GenericCommandResult(true, "Produto criado com sucesso !", product.ToString());
        }

        public ICommandResult Handle(RescueProductApplicationCommand command)
        {
            if (Invalid)
            {
                return new GenericCommandResult(false, "Opa, tem algo errado aí !", command.Notifications);
            }
            var product = new Product(command.Title, command.Price, command.InitialApplicationDate, command.EndApplicationDate);
            var taxValueRescue = _repository.GetApplicationTaxValue(product);
            taxValueRescue.Calculo(product);
            _repository.RescueTaxValue(taxValueRescue);
            return new GenericCommandResult(true, "Aplicação resgatada com sucesso ! Seu valor é de: ", taxValueRescue);
        }
    }
}
