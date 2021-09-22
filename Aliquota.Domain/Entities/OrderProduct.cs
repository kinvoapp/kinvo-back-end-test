namespace Aliquota.Domain.Entities
{
    public class OrderProduct : Entity
    {
        public OrderProduct()
        {

        }
        public OrderProduct(Product product)
        {
            Product = product;
        }

        public Product Product { get; private set; }
    }
}