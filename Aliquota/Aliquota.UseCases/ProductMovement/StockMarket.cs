using Aliquota.BusinessLogic.Models;
using Aliquota.UseCases.Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.UseCases.ProductMovement
{
    public class StockMarket : IStockMarket
    {
        //WEB SCRAPPER
        public decimal GetProductValue(FinanceProduct product) => 1;
    }
}
