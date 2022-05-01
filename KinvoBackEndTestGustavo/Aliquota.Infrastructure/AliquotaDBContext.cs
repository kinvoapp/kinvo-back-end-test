using Aliquota.Domain.AplicacaoModule;
using Aliquota.Domain.ProdutoModule;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Infrastructure
{
    public class AliquotaDBContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Aplicacao> Aplicacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=localhost\MSSQLSERVER01;Initial Catalog=KinvoBackEndTest;Integrated Security=True");
        }
    }
}
