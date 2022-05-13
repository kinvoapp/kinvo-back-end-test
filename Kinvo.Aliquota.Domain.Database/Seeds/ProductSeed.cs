using System;
using Kinvo.Aliquota.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Kinvo.Aliquota.Domain.Database.Seeds
{
    internal static class ProductSeed
    {
        public static void SeedProduct(this ModelBuilder builder) =>
            builder.Entity<Product>()
                .HasData(new Product
                {
                    Id = 1,
                    Name = "FIIS",
                    Uuid = Guid.Parse("36c7d034-8baf-4e4a-a8f2-6c1cfc27fca0"),
                    Income = 2,
                    Active = true,
                    CreationDate = Convert.ToDateTime("2022-05-13 09:00:00"),
                    ModificationDate = Convert.ToDateTime("2022-05-13 09:00:00")
                });
    }
}