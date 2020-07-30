using System;
using backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using src.Interfaces.IServices;
using src.Models;
using src.Services;
using Xunit;

namespace kinvo.test.UniTests.Controllers
{
    public class FundoInvestimentoControllerTest
    {
        FundoInvestimentoController controller;
        IFundoInvestimentoService service;

        public FundoInvestimentoControllerTest()
        {
            //service = new FundoInvestimentoService();
            controller = new FundoInvestimentoController(service);
        }

        [Fact]
        public void Get_ObterFundoInvestimento_ReturnsOkResult()
        {
            // Act
            var okResult = controller.ObterFundoInvestimento(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Post_SalvarFundoInvestimento_Bool()
        {
            FundoInvestimento fundo = new FundoInvestimento();
            // Act
            var okResult = controller.SalvarFundoInvestimento(fundo);
            // Assert
            Assert.IsType<bool>(okResult);
        }
    }
}
