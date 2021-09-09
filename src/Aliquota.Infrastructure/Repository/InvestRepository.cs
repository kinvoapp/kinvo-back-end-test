using Aliquota.Business.Interfaces;
using Aliquota.Domain.Entitys;
using Aliquota.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Infrastructure.Repository
{
    public class InvestRepository : IInvestRepository
    {
        private readonly ClientContext context;

        public InvestRepository(ClientContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Invest>> GetInvestsAsync()
        {
            return await context.Invests.AsNoTracking().ToListAsync();
        }

        public async Task<Invest> GetInvestAsync(int id)
        {
            return await context.Invests.FindAsync(id);
        }



        public async Task<Invest> UpdateInvestAsync(Invest invest)
        {
            var attInvest = await context.Invests.FindAsync(invest.InvestId);
            if (attInvest == null)
            {
                return null;
            }

            context.Entry(attInvest).CurrentValues.SetValues(invest);
            await context.SaveChangesAsync();

            return attInvest;
        }

        public async Task<Invest> InsertInvestAsync(Invest invest)
        {
            await context.AddAsync(invest);
            await context.SaveChangesAsync();

            return invest;

        }

        public async Task DeleteInvesAsync(int id)
        {
            var attInvest = await context.Invests.FindAsync(id);

            if (attInvest == null)
            {
                return;
            }
            
            context.Invests.Remove(attInvest);
            await context.SaveChangesAsync();
        }

        public async Task<Invest> RescueInvestAsync(Invest invest)
        {
            var attRescue = await context.Invests.FindAsync(invest.InvestId);
            if (attRescue == null)
            {
                return null;
            }

            context.Entry(attRescue.InvestedValue).CurrentValues.SetValues(invest.InvestedValue);
            await context.SaveChangesAsync();

            return attRescue;

        }

    }
}
