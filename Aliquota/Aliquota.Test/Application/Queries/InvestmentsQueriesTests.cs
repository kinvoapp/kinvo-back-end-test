using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Application.Features.Investments.Queries;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Enums;
using Xunit;
using static Aliquota.Test.Application.Base.TestingBaseFixture;

namespace Aliquota.Test.Application.Queries
{
    [Collection("CollectionFixture")]
    public class InvestmentsQueriesTests
    {
        [Fact]
        public async Task GetAllInvestments()
        {
            //arrange
            IEnumerable<FinancialProduct> financialProducts = new List<FinancialProduct>()
            {
                new FinancialProduct()
                {
                    Name = "Test Investment Queries",
                    Deadline = Deadline.AtLeastOneYear,
                    Profitability = Profitability.High,
                    MonthlyIncome = 0.50M,
                    MinimalInvestedAmount = 250
                }
            };

            financialProducts = await AddAsync(financialProducts);

            IEnumerable<Investment> investments = new List<Investment>()
            {
                new Investment()
                {
                    Amount = 2000,
                    Start = DateTime.Now.AddYears(-3),
                    FinancialProductId = financialProducts.FirstOrDefault().Id
                },
                new Investment()
                {
                    Amount = 5000,
                    Start = DateTime.Now.AddYears(-2),
                    FinancialProductId = financialProducts.FirstOrDefault().Id
                },
                new Investment()
                {
                    Amount = 10000,
                    Start = DateTime.Now.AddYears(-1),
                    FinancialProductId = financialProducts.FirstOrDefault().Id
                },
            };

            investments = await AddAsync(investments);

            //act
            var query = new GetAllInvestmentsQuery();
            var result = await SendAsync(query);

            //assert
            Assert.Equal(investments.Count(), result.Count());
        }

        [Fact]
        public async Task GetInvestmentByIdShouldReturnIt()
        {
            //arrange
            IEnumerable<FinancialProduct> financialProducts = new List<FinancialProduct>()
            {
                new FinancialProduct()
                {
                    Name = "Test Investment Queries",
                    Deadline = Deadline.AtLeastOneYear,
                    Profitability = Profitability.High,
                    MonthlyIncome = 0.50M,
                    MinimalInvestedAmount = 250
                }
            };

            financialProducts = await AddAsync(financialProducts);

            IEnumerable<Investment> investments = new List<Investment>()
            {
                new Investment()
                {
                    Amount = 2000,
                    Start = DateTime.Now.AddYears(-3),
                    FinancialProductId = financialProducts.FirstOrDefault().Id
                }
            };

            investments = await AddAsync(investments);

            //act
            var query = new GetInvestmentByIdQuery(){ Id = investments.FirstOrDefault().Id};
            var result = await SendAsync(query);

            //assert
            Assert.Equal(investments.FirstOrDefault().Id, result.Id);
            Assert.Equal(investments.FirstOrDefault().Amount, result.Amount);
            Assert.Equal(investments.FirstOrDefault().FinancialProductId, result.FinancialProductId);
        }
    }
}