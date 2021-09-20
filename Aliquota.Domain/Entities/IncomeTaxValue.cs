using System;
using Flunt.Notifications;

namespace Aliquota.Domain.Entities
{
    public class IncomeTaxValue : Notifiable
    {
        public Product Product { get; private set; }
        public TimeSpan DateCompare { get; private set; }
        public double Calculo(Product product)
        {
            DateCompare = product.EndApplicationDate.Date - product.ApplicationDate.Date;
            double time = DateCompare.Days / 365;
            double value = 0;
            if (time <= 1)
            {
                var n = (22.5 / 100) * product.Price;
                value = n;
            }
            if (time == 2)
            {
                var n = (18.5 / 100) * product.Price;
                value = n;
            }
            if (time >= 3)
            {
                var n = (15.0 / 100) * product.Price;
                value = n;
            }

            return value;
        }
    }
}
