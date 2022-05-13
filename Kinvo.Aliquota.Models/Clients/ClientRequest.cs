using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Models.Clients
{
    [AutoMap(typeof(Client))]
    public class ClientRequest
    {
        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public string Cpf { get; set; }

        public bool Active { get; set; }
    }
}
