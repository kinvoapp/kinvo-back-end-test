using Aliquota.Domain.Entities;
using Aliquota.Domain.Infra.Context;
using Aliquota.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Aliquota.Domain.Test.ControllersTest
{
    public class portfolioinvestimentcontrollertest
    {
        [Fact]
        public void ToApply()
        {
            var option = new DbContextOptionsBuilder<appcontext>()
                .UseInMemoryDatabase(databaseName: "ToApply")
                .Options;

            using (var context = new appcontext(option))
            {
                var application = new application();
                application.client = new client();
                application.client.id = 1;
                application.client.name = "Flávio";
                application.client.cpf = "04745578840";
                application.productfinancial = new productfinancial();
                application.productfinancial.id = 1;
                application.productfinancial.name = "Tesouro Direto";
                application.productfinancial.percentageyieldyear = 10;
                application.valueapplication = 5000;
                application.dateapplication = DateTime.Now;

                var applicationservice = new applicationservice(context);
                applicationservice.CreateApplication(application);
            }

            using (var context = new appcontext(option))
            {
                Assert.Equal(1, context.applications.Count());
                Assert.Equal(1, context.clients.Single().id);
                Assert.Equal("Flávio", context.clients.Single().name);
                Assert.Equal("04745578840", context.clients.Single().cpf);
                Assert.Equal(1, context.productfinancials.Single().id);
                Assert.Equal("Tesouro Direto", context.productfinancials.Single().name);
                Assert.Equal(10.0m, context.productfinancials.Single().percentageyieldyear);
                Assert.Equal(5000m, context.applications.Single().valueapplication);
            }
        }

        [Fact]
        public void Rescue()
        {
            var option = new DbContextOptionsBuilder<appcontext>()
                .UseInMemoryDatabase(databaseName: "Rescue")
                .Options;

            using (var context = new appcontext(option))
            {
                var application = new application();
                application.client = new client();
                application.client.id = 1;
                application.client.name = "Flávio";
                application.client.cpf = "04745578840";
                application.productfinancial = new productfinancial();
                application.productfinancial.id = 1;
                application.productfinancial.name = "Tesouro Direto";
                application.productfinancial.percentageyieldyear = 10;
                application.valueapplication = 5000;
                application.dateapplication = DateTime.Now;

                var applicationservice = new applicationservice(context);
                applicationservice.CreateApplication(application);
            }

            using (var context = new appcontext(option))
            {
                var application = new application();
                application.client = new client();
                application.client.id = 1;
                application.client.name = "Flávio";
                application.client.cpf = "04745578840";
                application.productfinancial = new productfinancial();
                application.productfinancial.id = 1;
                application.productfinancial.name = "Tesouro Direto";
                application.productfinancial.percentageyieldyear = 10;
                application.daterescue = DateTime.Now;

                var applicationservice = new applicationservice(context);
                applicationservice.RescueApplication(application);
            }

            using (var context = new appcontext(option))
            {
                Assert.Equal(1, context.clients.Single().id);
                Assert.Equal("Flávio", context.clients.Single().name);
                Assert.Equal("04745578840", context.clients.Single().cpf);
                Assert.Equal(1, context.productfinancials.Single().id);
                Assert.Equal("Tesouro Direto", context.productfinancials.Single().name);
                Assert.Equal(10.0m, context.productfinancials.Single().percentageyieldyear);
            }
        }
    }
}
