using FinancialProduct.Domain.Entities;
using FinancialProduct.Domain.Queries;
using FinancialProduct.Domain.Repositories;
using FinancialProduct.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Form.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public IEnumerable<Product> GetAllQuery(string user)
    {
        return _context.Products
           .AsNoTracking()
           .Where(ProductQuery.GetAllQuery(user))
           .OrderBy(x => x.Title);
    }

    public IEnumerable<Product> GetAllQueryRescued(string user)
    {
        return _context.Products
           .AsNoTracking()
           .Where(ProductQuery.GetAllDone(user))
           .OrderBy(x => x.Title);
    }

    public Product GetById(Guid id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }
}