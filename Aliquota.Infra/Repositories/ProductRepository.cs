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
            //return _context.Client.FirstOrDefault(x => x.Id == id);
            return _context.Client.AsNoTracking().FirstOrDefault(CreateQueriesInfos.GetClientInfo(document));
        }

        public Product GetProduct(string title)
        {
            //return _context.Product.FirstOrDefault(x => x.Id == id);
            return _context.Product.AsNoTracking().FirstOrDefault(CreateQueriesInfos.GetProductsInfo(title));
        }

        public Order GetOrder(string userDocument)
        {
            //return _context.Orders.FirstOrDefault(x => x.Id == id);
            return _context.Order.AsNoTracking().FirstOrDefault(CreateQueriesInfos.GetOrderInfo(userDocument));
        }
        // public Order ReturnIncomeTax(Order order)
        // {
        //     return _context.Orders.FirstOrDefault(x => x.TaxValue == order.TaxValue);
        // }

        public Order ReturnIncomeTax(double productTax)
        {
            return _context.Order.AsNoTracking().FirstOrDefault(CreateQueriesInfos.GetValue(productTax));
            //return _context.Orders.AsNoTracking().Where(CreateQueriesInfos.GetValue(productTax));
        }

        public Product Aliquota(string product)
        {
            return _context.Product.AsNoTracking().FirstOrDefault(CreateQueriesInfos.GetProductsInfo(product));
        }


    }
}
