using System;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Persistence.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        public AppDbContext Context { get; set; }

        public IQueryable<Investment> Investments
            => Context.Investments.Include(i => i.FinancialProduct).Include(i => i.Portfolio);

        public async Task<Investment> GetInvestmentAsync(Guid investmentId)
        {
            return await Investments.Where(i => i.Id == investmentId).FirstOrDefaultAsync();
        }
    }
}