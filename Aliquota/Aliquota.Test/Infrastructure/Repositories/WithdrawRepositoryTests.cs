using System;
using Aliquota.Domain.Entities;
using Aliquota.Persistence.Repositories;
using Aliquota.Test.Infrastructure.Repositories.Base;
using Xunit;

namespace Aliquota.Test.Infrastructure.Repositories
{
    public class WithdrawRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        public SharedDatabaseFixture Fixture { get; }

        public WithdrawRepositoryTests(SharedDatabaseFixture fixture)
        {
            Fixture = fixture;
        }


        [Fact]
        // [InlineData(DateTime.Now)]
        public async void InsertWithdrawShouldReturnIt()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var now = DateTime.Now;
                    var withdrawRepository = new WithdrawRepository(context);

                    var withdrawModel = new Withdraw
                    {
                        Amount = 2000,
                        Profit = 500,
                        InvestedTime = 20,
                        Start = now.AddDays(-20),
                        LiquidIncome = 0.05M,
                        TaxAmount = 200,
                        TaxPercentage = 0.225M
                    };

                    //act
                    var result = await withdrawRepository.AddAsync(withdrawModel);

                    //assert
                    Assert.Equal(withdrawModel, result);
                }
            }
        }

        [Fact]
        public async void GetWithdrawById()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var now = DateTime.Now;
                    var withdrawRepository = new WithdrawRepository(context);

                    var withdrawModel = new Withdraw
                    {
                        Amount = 2000,
                        Profit = 500,
                        InvestedTime = 20,
                        Start = now.AddDays(-20),
                        LiquidIncome = 0.05M,
                        TaxAmount = 200,
                        TaxPercentage = 0.225M
                    };

                    await withdrawRepository.AddAsync(withdrawModel);

                    //act
                    var result = await withdrawRepository.GetByIdAsync(withdrawModel.Id);

                    //assert
                    Assert.Equal(withdrawModel, result);
                }
            }
        }

        [Fact]
        public async void GetAllWithdraws()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var now = DateTime.Now;
                    var withdrawRepository = new WithdrawRepository(context);

                    var withdrawList = new[]
                    {
                        new Withdraw
                        {
                            Amount = 2000,
                            Profit = 500,
                            InvestedTime = 20,
                            Start = now.AddDays(-20),
                            LiquidIncome = 0.05M,
                            TaxAmount = 200,
                            TaxPercentage = 0.225M
                        },
                        new Withdraw
                        {
                            Amount = 10000,
                            Profit = 5600,
                            InvestedTime = 60,
                            Start = now.AddDays(-60),
                            LiquidIncome = 0.3M,
                            TaxAmount = 4400,
                            TaxPercentage = 0.255M
                        },
                        new Withdraw
                        {
                            Amount = 1000,
                            Profit = 900,
                            InvestedTime = 15,
                            Start = now.AddDays(-12),
                            LiquidIncome = 0.015M,
                            TaxAmount = 100,
                            TaxPercentage = 0.225M
                        }
                    };

                    foreach (var withdraw in withdrawList) await withdrawRepository.AddAsync(withdraw);

                    //act
                    var result = await withdrawRepository.GetAllAsync();

                    //assert
                    Assert.Equal(withdrawList, result);
                }
            }
        }

        [Fact]
        public async void ShouldDeleteWithdraw()
        {
            //arrange
            await using (var transaction = Fixture.Connection.BeginTransaction())
            {
                await using var context = Fixture.CreateContext(transaction);
                {
                    var now = DateTime.Now;
                    var withdrawRepository = new WithdrawRepository(context);

                    var withdrawModel = new Withdraw
                    {
                        Amount = 1000,
                        Profit = 900,
                        InvestedTime = 15,
                        Start = now.AddDays(-12),
                        LiquidIncome = 0.015M,
                        TaxAmount = 100,
                        TaxPercentage = 0.225M
                    };

                    await withdrawRepository.AddAsync(withdrawModel);

                    //act
                    await withdrawRepository.DeleteAsync(withdrawModel);
                    var result = await withdrawRepository.GetByIdAsync(withdrawModel.Id);

                    //assert
                    Assert.Null(result);
                }
            }
        }
    }
}