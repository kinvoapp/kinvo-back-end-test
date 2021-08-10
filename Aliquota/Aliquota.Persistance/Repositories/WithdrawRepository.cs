using Aliquota.Application.Interfaces.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Persistance.Contexts;
using Aliquota.Persistance.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Persistance.Repositories
{
    public class WithdrawRepository : GenericRepositoryAsync<Withdraw>, IWithdrawRepository
    {
        private readonly DbSet<Withdraw> _withdraws;
        public WithdrawRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _withdraws = dbContext.Set<Withdraw>();
        }
    }
}
