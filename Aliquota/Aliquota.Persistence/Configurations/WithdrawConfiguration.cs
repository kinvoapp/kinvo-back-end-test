using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Persistence.Configurations
{
    public class WithdrawConfiguration : IEntityTypeConfiguration<Withdraw>
    {
        public void Configure(EntityTypeBuilder<Withdraw> builder)
        {
            builder.Property(wd => wd.Id)
                .IsRequired()
                .HasColumnType("decimal")
                .ValueGeneratedOnAdd();

            builder.Property(wd => wd.Amount)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(wd => wd.TaxPercentage)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(wd => wd.InvestedTime)
                .HasColumnType("decimal(18)")
                .IsRequired();

            builder.Property(wd => wd.LiquidIncome)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(wd => wd.Profit)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(wd => wd.TaxAmount)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(wd => wd.Start)
                .IsRequired();
        }
    }
}