using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Application.Features.FinancialProducts.Queries;
using Aliquota.Application.Features.FinancialProductss.Queries;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Xunit;
using static Aliquota.Test.Application.Base.TestingBaseFixture;

namespace Aliquota.Test.Application.Queries
{
    [Collection("CollectionFixture")]
    public class FinancialProductQueriesTests
    {
        [Fact]
        public async Task ShouldReturnAllFinancialProducts()
        {
            //arrange
            var financialProducts = new List<FinancialProduct>()
            {
                new FinancialProduct()
                {
                    Name = "Test Financial Product Queries",
                    Deadline = Deadline.AtLeastOneYear,
                    Profitability = Profitability.High,
                    MonthlyIncome = 0.50M,
                    MinimalInvestedAmount = 250
                },
                new FinancialProduct()
                {
                    Name = "Test Financial Product Queries 3",
                    Deadline = Deadline.AtLeastOneYear,
                    Profitability = Profitability.High,
                    MonthlyIncome = 0.50M,
                    MinimalInvestedAmount = 250
                },
                new FinancialProduct()
                {
                    Name = "Test Financial Product Queries 2",
                    Deadline = Deadline.AtLeastOneYear,
                    Profitability = Profitability.High,
                    MonthlyIncome = 0.50M,
                    MinimalInvestedAmount = 250
                }
            };

            await AddAsync(financialProducts);

            //act
            var query = new GetAllFinancialProductQuery();
            var result = await SendAsync(query);

            //assert
            Assert.Equal(financialProducts.Count(), result.Count());
        }

        [Fact]
        public async Task GetFinancialProductByIdShouldReturnIt()
        {
            //arrange
            IEnumerable<FinancialProduct> financialProducts = new List<FinancialProduct>()
            {
                new FinancialProduct()
                {
                    Name = "Test Financial Product Queries by id",
                    Deadline = Deadline.AtLeastOneYear,
                    Profitability = Profitability.High,
                    MonthlyIncome = 0.50M,
                    MinimalInvestedAmount = 250
                }
            };

            financialProducts  = await AddAsync(financialProducts);

            //act
            var query = new GetFinancialProductByIdQuery() { Id = financialProducts.FirstOrDefault().Id};
            var result = await SendAsync(query);

            //assert
            Assert.Equal(financialProducts.FirstOrDefault().Name , result.Name);

            DeleteAsync(financialProducts.FirstOrDefault());
        }
    }
}