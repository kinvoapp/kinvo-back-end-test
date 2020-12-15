using Aliquota.Application.Dtos;
using Aliquota.Application.Intefaces;
using Aliquota.Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Application.Mapper
{
    public class MapperClient : IMapperClient
    {
        public Client MapperDtoToEntity(ClientDto clientDto)
        {
            var client = new Client()
            {
                Id = clientDto.Id,
                Name = clientDto.Name,
                Email = clientDto.Email,
                password = clientDto.password
            };

            return client;
        }
        public ClientDto MapperEntityToDto(Client client)
        {
            var clientDto = new ClientDto()
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                password = client.password
            };

            return clientDto;
        }
        public IEnumerable<ClientDto> MapperListClientsDto(IEnumerable<Client> clients)
        {
            var dto = clients.Select(c => new ClientDto
                                        {
                                            Id = c.Id,
                                            Name = c.Name,
                                            Email = c.Email,
                                            password = c.password
                                        });
            return dto;
        }
    }
}
