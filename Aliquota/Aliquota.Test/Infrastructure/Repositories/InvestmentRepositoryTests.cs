using System;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Enums;
using Aliquota.Persistence.Repositories;
using Aliquota.Test.Infrastructure.Repositories.Base;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Xunit;

namespace Aliquota.Test.Infrastructure.Repositories
{
    public class InvestmentRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        public SharedDatabaseFixture Fixture { get; }

        public InvestmentRepositoryTests(SharedDatabaseFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public async void InsertInvestmentShouldReturnIt()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var investmentRepository = new InvestmentRepository(context);

                    var inv = new Investment
                    {
                        Amount = 1000,
                        Start = DateTime.Now,
                        FinancialProductId = 1,
                        FinancialProduct = new FinancialProduct
                        {
                            Deadline = Deadline.AtLeastOneYear,
                            MinimalInvestedAmount = 1000,
                            MonthlyIncome = 0.025M,
                            Name = "Test",
                            Profitability = Profitability.High
                        }
                    };

                    //act
                    var result = await investmentRepository.AddAsync(inv);

                    //assert
                    Assert.Equal(result, inv);
                }
            }
        }

        [Fact]
        public async void GetInvestmentById()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var investmentRepository = new InvestmentRepository(context);

                    var inv = new Investment
                    {
                        Amount = 1000,
                        Start = DateTime.Now,
                        FinancialProductId = 1,
                        FinancialProduct = new FinancialProduct
                        {
                            Deadline = Deadline.AtLeastOneYear,
                            MinimalInvestedAmount = 1000,
                            MonthlyIncome = 0.025M,
                            Name = "Test",
                            Profitability = Profitability.High
                        }
                    };

                    //act
                    await investmentRepository.AddAsync(inv);

                    var result = await investmentRepository.GetByIdAsync(inv.Id);

                    Assert.Equal(inv.Id, result.Id);
                }
            }
        }

        [Fact]
        public async void GetAllInvestments()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var investmentRepository = new InvestmentRepository(context);

                    var invList = new[]
                    {
                        new Investment
                        {
                            Amount = 1000,
                            Start = DateTime.Now,
                            FinancialProductId = 1,
                            FinancialProduct = new FinancialProduct
                            {
                                Deadline = Deadline.AtLeastOneYear,
                                MinimalInvestedAmount = 1000,
                                MonthlyIncome = 0.025M,
                                Name = "Test",
                                Profitability = Profitability.High
                            }
                        },
                        new Investment
                        {
                            Amount = 2500,
                            Start = DateTime.Now,
                            FinancialProductId = 1,
                            FinancialProduct = new FinancialProduct
                            {
                                Deadline = Deadline.AtLeastOneYear,
                                MinimalInvestedAmount = 1000,
                                MonthlyIncome = 0.025M,
                                Name = "Test",
                                Profitability = Profitability.High
                            }
                        },
                        new Investment
                        {
                            Amount = 700,
                            Start = DateTime.Now,
                            FinancialProductId = 2,
                            FinancialProduct = new FinancialProduct
                            {
                                Deadline = Deadline.MoreThanTwoYears,
                                MinimalInvestedAmount = 200,
                                MonthlyIncome = 0.05M,
                                Name = "Test 2",
                                Profitability = Profitability.Uncertain
                            }
                        },
                        new Investment
                        {
                            Amount = 1000,
                            Start = DateTime.Now,
                            FinancialProductId = 2,
                            FinancialProduct = new FinancialProduct
                            {
                                Deadline = Deadline.MoreThanTwoYears,
                                MinimalInvestedAmount = 200,
                                MonthlyIncome = 0.05M,
                                Name = "Test 2",
                                Profitability = Profitability.Uncertain
                            }
                        }
                    };
                    foreach (var investment in invList)
                        await investmentRepository.AddAsync(investment);

                    //act
                    var result = await investmentRepository.GetAllAsync();

                    Assert.Equal(invList, result);
                }
            }
        }

        [Fact]
        public async void ShouldDeleteInvestment()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var investmentRepository = new InvestmentRepository(context);

                    var inv = new Investment
                    {
                        Amount = 1000,
                        Start = DateTime.Now,
                        FinancialProductId = 1,
                        FinancialProduct = new FinancialProduct
                        {
                            Deadline = Deadline.AtLeastOneYear,
                            MinimalInvestedAmount = 1000,
                            MonthlyIncome = 0.025M,
                            Name = "Test",
                            Profitability = Profitability.High
                        }
                    };

                    //act
                    await investmentRepository.AddAsync(inv);

                    await investmentRepository.DeleteAsync(inv);

                    var result = await investmentRepository.GetByIdAsync(inv.Id);

                    Assert.Null(result);
                }
            }
        }
    }
}