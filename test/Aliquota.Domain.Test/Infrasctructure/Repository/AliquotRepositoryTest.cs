using Moq;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using Aliquota.Infrastructure.Context;
using Aliquota.Domain.Entities;
using Aliquota.Infrastructure.Repository;

namespace Aliquota.Domain.Test.Infrastructure.Repository
{
    public class AliquotRepositoryTest
    {
        private Mock<DbSet<Application>> mockApplication;
        private Mock<DbSet<Client>> mockClient;
        private Mock<PostgresContext> mockContext;
        private AliquotRepository repository;

        public AliquotRepositoryTest()
        {
            var clients = new List<Client>
            {
                new Client() {Id = 1, FantasyName = "Fulano", Document = "000.000.000-00" },
                new Client() {Id = 2, FantasyName = "Beltrano", Document = "999.999.999-99" }
            }.AsQueryable();
            mockClient = new Mock<DbSet<Client>>();
            mockClient.As<IQueryable<Client>>().Setup(c => c.Provider).Returns(clients.Provider);
            mockClient.As<IQueryable<Client>>().Setup(c => c.Expression).Returns(clients.Expression);
            mockClient.As<IQueryable<Client>>().Setup(c => c.ElementType).Returns(clients.ElementType);
            mockClient.As<IQueryable<Client>>().Setup(c => c.GetEnumerator()).Returns(clients.GetEnumerator());

            var applications = new List<Application>
            {   new Application()
                {
                    Client = new Client() { FantasyName = "Fulano", Id = 1, Document = "000.000.000-00"},
                    ClientId = 1,
                    ApplicationDate = Convert.ToDateTime("2020-06-10"),
                    ApplicationValue = 1000,
                    IsActive = false,
                    WithdrawDate = Convert.ToDateTime("2021-06-9"),
                    WithdrawValue = 775
                },
                new Application()
                {
                    Client = new Client() { FantasyName = "Beltrano", Id = 2, Document = "999.999.999-99" },
                    ClientId = 2,
                    ApplicationDate = Convert.ToDateTime("2020-06-10"),
                    ApplicationValue = 2000,
                    IsActive = true
                }

            }.AsQueryable();
            mockApplication = new Mock<DbSet<Application>>();
            mockApplication.As<IQueryable<Application>>().Setup(c => c.Provider).Returns(applications.Provider);
            mockApplication.As<IQueryable<Application>>().Setup(c => c.Expression).Returns(applications.Expression);
            mockApplication.As<IQueryable<Application>>().Setup(c => c.ElementType).Returns(applications.ElementType);
            mockApplication.As<IQueryable<Application>>().Setup(c => c.GetEnumerator()).Returns(applications.GetEnumerator());

            mockContext = new Mock<PostgresContext>();

            mockContext.Setup(m => m.Clients).Returns(mockClient.Object);
            mockContext.Setup(m => m.Applications).Returns(mockApplication.Object);

            repository = new AliquotRepository(mockContext.Object);
        }

        [Fact]
        public void ShoudlReturnApplication()
        {
            //Act
            var result = repository.GetApplication(It.IsAny<int>());

            //Assert
            Assert.IsType<Application>(result);
        }

        [Fact]
        public void ShouldAddApplicationInDb()
        {
            //Arranje
            Application applicationTest = new Application()
            {
                Client = new Client() { FantasyName = "Fulano", Id = 1 },
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = 1000,
                IsActive = true
            };
            //Act
            repository.Apply(applicationTest);

            //Assert
            mockApplication.Verify(e => e.Add(It.IsAny<Application>()), Times.Once);
            mockContext.Verify(e => e.SaveChanges(), Times.Once);

        }

        [Fact]
        public void ShouldUpdateApplicationInDb()
        {
            //Arranje
            Application applicationTest = new Application()
            {
                Client = new Client() { FantasyName = "Fulano", Id = 1 },
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = 1000,
                IsActive = false,
                WithdrawDate = Convert.ToDateTime("2021-06-9"),
                WithdrawValue = 775
            };

            //Act
            repository.Withdraw(applicationTest);

            //Assert
            mockApplication.Verify(e => e.Attach(It.IsAny<Application>()), Times.Once);
            mockContext.Verify(e => e.SaveChanges(), Times.Once);


        }

    }
}