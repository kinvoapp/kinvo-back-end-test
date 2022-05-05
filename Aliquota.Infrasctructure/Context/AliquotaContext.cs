public partial class AliquotaContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=db;User Id=admin;Password=admin;Database=aliquota");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {}
}