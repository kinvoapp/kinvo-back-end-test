using Aliquota.Data.Entity;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Interface;
using Aliquota.Domain.Service;
using Moq;
using Xunit;

namespace Aliquota.Test.ServiceTest
{
    public class ClientServiceTest
    {   
        public Mock<IClientRepository> repository = new Mock<IClientRepository>();
        
        [Fact]
        public void Create()
        {
            // Arrange
            ClientDTO client = new ClientDTO() { CPF = "Paloma" };

            ClientService service = new ClientService(repository.Object);

            // Act
            service.Create(client);
            
            // Assert
            repository.Verify(x => x.Create(It.IsAny<Client>()), Times.Once());
        }

        [Fact]
        public void GetByCPF()
        {
            // Arrange
            Client client = new Client()
            {
                ClientId = 1
            };

            repository.Setup(x => x.GetByCPF(It.IsAny<string>())).Returns(client);
            ClientService service = new ClientService(repository.Object);

            // Act
            var response = service.GetByCPF(It.IsAny<string>());
            
            // Assert
            Assert.Equal(response.ClientId, client.ClientId);
        }
    }
}