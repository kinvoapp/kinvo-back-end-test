using FinancialProduct.Domain.Entities;

namespace FinancialProduct.Domain.Repositories;

public interface IProductRepository
{
    void Create(Product product);
    void Update(Product product);
    Product GetById(Guid id);
    IEnumerable<Product> GetAllQueryRescued(string user);
    IEnumerable<Product> GetAllQuery(string user);

}
