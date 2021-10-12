using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Models.Enums;

namespace Aliquota.Domain.Data
{
    public class SeedingService
    {

        private AliquotaDomainContext _context;

        public SeedingService(AliquotaDomainContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Client.Any() || _context.Product.Any() || _context.IR_Record.Any())
            {
                return;
            }

            Client c1 = new Client(1, "Leonam");
            Client c2 = new Client(2, "Sousa");
            Client c3 = new Client(3, "Bittencourt");

            Product p1 = new Product(1, "Fixed Income", 100.0, new DateTime(2023, 10, 10), new DateTime(2021, 10, 12), c1);
            Product p2 = new Product(2, "Variable Income", 1000.0, new DateTime(2022, 12, 30), new DateTime(2021, 10, 12), c2);
            Product p3 = new Product(3, "High Liquidity", 500.0, new DateTime(2025, 10, 10), new DateTime(2021, 10, 12), c3);
            Product p4 = new Product(4, "Low Liquidity", 350.0, new DateTime(2023, 4, 21), new DateTime(2021, 10, 12), c1);
            Product p5 = new Product(5, "High Risk", 100.0, new DateTime(2024, 10, 10), new DateTime(2021, 10, 12), c2);
            Product p6 = new Product(6, "Short Term", 200.0, new DateTime(2024, 11, 11), new DateTime(2021, 10, 12), c3);
            Product p7 = new Product(7, "Mid Term", 400.0, new DateTime(2023, 5, 5), new DateTime(2021, 10, 12), c1);
            Product p8 = new Product(8, "Long Term", 400.0, new DateTime(2022, 12, 31), new DateTime(2021, 10, 12), c2);

            IR_Record ir1 = new IR_Record(1, new DateTime(2021, 10, 12), p1.Rescue(p1.dateApplication, p1.dateRescue), IR_Status.MoreTwoYearApplication, c1);
            IR_Record ir2 = new IR_Record(2, new DateTime(2021, 10, 12), p1.Rescue(p1.dateApplication, p1.dateRescue), IR_Status.LessOneYearApplication, c2);
            IR_Record ir3 = new IR_Record(3, new DateTime(2021, 10, 12), p1.Rescue(p1.dateApplication, p1.dateRescue), IR_Status.MoreTwoYearApplication, c3);
            IR_Record ir4 = new IR_Record(4, new DateTime(2021, 10, 12), p1.Rescue(p1.dateApplication, p1.dateRescue), IR_Status.LessTwoYearApplication, c1);
            IR_Record ir5 = new IR_Record(5, new DateTime(2021, 10, 12), p1.Rescue(p1.dateApplication, p1.dateRescue), IR_Status.MoreTwoYearApplication, c2);
            IR_Record ir6 = new IR_Record(6, new DateTime(2021, 10, 12), p1.Rescue(p1.dateApplication, p1.dateRescue), IR_Status.MoreTwoYearApplication, c3);
            IR_Record ir7 = new IR_Record(7, new DateTime(2021, 10, 12), p1.Rescue(p1.dateApplication, p1.dateRescue), IR_Status.LessTwoYearApplication, c1);
            IR_Record ir8 = new IR_Record(8, new DateTime(2021, 10, 12), p1.Rescue(p1.dateApplication, p1.dateRescue), IR_Status.LessOneYearApplication, c2);


            _context.Client.AddRange(c1, c2, c3);

            _context.Product.AddRange(p1, p2, p3, p4, p5, p6, p7, p8);

            _context.IR_Record.AddRange(ir1, ir2, ir3, ir4, ir5, ir6, ir7, ir8);

            _context.SaveChanges();
        }
    }
}
