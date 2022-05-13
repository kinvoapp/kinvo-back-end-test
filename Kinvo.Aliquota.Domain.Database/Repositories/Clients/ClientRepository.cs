using Kinvo.Aliquota.Domain.Database.Interfaces.Clients;
using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Domain;
using Kinvo.Aliquota.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Repositories.Clients
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClientRepository(AppDbContext appDbContext)
            :base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
