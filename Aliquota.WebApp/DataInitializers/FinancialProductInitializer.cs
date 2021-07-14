using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.WebApp.DataInitializers
{
    public class FinancialProductInitializer
    {
        private readonly AppDbContext context;

        public FinancialProductInitializer(AppDbContext context)
        {
            this.context = context;
        }

        public async Task EnsureFinancialProductsExist(List<FinancialProduct> products)
        {
            bool changed = false;
            foreach (var product in products)
            {
                if (!await context.FinancialProducts.AnyAsync(fp => fp.Name == product.Name))
                {
                    context.Add(product);
                    changed = true;
                }
            }

            if(changed) {
                await context.SaveChangesAsync();
            }
        }
    }
}