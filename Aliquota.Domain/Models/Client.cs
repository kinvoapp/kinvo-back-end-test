using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddProduct(Product _product)
        {
            Products.Add(_product);
        }

        public double TotalProducts(DateTime _dateApplication, DateTime _dateRescue)
        {
            return Products.Sum(products => products.TotalProducts(_dateApplication, _dateRescue));
        }

    }
}
