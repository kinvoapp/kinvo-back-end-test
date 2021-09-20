using System;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Commands.Contracts;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers.Contracts;
using Aliquota.Domain.Repositories;
using Flunt.Notifications;

namespace Aliquota.Domain.Handlers
{
    //Handlers => Manipuladores (Executa) Responsáveis pelos input dos dados...
    //Pegamos um comando(Commands) e fazendo sua execução(Handlers) 
    //Pq não fazer no controller da API? Se eu quiser replicar esse código eu consigo pois 
    //O controle está no Domínio, se estivesse na API eu não conseguiria fazer... Se eu tivesse que
    //Alterar alguma coisa desses Handlers deveria ser através de um Controller, o que iria precisar
    //Fazer um HTTP REQUEST para a API que faria um REQUEST pro banco.. isso dá muito trabalho
    //O Fluxo estando fora do controller(API) Além do controle de manipulação ser melhor eu consigo reutilizar 
    //Tornando assim as mudanças mais facéis e seguras 
    //Testar um controller é mais díficil do que um objeto do domínio 
    //E testar um Handler é mais fácil pois é um objeto C# puro 
    public class ProductHandler : Notifiable, IHandler<CreateProductCommand>, IHandler<RescueProductApplicationCommand>
    {
        private readonly IProductRepository _repository; //injeção de dependencia 
        public ProductHandler(IProductRepository repo)
        {
            _repository = repo;
        }
        public ICommandResult Handle(CreateProductCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Opa, tem algo errado aí !", command.Notifications);
            }
            var product = new Product(command.Title, command.Price, command.InitialApplicationDate, command.EndApplicationDate);
            _repository.Create(product);
            _repository.Save(product);
            return new GenericCommandResult(true, "Produto criado com sucesso !", product.ToString());
        }

        public ICommandResult Handle(RescueProductApplicationCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Opa, tem algo errado aí !", command.Notifications);
            }
            var product = _repository.GetProduct(command.Id, command.Title, command.Price);
            var value = _repository.GetTaxValue(product.CalculationOfIncomeTaxCollection());
            return new GenericCommandResult(true, "Aplicação resgatada com sucesso ! Seu valor é de: ", value);
        }
    }
}
