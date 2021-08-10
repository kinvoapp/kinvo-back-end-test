using System.Collections.Generic;
using System.Threading.Tasks;
using Aliquota.Application.Interfaces.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Contexts;
using Aliquota.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Persistence.Repositories
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