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
        public void ShouldReturnApplicationInfo()
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
        public void ShouldReturnExceptionWhenApplicationNotExists()
        {
            //Arranje
            mock.Setup(a => a.GetApplication(It.IsAny<int>())).Returns<Application>(null);

            //Act & Assert
            var exception = Assert.Throws<BusinessException>(() => service.GetApplication(It.IsAny<int>()));
            Assert.Equal("Application not found", exception.Message);

        }

        [Fact]
        public void ShouldReturnApplicationInfoWhenApplySuccessful()
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
                ApplicationValue = 1200.00m,
                ClientId = 1
            };
            mock.Setup(a => a.Apply(It.IsAny<Application>())).Returns(applicationTest);

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
        public void ShouldReturnApplicationInfoWhenApplyIsLessOrEqualThanZero(int value)
        {
            //Arranje
            ApplicationDTO dtoTest = new ApplicationDTO()
            {
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = value,
                ClientId = 1
            };

            //Act & Assert
            var exception = Assert.Throws<BusinessException>(() => service.Apply(dtoTest));
            Assert.Equal("This application must bigger than 0", exception.Message);
        }

        [Theory]
        [InlineData(1000, "2021-06-9", 775)]//OneYearFactor
        [InlineData(1000, "2022-07-11", 815)]//BetweenOneAndTwoYearsFactor
        [InlineData(1000, "2025-07-11", 850)]//PlusTwoYearsFactor
        public void ShouldReturnWithdrawWhenDateWithdrawIsCorrect(decimal valueApplication, string date, decimal valueWithdraw)
        {
            //Arranje
            RequestWithdrawDTO requestTest = new RequestWithdrawDTO()
            {
                ApplicationId = 1,
                WithdrawDate = Convert.ToDateTime("2020-06-10")
            };

            Application applicationTest = new Application()
            {
                Client = new Client() { FantasyName = "Fulano", Id = 1 },
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = valueApplication,
                IsActive = true
            };
            Application applicationResultTest = new Application()
            {
                Client = new Client() { FantasyName = "Fulano", Id = 1 },
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = valueApplication,
                IsActive = false,
                WithdrawDate = Convert.ToDateTime(date),
                WithdrawValue = valueWithdraw
            };
            mock.Setup(a => a.GetApplication(It.IsAny<int>())).Returns(applicationTest);
            mock.Setup(a => a.Withdraw(It.IsAny<Application>())).Returns(applicationResultTest);

            //Act
            var result = service.Withdraw(requestTest);

            //Assert
            Assert.Equal(valueWithdraw, result.WithdrawValue);
        }

        [Fact]
        public void ShouldReturnWithdrawWhenDateWithdrawIsLess()
        {
            //Arranje
            RequestWithdrawDTO requestTest = new RequestWithdrawDTO()
            {
                ApplicationId = 1,
                WithdrawDate = Convert.ToDateTime("2019-06-10")
            };

            Application applicationTest = new Application()
            {
                Client = new Client() { FantasyName = "Fulano", Id = 1 },
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = 1000,
                IsActive = true
            };
            mock.Setup(a => a.GetApplication(It.IsAny<int>())).Returns(applicationTest);
            mock.Setup(a => a.Withdraw(It.IsAny<Application>())).Returns(applicationTest);

            //Act & Assert
            var exception = Assert.Throws<BusinessException>(() => service.Withdraw(requestTest));
            Assert.Equal("Date withdraw must older than date application", exception.Message);
        }

        [Fact]
        public void ShouldReturnBusinessExceptionWhenWithdrawAlreadyBeenMade()
        {
            //Arranje
            Application applicationTest = new Application()
            {
                Client = new Client() { FantasyName = "Fulano", Id = 1 },
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = 1000,
                IsActive = false
            };
            Application applicationResultTest = new Application()
            {
                Client = new Client() { FantasyName = "Fulano", Id = 1 },
                ClientId = 1,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = 1000,
                IsActive = false,
                WithdrawDate = Convert.ToDateTime("2022-07-11"),
                WithdrawValue = 815
            };
             RequestWithdrawDTO requestTest = new RequestWithdrawDTO()
            {
                ApplicationId = 1,
                WithdrawDate = Convert.ToDateTime("2020-06-10")
            };
            mock.Setup(a => a.GetApplication(It.IsAny<int>())).Returns(applicationTest);
            mock.Setup(a => a.Withdraw(It.IsAny<Application>())).Returns(applicationResultTest);

            //Act & Assert
            var exception = Assert.Throws<BusinessException>(() => service.Withdraw(requestTest));
            Assert.Equal("This application is already withdraw", exception.Message);

        }
    }
}
