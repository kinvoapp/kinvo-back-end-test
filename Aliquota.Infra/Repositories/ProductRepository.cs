using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Queries;
using Aliquota.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Repositories
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
        public void Create(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges(); //persiste os dados
        }

        public IEnumerable<Product> GetByDate(string title, DateTime date)
        {
            return _context.Product.AsNoTracking()
                        .Where(GetProductQueryResult.GetByDate(title, date))
                        .OrderBy(x => x.ApplicationDate);
        }

        public Product GetById(Guid id, string title)
        {
            return _context.Product.FirstOrDefault(x => x.Id == id && x.Title == title);
        }

        public IEnumerable<Product> GetPrices(double price)
        {
            return _context.Product.AsNoTracking()
                        .Where(GetProductQueryResult.GetPrices(price))
                        .OrderBy(x => x.ApplicationDate);
        }

        public Product GetProduct(Guid id, string title, double price)
        {
            return _context.Product.FirstOrDefault(x => x.Id == id && x.Title == title && x.Price == price);
        }

        public IEnumerable<Product> GetProducts(string title)
        {
            return _context.Product.AsNoTracking()
            .Where(GetProductQueryResult.GetProducts(title))
            .OrderBy(x => x.ApplicationDate);
            //Se não for fazer update ou delete é bom utilizar o AsNoTracking para apenas lançar os dados na tela
        }

        public Product GetTaxValue(double value)
        {
            return _context.Product.FirstOrDefault(x => x.Value == value);

        }

    }
}