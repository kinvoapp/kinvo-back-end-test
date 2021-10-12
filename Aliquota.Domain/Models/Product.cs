using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain.Models
{
    public class Product
    {

        public int productId { get; set; }
        public List<string> productName = new List<string>();
        public double productInvestment { get; set; }
        public double productGain { get; set; }
        public double productTax { get; set; }
        public DateTime dateRescue { get; set; }
        public DateTime dateApplication { get; set; }
        public Client Client { get; set; }
        public ICollection<IR_Record> Records { get; set; } = new List<IR_Record>();
   
        public Product()
        {
            productName.Add("Fixed Income");
            productName.Add("Variable Income");
            productName.Add("High Liquidity");
            productName.Add("Low Liquidity");
            productName.Add("High Risk");
            productName.Add("Short Term");
            productName.Add("Mid Term");
            productName.Add("Long Term");

            try
            {
                if (this.dateRescue <= this.dateApplication)
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Product(int productId, double productInvestment, double productGain, DateTime dateRescue, DateTime dateApplication, Client client)
        {

            productName.Add("Fixed Income");
            productName.Add("Variable Income");
            productName.Add("High Liquidity");
            productName.Add("Low Liquidity");
            productName.Add("High Risk");
            productName.Add("Short Term");
            productName.Add("Mid Term");
            productName.Add("Long Term");

            this.productId = productId;
            this.productInvestment = productInvestment;
            this.productGain = productGain;
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
        public void Rescue(DateTime _dateApplication, DateTime _dateRescue, double _gain)
        {
            double aux;
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
                }
                else if (timeApplication.TotalHours > 1 && timeApplication.TotalHours <= 2)
                {
                    productTax = 0.185;
                    productGain = productInvestment + 150;
                    aux = productGain / productTax;
                }
                else if (timeApplication.TotalHours > 2)
                {
                    productTax = 0.15;
                    productGain = productInvestment + 500;
                    aux = productGain / productTax;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Aplicação invalida, valor menor que 0" + e);
            }


        }

    }
}
