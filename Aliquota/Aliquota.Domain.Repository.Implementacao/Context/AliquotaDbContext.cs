using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Repository.Implementacao.Mapeamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Aliquota.Domain.Repository.Implementacao.Context
{
    public class AliquotaDbContext : DbContext
    {
        private string _connectionString;
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        public DbSet<SituacaoProduto> SituacaoProdutos { get; set; }
        public AliquotaDbContext(IConfiguration configuration) : base()
        {
            _connectionString = configuration.GetConnectionString("AliquotaDbContext");
        }

        public AliquotaDbContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public AliquotaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connection = new SqlConnection(_connectionString);
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new SituacaoProdutoMap());
            builder.ApplyConfiguration(new TipoProdutoMap());
        }
    }
}
