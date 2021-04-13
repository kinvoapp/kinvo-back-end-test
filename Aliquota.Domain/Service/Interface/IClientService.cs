using Aliquota.Data.Entity;
using Aliquota.Domain.DTO;

namespace Aliquota.Domain.Service.Interface
{
    public interface IClientService
    {
        void Create(ClientDTO clientDTO);
        ClientDTO GetByCPF(string cpf);
    }
}