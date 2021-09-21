using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Data
{
    public class InvestimentoContext : DbContext
    {
        public InvestimentoContext(DbContextOptions<InvestimentoContext> opt) : base (opt)
        {

        }

        public DbSet<Investimento> Investimentos { get; set; }
    }
}
