#pragma checksum "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "430742f2659ca21a79603194fe30c472b0c5302f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Investimento_Carteira), @"mvc.1.0.view", @"/Views/Investimento/Carteira.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Investimento/Carteira.cshtml", typeof(AspNetCore.Views_Investimento_Carteira))]
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
#line 1 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\_ViewImports.cshtml"
using KinvoProject;

#line default
#line hidden
#line 2 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\_ViewImports.cshtml"
using Domain.Aliquiota;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430742f2659ca21a79603194fe30c472b0c5302f", @"/Views/Investimento/Carteira.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0dc1a3e9393c7e8949ddd62a46a9d1c5efdb085f", @"/Views/_ViewImports.cshtml")]
    public class Views_Investimento_Carteira : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Investimento>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Visualizar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Resgatar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 391, true);
            WriteLiteral(@"
<h2>Minha Carteira</h2>
<table class=""table table-hover table-striped""
       style=""margin-top:15px;margin-bottom:15px"">
    <thead>
        <tr>
            <th>Produto</th>
            <th>Taxa de Rendimento</th>
            <th>Valor Investido</th>
            <th>Data Investimento</th>
            <th></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 17 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
         foreach (Investimento item in Model)
        {


#line default
#line hidden
            BeginContext(478, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(509, 17, false);
#line 21 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
           Write(item.Produto.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(526, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(550, 23, false);
#line 22 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
           Write(item.Produto.Rendimento);

#line default
#line hidden
            EndContext();
            BeginContext(573, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(597, 19, false);
#line 23 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
           Write(item.ValorInvestido);

#line default
#line hidden
            EndContext();
            BeginContext(616, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(640, 18, false);
#line 24 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
           Write(item.DataAplicacao);

#line default
#line hidden
            EndContext();
            BeginContext(658, 9, true);
            WriteLiteral("</td>\r\n\r\n");
            EndContext();
#line 26 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
             if (item.DataResgate != DateTime.MinValue)
            {

#line default
#line hidden
            BeginContext(739, 48, true);
            WriteLiteral("            <td>\r\n               Resgadato dia: ");
            EndContext();
            BeginContext(788, 21, false);
#line 29 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
                         Write(item.DataResgate.Date);

#line default
#line hidden
            EndContext();
            BeginContext(809, 21, true);
            WriteLiteral("\r\n            </td>\r\n");
            EndContext();
            BeginContext(832, 34, true);
            WriteLiteral("            <td>\r\n                ");
            EndContext();
            BeginContext(866, 231, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec8bc934c81441df9208f5b775b727ac", async() => {
                BeginContext(910, 38, true);
                WriteLiteral("\r\n                    <input name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 948, "\"", 976, 1);
#line 34 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
WriteAttributeValue("", 956, item.IdInvestimento, 956, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(977, 113, true);
                WriteLiteral(" hidden />\r\n                    <input type=\"submit\" class=\"btn btn-info\" value=\"Visualizar\" />\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1097, 21, true);
            WriteLiteral("\r\n            </td>\r\n");
            EndContext();
#line 38 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
            
            
            }
            else
            { 

#line default
#line hidden
            BeginContext(1195, 35, true);
            WriteLiteral("             <td>\r\n                ");
            EndContext();
            BeginContext(1230, 230, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6848baba978b43038100724143ec7084", async() => {
                BeginContext(1272, 38, true);
                WriteLiteral("\r\n                    <input name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1310, "\"", 1338, 1);
#line 45 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
WriteAttributeValue("", 1318, item.IdInvestimento, 1318, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1339, 114, true);
                WriteLiteral(" hidden />\r\n                    <input type=\"submit\" class=\"btn btn-warning\" value=\"Resgatar\" />\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1460, 19, true);
            WriteLiteral("\r\n            </td>");
            EndContext();
#line 48 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
                 }           

#line default
#line hidden
            BeginContext(1493, 29, true);
            WriteLiteral("            \r\n        </tr>\r\n");
            EndContext();
#line 51 "C:\Users\yanrd\source\repos\KinvoProject\KinvoProject\Views\Investimento\Carteira.cshtml"
        }

#line default
#line hidden
            BeginContext(1533, 26, true);
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Investimento>> Html { get; private set; }
    }
}
#pragma warning restore 1591
