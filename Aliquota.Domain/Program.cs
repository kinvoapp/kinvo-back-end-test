using System;
using System.Globalization;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Services;

namespace Aliquota.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Insert Initial Amount:");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Investment investment = new Investment(amount);
                Console.Write("Insert Start Date (dd/MM/yyyy): ");
                DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Insert Redeem Date (dd/MM/yyyy): ");
                DateTime redeem = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Invoice invoice = new Invoice(start, redeem, investment);
                Console.Write("Insert Monthly Profit Rate (0-100): ");
                double profitRate = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture) / 100;
                CalculateService calculateService = new CalculateService(profitRate, new IncomeTaxService());
                calculateService.ProcessInvoice(invoice);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error! "+ e.Message);
            }
            finally { Console.ReadKey(); }
        }
    }
}
