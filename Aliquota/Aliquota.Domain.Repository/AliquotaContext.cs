using Aliquota.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Repository
{
    public class AliquotaContext : DbContext
    {
        //Metodo construtor
        public AliquotaContext(DbContextOptions<AliquotaContext> options) : base(options)
        {
        }

        public DbSet<Cliente> CLIENTES { get; set; }
        public DbSet<Investimento> INVESTIMENTOS { get; set; }
        public DbSet<Resgate> RESGATES { get; set; }
    }
}
