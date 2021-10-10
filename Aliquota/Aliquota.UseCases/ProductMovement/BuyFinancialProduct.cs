using Aliquota.BusinessLogic.Models;
using Aliquota.UseCases.Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.UseCases.ProductMovement
{
    class BuyFinancialProduct
    {
        public delegate Decimal TaxesDelegate(decimal d);

        bool BuyFinanceProduct
        (
            User owner, 
            decimal amount, 
            IDatabaseAdapter databaseAdapter,
            FinanceProduct financeProduct,
            TaxesDelegate applyTaxes = null
        ) 
        {
            if (applyTaxes == null) 
                applyTaxes = applyTaxesDefault;

            amount = applyTaxes(amount);
            return databaseAdapter.RestrictFinanceProductBuy(owner, financeProduct, amount);
        }

        private TaxesDelegate applyTaxesDefault  =  (decimal e) => e;
    }
}
