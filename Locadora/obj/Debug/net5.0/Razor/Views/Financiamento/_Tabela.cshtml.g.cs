#pragma checksum "C:\Git\NorteLocadora\Locadora\Views\Financiamento\_Tabela.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3b16d09ae8342f3f08a17f3256ce62c34bf1299"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Financiamento__Tabela), @"mvc.1.0.view", @"/Views/Financiamento/_Tabela.cshtml")]
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
#line 1 "C:\Git\NorteLocadora\Locadora\Views\_ViewImports.cshtml"
using Locadora;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Git\NorteLocadora\Locadora\Views\_ViewImports.cshtml"
using Locadora.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3b16d09ae8342f3f08a17f3256ce62c34bf1299", @"/Views/Financiamento/_Tabela.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c0224845b91fd63a4726505e5348f391d40b261", @"/Views/_ViewImports.cshtml")]
    public class Views_Financiamento__Tabela : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Financiamento>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table id=""example"" class=""table table-responsive table-striped table-bordered display"" style=""width:100%"">
    <thead>
        <tr>
            <th>Veículo</th>
            <th>Parcelas</th>
            <th>Valor da Parcela</th>
            <th>Ação</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 13 "C:\Git\NorteLocadora\Locadora\Views\Financiamento\_Tabela.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 16 "C:\Git\NorteLocadora\Locadora\Views\Financiamento\_Tabela.cshtml"
           Write(item.Veiculo.Placa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 17 "C:\Git\NorteLocadora\Locadora\Views\Financiamento\_Tabela.cshtml"
           Write(item.ParcelasVigentes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 18 "C:\Git\NorteLocadora\Locadora\Views\Financiamento\_Tabela.cshtml"
           Write(item.ValorDaParcela);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-nowrap\" width=\"10\">\r\n                <a id=\"btn-excluir\" class=\"btn btn-circle btn-danger btn-sm\" title=\"Excluir\" btn-sm\"");
            BeginWriteAttribute("href", " href=\"", 684, "\"", 735, 1);
#nullable restore
#line 20 "C:\Git\NorteLocadora\Locadora\Views\Financiamento\_Tabela.cshtml"
WriteAttributeValue("", 691, Url.Action("Remover", new { id = item.Id }), 691, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-togle=\"tooltip\">\r\n                    <i class=\"fa fa-close\" aria-hidden=\"true\"></i>\r\n                </a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 25 "C:\Git\NorteLocadora\Locadora\Views\Financiamento\_Tabela.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Financiamento>> Html { get; private set; }
    }
}
#pragma warning restore 1591
