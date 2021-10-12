﻿using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
