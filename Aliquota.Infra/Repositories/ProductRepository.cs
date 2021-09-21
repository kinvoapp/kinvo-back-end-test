using System;
using System.Linq;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Repositories;
using Aliquota.Infra.Context;

namespace Aliquota.Domain.Infra.Repositories
{
    //CQRS
    //Leitura e Escrita
    //Perde um pouco em performance 
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public bool ClientExist(string document)
        {
            _context.Client.Find(document);
            //_context.SaveChanges(); 
            return true;
        }

        public Client GetById(Guid id)
        {
            return _context.Client.FirstOrDefault(x => x.Id == id);
        }

        public Product GetByProductId(Guid id)
        {
            return _context.Product.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void SaveProduct(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }
    }
}
