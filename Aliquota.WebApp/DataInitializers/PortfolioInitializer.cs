using System.Collections.Generic;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Context;

namespace Aliquota.WebApp.DataInitializers
{
    public class PortfolioInitializer
    {
        private readonly AppDbContext context;

        public PortfolioInitializer(AppDbContext context)
        {
            this.context = context;
        }

        public void EnsurePortfoliosExist(List<Portfolio> portfolios)
        {
            context.Portfolios.AddRange(portfolios);
            context.SaveChangesAsync();
        }
    }
}