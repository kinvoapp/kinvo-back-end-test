using Aliquota.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.UseCases.Plugin.Interfaces
{
    public interface IStockMarket
    {
        public decimal GetProductValue(FinanceProduct product);
    }
}
