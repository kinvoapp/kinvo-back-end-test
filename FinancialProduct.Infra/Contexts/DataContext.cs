using FinancialProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialProduct.Infra.Contexts;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
          : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) { }

}