using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.DTO
{
    public class ClientDTO
    {
        public string FantasyName { get; set; }
        public string Document { get; set; }

        public static explicit operator ClientDTO(Client client)
        {
            return new ClientDTO()
            {
                FantasyName = client.FantasyName,
                Document = client.Document
            };
        }
    }
}
