using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

using Aliquota.API.Controllers;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Service.Interfaces;

namespace Aliquota.Domain.Test.API
{
    public class AliquotsControllerTest
    {
        private Mock<IAliquotService> mockAliquot;
        private Mock<IClientService> mockClient;
        private AliquotsController controller;
        public AliquotsControllerTest()
        {
            mockAliquot = new Mock<IAliquotService>();
            mockClient = new Mock<IClientService>();
            controller = new AliquotsController(mockAliquot.Object, mockClient.Object);
        }

        [Fact]
        public void GetOneApplication()
        {
            //Arranje
            ResponseApplicationDTO responseTest = new ResponseApplicationDTO()
            {
                ClientId = 1,
                ApplicationValue = 1200.00m,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                IsActive = true
            };
            mockAliquot.Setup(a => a.GetApplication(It.IsAny<int>())).Returns(responseTest);

            //Act
            var result = controller.GetApplication(1);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void FailedToGetOneApplication()
        {
            //Arranje
            mockAliquot.Setup(a => a.GetApplication(It.IsAny<int>())).Returns<ResponseApplicationDTO>(null);

            //Act
            var result = controller.GetApplication(It.IsAny<int>());

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void NewApplySuccessfull()
        {
            //Arranje
            ResponseApplicationDTO responseTest = new ResponseApplicationDTO()
            {
                ClientId = 1,
                ApplicationValue = 1200.00m,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                IsActive = true
            };
            ApplicationDTO applicationTest = new ApplicationDTO()
            {
                Value = 1200.00m,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                Document = "00000.000/000.0"
            };
            mockAliquot.Setup(a => a.Apply(It.IsAny<ApplicationDTO>())).Returns(responseTest);

            //Act
            var result = controller.Apply(applicationTest);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void NewApplyFailed()
        {
            //Arranje
            ApplicationDTO applicationTest = new ApplicationDTO()
            {
                Value = 1200.00m,
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                Document = "00000.000/000.0"
            };
            controller.ModelState.AddModelError("error", "error");

            //Act
            var result = controller.Apply(applicationTest);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void RealizeWithdraw()
        {
            //Arranje
            RequestWithdrawDTO requestTest = new RequestWithdrawDTO()
            {
                ApplicationId = 1,
                WithdrawDate = Convert.ToDateTime("2020-06-10")
            };
            WithdrawDTO responseTest = new WithdrawDTO()
            {
                ApplicationDate = Convert.ToDateTime("2020-06-10"),
                ApplicationValue = 1200.00m,
                FantasyName = "Fulano",
                WithdrawDate = DateTime.Now,
                WithdrawValue = 1000
            };
            mockAliquot.Setup(a => a.Withdraw(It.IsAny<RequestWithdrawDTO>())).Returns(responseTest);

            //Act
            var result = controller.Withdraw(requestTest);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddNewClient()
        {
            //Arranje
            ClientDTO clientTest = new ClientDTO()
            {
                FantasyName = "test_name",
                Document = "00000.000/000.0",

            };
            mockClient.Setup(c => c.Add(It.IsAny<ClientDTO>())).Returns(clientTest);

            //Act
            var result =controller.Add(clientTest);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddExistingClient()
        {
            //Arranje
            ClientDTO clientTest = new ClientDTO()
            {
                FantasyName = "test_name",
                Document = "00000.000/000.0",

            };
            mockClient.Setup(c => c.VerifyIfExists(It.IsAny<ClientDTO>())).Returns(true);

            //Act
            var result = controller.Add(clientTest);

            //Assert
            var exception = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Client already exists", exception.Value);
        }
    }
}
