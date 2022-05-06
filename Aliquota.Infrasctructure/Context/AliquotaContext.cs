using Microsoft.EntityFrameworkCore;

public partial class AliquotaContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL("server=db;database=aliquota;user=admin;password=admin");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {}
}