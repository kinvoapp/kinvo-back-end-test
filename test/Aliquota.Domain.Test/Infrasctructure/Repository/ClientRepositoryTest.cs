using Moq;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using Aliquota.Infrastructure.Context;
using Aliquota.Domain.Entities;
using Aliquota.Infrastructure.Repository;


namespace Aliquota.Domain.Test.Infrasctructure.Repository
{
    public class ClientRepositoryTest
    {
        private Mock<DbSet<Client>> mockClient;
        private Mock<PostgresContext> mockContext;
        private ClientRepository repository;

        public ClientRepositoryTest()
        {
            var clients = new List<Client>
            {
                new Client() {FantasyName = "Fulano", Document = "000.000.000-00" },
                new Client() {FantasyName = "Beltrano", Document = "999.999.999-99" }
            }.AsQueryable();
            mockClient = new Mock<DbSet<Client>>();
            mockClient.As<IQueryable<Client>>().Setup(c => c.Provider).Returns(clients.Provider);
            mockClient.As<IQueryable<Client>>().Setup(c => c.Expression).Returns(clients.Expression);
            mockClient.As<IQueryable<Client>>().Setup(c => c.ElementType).Returns(clients.ElementType);
            mockClient.As<IQueryable<Client>>().Setup(c => c.GetEnumerator()).Returns(clients.GetEnumerator());

            mockContext = new Mock<PostgresContext>();

            mockContext.Setup(m => m.Clients).Returns(mockClient.Object);

            repository = new ClientRepository(mockContext.Object);
        }

        [Fact]
        public void ShouldAddClientInDb()
        {
            //Arranje
            Client clientTest = new Client() { Id = 1, FantasyName = "Fulano", Document = "000.000.000-00" };

            //Act
            repository.Add(clientTest);

            //Assert
            mockClient.Verify(e => e.Add(It.IsAny<Client>()), Times.Once);
            mockContext.Verify(e => e.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ShoudlReturnClient()
        {
            //Act
            var result = repository.GetById(It.IsAny<int>());

            //Assert
            Assert.IsType<Client>(result);
        }

        [Theory]
        [InlineData("000.000.000-00", true)]
        [InlineData("111.111.111-11", false)]
        public void ShouldReturnBoolWhenVerifyIfExistsInDb(string document, bool expectedResult)
        {
            //Assert
            
            
            //Act
            var result = repository.VerifyIfExists(document);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}