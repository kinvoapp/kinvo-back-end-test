using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Services.Exceptions;

namespace Aliquota.Domain.Services
{
    public class ProductService
    {
        private readonly AliquotaDomainContext _context;

        public ProductService(AliquotaDomainContext context)
        {
            _context = context;
        }

        public List<Product> FindAll()
        {
            return _context.Product.ToList();
        }

        public void Insert(Product obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Product FindById(int _id)
        {
            return _context.Product.Include(obj => obj.Client).FirstOrDefault(obj => obj.productId == _id);
        }

        public void Remove(int _id)
        {
            var obj = _context.Product.Find(_id);
            _context.Product.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Product obj)
        {
            if (!_context.Product.Any(x => x.productId == obj.productId))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
