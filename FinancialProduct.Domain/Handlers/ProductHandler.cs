using FinancialProduct.Domain.Commands;
using FinancialProduct.Domain.Commands.Contracts;
using FinancialProduct.Domain.Entities;
using FinancialProduct.Domain.Handlers.Contracts;
using FinancialProduct.Domain.Repositories;
using Flunt.Notifications;

namespace FinancialProduct.Domain.Handlers;

public class ProductHandler :
    Notifiable,
    IHandler<CreateProductCommand>,
    IHandler<UpdateProductCommand>,
    IHandler<MarkProductAsRescuedCommand>

{
    private readonly IProductRepository _repository;

    public ProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateProductCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        // Gera o Produto 
        var product = new Product(command.Title, command.Value, command.User);

        // Salva no banco
        _repository.Create(product);

        // Retorna o resultado
        return new CommandResult(true, "Produto inserido com sucesso!", product);
    }

    public ICommandResult Handle(UpdateProductCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        // Recupera o produto pelo Id (Rehidratação)
        var product = _repository.GetById(command.Id);

        //Executa o método Apply 
        product.Apply(command.Value);

        // Salva no banco
        _repository.Update(product);

        // Retorna o resultado
        return new CommandResult(true, $"Aplicação de {command.Value} foi feita com sucesso", product);
    }

    public ICommandResult Handle(MarkProductAsRescuedCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        // Recupera o produto
        var product = _repository.GetById(command.Id);

        // Altera o estado
        product.MarkAsWithdrawn();

        // Retona o tributo calculado
        var tribute = product.CalculateTribute();

        // Salva no banco
        _repository.Update(product);

        // Retorna o resultado
        return new CommandResult(true, $"Resgate efetuado com sucesso. Foi cobrado {tribute}  ", product);
    }


}
