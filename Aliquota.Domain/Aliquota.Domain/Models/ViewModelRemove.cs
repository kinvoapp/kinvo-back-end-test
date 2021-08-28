using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class ViewModelRemove
    {
        public Investment ActualInvestment { get; set; }
        public DateTime ActualDate { get; set; }

        public ViewModelRemove()
        {
        }

        public ViewModelRemove(Investment investment, DateTime dateTime)
        {
            ActualInvestment = investment;
            ActualDate = dateTime;
        }
    }
}
