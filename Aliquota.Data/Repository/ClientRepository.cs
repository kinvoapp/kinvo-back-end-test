using System.Linq;
using Aliquota.Data.Context;
using Aliquota.Data.Entity;
using Aliquota.Domain.Interface;

namespace Aliquota.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AliquotaContext DbContext;
        public ClientRepository(AliquotaContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Create(Client client)
        {
            DbContext.Clients.Add(client);
            DbContext.SaveChanges();
        }

        public Client GetByCPF(string cpf) => DbContext.Clients.FirstOrDefault(c => c.CPF == cpf);

    }
}