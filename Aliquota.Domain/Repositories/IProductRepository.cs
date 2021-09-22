using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Repositories
{
    //Abstração do repositório 
    public interface IProductRepository
    {
        bool ClientExist(string document);
        bool ProductExist(string productName);
        void Save(Client client);
        void SaveOrder(Order order);
        void SaveProduct(Product product);

        Client GetClient(string document);
        Product GetProduct(string title);
    }
}
