using Xunit;
using Moq;
using Aliquota.Data.Interface;
using Aliquota.Data.Entity;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Service;
using Aliquota.Domain.Utils;

namespace Aliquota.Test.ServiceTest
{
    public class ApplicationServiceTest
    {
        public Mock<IApplicationRepository> repository = new Mock<IApplicationRepository>();

        [Fact]
        public void Apply()
        {
            // Arrange
            Application application = new Application()
            {
                ApplicationDate = new System.DateTime(2020,1,1),
                ApplicationValue = 2000.00m,
                ClientId = 1,
            };

            repository.Setup(x => x.Apply(It.IsAny<Application>())).Returns(application);
            ApplicationService service = new ApplicationService(repository.Object);

            // Act
            Application response = service.Apply(It.IsAny<decimal>(), It.IsAny<long>());

            // Assert
            Assert.Equal(application, response);
        }

        [Fact]
        public void WithdrawOneYearApp()
        {
            // Arrange
            Application application = new Application()
            {
                WithdrawValue = 2000.00m - 2000.00m * Constant.OneYearApp,
            };

            ApplicationDTO applicationDTO = new ApplicationDTO()
            {
                ApplicationDate = new System.DateTime(2020,1,1),
                ApplicationValue = 2000.00m,
                WithdrawDate = new System.DateTime(2021,1,1),
            };

            repository.Setup(x => x.Withdraw(It.IsAny<long>(), It.IsAny<decimal>())).Returns(application);
            ApplicationService service = new ApplicationService(repository.Object);

            // Act
            ApplicationDTO response = service.Withdraw(applicationDTO);

            // Assert
            Assert.Equal(application.WithdrawValue, response.WithdrawValue);
        }

        [Fact]
        public void WithdrawOneToTwoYearApp()
        {
            // Arrange
            Application application = new Application()
            {
                WithdrawValue = 2000.00m - 2000.00m * Constant.OneToTwoYearsApp
            };

            ApplicationDTO applicationDTO = new ApplicationDTO()
            {
                ApplicationDate = new System.DateTime(2018,10,1),
                ApplicationValue = 2000.00m,
                WithdrawDate = new System.DateTime(2020,1,1),
            };

            repository.Setup(x => x.Withdraw(It.IsAny<long>(), It.IsAny<decimal>())).Returns(application);
            ApplicationService service = new ApplicationService(repository.Object);

            // Act
            ApplicationDTO response = service.Withdraw(applicationDTO);

            // Assert
            Assert.Equal(application.WithdrawValue, response.WithdrawValue);
        }

        [Fact]
        public void WithdrawMoreTwoYearApp()
        {
            // Arrange
            Application application = new Application()
            {
                WithdrawValue = 2000.00m - 2000.00m * Constant.OneToTwoYearsApp
            };

            ApplicationDTO applicationDTO = new ApplicationDTO()
            {
                ApplicationDate = new System.DateTime(2017,1,1),
                ApplicationValue = 2000.00m,
                WithdrawDate = new System.DateTime(2020,1,1),
            };

            
            repository.Setup(x => x.Withdraw(It.IsAny<long>(), It.IsAny<decimal>())).Returns(application);
            ApplicationService service = new ApplicationService(repository.Object);

            // Act
            ApplicationDTO response = service.Withdraw(applicationDTO);

            // Assert
            Assert.Equal(application.WithdrawValue, response.WithdrawValue);
        }

        [Fact]
        public void GetByCode()
        {
            // Arrange
            Application application = new Application() { Id = 0 };

            repository.Setup(x => x.GetByCode(It.IsAny<string>())).Returns(application);
            ApplicationService service = new ApplicationService(repository.Object);

            // Act
            ApplicationDTO response = service.GetByCode(It.IsAny<string>());

            // Assert
            Assert.Equal(application.Id, response.Id);
        }

    }
}