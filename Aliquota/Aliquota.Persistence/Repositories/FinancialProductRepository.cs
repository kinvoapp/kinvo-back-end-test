using System.Threading.Tasks;
using Aliquota.Application.Interfaces.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Contexts;
using Aliquota.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Persistence.Repositories
{
    public class FinancialProductRepository : GenericRepositoryAsync<FinancialProduct>, IFinancialProductRepository
    {
        private readonly DbSet<FinancialProduct> _financialProducts;

        public FinancialProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _financialProducts = dbContext.Set<FinancialProduct>();
        }

        public Task<bool> IsNameUnique(string name)
        {
            return _financialProducts.AllAsync(fp => fp.Name != name);
        }
    }
}