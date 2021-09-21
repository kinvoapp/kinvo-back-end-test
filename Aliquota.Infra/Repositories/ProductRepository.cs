using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Queries;
using Aliquota.Domain.Repositories;
using Aliquota.Infra.Context;
using Microsoft.EntityFrameworkCore;

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
        public bool ClientExist(string document)
        {
            //if(_context.Client.Where(_context.Clie));
            //implementar sistema de verificação
            //_context.SaveChanges(); 
            return true;
        }

        public IEnumerable<Client> GetById(Guid id)
        {
            //return _context.Client.FirstOrDefault(x => x.Id == id);
            return _context.Client.AsNoTracking().Where(CreateQueriesInfos.GetClientInfo(id));
        }

        public IEnumerable<Product> GetByProductId(Guid id)
        {
            //return _context.Product.FirstOrDefault(x => x.Id == id);
            return _context.Product.AsNoTracking().Where(CreateQueriesInfos.GetProductsInfo(id));
        }

        public IEnumerable<Order> GetOrderById(Guid id)
        {
            //return _context.Orders.FirstOrDefault(x => x.Id == id);
            return _context.Orders.AsNoTracking().Where(CreateQueriesInfos.GetOrderInfo(id));
        }
        // public Order ReturnIncomeTax(Order order)
        // {
        //     return _context.Orders.FirstOrDefault(x => x.TaxValue == order.TaxValue);
        // }

        public Order ReturnIncomeTax(double productTax)
        {
            return _context.Orders.AsNoTracking().FirstOrDefault(CreateQueriesInfos.GetValue(productTax));
            //return _context.Orders.AsNoTracking().Where(CreateQueriesInfos.GetValue(productTax));
        }


    }
}
