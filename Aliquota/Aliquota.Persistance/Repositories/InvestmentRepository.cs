using System.Collections.Generic;
using System.Threading.Tasks;
using Aliquota.Application.Interfaces.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Persistance.Contexts;
using Aliquota.Persistance.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Persistance.Repositories
{
    public class InvestmentRepository : GenericRepositoryAsync<Investment>, IInvestmentRepository
    {
        private readonly DbSet<Investment> _investments;
        public InvestmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _investments = dbContext.Set<Investment>();
        }

        public override async Task<Investment> GetByIdAsync(decimal id)
        {
            return await _investments
                .Include(inv => inv.FinancialProduct)
                .FirstOrDefaultAsync(inv => inv.Id == id);
        }

        public override async Task<IReadOnlyList<Investment>> GetAllAsync()
        {
            return await _investments
                .Include(inv => inv.FinancialProduct)
                .ToListAsync();
        }
    }
}
