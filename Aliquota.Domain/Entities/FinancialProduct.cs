namespace Aliquota.Domain.Entities
{
    public class FinancialProduct : EntityBase
    {
        public FinancialProduct() : base() { }

        public string Name { get; private set; }
    }
}