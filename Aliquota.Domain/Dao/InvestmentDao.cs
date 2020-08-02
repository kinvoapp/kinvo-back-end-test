using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Dao
{
    public class InvestmentDao : BaseDao<Investment, int>
    {
        public InvestmentDao(DbSet<Investment> dbSet) : base(dbSet)
        {
        }
    }
}
