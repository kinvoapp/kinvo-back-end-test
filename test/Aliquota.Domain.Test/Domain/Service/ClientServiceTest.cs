using Moq;
using System;
using Xunit;

using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Service;
using Aliquota.Domain.Entities;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Exceptions;

namespace Aliquota.Domain.Test.Domain.Service
{
    public class ClientServiceTest
    {
        private Mock<IClientRepository> mock;
        private ClientService service;

        public ClientServiceTest()
        {
            mock = new Mock<IClientRepository>();
            service = new ClientService(mock.Object);
        }

        [Fact]
        public void ShouldReturnNewClientWhenAddSuccessful()
        {
            //Arranje
            ClientDTO clientDtoTest = new ClientDTO()
            {
                FantasyName = "Fulano",
                Document = "000.000.000-00"
            };
            Client clientTest = new Client()
            {
                FantasyName = "Fulano",
                Document = "000.000.000-00"
            };
            mock.Setup(c => c.Add(It.IsAny<Client>())).Returns(clientTest);

            //Act
            var result = service.Add(clientDtoTest);

            //Assert
            Assert.Equal(clientDtoTest.FantasyName, result.FantasyName);
            Assert.Equal(clientDtoTest.Document, result.Document);
        }

        [Fact]
        public void ShouldReturnExceptionWhenTryAddClientAlreadyExists()
        {
            //Arranje
            ClientDTO clientDtoTest = new ClientDTO()
            {
                FantasyName = "Fulano",
                Document = "000.000.000-00"
            };
            mock.Setup(c => c.VerifyIfExists(It.IsAny<string>())).Returns(true);

            //Act & Assert
            var exception = Assert.Throws<BusinessException>(() => service.Add(clientDtoTest));
            Assert.Equal("Client already exists", exception.Message);
        }

        [Fact]
        public void ShouldReturnClientInfo()
        {
            //Arranje
            Client clientTest = new Client()
            {
                FantasyName = "Fulano",
                Document = "000.000.000-00"
            };
            mock.Setup(c => c.GetById(It.IsAny<int>())).Returns(clientTest);

            //Act
            var result = service.GetById(It.IsAny<int>());

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldReturnExceptionWhenApplicationNotExists()
        {
            //Arranje
            mock.Setup(c => c.GetById(It.IsAny<int>())).Returns<Client>(null);

            //Act & Assert
            var exception = Assert.Throws<BusinessException>(() => service.GetById(It.IsAny<int>()));
            Assert.Equal("Client not found", exception.Message);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldReturnTrueOrFalse(bool value)
        {
            //Arranje
            ClientDTO clientDtoTest = new ClientDTO()
            {
                FantasyName = "Fulano",
                Document = "000.000.000-00"
            };
            mock.Setup(c => c.VerifyIfExists(It.IsAny<string>())).Returns(value);

            //Act
            var result = service.VerifyIfExists(clientDtoTest);

            //Assert
            Assert.Equal(value, result);
        }

    }
}