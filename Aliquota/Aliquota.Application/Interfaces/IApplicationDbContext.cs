using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<FinancialProduct> FinancialProducts { get; set; }
        DbSet<Investment> Investments { get; set; }
    }
}
