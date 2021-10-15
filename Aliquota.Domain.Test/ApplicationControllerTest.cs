using Aliquota.Domain.Controllers;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ApplicationControllerTest
    {
        private readonly Mock<DbSet<Application>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Application _application;
        public ApplicationControllerTest()
        {
            _mockSet = new Mock<DbSet<Application>>();
            _mockContext = new Mock<Context>();
            _application = new Application
            {
                ApplicationID = 1,
                ApplicationValue = 1000,
                ApplicationDate = DateTime.Now,
                ApplicationRescue = DateTime.Now.AddYears(1)
            };

            _mockContext.Setup(m => m.Applications).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.Applications.FindAsync(1)).ReturnsAsync(_application);

            _mockContext.Setup(m => m.SetModified(_application));

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);
        }

        [Fact]
        public async Task Get_Applications()
        {
            var service = new ApplicationsController(_mockContext.Object);

            var app = await service.GetApplication(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
        }

        [Fact]
        public async Task Put_Application()
        {
            var service = new ApplicationsController(_mockContext.Object);

            await service.PutApplication(1, _application);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Post_Application()
        {
            var service = new ApplicationsController(_mockContext.Object);

            await service.PostApplication(_application);

            _mockSet.Verify(x => x.Add(_application), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Delete_Application()
        {
            var service = new ApplicationsController(_mockContext.Object);

            await service.DeleteApplication(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
            _mockSet.Verify(x => x.Remove(_application), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());

        }
    }
}
