using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class AliquotaDomainContext : DbContext
    {
        public DbSet<AliquotaDomain> AliquotaDomains { get; set; }

        private static bool _created = false;
        public AliquotaDomainContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"DataSource=C:/Users/pablo/source/repos/kinvo-back-end-test/kinvo-back-end-test/kinvo-back-end-test.db");
    }
}
