#pragma checksum "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5a946168376342ec2661d0dcc1fa5b0d4b0ad72"
// <auto-generated/>
#pragma warning disable 1591
namespace Aliquota.Website.Blazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\_Imports.razor"
using Aliquota.Website.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\_Imports.razor"
using Aliquota.Website.Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
using Aliquota.Domain.Entities.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
using Aliquota.Domain.UseCases.ProductMovement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
using Aliquota.Website.Blazor.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/trade")]
    public partial class Trade : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 7 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
 if(products == null){

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<div class=\"spinner-border\" role=\"status\"><span class=\"sr-only\">Loading...</span></div>");
#nullable restore
#line 11 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
}
else{


#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "table");
            __builder.AddAttribute(2, "class", "table table-striped text-center");
            __builder.OpenElement(3, "thead");
            __builder.OpenElement(4, "tr");
            __builder.AddMarkupContent(5, "<th scope=\"col\">Produto</th>\r\n            ");
            __builder.AddMarkupContent(6, "<th scope=\"col\">Valor</th>\r\n            ");
            __builder.AddMarkupContent(7, "<th scope=\"col\">Em Carteira</th>\r\n            ");
            __builder.OpenElement(8, "th");
            __builder.AddAttribute(9, "scope", "col");
            __builder.OpenElement(10, "input");
            __builder.AddAttribute(11, "type", "number");
            __builder.AddAttribute(12, "name", "number");
            __builder.AddAttribute(13, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 21 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
                              quantidade

#line default
#line hidden
#nullable disable
            , culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(14, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => quantidade = __value, quantidade, culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n        ");
            __builder.OpenElement(16, "tbody");
#nullable restore
#line 26 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
             foreach (var item in products)
            {
                if(item.Name != "BRL")
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(17, "tr");
            __builder.AddAttribute(18, "class");
            __builder.OpenElement(19, "td");
            __builder.AddAttribute(20, "class");
#nullable restore
#line 31 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
__builder.AddContent(21, item.Name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n                        ");
            __builder.OpenElement(23, "td");
            __builder.AddAttribute(24, "class");
#nullable restore
#line 32 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
__builder.AddContent(25, (new StockMarket()).GetProductValue(@item));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n                        ");
            __builder.OpenElement(27, "td");
            __builder.AddAttribute(28, "class");
#nullable restore
#line 33 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
__builder.AddContent(29, getWalletAmount(item));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                        ");
            __builder.OpenElement(31, "td");
            __builder.AddAttribute(32, "class");
            __builder.OpenElement(33, "button");
            __builder.AddAttribute(34, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
                                              () => buyProduct(item)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(35, "class", "btn btn-lg btn-success");
            __builder.AddContent(36, "Comprar");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n                            ");
            __builder.OpenElement(38, "button");
            __builder.AddAttribute(39, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 36 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
                                              () => sellProduct(item)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(40, "class", "btn btn-lg btn-primary");
            __builder.AddContent(41, "Vender");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 39 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
                }
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 43 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 44 "C:\Users\lab\source\repos\kinvo-back-end-tes\Aliquota\Aliquota.Website.Blazor\Pages\Trade.razor"
       
    List<FinanceProduct> products = null;
    User user;
    public  decimal quantidade = 0;
    List<FinanceProductWallet> wallets;
    public FinanceProduct BRL  = Program.databaseAdapter.DatabaseDriver.GetFinanceProductByName("BRL");

    protected override async Task OnInitializedAsync()
    {
        products = await Task.Run(() => DataLists.GetAllFinanceProducts(Program.databaseAdapter) );
        var userblazor = await authenticationStateProvider.GetAuthenticationStateAsync();
        user = Program.databaseAdapter.DatabaseDriver.GetUserById(1);
        getwallet();
    }
    decimal getWalletAmount(FinanceProduct p)
    {
        decimal result = 0;
        foreach (var item in wallets)
        {
            if (item.FinanceProduct == p)
                result = item.Amount;
        }
        getwallet();
        return result;
    }
    void getwallet()
    {
        wallets = DataLists.GetAllFinanceProductWallets(user, Program.databaseAdapter);
        
    }

    void buyProduct(FinanceProduct p)
    {
        MakeFinanceProductMove.TradeFinanceProducts(user, BRL, quantidade, p,Program.databaseAdapter, new StockMarket(), new Taxer());
    }
    void sellProduct(FinanceProduct p)
    {
        MakeFinanceProductMove.TradeFinanceProducts(user, p, quantidade, BRL,Program.databaseAdapter, new StockMarket(), new Taxer());
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider authenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
