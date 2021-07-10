using Aliquota.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Service.Interfaces
{
    public interface IClientService
    {
        ClientDTO Add(ClientDTO clientDTO);
        ClientDTO GetById(int id);
        ClientDTO GetByDocument(string document);
        bool VerifyIfExists(ClientDTO clientDTO);
        void Remove(int id);
        
    }
}
