#pragma checksum "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "821863b7686aa9d86afc048a043e8105d199945d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ResultadoFinanceiro), @"mvc.1.0.view", @"/Views/Home/ResultadoFinanceiro.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\_ViewImports.cshtml"
using Aliquota.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\_ViewImports.cshtml"
using Aliquota.Domain.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"821863b7686aa9d86afc048a043e8105d199945d", @"/Views/Home/ResultadoFinanceiro.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a945cf6aa20908a1d46f86c17747c3215055b8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ResultadoFinanceiro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Aliquota.Domain.Models.ResultadoFinanceiro>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
  
    ViewData["Title"] = "Dados da Aplicação Financeira";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Dados da Aplicação Financeira</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayNameFor(model => model.DataAplicacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayFor(model => model.DataAplicacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayNameFor(model => model.DataResgate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayFor(model => model.DataResgate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayNameFor(model => model.ValorAplicado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayFor(model => model.ValorAplicado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayNameFor(model => model.ValorRendimento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayFor(model => model.ValorRendimento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayNameFor(model => model.ImpostoDevido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayFor(model => model.ImpostoDevido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayNameFor(model => model.LucroReal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
       Write(Html.DisplayFor(model => model.LucroReal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 58 "C:\Users\C&S\source\repos\kinvo-back-end-test\Aliquota.Domain\Aliquota.Domain\Views\Home\ResultadoFinanceiro.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "821863b7686aa9d86afc048a043e8105d199945d9384", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Aliquota.Domain.Models.ResultadoFinanceiro> Html { get; private set; }
    }
}
#pragma warning restore 1591
