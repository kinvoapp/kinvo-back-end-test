using System.Linq;
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
            => Context.Portfolios.Include(p => p.Owner)
                                 .Include(p => p.Investments);
        
        public void Add(Portfolio portfolio)
        {
            Context.Portfolios.Add(portfolio);
        }
    }
}