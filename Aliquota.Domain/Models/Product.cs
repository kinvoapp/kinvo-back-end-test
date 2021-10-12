using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain.Models
{
    public class Product
    {

        public int productId { get; set; }
        public string productName { get; set; }
        public double productInvestment { get; set; }
        public double productGain { get; set; }
        public double productTax { get; set; }
        public DateTime dateRescue { get; set; }
        public DateTime dateApplication { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public ICollection<IR_Record> Records { get; set; } = new List<IR_Record>();

        public Product()
        {
        }

        public Product(int productId, string productName, double productInvestment, DateTime dateRescue, DateTime dateApplication, Client client)
        {
            this.productId = productId;
            this.productName = productName;
            this.productInvestment = productInvestment;
            this.dateRescue = dateRescue;
            this.dateApplication = dateApplication;
            Client = client;
        }
        public void AddProducts(IR_Record _ir)
        {
            Records.Add(_ir);
        }
        public void RemoveProducts(IR_Record _ir)
        {
            Records.Remove(_ir);
        }
        public double TotalProducts(DateTime _dateApplication, DateTime _dateRescue)
        {
            return Records.Where(ir => ir.recordDate >= _dateApplication && ir.recordDate <= _dateRescue).Sum(ir => ir.recordAmount);
        }
        public double Rescue(DateTime _dateApplication, DateTime _dateRescue)
        {
            double aux = 0.0;
            TimeSpan timeApplication = _dateApplication.Subtract(_dateRescue);

            timeApplication /= 24;
            timeApplication /= 365;

            try
            {
                if (timeApplication.TotalHours > 0 && timeApplication.TotalHours <= 1)
                {
                    productTax = 0.225;
                    productGain = productInvestment + 100;
                    aux = productGain / productTax;
                    return aux;
                }
                else if (timeApplication.TotalHours > 1 && timeApplication.TotalHours <= 2)
                {
                    productTax = 0.185;
                    productGain = productInvestment + 200;
                    aux = productGain / productTax;
                    return aux;
                }
                else if (timeApplication.TotalHours > 2)
                {
                    productTax = 0.15;
                    productGain = productInvestment + 500;
                    aux = productGain / productTax;
                    return aux;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Aplicação invalida, valor menor que 0" + e);
            }

            return aux;
        }

    }
}
