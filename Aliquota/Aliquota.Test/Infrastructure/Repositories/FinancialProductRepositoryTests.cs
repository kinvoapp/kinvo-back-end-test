using Aliquota.Domain.Entities;
using Aliquota.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Persistence.Repositories;
using Aliquota.Test.Infrastructure.Repositories.Base;
using Xunit;

namespace Aliquota.Test.Infrastructure.Repositories
{
    public class FinancialProductRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        public SharedDatabaseFixture Fixture { get; }

        public FinancialProductRepositoryTests(SharedDatabaseFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public async void InsertFinancialProductShouldReturnIt()
        {
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using (var context = Fixture.CreateContext(transaction))
                {
                    var financialProductRepository = new FinancialProductRepository(context);

                    var fpModel = new FinancialProduct
                    {
                        Deadline = Deadline.AtLeastOneYear,
                        MinimalInvestedAmount = 1000,
                        MonthlyIncome = 0.025M,
                        Name = "Test",
                        Profitability = Profitability.High
                    };

                    //act
                    var result = await financialProductRepository.AddAsync(fpModel);

                    //assert
                    Assert.Equal(result, fpModel);
                }
            }
        }

        [Fact]
        public async void GetFinancialProductById()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var financialProductRepository = new FinancialProductRepository(context);

                    var fpModel = new FinancialProduct
                    {
                        Deadline = Deadline.AtLeastOneYear,
                        MinimalInvestedAmount = 1000,
                        MonthlyIncome = 0.025M,
                        Name = "Test",
                        Profitability = Profitability.High
                    };

                    //act
                    await financialProductRepository.AddAsync(fpModel);

                    var result = await financialProductRepository.GetByIdAsync(fpModel.Id);

                    //assert
                    Assert.Equal(fpModel.Id, result.Id);
                }
            }
        }

        [Fact]
        public async void GetAllFinancialProducts()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var financialProductRepository = new FinancialProductRepository(context);

                    var fpList = new List<FinancialProduct>
                    {
                        new()
                        {
                            Deadline = Deadline.AtLeastOneYear,
                            MinimalInvestedAmount = 1000,
                            MonthlyIncome = 0.025M,
                            Name = "Test",
                            Profitability = Profitability.High
                        },
                        new()
                        {
                            Deadline = Deadline.AtLeastOneYear,
                            MinimalInvestedAmount = 2000,
                            MonthlyIncome = 0.025M,
                            Name = "Test 2",
                            Profitability = Profitability.Low
                        },
                        new()
                        {
                            Deadline = Deadline.AtLeastOneYear,
                            MinimalInvestedAmount = 500,
                            MonthlyIncome = 0.025M,
                            Name = "Test 3",
                            Profitability = Profitability.Uncertain
                        }
                    };

                    //act
                    foreach (var fp in fpList) await financialProductRepository.AddAsync(fp);

                    IEnumerable<FinancialProduct> result = await financialProductRepository.GetAllAsync();

                    result = result.TakeLast(3);

                    //assert
                    Assert.Equal(result, fpList);
                }
            }
        }

        [Fact]
        public async void ShouldDeleteFinancialProduct()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var financialProductRepository = new FinancialProductRepository(context);

                    var fpModel = new FinancialProduct
                    {
                        Deadline = Deadline.AtLeastOneYear,
                        MinimalInvestedAmount = 1000,
                        MonthlyIncome = 0.025M,
                        Name = "Test",
                        Profitability = Profitability.High
                    };

                    //act
                    await financialProductRepository.AddAsync(fpModel);
                    await financialProductRepository.DeleteAsync(fpModel);

                    var result = await financialProductRepository.GetByIdAsync(fpModel.Id);

                    //assert
                    Assert.Null(result);
                }
            }
        }
    }
}