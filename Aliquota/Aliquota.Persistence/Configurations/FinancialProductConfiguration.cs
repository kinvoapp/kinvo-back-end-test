using System.Collections;
using System.Collections.Generic;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Enums;
using Aliquota.Persistence.Configurations.DataInitializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Persistence.Configurations
{
    public class FinancialProductConfiguration : IEntityTypeConfiguration<FinancialProduct>
    {
        private class FinancialProductDataInitializer : DataInitializer<FinancialProduct>
        {
            protected override IEnumerable<FinancialProduct> GetData()
            {
                return new List<FinancialProduct>()
                {
                    new("ABEV1", 0.0289M, Profitability.Low, Deadline.AtLeastOneYear, 17.10M) {Id = 1},
                    new("ABEV2", -0.0048M, Profitability.High, Deadline.MoreThanTwoYears, 100.69M) {Id = 2},
                    new("ABEV3", 0.3M, Profitability.Medium, Deadline.BetweenOneYearOrTwo, 2.48M) {Id = 3},
                    new("ABEV4", -0.064M, Profitability.Uncertain, Deadline.AtLeastOneYear, 32.78M) {Id = 4},
                    new("ABEV5", 0.0397M, Profitability.High, Deadline.MoreThanTwoYears, 48.88M) {Id = 5}
                };
            }
        }

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

            builder.HasData(new FinancialProductDataInitializer().Data);
        }
    }
}