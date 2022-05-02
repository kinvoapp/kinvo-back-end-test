using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Models.Clients;
using Kinvo.Aliquota.Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Service.Interfaces.Clients
{
    public interface IClientService : IBaseService<Client>
    {
        Task<ClientResponse> Create(ClientRequest clientRequest);

        Task<ClientResponse> Edit(Guid? Uuid, ClientRequest request);

        Task Remove(Guid? Uuid);

        Task<List<ClientResponse>> List();
    }
}
