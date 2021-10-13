using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Aliquota.Domain.Models
{
    public class Product
    {

        public int productId { get; set; }
        [Display(Name = "Name")]
        public string productName { get; set; }
        [Display(Name = "Investment")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double productInvestment { get; set; }
        public double productGain { get; set; }
        public double productTax { get; set; }
        [Display(Name = "Date Rescue")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime dateRescue { get; set; }
        [Display(Name = "Date Application")]
        [DataType(DataType.Date)]
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
            TimeSpan timeApplication = _dateRescue.Subtract(_dateApplication);

            try
            {
                if (timeApplication.TotalDays > 0 && timeApplication.TotalDays <= 366)
                {
                    productTax = 0.225;
                    productGain = productInvestment + 100;
                    aux = productGain * productTax;
                    return productGain - aux;
                }
                else if (timeApplication.TotalDays > 367 && timeApplication.TotalDays <= 734)
                {
                    productTax = 0.185;
                    productGain = productInvestment + 200;
                    aux = productGain * productTax;
                    return productGain - aux;
                }
                else if (timeApplication.TotalDays > 374)
                {
                    productTax = 0.15;
                    productGain = productInvestment + 500;
                    aux = productGain * productTax;
                    return productGain - aux;
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
