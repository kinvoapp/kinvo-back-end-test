using Aliquota.Application.Dtos;
using Aliquota.Application.Intefaces;
using Aliquota.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Aliquota.Application
{
    public class ApplicationServiceCliente : IApplicationServiceClient
    {
        private readonly IServiceClient serviceClient;
        private readonly IMapperClient mapperClient;

        public ApplicationServiceCliente(IServiceClient serviceClient,
                                         IMapperClient mapperCliente)
        {
            this.serviceClient = serviceClient;
            this.mapperClient = mapperCliente;
        }
        public void Add(ClientDto clientDto)
        {
            var client = mapperClient.MapperDtoToEntity(clientDto);
            serviceClient.Add(client);
        }

        public IEnumerable<ClientDto> GetAll()
        {
            var clients = serviceClient.GetAll();
            return mapperClient.MapperListClientsDto(clients);
        }

        public ClientDto GetById(int id)
        {
            var client = serviceClient.GetById(id);
            return mapperClient.MapperEntityToDto(client);
        }

        public void Remove(ClientDto clientDto)
        {
            var client = mapperClient.MapperDtoToEntity(clientDto);
            serviceClient.Remove(client);
        }

        public void Update(ClientDto clientDto)
        {
            var client = mapperClient.MapperDtoToEntity(clientDto);
            serviceClient.Update(client);
        }
    }
}
