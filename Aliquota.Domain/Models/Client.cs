using System.Collections.Generic;

namespace Aliquota.Domain.Models
{
    public class Client
    {

        public int clientId { get; set; }
        public string clientName { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Client() 
        { 
        }
        public Client(int clientId, string clientName)
        {
            this.clientId = clientId;
            this.clientName = clientName;
        }
    }
}
