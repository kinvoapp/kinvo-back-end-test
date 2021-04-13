using Aliquota.Data.Entity;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Interface;
using Aliquota.Domain.Service.Interface;

namespace Aliquota.Domain.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository Repository;
        public ClientService(IClientRepository repository) 
        {
            Repository = repository;
        }

        public void Create(ClientDTO clientDTO)
        {
            Client client = new Client() {CPF = clientDTO.CPF};
            Repository.Create(client);
        } 

        public ClientDTO GetByCPF(string cpf) => (ClientDTO)Repository.GetByCPF(cpf);
    }
}