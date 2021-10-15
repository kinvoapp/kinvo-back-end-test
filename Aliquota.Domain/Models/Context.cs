using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Models
{
    public class Context:DbContext
    {  
        public DbSet<Application> Applications { get; set; }
        public DbSet<Rescue> Rescues { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Desafio;Integrated Security=True");
        }

        
        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
        
    }
}
