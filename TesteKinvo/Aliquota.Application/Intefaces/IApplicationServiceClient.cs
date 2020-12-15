using Aliquota.Application.Dtos;
using System.Collections.Generic;

namespace Aliquota.Application.Intefaces
{
    public interface IApplicationServiceClient
    {
        void Add(ClientDto clientDto);
        void Update(ClientDto clientDto);
        void Remove(ClientDto clientDto);
        IEnumerable<ClientDto> GetAll();
        ClientDto GetById(int id);
    }
}
