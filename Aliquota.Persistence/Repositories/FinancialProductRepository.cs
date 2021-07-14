using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Persistence.Repositories {
    public class FinancialProductRepository : IFinancialProductRepository
    {
        public FinancialProductRepository(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; set; }

        public IQueryable<FinancialProduct> FinancialProducts
            => Context.FinancialProducts;

        public async Task<List<FinancialProduct>> GetProductsAsync()
        {
            return await FinancialProducts.ToListAsync();
        }

        public async Task<FinancialProduct> GetProductAsync(Guid productId)
        {
            return await FinancialProducts.FirstOrDefaultAsync(p => p.Id == productId);
        }
    }
}