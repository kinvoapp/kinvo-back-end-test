using Aliquota.Business.Interfaces;
using Aliquota.Domain.Entitys;
using Aliquota.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientContext context;

        public ClientRepository(ClientContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await context.Clients.AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetClientAsync(int id)
        {
            return await context.Clients.FindAsync(id);
        }

        public async Task<Client> InsertClientAsync(Client client)
        {
            await context.AddAsync(client);
            await context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            var consultedClient = await context.Clients.FindAsync(client.ClientId);
            if (consultedClient == null)
            {
                return null;
            }

            context.Entry(consultedClient).CurrentValues.SetValues(client);
            await context.SaveChangesAsync();

            return consultedClient;

        }

        public async Task DeleteClientAsync(int id)
        {
            var consultedClient = await context.Clients.FindAsync(id);
            if (consultedClient == null)
            {
                return;
            }
            context.Clients.Remove(consultedClient);
            await context.SaveChangesAsync();
        }

    }
}
