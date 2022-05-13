using AutoMapper;
using Kinvo.Aliquota.Domain.Database.Interfaces.Clients;
using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Models.Clients;
using Kinvo.Aliquota.Service.Interfaces.Clients;
using Kinvo.Aliquota.Validators.Interfaces.Clients;
using Kinvo.Aliqutota.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliqutota.Service.Clients
{
    public class ClientService : BaseService<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientValidator _clientValidator;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IClientValidator clientValidator, IMapper mapper)
            :base(clientRepository)
        {
            _clientRepository = clientRepository;
            _clientValidator = clientValidator;
            _mapper = mapper;
        }

        public async Task<ClientResponse> Create(ClientRequest clientRequest)
        {
            await _clientValidator.ValidateCreation(clientRequest);
            var client = _mapper.Map<Client>(clientRequest);
            
            _clientRepository.Insert(client);
            return _mapper.Map<ClientResponse>(client);
            
        }

        public async Task<ClientResponse> Edit(Guid? uuid, ClientRequest clientRequest)
        {
            var client = await _clientRepository.FindAsync(uuid.Value); 

            client.ModificationDate = DateTime.Now;
            client.Name = clientRequest.Name;
            client.Cpf = clientRequest.Cpf;
            client.Active = clientRequest.Active;

            _clientRepository.Update(client);
            return _mapper.Map<ClientResponse>(client);
        }

        public async Task Remove(Guid? Uuid)
        {
            var obj = await _clientRepository.FindAsync(Uuid.Value);

            _clientRepository.Delete(obj.Id);

            return;

        }

        public async Task<List<ClientResponse>> List()
        {
            var obj = await _clientRepository.ListAsync();
            List<ClientResponse> response = _mapper.Map<List<ClientResponse>>(obj);

            return response;
            

        }
    }
}
