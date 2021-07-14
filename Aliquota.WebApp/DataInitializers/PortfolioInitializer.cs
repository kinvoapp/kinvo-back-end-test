using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.WebApp.DataInitializers
{
    public class PortfolioInitializer
    {
        private readonly AppDbContext context;

        public PortfolioInitializer(AppDbContext context)
        {
            this.context = context;
        }

        public async Task EnsurePortfoliosExist(List<Portfolio> portfolios)
        {
            foreach(var portfolio in portfolios) {
                var existingPortfolio = await context.Portfolios.Include(p => p.Owner)
                                                                .Where(p => p.Owner.Email == portfolio.Owner.Email)
                                                                .FirstOrDefaultAsync();
                if(existingPortfolio != null) {
                    context.Portfolios.Remove(existingPortfolio);
                }

                context.Portfolios.Add(portfolio);
            }
            await context.SaveChangesAsync();
        }
    }
}