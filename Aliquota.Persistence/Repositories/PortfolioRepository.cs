using System;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Persistence.Repositories {
    public class PortfolioRepository : IPortfolioRepository
    {
        public PortfolioRepository(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; set; }

        public IQueryable<Portfolio> Portfolios 
            => Context.Portfolios.Include(p => p.Investments).ThenInclude(i => i.FinancialProduct);
        
        public void Add(Portfolio portfolio)
        {
            Context.Portfolios.Add(portfolio);
        }

        public async Task<Portfolio> GetPortfolioByOwnerIdAsync(Guid ownerId) {
            return await Portfolios.Where(p => p.OwnerId == ownerId).FirstOrDefaultAsync();
        }
    }
}