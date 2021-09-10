using Aliquota.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Dados
{
    class KinvoContext : DbContext
    {
        //Implementação do DB. Configurar no WebApp/Startup.cs e WebApp/appsettings.json conexão para DB.
        public KinvoContext(DbContextOptions<KinvoContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }
        public DbSet<ClienteProdutoFinanceiro> ClientesProdutoFinanceiros { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteProdutoFinanceiro>()
                .HasKey(x => new { x.ClienteId, x.ProdutoFinanceiroId });
        }

    }
}
