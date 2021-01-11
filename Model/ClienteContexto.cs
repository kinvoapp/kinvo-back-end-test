using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Model
{
    class ClienteContexto : DbContext

    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ISLBEJJ;Initial Catalog= DB_kinvo;Integrated Security=SSPI;Persist Security Info=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Cliente> clientes { get; set; }


    }
}
