using Aliquota.Domain.DTO;
using System;
using System.Collections.Generic;

namespace Aliquota.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FantasyName { get; set; }
        public string Document { get; set; }
        public List<Application> ListApplications { get; private set; }
        
        public Client()
        {
            
        }

        public static explicit operator Client(ClientDTO clientDTO)
        {
            return new Client()
            {
                FantasyName = clientDTO.FantasyName,
                Document = clientDTO.Document,
            };
        }
    }
}