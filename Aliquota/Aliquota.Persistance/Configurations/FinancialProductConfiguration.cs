using Aliquota.Domain.Entities;
using Aliquota.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Persistance.Configurations
{
    public class FinancialProductConfiguration : IEntityTypeConfiguration<FinancialProduct>
    {
        public void Configure(EntityTypeBuilder<FinancialProduct> builder)
        {
            builder.Property(fp => fp.Id)
                .IsRequired()
                .HasColumnType("decimal")
                .ValueGeneratedOnAdd();

            builder.Property(fp => fp.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(fp => fp.MinimalInvestedAmount)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(fp => fp.Profitability)
                .IsRequired();

            builder.Property(fp => fp.MonthlyIncome)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(fp => fp.Deadline)
                .IsRequired();

            builder.HasData(
                new FinancialProduct("ABEV1", 0.0289M, Profitability.Low, Deadline.AtLeastOneYear, 17.10M) { Id = 1 },
                new FinancialProduct("ABEV2", -0.0048M, Profitability.High, Deadline.MoreThanTwoYears, 100.69M) { Id = 2 },
                new FinancialProduct("ABEV3", 0.3M, Profitability.Medium, Deadline.BetweenOneYearOrTwo, 2.48M) { Id = 3 },
                new FinancialProduct("ABEV4", -0.064M, Profitability.Uncertain, Deadline.AtLeastOneYear, 32.78M) { Id = 4 },
                new FinancialProduct("ABEV5", 0.0397M, Profitability.High, Deadline.MoreThanTwoYears, 48.88M) { Id = 5 }
            );
        }
    }
}
