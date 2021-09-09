using Aliquota.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Business.Interfaces
{
    public interface IClientRepository
    {
        Task DeleteClientAsync(int id);
        Task<Client> GetClientAsync(int id);
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> InsertClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
    }
}
