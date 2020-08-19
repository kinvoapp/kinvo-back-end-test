using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Entities;

namespace Aliquota.Data.Context
{
    public class AliquotaContext: DbContext
    {
        public AliquotaContext(DbContextOptions<AliquotaContext> options) : base(options)
        {

        }
        public DbSet<AplicacaoRF> AplicacoesRF { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        
    }
}