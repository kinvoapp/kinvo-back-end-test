using System;
using System.Collections.Generic;

namespace Aliquota.Domain.Models
{
    public class Product
    {

        public int productId { get; set; }
        public double productGain { get; set; }
        public double productTax { get; set; }
        public double productApplication { get; set; }
        public DateTime dateRescue { get; set; }
        public DateTime dateApplication { get; set; }
        public Client Client { get; set; }
        public ICollection<IR_Record> Records { get; set; } = new List<IR_Record>();
   
        public Product()
        {
        }

        public Product(int productId, double productGain, double productTax, double productApplication, DateTime dateRescue, DateTime dateApplication, Client client)
        {
            this.productId = productId;
            this.productGain = productGain;
            this.productTax = productTax;
            this.productApplication = productApplication;
            this.dateRescue = dateRescue;
            this.dateApplication = dateApplication;
            Client = client;
        }
    }
}
