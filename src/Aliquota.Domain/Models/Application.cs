using Aliquota.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Models
{
    public class Application : Entity
    {
        public Application()
        {
            Active = true;
        }
        public string Name { get; set; }
        public decimal InitialValue { get; set; }
        public decimal CurrentValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? WithdrawnAt { get; set; }
        public bool Active { get; set; }
        private int YearDifference()
        {
            return Convert.ToDateTime(WithdrawnAt).Year - CreatedAt.Year;
        }
        public decimal WithdrawValue
        {
            get
            {
                if (YearDifference() < 1)
                {
                    return CurrentValue - (CurrentValue - InitialValue) * Convert.ToDecimal(0.225);
                }
                else if(YearDifference() >= 1 && YearDifference() <= 2)
                {
                    return CurrentValue - (CurrentValue - InitialValue) * Convert.ToDecimal(0.185);
                }
                else
                {
                    return CurrentValue - (CurrentValue - InitialValue) * Convert.ToDecimal(0.15);
                }
            }
        }
    }
}
