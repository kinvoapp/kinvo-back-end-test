using System;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories;
using src.Services;
using Xunit;

namespace kinvo.test.UniTests.Services
{
    public class FundoInvestimentoServiceTest
    {
        FundoInvestimentoService service;
        IFundoInvestimentoRepository repository;

        public FundoInvestimentoServiceTest()
        {
            //service = new FundoInvestimentoService();
            service = new FundoInvestimentoService(repository);
        }

        [Fact]
        public void Get_ObterFundoInvestimento_ReturnsOkResult()
        {
            // Act
            var okResult = service.ObterFundoInvestimento(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            FundoInvestimento fundo = new FundoInvestimento();
            // Act
            var okResult = service.SalvarFundoInvestimento(fundo);
            // Assert
            Assert.IsType<bool>(okResult);
        }
    }
}
