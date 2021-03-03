using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain;

namespace Aliquota.Domain.Data
{
    public class AplicacaoDbContext : DbContext
    {
        public AplicacaoDbContext (DbContextOptions<AplicacaoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aliquota.Domain.Aplicacao> Aplicacao { get; set; }
    }
}
