using System;
using FinancialProduct.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;


namespace FinancialProduct.Domain.Commands;

public class UpdateProductCommand
 : Notifiable, ICommand
{
    public UpdateProductCommand
    ()
    { }

    public UpdateProductCommand
    (Guid id, int value)
    {
        Id = id;
        Value = value;
    }

    public Guid Id { get; set; }
    public int Value { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsGreaterThan(Value,0,"Value","Erro ao adicionar valor")
        );
    }
}
