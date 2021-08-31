using Domain.Aliquiota;
using Microsoft.EntityFrameworkCore;





namespace Repository
{
    public class Context : DbContext

    {
        public Context(DbContextOptions<Context> options)
         : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Investimento> Investimentos { get; set; }

    }
}
