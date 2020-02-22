using System;
using Aliquota.Domain.Entities.Exceptions;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Services
{
    public class IncomeTaxService : ITaxService
    {
        public double Tax(TimeSpan ElapsedTime)
        {

            if (ElapsedTime.TotalDays <= 360)
            {
                return 0.225;
            }
            else if (ElapsedTime.TotalDays <= 720)
            {
                return 0.185;
            }
            else
            {
                return 0.15;
            }
        }
    }
}