using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Infrastructure.DBContext
{
    public class AliquotaDBContext : DbContext
    {
        public AliquotaDBContext(DbContextOptions<AliquotaDBContext> a_options) : base(a_options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder a_optionsBuilder)
        {
            if (!a_optionsBuilder.IsConfigured)
            {
                a_optionsBuilder.UseSqlServer(getConnectionString());
            }
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Aplicacao> Aplicacao { get; set; }
        public DbSet<ProdutoFinanceiro> ProdutoFinanceiro { get; set; }


        private string getConnectionString()
        {
            string l_ConnectionSTring = "Data Source=localhost\\SQLSERVER2016; Initial Catalog=AutoloadDB_Granel; Persist Security Info=True; User ID=sa; Password=sa; Pooling=True";

            return l_ConnectionSTring;
        }
    }
}
