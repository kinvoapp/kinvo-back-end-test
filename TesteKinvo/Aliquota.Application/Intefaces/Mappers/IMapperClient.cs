using Aliquota.Application.Dtos;
using Aliquota.Domain.Entitys;
using System.Collections.Generic;


namespace Aliquota.Application.Intefaces
{
    public interface IMapperClient
    {
        Client MapperDtoToEntity(ClientDto clientDto);
        IEnumerable<ClientDto> MapperListClientsDto(IEnumerable<Client> clients);
        ClientDto MapperEntityToDto(Client client);
    }
}
