using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using System.Collections.Generic;
using System.Linq;


namespace Aliquota.Domain.Services
{
    public class ClientService
    {
        private readonly AliquotaDomainContext _context;

        public ClientService(AliquotaDomainContext context)
        {
            _context = context;
        }

        public List<Client> FindAll()
        {
            return _context.Client.OrderBy(x => x.clientName).ToList();
        }
    }
}
