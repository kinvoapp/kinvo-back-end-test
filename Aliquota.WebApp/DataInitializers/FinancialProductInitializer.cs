using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Context;

namespace Aliquota.WebApp.DataInitializers {
    public class FinancialProductInitializer {
        private readonly AppDbContext context;

        public FinancialProductInitializer(AppDbContext context)
        {
            this.context = context;
        }

        public void EnsureFinancialProductsExist(List<FinancialProduct> products) {
            foreach(var product in products) {
                if (!context.FinancialProducts.Any(fp => fp.Name == product.Name)) {
                    context.Add(product);
                }
            }

            context.SaveChanges();
        }
    }
}