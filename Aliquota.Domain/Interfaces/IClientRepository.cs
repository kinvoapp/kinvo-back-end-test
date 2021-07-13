using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces
{
    public interface IClientRepository
    {
        Client Add(Client client);
        Client GetById(int id);
        bool VerifyIfExists(string document);
    }
}
