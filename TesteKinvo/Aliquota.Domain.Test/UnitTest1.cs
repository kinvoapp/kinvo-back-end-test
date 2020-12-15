using System;
using Xunit;
using Moq;
using Aliquota.Api.Controllers;
using Aliquota.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Aliquota.Application.Intefaces;

namespace Aliquota.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var mockRepo = new Mock<IApplicationServiceFinancialApplication>();

            var model = new FinancialApplicationDto
            {
                DateApplication = DateTime.Now,
                DateRescue = DateTime.Now,
                Investiment = 0,
                YieldRate = 0
            };

            mockRepo.Setup(repo => repo.Add(model)).Verifiable();
           
            var controller = new FinancialApplicationController(mockRepo.Object);
            
            ActionResult result = controller.Post(model);
            Assert.NotNull(result);

        }
    }
}
