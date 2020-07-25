using Aliquota.Domain.Infra.Context;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test.ServicesTest
{
    public class productfinancialtest
    {
        [Fact]
        public void CreateProductFinancial()
        {
            var option = new DbContextOptionsBuilder<appcontext>()
                .UseInMemoryDatabase(databaseName: "CreateProductFinancial")
                .Options;

            using (var context = new appcontext(option))
            {
                var productfinancial = new productfinancial();
                productfinancial.name = "Tesouro Direto";
                productfinancial.percentageyieldyear = 10;

                var productfinancialservice = new productfinancialservice(context);
                productfinancialservice.CreateProductFinancial(productfinancial);
            }

            using (var context = new appcontext(option))
            {
                Assert.Equal(1, context.productfinancials.Count());
                Assert.Equal("Tesouro Direto", context.productfinancials.Single().name);
                Assert.Equal(10.0m, context.productfinancials.Single().percentageyieldyear);
                Assert.Equal(1, context.productfinancials.Single().id);
            }
        }

        [Fact]
        public void SearchProductFinancial()
        {
            var option = new DbContextOptionsBuilder<appcontext>()
                .UseInMemoryDatabase(databaseName: "SearchProductFinancial")
                .Options;

            using (var context = new appcontext(option))
            {
                var productfinancial = new productfinancial();
                productfinancial.name = "Tesouro Direto";

                var productfinancialservice = new productfinancialservice(context);
                productfinancialservice.CreateProductFinancial(productfinancial);
            }

            using (var context = new appcontext(option))
            {
                var productfinancial = new productfinancial();
                productfinancial.name = "Tesouro Direto";

                var productfinancialservice = new productfinancialservice(context);
                productfinancial productfinancials = productfinancialservice.SearchProductFinancial(productfinancial);

                Assert.Equal("Tesouro Direto", productfinancials.name);
                Assert.Equal(1, productfinancials.id);
            }
        }
    }
}
