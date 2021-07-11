using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using Aliquota.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly AliquotaDbContext _aliquotaDbContext;

        public InvestmentRepository(AliquotaDbContext aliquotaDbContext)
        {
            _aliquotaDbContext = aliquotaDbContext;
        }

        public List<Investment> FindAll()
        {
            return _aliquotaDbContext.Investments.ToList();
        }

        public Investment GetById(int id)
        {
            return _aliquotaDbContext.Investments.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Investment investment)
        {
            _aliquotaDbContext.Investments.Add(investment);
            _aliquotaDbContext.SaveChanges();
        }

        public void Update(Investment investment)
        {
            _aliquotaDbContext.Investments.Update(investment);
            _aliquotaDbContext.SaveChanges();
        }
    }
}
