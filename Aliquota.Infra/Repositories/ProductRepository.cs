using System.Linq;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Queries;
using Aliquota.Domain.Repositories;
using Aliquota.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Infra.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public void Save(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
        }
        public void SaveOrder(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
        }
        public void SaveProduct(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }
        public bool ClientExist(string document)
        {
            return true;
        }
        public bool ProductExist(string productName)
        {
            return true;
        }
        public Client GetClient(string document)
        {
            return _context.Client.AsNoTracking().FirstOrDefault(CreateQueriesInfos.GetClientInfo(document));
        }
        public Product GetProduct(string title)
        {
            return _context.Product.AsNoTracking().FirstOrDefault(CreateQueriesInfos.GetProductsInfo(title));
        }
    }
}
