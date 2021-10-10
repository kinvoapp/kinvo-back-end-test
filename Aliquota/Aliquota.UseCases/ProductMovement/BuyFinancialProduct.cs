using Aliquota.BusinessLogic.Models;
using Aliquota.UseCases.Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.UseCases.ProductMovement
{
    public static class BuyFinancialProduct
    {

        public static FinanceProductMove BuyFinanceProduct
        (
            User owner, 
            decimal amount, 
            FinanceProduct financeProduct,
            IDatabaseAdapter databaseAdapter
        ) 
        {
            return databaseAdapter.RestrictFinanceProductBuy(owner, financeProduct, amount);
        }

    }
}
