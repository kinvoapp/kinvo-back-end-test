using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Aliquota.Domain.Repository
{
    class Context : DbContext
    {
        public Context() : base("DefaultConnection") { }

        public DbSet<Investment> Investments { get; set; }
    }
}
