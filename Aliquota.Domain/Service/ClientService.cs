using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Exceptions;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Service.Interfaces;



namespace Aliquota.Domain.Service
{
    public class ClientService : IClientService
    {
        public readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public ClientDTO Add(ClientDTO clientDTO)
        {
            if (VerifyIfExists(clientDTO))
            {
                throw new BusinessException("Client already exists");
            }
            Client client = new Client()
            {
                FantasyName = clientDTO.FantasyName,
                Document = clientDTO.Document,
            };

            _clientRepository.Add(client);

            return clientDTO;
        }

        public ClientDTO GetById(int id)
        {
            var client = _clientRepository.GetById(id);

            if (client != null)
            {
                return (ClientDTO)client;
            }
            throw new BusinessException("Client not found");
        }

        public ClientDTO GetByDocument(string document)
        {
            var client = _clientRepository.GetByDocument(document);

            if (client != null)
            {
                return (ClientDTO)client;
            }
            throw new BusinessException("Client not found");
        }

        public bool VerifyIfExists(ClientDTO clientDTO)
        {
            return _clientRepository.VerifyIfExists(clientDTO.Document);
        }
        public void Remove(int id)
        {
            _clientRepository.Remove(id);
        }

        
    }
}
