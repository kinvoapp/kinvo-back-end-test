using Aliquota.Data.Entity;

namespace Aliquota.Domain.Interface
{
    public interface IClientRepository
    {
        void Create(Client client);
        Client GetByCPF(string cpf);        
    }
}