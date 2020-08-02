using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class AliquotContext: DbContext
    {
        public AliquotContext(DbContextOptions options) : base(options)
        {
        }

        protected AliquotContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Investment> Investments { get; set; }
    }
}
