using Aliquota.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Infrastructure.Data.Configuration
{
    class FinancialApplicationConfiguration : IEntityTypeConfiguration<FinancialApplication>
    {
        public void Configure(EntityTypeBuilder<FinancialApplication> builder)
        {
            builder.Property(a => a.DateApplication).IsRequired();
            builder.Property(a => a.Investiment).IsRequired();
            
        }
    }
}
