using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KinvoEstagio.Models;

namespace KinvoEstagio.Data
{
    public class KinvoEstagioContext : DbContext
    {
        public KinvoEstagioContext (DbContextOptions<KinvoEstagioContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<KinvoEstagio.Models.Cliente> Cliente { get; set; }
    }
}
