using Moq;
using System;
using Xunit;

using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Service;
using Aliquota.Domain.Entities;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Exceptions;

namespace Aliquota.Domain.Test.Service
{
    public class AliquotServiceTest
    {
        private Mock<IAliquotRepository> mock;
        private AliquotService service;

        public AliquotServiceTest()
        {
            mock = new Mock<IAliquotRepository>();
            service = new AliquotService(mock.Object);
        }

        [Fact]
        public void GetOneApplication()
        {
            //Arranje
            Application applicationTest = new Application()
            {
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = 1200.00m,
                IsActive = true
            };
            ResponseApplicationDTO responseTest = new ResponseApplicationDTO()
            {
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = 1200.00m,
                IsActive = true
            };
            mock.Setup(a => a.GetApplication(It.IsAny<int>())).Returns(applicationTest);

            //Act
            var result = service.GetApplication(It.IsAny<int>());

            //Assert
            Assert.Equal(responseTest.ClientId, result.ClientId);
            Assert.Equal(responseTest.ApplicationDate, result.ApplicationDate);
            Assert.Equal(responseTest.ApplicationValue, result.ApplicationValue);
            Assert.Equal(responseTest.IsActive, result.IsActive);

        }
        
        [Fact]
        public void FailedToGetApplication()
        {
            //Arranje
            mock.Setup(a => a.GetApplication(It.IsAny<int>())).Returns<Application>(null);

            //Act & Assert
            var exception = Assert.Throws<BusinessException>(() => service.GetApplication(It.IsAny<int>()));
            Assert.Equal("Aplicação não encontrada", exception.Message);

        }

        [Fact]
        public void RealizeApplySuccessful()
        {
            //Arranje
            Application applicationTest = new Application()
            {
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = 1200.00m,
                IsActive = true
            };
            ResponseApplicationDTO responseTest = new ResponseApplicationDTO()
            {
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = 1200.00m,
                IsActive = true
            };
            ApplicationDTO dtoTest = new ApplicationDTO()
            {
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                Value = 1200.00m,
                Document = "00000.000/000.0"
            };
            mock.Setup(a => a.Apply(It.IsAny<ApplicationDTO>())).Returns(applicationTest);

            //Act
            var result = service.Apply(dtoTest);

            //Assert
            Assert.Equal(responseTest.ClientId, result.ClientId);
            Assert.Equal(responseTest.ApplicationDate, result.ApplicationDate);
            Assert.Equal(responseTest.ApplicationValue, result.ApplicationValue);
            Assert.Equal(responseTest.IsActive, result.IsActive);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        public void TryApplyNegativeValues(int value)
        {
            //Arranje
            ApplicationDTO dtoTest = new ApplicationDTO()
            {
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                Value = value,
                Document = "00000.000/000.0"
            };

            //Act & Assert
            var exception = Assert.Throws<BusinessException>(() => service.Apply(dtoTest));
            Assert.Equal("A aplicação não pode ser igual ou menor que zero", exception.Message);
        }
    }
}
