using System.Collections.Generic;

namespace Aliquota.Domain.Entities
{
    public class Client
    {
        public int Id { get; private set; }
        public string FantasyName { get; private set; }
        public List<Application> ListApplications { get; private set; }
        
        public Client()
        {
            
        }
    }
}