using System.Collections.Generic;

namespace Aliquota.Domain.Entities
{
    public class Client
    {
        public int Id { get; private set; }
        public string FantasyName { get; set; }
        public string Document { get; set; }
        public List<Application> ListApplications { get; private set; }
        
        public Client()
        {
            
        }

    }
}