using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Models;

namespace Aliquota.Domain.Data
{
    public class AliquotaDomainContext : DbContext
    {
        public AliquotaDomainContext (DbContextOptions<AliquotaDomainContext> options)
            : base(options)
        {
        }

        public DbSet<Aliquota.Domain.Models.Client> Client { get; set; }
        public DbSet<Aliquota.Domain.Models.Product> Product { get; set; }
        public DbSet<Aliquota.Domain.Models.IR_Record> IR_Record { get; set; }
    }
}
