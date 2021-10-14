using Aliquota.BusinessLogic.Models;
using Aliquota.UseCases.ProductMovement;
using ControllersGatewaysAndPresenters.Adapters;
using FrameworksAndDrivers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Aliquota.Website.Pages.Wallets
{
    public class IndexModel : PageModel
    {
        public User user = Program.databaseAdapter.DatabaseDriver.GetUserById(1);
        public List<ProductTradeMove> trademoves { get; set; }
        public List<FinanceProductWallet> wallets { get; set; }

        public void OnGet()
        {
            wallets = DataLists.GetAllFinanceProductWallets(user, Program.databaseAdapter);
            
        }
    }
}
