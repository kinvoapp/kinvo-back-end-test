// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Aliquota.Domain.Client.Pages.Aplicacao
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using Aliquota.Domain.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using Aliquota.Domain.Client.Pages.Aplicacao;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using Aliquota.Domain.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using Aliquota.Domain.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\_Imports.razor"
using Aliquota.Domain.Shared.Utils;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/aplicacoes")]
    public partial class Lista : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 65 "C:\Users\bruno.welausen\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Client\Pages\Aplicacao\Lista.razor"
       
    List<Aplicacao> aplicacaos;

    protected async override Task OnInitializedAsync()
    {
        await CarregarAplicacoes();
    }

    private async Task CarregarAplicacoes()
    {
        aplicacaos = await http.GetFromJsonAsync<List<Aplicacao>>("api/aplicacao");
    }

    private async Task FinalizarAplicacao(int id)
    {
        await http.DeleteAsync($"api/aplicacao/{id}");
        await CarregarAplicacoes();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
