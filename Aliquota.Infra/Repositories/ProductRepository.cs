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

            return true;
        }

        public IEnumerable<Client> GetClient(string document)
        {
            //return _context.Client.FirstOrDefault(x => x.Id == id);
            return _context.Client.AsNoTracking().Where(CreateQueriesInfos.GetClientInfo(document));
        }

        public IEnumerable<Product> GetProduct(string product)
        {
            //return _context.Product.FirstOrDefault(x => x.Id == id);
            return _context.Product.AsNoTracking().Where(CreateQueriesInfos.GetProductsInfo(product));
        }

        public IEnumerable<Order> GetOrder(string order)
        {
            //return _context.Orders.FirstOrDefault(x => x.Id == id);
            return _context.Orders.AsNoTracking().Where(CreateQueriesInfos.GetOrderInfo(order));
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

        public bool ProductExist(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
