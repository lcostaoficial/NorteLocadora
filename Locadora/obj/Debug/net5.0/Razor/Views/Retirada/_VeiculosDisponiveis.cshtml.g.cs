#pragma checksum "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d88f209d65ceb70dde4bd4723dfb880f91678002"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Retirada__VeiculosDisponiveis), @"mvc.1.0.view", @"/Views/Retirada/_VeiculosDisponiveis.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d88f209d65ceb70dde4bd4723dfb880f91678002", @"/Views/Retirada/_VeiculosDisponiveis.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c0224845b91fd63a4726505e5348f391d40b261", @"/Views/_ViewImports.cshtml")]
    public class Views_Retirada__VeiculosDisponiveis : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Veiculo>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
  
    var i = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
 if (Model != null && Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"prj-list row\">\r\n\r\n");
#nullable restore
#line 10 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col-lg-4 col-md-6 col-xs-12 margin-bottom-30"">
                <a href=""#"" class=""prj-item"">
                    <div class=""top-project-section"">
                        <div class=""project-icon"">
                            <img height=""170"" width=""184""");
            BeginWriteAttribute("src", " src=\"", 459, "\"", 546, 1);
#nullable restore
#line 16 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
WriteAttributeValue("", 465, Url.Content(item.FotosDeGaragem.FirstOrDefault(x => x.Principal).CaminhoVirtual), 465, 81, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 547, "\"", 553, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </div>\r\n                        <h3>");
#nullable restore
#line 18 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
                       Write(item.Marca);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 18 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
                                     Write(item.Modelo);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 18 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
                                                    Write(item.AnoDeModelo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <div class=\"meta\">\r\n                            <p class=\"author\">\r\n                                Placa: <span>");
#nullable restore
#line 21 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
                                        Write(item.Placa);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </p>
                        </div>
                    </div>
                    <div class=""bottom-project-section"">
                        <div class=""form-check"">
                            <label><input type=""radio"" id=""VeiculoId"" name=""VeiculoId""");
            BeginWriteAttribute("value", " value=\"", 1115, "\"", 1131, 1);
#nullable restore
#line 27 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
WriteAttributeValue("", 1123, item.Id, 1123, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> Escolher</label>\r\n                        </div>\r\n                    </div>\r\n                </a>\r\n            </div>\r\n");
#nullable restore
#line 32 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"

            i++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 37 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Nenhum veículo disponível</p>\r\n");
#nullable restore
#line 41 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_VeiculosDisponiveis.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Veiculo>> Html { get; private set; }
    }
}
#pragma warning restore 1591
