#pragma checksum "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3a06f507a887d90397a3efaf05f956be99ebf0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Retirada__Tabela), @"mvc.1.0.view", @"/Views/Retirada/_Tabela.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3a06f507a887d90397a3efaf05f956be99ebf0b", @"/Views/Retirada/_Tabela.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c0224845b91fd63a4726505e5348f391d40b261", @"/Views/_ViewImports.cshtml")]
    public class Views_Retirada__Tabela : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Locacao>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table id=""example"" class=""table table-responsive table-striped table-bordered display"" style=""width:100%"">
    <thead>
        <tr>
            <th>Protocolo</th>
            <th>Cliente</th>
            <th>Situação</th>
            <th>Ação</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 13 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 16 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 17 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
               Write(item.Cliente.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n");
#nullable restore
#line 19 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
                      
                        if (item.Finalizada && !item.Devolvido)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
                       Write(Html.Raw("<b class='text-warning'>Finalizado</b>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
                                                                               
                        }

                        if (item.Finalizada && item.Devolvido)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
                       Write(Html.Raw("<b class='text-success'>Devolvido</b>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
                                                                              
                        }

                        if (!item.Finalizada && !item.Devolvido)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
                       Write(Html.Raw("<b class='text-danger'>Pendente</b>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
                                                                            
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td class=\"text-nowrap\" width=\"10\">\r\n                    <a class=\"btn btn-circle btn-info btn-sm\" title=\"Editar\"");
            BeginWriteAttribute("href", " href=\"", 1297, "\"", 1347, 1);
#nullable restore
#line 37 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
WriteAttributeValue("", 1304, Url.Action("Editar", new { id = item.Id }), 1304, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-togle=\"tooltip\">\r\n                        <i class=\"fa fa-eye\" aria-hidden=\"true\"></i>\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 42 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Tabela.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Locacao>> Html { get; private set; }
    }
}
#pragma warning restore 1591
