using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Banco de Dados que estou usando está em minha máquina
            optionsBuilder.UseSqlServer("Data Source=JOAO-RODRIGUES; Initial Catalog=KinvoDB; Integrated Security=True");
        }
    }
}