using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Service;
using Moq;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class UnitTest1
    {
        private Mock<IApplicationRepository> mockRepository;
        private ApplicationService service;

        public UnitTest1()
        {
            mockRepository = new Mock<IApplicationRepository>();
            service = new ApplicationService(mockRepository.Object);
        }



        [Fact]
        public void Test1()
        {
            mockRepository.Setup(a => a.GetApplication(It.IsAny<int>())).Returns<Application>(null);

            var resultado = service.GetApplication(1);

            Assert.Null(resultado);
        }
    }
}
