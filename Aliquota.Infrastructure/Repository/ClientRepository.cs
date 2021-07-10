using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces;
using Aliquota.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        public readonly PostgresContext _context;

        public ClientRepository(PostgresContext context)
        {
            _context = context;
        }

        public Client Add(Client client)
        {
            var teste =_context.Clients.Add(client);

            return client;
        }

        public Client GetById(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == id);
        }

        public Client GetByDocument(string document)
        {
            return _context.Clients.FirstOrDefault(c => c.Document == document);
        }

        public bool VerifyIfExists(string document) => (_context.Clients.FirstOrDefault(x => x.Document == document) != null);
        

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
