using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Models.Clients
{
    [AutoMap(typeof(Client))]
    public class ClientResponse
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
