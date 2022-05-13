using System;
using Kinvo.Aliquota.Domain.Entities.Clients;
using Microsoft.EntityFrameworkCore;

namespace Kinvo.Aliquota.Domain.Database.Seeds
{
    public static class ClientSeed
    {
        public static void SeedClient(this ModelBuilder builder) =>
            builder.Entity<Client>()
                .HasData(new Client
                {
                    Id = 1,
                    Uuid = Guid.Parse("e0aa02bc-51bd-4766-bd5f-8b149b725085"),
                    Name = "Cliente Seed",
                    Active = true,
                    Cpf = "123.456.789-10",
                    CreationDate = Convert.ToDateTime("2022-05-13 09:00:00"),
                    ModificationDate = Convert.ToDateTime("2022-05-13 09:00:00")
                });
    }
}