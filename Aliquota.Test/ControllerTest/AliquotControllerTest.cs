using Aliquot.API.Controllers;
using Aliquota.API.Models.Request;
using Aliquota.Data.Entity;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Aliquota.Test.ControllerTest
{
    public class AliquotControllerTest
    {
        #region Mock
        public Mock<IClientService> clientService = new Mock<IClientService>();
        public Mock<IApplicationService> applicationService = new Mock<IApplicationService>();
        #endregion

        [Fact]
        public void CreateReturnNoContent()
        {
            // Arrange
            CreateClientRequest request = new CreateClientRequest() { CPF = "Paloma" };
            ClientDTO client = new ClientDTO() { CPF = "Leandro" };


            clientService.Setup(x => x.GetByCPF(It.IsAny<string>())).Returns(client);
            clientService.Setup(x => x.Create(client));

            AliquotController controller = new AliquotController(applicationService.Object, clientService.Object);
            
            // Act
            ActionResult response = controller.Create(request);

            NoContentResult result = response as NoContentResult;
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.StatusCode , 204);
        }

        [Fact]
        public void CreateReturnBadRequest()
        {
            // Arrange
            CreateClientRequest request = new CreateClientRequest() { CPF = "Paloma" };
            ClientDTO client = new ClientDTO() { CPF = "Paloma" };

            clientService.Setup(x => x.GetByCPF(It.IsAny<string>())).Returns(client);
            clientService.Setup(x => x.Create(client));

            AliquotController controller = new AliquotController(applicationService.Object, clientService.Object);
            

            // Act
            ActionResult response = controller.Create(request);

            BadRequestResult badRequestResult = response as BadRequestResult;
            
            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(badRequestResult.StatusCode , 400);
        }

        [Fact]
        public void ApplyReturnOK()
        {
            // Arrange
            ApplyRequest request = new ApplyRequest() { ApplicationValue = 200.00m };
            ClientDTO client = new ClientDTO() { CPF = "Paloma" };
            Application application = new Application() { ApplicationCode = "codigo" };

            clientService.Setup(x => x.GetByCPF(It.IsAny<string>())).Returns(client);
            applicationService.Setup(x => x.Apply(It.IsAny<decimal>(),It.IsAny<long>())).Returns(application);

            AliquotController controller = new AliquotController(applicationService.Object, clientService.Object);
            
            // Act
            ActionResult response = controller.Apply(request);

            OkObjectResult okResult = response as OkObjectResult;
            
            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(okResult.StatusCode , 200);
        }

        [Fact]
        public void ApplyReturnBadRequest()
        {
            // Arrange
            ApplyRequest request = new ApplyRequest() { ApplicationValue = 0m };
            ClientDTO client = new ClientDTO() { CPF = "Paloma" };
            Application application = new Application() { ApplicationCode = "codigo" };

            clientService.Setup(x => x.GetByCPF(It.IsAny<string>())).Returns(client);
            applicationService.Setup(x => x.Apply(It.IsAny<decimal>(),It.IsAny<long>())).Returns(application);

            AliquotController controller = new AliquotController(applicationService.Object, clientService.Object);
            
            // Act
            ActionResult response = controller.Apply(request);

            BadRequestResult badRequestResult = response as BadRequestResult;
            
            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(badRequestResult.StatusCode , 400);
        }

        [Fact]
        public void WithdrawReturnOK()
        {
            // Arrange
            ApplyRequest request = new ApplyRequest() { ApplicationValue = 200.00m };
            ApplicationDTO applicationDTO = new ApplicationDTO() { ApplicationDate = new System.DateTime(2017,1,1), WithdrawDate = null};

            applicationService.Setup(x => x.GetByCode(It.IsAny<string>())).Returns(applicationDTO);
            applicationService.Setup(x => x.Withdraw(It.IsAny<ApplicationDTO>())).Returns(applicationDTO);

            AliquotController controller = new AliquotController(applicationService.Object, clientService.Object);
            
            // Act
            ActionResult response = controller.Withdraw(It.IsAny<string>());

            OkObjectResult okResult = response as OkObjectResult;
            
            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(okResult.StatusCode , 200);
        }

        [Fact]
        public void WithdrawBadRequestCase1()
        {
            // Arrange
            ApplyRequest request = new ApplyRequest() { ApplicationValue = 200.00m };
            ApplicationDTO applicationDTO = new ApplicationDTO() 
            { 
                ApplicationDate = new System.DateTime(2017,1,1), 
                WithdrawDate = new System.DateTime(2017,1,1)
            };

            applicationService.Setup(x => x.GetByCode(It.IsAny<string>())).Returns(applicationDTO);
            applicationService.Setup(x => x.Withdraw(It.IsAny<ApplicationDTO>())).Returns(applicationDTO);

            AliquotController controller = new AliquotController(applicationService.Object, clientService.Object);
            
            // Act
            ActionResult response = controller.Withdraw(It.IsAny<string>());

            BadRequestResult badRequestResult = response as BadRequestResult;
            
            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(badRequestResult.StatusCode , 400);
        }

        [Fact]
        public void WithdrawBadRequestCase2()
        {
            // Arrange
            ApplyRequest request = new ApplyRequest() { ApplicationValue = 200.00m };
            ApplicationDTO applicationDTO = new ApplicationDTO() 
            { 
                ApplicationDate = new System.DateTime(2019,1,1), 
                WithdrawDate = new System.DateTime(2017,1,1)
            };

            applicationService.Setup(x => x.GetByCode(It.IsAny<string>())).Returns(applicationDTO);
            applicationService.Setup(x => x.Withdraw(It.IsAny<ApplicationDTO>())).Returns(applicationDTO);

            AliquotController controller = new AliquotController(applicationService.Object, clientService.Object);
            
            // Act
            ActionResult response = controller.Withdraw(It.IsAny<string>());

            BadRequestResult badRequestResult = response as BadRequestResult;
            
            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(badRequestResult.StatusCode , 400);
        }
    }
}