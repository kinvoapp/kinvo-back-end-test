namespace FinancialProduct.Domain.Entities;

public abstract class Base : IEquatable<Base>
{
    protected Base()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }

    public bool Equals(Base? other)
    {
        return Id == other.Id;
    }
}